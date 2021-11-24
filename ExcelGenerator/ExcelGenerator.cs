using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Utiliti.Net.ExcelGenerator
{
   
 public class ExcelGenerator<T>
    {
        public ExcelGenerator()
        {

        }
        public byte[] GenerateExel(IEnumerable<T> dto, string name)
        {

            string sFileName = DateTime.Now.ToString("yy-MM-dd-hh-mm-ss-ff") + @"-" + name;
            IWorkbook wb = new XSSFWorkbook();

            ISheet sheet1 = wb.CreateSheet(name);         

            var data = typeof(T).GetProperties().Where(x => x.IsDefined(typeof(DescriptionAttribute), false));

            IRow headerRow = sheet1.CreateRow(0);

            int HeaderCellCounter = 0;
            foreach (var item in data)
            {
                var cell = headerRow.CreateCell(HeaderCellCounter);
                //cell.SetCellValue(typeof(T).GetProperties()[i].Name);
                var header = item.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(DescriptionAttribute)).ConstructorArguments.FirstOrDefault().Value.ToString();
                cell.SetCellValue(header);
                cell.CellStyle.FillPattern = FillPattern.SolidForeground;
                cell.CellStyle.FillBackgroundColor = (Int32)ConsoleColor.Green;
                //HC.SetStyle(Hedearstyle);
                HeaderCellCounter++;
            }
           
            int CN = 1;

            foreach (var item in dto)
            {

                IRow Row = sheet1.CreateRow(CN);

                for (int i = 0; i < data.Count(); i++)
                {
                    var cell = Row.CreateCell(i);
                    var val = item.GetType().GetProperty(typeof(T).GetProperties().Where(x => x.IsDefined(typeof(DescriptionAttribute), false)).ToList()[i].Name).GetValue(item, null);

                    if (val != null)
                    {
                        if (val.GetType().FullName.ToString().Contains("Collections"))
                        {
                            cell.SetCellValue("Collections");

                        }
                        else
                        {
                            cell.SetCellValue(val.ToString());
                        }
                    }
                    else
                        cell.SetCellValue("");


                    //Cell cell = ws.Cells[CN, i];
                    //cell.Value = item.GetType().GetProperty(typeof(T).GetProperties()[i].Name).GetValue(item, null);
                    //cell.SetStyle(CellStyle);
                }
                CN++;
            }
            MemoryStream ms = new MemoryStream();

            wb.Write(ms);
            return ms.ToArray();
        }
    }
}
