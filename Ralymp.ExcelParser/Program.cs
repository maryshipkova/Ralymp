using System.Collections.Generic;
using Ralymp.Models.InterimTypes;

namespace Ralymp.ExcelParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<ParticipationRow> winner16 = ExcelDataImporter.GetResult16();
            List<ParticipationRow> winner17 = ExcelDataImporter.GetResult17();

            var infoGenerator = new ModelsAggregator();
            infoGenerator.AddData(winner16, 16, OlympLevel.City);
            infoGenerator.AddData(winner17, 17, OlympLevel.City);

            var dbProvider = new DatabaseUpdater();
            dbProvider.DeleteAllData();
            dbProvider.AddData(infoGenerator);
        }
    }
}