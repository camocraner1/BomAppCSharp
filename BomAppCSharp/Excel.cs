using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using Microsoft.Office.Interop.Excel;
using ServiceStack.Configuration;
using _Excel = Microsoft.Office.Interop.Excel;


namespace BomAppCSharp
{
    class Excel
    {
            public int rowCount = 0;
       public int refRowCount = 0;

        string path = string.Empty;
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public Excel(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        public List<string> ReadExcelRange(char startX, int startY, char endX, int endY)
        {
            List<string> tempList = new List<string>();
                
            if (ws.Range[ws.Cells[startY, startX - 64], ws.Cells[endY, endX - 64]].Value2 != null)
            {
                object[,] str = ws.Range[ws.Cells[startY, startX - 64], ws.Cells[endY, endX - 64]].Value2;
                tempList = str.Cast<string>().ToList();
            }
            else
            {
                tempList.Add("The Range entered included empty or bad cells");
            }
            return tempList;
        }

        public string ReadCell(char x, int y)
        {
            return (ws.Cells[y, x - 64]).Value2.ToString();
        }


        public void SaveCopyAs(string filename)
        {
            wb.SaveCopyAs(filename);
        }

        public void SaveAs(string path)
        {
            wb.SaveAs(path, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
        }
        
        public void Close()
        {
            wb.Close(true);
        }

        public void Quit()
        {
            excel.Quit();
        }

        public void PasteCells(string quantity, string descrip, string manu, string manuPN)
        {
            ws.Cells[2 + rowCount, 2] = quantity;
            ws.Cells[2 + rowCount, 5] = descrip;
            ws.Cells[2 + rowCount, 6] = manu;
            ws.Cells[2 + rowCount, 7] = manuPN;
            rowCount++;
        }

        public void PasteSortedRefs(string sortedRefs)
        {
            ws.Cells[2 + refRowCount, 3] = sortedRefs;
            refRowCount++;
        }
    }
   
}
