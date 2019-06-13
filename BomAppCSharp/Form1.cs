using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BomAppCSharp
{
    public partial class Form1 : Form
    {
        public List<String> RefStringList = new List<string>();
        public List<RefComponents> RefCompList = new List<RefComponents>();
        public List<int> IndexToDelete = new List<int>();
        public List<String> SortedList = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            IndexToDelete.Clear();
            RefStringList.Clear();
            RefTextBox.Text = String.Empty;

            char[] delimiterChars = { ' ', ',' };

            //load in text from file into a string
            string text = System.IO.File.ReadAllText(@"Z:\BomSortProgram\BomAppCSharp\BomFile.txt");

            //split string into a list of strings
            RefStringList = text.Split(delimiterChars).ToList();

            //remove extra empty slots in list
            RefStringList = RefStringList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

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

            //print elements to GUI
            for (int i = 0; i < RefStringList.Count; i++)
            {
                RefTextBox.Text += RefStringList[i] + Environment.NewLine;
            }



        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            RowCountText.Text = string.Empty;
            SortedTextBox.Text = string.Empty;
            TotalCountBox.Text = string.Empty;
            SortedList.Clear();
            RefCompList.Clear();

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
            for(int j = 1; j <= SortedList.Count; j++)
            {
                if (j % 5 == 0)
                {
                    SortedTextBox.Text += SortedList[j - 1] + Environment.NewLine;
                    RowCountText.Text += "5" + Environment.NewLine;
                }
                else
                {
                    SortedTextBox.Text += SortedList[j - 1] + ", ";   
                }
                
            }

            RowCountText.Text += (SortedList.Count % 5).ToString();
            TotalCountBox.Text = (SortedList.Count).ToString();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            //clear all labels that contain text, and reset all lists 
            RefTextBox.Text = string.Empty;
            SortedTextBox.Text = string.Empty;
            TotalCountBox.Text = string.Empty;
            RowCountText.Text = string.Empty;


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

            string numstr1 = Regex.Replace(str1, "[^0-9.]", string.Empty);
            int num = int.Parse(numstr1);
            string letter = Regex.Replace(str1, @"[\d-]", string.Empty);

            TempComp.prefix = letter;
            TempComp.number = num;

            return TempComp;

        }

        public string Combine (RefComponents Temp)
        {
            string str = Temp.prefix + Temp.number.ToString();
            return str;
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

