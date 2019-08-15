using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace Excel
{
    internal static class PersonCollectionUtils
    {
        public static void WriteToSpreadsheet(this IEnumerable<Person> persons, FileInfo outputFile)
        {
            using (var excelPackage = new ExcelPackage(outputFile))
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                worksheet.Column(1).Width = 20;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 7;
                worksheet.Column(3).Style.Numberformat.Format = "#";

                worksheet.Cells[1, 1].Value = "First Name";
                worksheet.Cells[1, 2].Value = "Last Name";
                worksheet.Cells[1, 3].Value = "Age";

                var row = 1;
                foreach (var person in persons)
                {
                    row++;

                    worksheet.Cells[row, 1].Value = person.FirstName;
                    worksheet.Cells[row, 2].Value = person.LastName;
                    worksheet.Cells[row, 3].Value = person.Age;
                }

                excelPackage.Save();
            }
        }
    }
}
