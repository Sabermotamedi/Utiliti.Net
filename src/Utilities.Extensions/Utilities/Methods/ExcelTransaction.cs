using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Utilities
{
    public static class ExcelTransactios
    {

        public static Tuple<byte[], long> GenerateAndUploadExcelFile(List<string[]> records,string[] titles)
        {
            long fileSize = 0;
           // string[] titles = null;
            string[][] data = null;

                    //titles = ResumeTitles();
                    data = records.ToArray();//(records[0]) //TODO

             var workBook = GenerateWorkBook(titles, data);
            var fileData = GenerateExcelFile(workBook);
            fileSize = fileData.Length;

            return new Tuple<byte[], long>(fileData, fileSize);
        }

        public static IWorkbook GenerateWorkBook(string[] titles, string[][] data)
        {
            IWorkbook result = new XSSFWorkbook();
            ISheet sheet1 = result.CreateSheet("Resumes");

            IRow headerRow = sheet1.CreateRow(0);

            for (int i = 0; i < titles.Length; i++)
            {
                var cell = headerRow.CreateCell(i);
                cell.SetCellValue(titles[i]);
                cell.CellStyle.FillPattern = FillPattern.SolidForeground;
                cell.CellStyle.FillBackgroundColor = (Int32)ConsoleColor.Green;
            }

            if (data != null)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] != null)
                    {
                        IRow theRow = sheet1.CreateRow(i + 1);
                        for (int j = 0; j < data[i].Length; j++)
                        {
                            var cell = theRow.CreateCell(j);
                            cell.SetCellValue(data[i][j]);
                            cell.CellStyle.ShrinkToFit = true;
                        }
                    }
                }
            }
            for (int i = 0; i < titles.Length; i++)
            {
                sheet1.AutoSizeColumn(i);
            }
            return result;
        }
        public static byte[] GenerateExcelFile(IWorkbook workBook)
        {
            var result = new MemoryStream();
            workBook.Write(result);
            return result.ToArray();
        }

    }
}