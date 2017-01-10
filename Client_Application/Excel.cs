using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using NLog;


namespace Client_Application
{
    class ExcelInsert
    {
        private Excel.Application xlApp = new Excel.Application();
        private Excel.Workbook xlWorkBook;
        private Excel.Worksheet xlWorkSheet;
        private object misValue = System.Reflection.Missing.Value;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void OpenExcelSheet(string file,string sheet ="Sheet1")
        {
            try
            {
                xlApp.Visible = true;
                xlWorkBook = xlApp.Workbooks.Open(file);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets[sheet];
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }

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
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }

        }

        public void CloseExcelSheet()
        {
            try
            {
                xlWorkBook.Save();
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }

            return;
        }

    }
}
