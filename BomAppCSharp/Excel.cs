using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
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
            return (ws.Cells[x - 64, y]).Value2.ToString();
        }

        public void Save()
        {
            wb.Save();
        }
        public void Close()
        {
            wb.Close(true);
        }

        int rowCount = 0;
        public void PasteCells(string quantity, string descrip, string manu, string manuPN)
        {
            ws.Cells[2 + rowCount, 2] = quantity;
            ws.Cells[2 + rowCount, 5] = descrip;
            ws.Cells[2 + rowCount, 6] = manu;
            ws.Cells[2 + rowCount, 7] = manuPN;
            rowCount++;
        }

        int refRowCount = 0;
        public void PasteSortedRefs(string sortedRefs)
        {
            ws.Cells[2 + refRowCount, 3] = sortedRefs;
            refRowCount++;
        }
    }
   
}
