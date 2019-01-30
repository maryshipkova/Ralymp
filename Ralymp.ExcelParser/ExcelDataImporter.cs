using System.Collections.Generic;
using System.IO;
using System.Text;
using ExcelDataReader;

namespace Ralymp.ExcelParser
{
    public static class ExcelDataImporter
    {
        static ExcelDataImporter()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public static List<ParticipationRow> GetResult16()
        {
            const string filePath16 = "winner-list-16.xlsx";
            List<ParticipationRow> winner16 = Parser(filePath16);
            return winner16;
        }

        public static List<ParticipationRow> GetResult17()
        {
            const string filePath17 = "winner-list-17.xlsx";
            List<ParticipationRow> winner17 = Parser(filePath17);
            return winner17;
        }

        private static List<ParticipationRow> Parser(string filePath)
        {
            var result = new List<ParticipationRow>();

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

            return result;
        }

        private static ParticipationRow Convertor(IExcelDataReader reader)
        {
            //TODO: Parse to string or get course number from string
            bool isCorrectForm = int.TryParse(reader[2].ToString(), out int form);

            return new ParticipationRow
            {
                StudentName = reader.GetString(0),
                School = reader[1].ToString(),
                Form = isCorrectForm ? form : 1,
                Teacher = reader.GetString(3),
                Subject = reader.GetString(4),
                Place = int.Parse(reader[5].ToString())
            };
        }
    }
}