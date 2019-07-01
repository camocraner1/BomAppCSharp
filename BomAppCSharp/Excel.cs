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

        public void SaveAs(string path)
        {
            wb.SaveAs(path, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
        }
        
        public void Close()
        {
            wb.Close(true);
        }

        public void Quit()
        {
            excel.Quit();
        }

        public void PasteCells(string quantity, string descrip, string manu, string manuPN, int rowCount, int startRow)
        {
            System.Threading.Thread.Sleep(2000);
            ws.Cells[startRow + rowCount, 2] = quantity;
            ws.Cells[startRow + rowCount, 5] = descrip;
            ws.Cells[startRow + rowCount, 6] = manu;
            ws.Cells[startRow + rowCount, 7] = manuPN;
        }

        public void PasteSortedRefs(string sortedRefs, int refRowCount, int startRow)
        {
            ws.Cells[startRow + refRowCount, 3] = sortedRefs;
        }
    }
   
}
