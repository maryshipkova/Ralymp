using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExcelDataReader;
using OfficeOpenXml;

namespace Ralymp.ExcelParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            const string filePath = "winner-list-16.xlsx";
            List<ParticipationRow> result = new List<ParticipationRow>();

            using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    //Skip first row
                    reader.Read();

                    while (reader.Read())
                    {
                        result.Add(Convertor(reader));
                    }
                }
            }


        }

        public static ParticipationRow Convertor(IExcelDataReader reader)
        {
            return new ParticipationRow
            {
                StudentName = reader.GetString(0),
                School = reader[1].ToString(),
                Form = int.Parse(reader[2].ToString()),
                Teacher = reader.GetString(3),
                Subject = reader.GetString(4),
                Place = int.Parse(reader[5].ToString())
            };
        }
    }
}
