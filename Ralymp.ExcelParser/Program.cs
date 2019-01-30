using System.Collections.Generic;

namespace Ralymp.ExcelParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<ParticipationRow> winner16 = ExcelDataImporter.GetResult16();
            List<ParticipationRow> winner17 = ExcelDataImporter.GetResult17();

            var generator = new IdentifierGenerator();
            generator.ExtentData(winner16);
            generator.ExtentData(winner17);
        }
    }
}