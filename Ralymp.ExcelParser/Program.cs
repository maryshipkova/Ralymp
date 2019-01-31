using System.Collections.Generic;
using Ralymp.Models.DatabaseTypes;
using Ralymp.Models.InterimTypes;

namespace Ralymp.ExcelParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<ParticipationRow> winner16 = ExcelDataImporter.GetResult16();
            List<ParticipationRow> winner17 = ExcelDataImporter.GetResult17();

            var infoGenerator = new DatabaseInfoGenerator();
            infoGenerator.AddData(winner16, 1, OlympLevel.City);
            infoGenerator.AddData(winner17, 2, OlympLevel.City);

            List<Participation> participations = infoGenerator.GetParticipations();
        }
    }
}