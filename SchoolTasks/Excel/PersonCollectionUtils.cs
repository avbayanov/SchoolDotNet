using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Excel
{
    internal static class PersonCollectionUtils
    {
        public static void WriteToSpreadsheet(this IEnumerable<Person> persons, FileInfo outputFile)
        {
            if (outputFile.Exists)
            {
                outputFile.Delete();
            }

            const int propertiesCount = 3;

            using (var excelPackage = new ExcelPackage(outputFile))
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Persons");

                worksheet.Column(3).Style.Numberformat.Format = "#";

                worksheet.Cells[1, 1, 1, propertiesCount].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 1, 1, propertiesCount].Style.Font.Bold = true;

                for (int i = 1; i <= propertiesCount; i++)
                {
                    worksheet.Cells[1, i].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }

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

                    for (int i = 1; i <= propertiesCount; i++)
                    {
                        worksheet.Cells[row, i].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }
                }

                worksheet.Cells[1, 1, 1, propertiesCount].AutoFitColumns(1);

                excelPackage.Save();
            }
        }
    }
}
