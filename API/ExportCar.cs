using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class ExportCar
    {
        public void Load()
        {
            string file = "e:\\20191028.xls";
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                if (fileExt == ".xlsx"){ workbook = new XSSFWorkbook(fs); }
                else if (fileExt == ".xls") { workbook = new HSSFWorkbook(fs); }
                else { workbook = null; }
                if (workbook == null) { return; }
                ISheet sheet = workbook.GetSheetAt(0);

                IRow header = sheet.GetRow(sheet.FirstRowNum);
                List<int> columns = new List<int>();
                for (int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = header.GetCell(i);
                    if (obj == null || obj.ToString() == string.Empty)
                    {
                        Console.WriteLine(i.ToString());
                    }
                    else
                    {
                        Console.WriteLine(obj.ToString());
                        Logger.Critical("ExportCar", obj.ToString());
                    }
                       
                }
            }
        }
    }
}
