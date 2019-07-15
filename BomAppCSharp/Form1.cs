using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BomAppCSharp
{

    public partial class Form1 : Form
    {
        public List<String> RefStringList = new List<string>();
        public List<RefComponents> RefCompList = new List<RefComponents>();
        public List<int> IndexToDelete = new List<int>();
        public List<String> SortedList = new List<string>();

        private bool LoadButtonClicked = false;
        private bool SortButtonClicked = false;
        private bool SaveButtonClicked = false;

        //open excel files
        Excel UnsortedExcelFile = null;
        Excel SortedExcelFile = null;

        int UnsortedsheetNum;
        int SortedsheetNum;
        public int rowCount = 0;
        public int refRowCount = 0;
        public int rowTextCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        public void LoadButton_Click(object sender, EventArgs e)
        {
            SaveButtonClicked = false;
            LoadButtonClicked = true;
            IndexToDelete.Clear();
            RefStringList.Clear();
            SortedTextBox.Text = String.Empty;
            SortedTextBox.ScrollBars = ScrollBars.Vertical;

            //taking input from user and converting to variable
            if (Cell1.Text != String.Empty || Cell2.Text != String.Empty)
            {
                if (IsAllLettersOrDigits(Cell1.Text) && IsAllLettersOrDigits(Cell2.Text) && FileInTextBox.Text != String.Empty)
                {
                    ExportDataToExcel();
                }
                else
                {
                    SortedTextBox.Text = "Invalid cell(s)";
                }

            }
            else
            {
                SortedTextBox.Text = "The range entered was invalid";
            }

        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            SaveButtonClicked = false;
            SortButtonClicked = true;
            label8.Text = string.Empty;
            label9.Text = string.Empty;
            RowOf5Count.Text = string.Empty;
            LastRowCount.Text = string.Empty;
            SortedTextBox.Text = string.Empty;
            TotalCountBox.Text = string.Empty;
            SortedList.Clear();
            RefCompList.Clear();

            if (LoadButtonClicked)
            {
                SortReferences();

                //delete extra comma at the end
                if (SortedTextBox.Text != string.Empty 
                    && SortedTextBox.Text != "The range entered was invalid" 
                    && SortedTextBox.Text != "Invalid cell(s)")
                {
                    SortedTextBox.Text = SortedTextBox.Text.Remove(SortedTextBox.Text.LastIndexOf(","));

                    //paste the references in the file
                    SortedExcelFile.PasteSortedRefs(SortedTextBox.Text.ToString(),
                                                    refRowCount,
                                                    Convert.ToInt32(numericUpDownRowStart.Value));

                    label8.Text = "1    Row of ";
                    label9.Text = "Rows of 5";
                    RowOf5Count.Text = rowTextCount.ToString();
                    LastRowCount.Text += (SortedList.Count % 5).ToString();
                    TotalCountBox.Text = (SortedList.Count).ToString();
                    refRowCount++;
                }
                else
                {
                    SortedTextBox.Text = "Please enter cells and load them in before sorting.";
                }

                LoadButtonClicked = false;
            }
            else
            {
                SortedTextBox.Text = "Please enter cells and load them in before sorting.";
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            //clear all labels that contain text, and reset all lists 
            SortedTextBox.Text = string.Empty;
            TotalCountBox.Text = string.Empty;
            RowOf5Count.Text = string.Empty;
            Cell1.Text = string.Empty;
            Cell2.Text = string.Empty;
            label8.Text = string.Empty;
            label9.Text = string.Empty;
            RowOf5Count.Text = string.Empty;
            LastRowCount.Text = string.Empty;
            QuantityTextBox.Text = string.Empty;
            PartDescTextBox.Text = string.Empty;
            ManufacturerTextBox.Text = string.Empty;
            ManufacturerPNTextBox.Text = string.Empty;
            FileInTextBox.Text = string.Empty;
            FileOutTextBox.Text = string.Empty;
            ofd.Reset();
            ofd2.Reset();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Excel|*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInTextBox.Text = ofd.FileName;
            }
        }
        private void BrowseButton2_Click(object sender, EventArgs e)
        {
            ofd2.Filter = "Excel|*.xlsx";
            if (ofd2.ShowDialog() == DialogResult.OK)
            {
                FileOutTextBox.Text = ofd2.FileName;
            }
        }

        public List<string> Split(string str1)
        {
            List<string> temp = new List<string>();

            if (str1.Contains("\r\n"))
            {
                temp.AddRange(str1.Split(new string[] { "\r\n" }, StringSplitOptions.None));
            }
            else if (str1.Contains("-"))
            {
                temp.AddRange(str1.Split("-".ToCharArray()));
            }
            return temp;
        }
        public List<string> AddComponents(List<string> list1)
        {
            List<string> Temp1 = new List<string>();

            string numstr1 = Regex.Replace(list1[0], "[^0-9.]", string.Empty);
            int num1 = int.Parse(numstr1);
            string numstr2 = Regex.Replace(list1[1], "[^0-9.]", string.Empty);
            int num2 = int.Parse(numstr2);

            string letters = Regex.Replace(list1[0], @"[\d-]", string.Empty);

            for (int i = 0; i <= num2 - num1; i++)
            {
                Temp1.Add(letters + (num1 + i).ToString());
            }

            return Temp1;
        }

        public RefComponents CreateComponents(string str1)
        {
            RefComponents TempComp = new RefComponents();

            if (str1 != string.Empty)
            {
                string numstr1 = Regex.Replace(str1, "[^0-9.]", string.Empty);
                int num = int.Parse(numstr1);
                string letter = Regex.Replace(str1, @"[\d-]", string.Empty);

                TempComp.prefix = letter;
                TempComp.number = num;
            }

            return TempComp;

        }

        public string Combine (RefComponents Temp)
        {
            string str = Temp.prefix + Temp.number.ToString();
            return str;
        }
        public bool IsAllLettersOrDigits(string Str)
        {
            if (Regex.IsMatch(Str, @"\S*(\S*([a-zA-Z]\S*[0-9])|([0-9]\S*[a-zA-Z]))\S*") || Str == string.Empty)
            {
                return true;
            }
            else
                return false;
        }
        private void ExportDataToExcel()
        {

            string firstCellStr = Cell1.Text.ToString();
            string secondCellStr = Cell2.Text.ToString();

            //creating strings for the users column inputs
            string QuantityCol = QuantityTextBox.Text.ToString();
            string PartDescriptionCol = PartDescTextBox.Text.ToString();
            string ManufacturerCol = ManufacturerTextBox.Text.ToString();
            string ManufacturerPNCol = ManufacturerPNTextBox.Text.ToString();

            //splitting variables into separate parts 
            RefComponents cell1Comps = CreateComponents(firstCellStr);
            RefComponents cell2Comps = CreateComponents(secondCellStr);

            //reading the excel range into a list of strings
            if (firstCellStr != string.Empty && secondCellStr == string.Empty)
            {
                RefStringList.Add(UnsortedExcelFile.ReadCell(cell1Comps.prefix[0], cell1Comps.number));
            }
            else if (firstCellStr != string.Empty && secondCellStr != string.Empty)
            {
                RefStringList = UnsortedExcelFile.ReadExcelRange(cell1Comps.prefix[0], cell1Comps.number, cell2Comps.prefix[0], cell2Comps.number);
            }
            else
                SortedTextBox.Text = "Error, Invalid Entry";

            //remove extra empty slots in list
            RefStringList = RefStringList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();


            string QuantityCell, PartDescriptionCell, ManufacturerCell, ManufacturerPNCell;

            //find the cells that need to be copied and copy contents into strings

                if (Regex.IsMatch(QuantityCol, @"^[A-Z]+$"))
                {
                    QuantityCell = UnsortedExcelFile.ReadCell(QuantityCol[0], cell1Comps.number);
                }
                else
                    QuantityCell = string.Empty;

                if (Regex.IsMatch(PartDescriptionCol, @"^[A-Z]+$"))
                {
                    PartDescriptionCell = UnsortedExcelFile.ReadCell(PartDescriptionCol[0], cell1Comps.number);
                }
                else
                    PartDescriptionCell = string.Empty;

                if (Regex.IsMatch(ManufacturerCol, @"^[A-Z]+$"))
                {
                    ManufacturerCell = UnsortedExcelFile.ReadCell(ManufacturerCol[0], cell1Comps.number);
                }
                else
                    ManufacturerCell = string.Empty;

                if (Regex.IsMatch(ManufacturerPNCol, @"^[A-Z]+$"))
                {
                    ManufacturerPNCell = UnsortedExcelFile.ReadCell(ManufacturerPNCol[0], cell1Comps.number);
                }
                else
                    ManufacturerPNCell = string.Empty;

            if (QuantityCell == string.Empty && 
                PartDescriptionCell == string.Empty && 
                ManufacturerCell == string.Empty && 
                ManufacturerPNCell == string.Empty)
            {
                SortedTextBox.Text = "Invalid column entries.";
            }
            else
            {
                //print the copied contents into the new excel file in the correct columns
                SortedExcelFile.PasteCells(QuantityCell, PartDescriptionCell, ManufacturerCell, ManufacturerPNCell, rowCount, Convert.ToInt32(numericUpDownRowStart.Value));
                rowCount++;
            }
          
        }

        private void KillExcel()
        {
            Process[] AllProcesses = Process.GetProcessesByName("EXCEL");

            // check to kill the right process
            foreach (Process clsProcess in Process.GetProcesses())
                if (clsProcess.ProcessName.Equals("EXCEL"))  //Process Excel?
                    clsProcess.Kill();

            AllProcesses = null;
        }

        private void SaveSortedFile()
        {
            string TempFilePath = Path.GetDirectoryName(ofd2.FileName) + @"\TEMPEXCEL.xlsx";

            SortedExcelFile.SaveAs(TempFilePath);
            SortedExcelFile.Close();
            SortedExcelFile.Quit();
            UnsortedExcelFile.Close();
            UnsortedExcelFile.Quit();

            KillExcel();

            Thread.Sleep(2000);
            if (File.Exists(ofd2.FileName))
            {
                File.Delete(ofd2.FileName);
                File.Move(TempFilePath, ofd2.FileName);
            }
        }

        private void SortReferences()
        {
            //for loop to go through all elements in list
            for (int i = 0; i < RefStringList.Count; i++)
            {
                //if contains "\r\n"
                if (RefStringList[i].Contains("\r\n"))
                {
                    IndexToDelete.Add(i);
                    RefStringList.AddRange(Split(RefStringList[i]));
                }

                //else if contains "-"
                else if (RefStringList[i].Contains("-"))
                {
                    IndexToDelete.Add(i);

                    List<string> TempList = new List<string>();
                    TempList.AddRange(Split(RefStringList[i]));

                    RefStringList.AddRange(AddComponents(TempList));
                }

            }

            //inverse the IndexToDelete list, then remove the bad indexes with a foreach loop
            IndexToDelete.Reverse();

            foreach (int x in IndexToDelete)
            {
                RefStringList.RemoveAt(x);
            }

            RefStringList = RefStringList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

            //using the list of strings, split the refs into separate parts and place in components list
            for (int i = 0; i < RefStringList.Count; i++)
            {
                RefCompList.Add(CreateComponents(RefStringList[i]));
            }
            // sort refs by their components, first prefix then number
            RefCompList = RefCompList.OrderBy(o => o.prefix).ThenBy(o => o.number).ToList();

            foreach (RefComponents C in RefCompList)
            {
                SortedList.Add(Combine(C));
            }

            //print list to screen, separated by commas, 5 items per row

            for (int j = 1; j <= SortedList.Count; j++)
            {
                if (j % 5 == 0)
                {
                    SortedTextBox.Text += SortedList[j - 1] + ", " + Environment.NewLine;
                    rowTextCount++;
                }
                else
                {
                    SortedTextBox.Text += SortedList[j - 1] + ", ";
                }

            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveButtonClicked = true;

            if (SortButtonClicked 
                && SortedTextBox.Text != "The range entered was invalid"
                    && SortedTextBox.Text != "Invalid cell(s)"
                    && SortedTextBox.Text != "Please enter cells and load them in before sorting.")
            {
                SaveSortedFile();

                //open excel files
                UnsortedExcelFile = new Excel(ofd.FileName, UnsortedsheetNum);
                SortedExcelFile = new Excel(ofd2.FileName, SortedsheetNum);

                SortButtonClicked = false;
            }

            else
                SortedTextBox.Text = "Please Load a set of references, then sort them before saving the file.";
        }

        private void SelectExcelButton_Click(object sender, EventArgs e)
        {
            UnsortedsheetNum = Convert.ToInt32(numericUpDown1.Value);
            SortedsheetNum = Convert.ToInt32(numericUpDown2.Value);

            //open excel files
            UnsortedExcelFile = new Excel(ofd.FileName, UnsortedsheetNum);
            SortedExcelFile = new Excel(ofd2.FileName, SortedsheetNum);
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //when window is closed, show popup asking if they want to save
            if (!SaveButtonClicked)
            {
                PopUpForm popup = new PopUpForm();
                DialogResult dialogresult = popup.ShowDialog();
                if (dialogresult == DialogResult.OK)
                {
                    SaveSortedFile();
                }
                else if (dialogresult == DialogResult.Cancel)
                {
                    if (IsOpened(ofd.FileName))
                    {
                        UnsortedExcelFile.Close();
                        UnsortedExcelFile.Quit();
                    }

                    if (IsOpened(ofd2.FileName))
                    {
                        SortedExcelFile.Close();
                        SortedExcelFile.Quit();
                    }
                    KillExcel();
                }
                else if(dialogresult == DialogResult.Abort)
                {
                    e.Cancel = true;
                }
                popup.Dispose();
            }
            else
            {
               KillExcel();
            }
        }
        public static bool IsOpened(string FileName)
        {
            try
            {
                Stream s = File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.None);

                s.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void OpenFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void FileInTextBox_TextChanged(object sender, EventArgs e)
        {

        }

    }

    public class RefComponents
    {

        public RefComponents()
        {

        }
        public string prefix;
        public int number;

    }
}

