using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace Client_Application
{
    class ExcelInsert
    {
        private Excel.Application xlApp = new Excel.Application();
        private Excel.Workbook xlWorkBook;
        private Excel.Worksheet xlWorkSheet;
        private object misValue = System.Reflection.Missing.Value;

        public void OpenExcelSheet(string file,string sheet ="Sheet1")
        {
            Console.WriteLine("Opening Excel File: " + file);
            xlApp.Visible = true;
            xlWorkBook = xlApp.Workbooks.Open(file);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[sheet];
            return;
        }

        public void insertIntoExcelFile(Dictionary<string, string> marketData, long count)
        {
            try
            {
                xlWorkSheet.Cells[count, 1].Value = marketData["TimeStamp"];
                xlWorkSheet.Cells[count, 2].Value = marketData["Symbol"];
                xlWorkSheet.Cells[count, 3].Value = marketData["BidPrice"];
                xlWorkSheet.Cells[count, 4].Value = marketData["AskPrice"];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

        }

        public void CloseExcelSheet()
        {
            Console.WriteLine("Closing Excel File");
            xlWorkBook.Save();
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            return;
        }

    }
}
