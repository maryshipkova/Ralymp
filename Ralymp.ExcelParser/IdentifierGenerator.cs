using System;
using System.Collections.Generic;

namespace Ralymp.ExcelParser
{
    public class IdentifierGenerator
    {
        public IdentifierGenerator()
        {
            StudentsId = new Dictionary<string, int>();
            TeachersId = new Dictionary<string, int>();
            SubjectsId = new Dictionary<string, int>();
        }

        public Dictionary<string, int> StudentsId { get; }
        public Dictionary<string, int> TeachersId { get; }
        public Dictionary<string, int> SubjectsId { get; }

        public void ExtentData(List<ParticipationRow> rows)
        {
            ExtendDictionary(rows, r => r.StudentName, StudentsId);
            ExtendDictionary(rows, r => r.Teacher, TeachersId);
            ExtendDictionary(rows, r => r.Subject, SubjectsId);
        }

        private void ExtendDictionary<T>(
            List<ParticipationRow> rows,
            Func<ParticipationRow, T> selector,
            Dictionary<T, int> dictionary)
        {
            foreach (ParticipationRow row in rows)
            {
                if (dictionary.ContainsKey(selector(row)) == false)
                {
                    int id = dictionary.Count + 1;
                    dictionary.Add(selector(row), id);
                }
            }
        }
    }
}