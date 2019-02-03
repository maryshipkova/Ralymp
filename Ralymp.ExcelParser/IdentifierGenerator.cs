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
            StudentSchool = new Dictionary<string, int>();
        }

        public Dictionary<string, int> StudentsId { get; }
        public Dictionary<string, int> TeachersId { get; }
        public Dictionary<string, int> SubjectsId { get; }
        public Dictionary<string, int> SchoolDictionary { get; private set; }
        public Dictionary<string, int> StudentSchool { get; private set; }

        public void ExtentData(List<ParticipationRow> rows)
        {
            InitSchoolDictionary();
            InitStudentsSchool(rows);

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

        private void InitSchoolDictionary()
        {
            SchoolDictionary = new Dictionary<string, int>
            {
                {"СЗОШ № 1", 1},
                {"СЗОШ № 2", 2},
                {"ЗОШ № 4", 4},
                {"ЗОШ № 5", 5},
                {"ЗОШ № 6", 6},
                {"ЗОШ № 7", 7},
                {"ЗОШ № 8", 8},
                {"ЗОШ № 10", 10},
                {"ЗОШ № 11", 11},
                {"РК КНЕУ", 12},
                {"РК СНАУ", 13},
                {"Рогинська ЗОШ", 14},
                {"СОГ-ІТД", 15}
            };
        }

        private void InitStudentsSchool(List<ParticipationRow> rows)
        {
            foreach (ParticipationRow row in rows)
            {
                if (StudentSchool.ContainsKey(row.StudentName) == false)
                {
                    StudentSchool[row.StudentName] = SchoolDictionary[row.School];
                }
            }
        }
    }
}