using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw_numbers_spiner
{
    internal class GetData
    {
        public List<People> get_data()
        {
            List<People> list_people = new List<People>();

            // Tạo đối tượng FileInfo
            var file = new System.IO.FileInfo(@"data/data.xlsx");

            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Tạo đối tượng ExcelPackage
            using (var package = new ExcelPackage(file))
            {
                // Lấy sheet đầu tiên trong file
                var worksheet = package.Workbook.Worksheets[1];

                // Lấy số dòng và cột của sheet
                int rows = worksheet.Dimension.End.Row;
                int cols = worksheet.Dimension.End.Column;

                // Duyệt từng ô trong shOfficeOpenXml.LicenseException: 'Please set the ExcelPackage.LicenseContext property. See https://epplussoftware.com/developers/licenseexception'eet
                for (int r = 2; r <= rows; r++)
                {  
                    list_people.Add(new People()
                    {
                        id = worksheet.Cells[r, 1].Value.ToString(),
                        name = worksheet.Cells[r, 2].Value.ToString(),
                        department = worksheet.Cells[r, 3].Value.ToString()
                    });
                }
            }

            return list_people;
        }
    }
}
