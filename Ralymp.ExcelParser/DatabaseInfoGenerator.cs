using System.Collections.Generic;
using System.Linq;
using Ralymp.Models.DatabaseTypes;
using Ralymp.Models.InterimTypes;

namespace Ralymp.ExcelParser
{
    public class DatabaseInfoGenerator
    {
        private readonly IdentifierGenerator _idGenerator;
        private readonly List<Participation> _participations;

        public DatabaseInfoGenerator()
        {
            _idGenerator = new IdentifierGenerator();
            _participations = new List<Participation>();
        }

        public void AddData(List<ParticipationRow> rows, int yearId, OlympLevel level)
        {
            _idGenerator.ExtentData(rows);
            AddParticipation(rows, yearId, level);
        }

        private void AddParticipation(List<ParticipationRow> rows, int yearId, OlympLevel level)
        {
            var id = 1;
            foreach (ParticipationRow row in rows)
            {
                var participation = new Participation
                {
                    Subject = new Subject {Id = _idGenerator.SubjectsId[row.Subject]},
                    Teacher = new Teacher {Id = _idGenerator.TeachersId[row.Teacher]},
                    Student = new Student {Id = _idGenerator.StudentsId[row.StudentName]},
                    YearInfo = new YearInfo {Id = yearId},
                    Place = row.Place,
                    Level = level,
                    Id = id
                };

                _participations.Add(participation);
                id++;
            }
        }


        public List<Participation> GetParticipations()
        {
            return _participations;
        }

        public List<School> GetSchools()
        {
            return _idGenerator
                .SchoolDictionary
                .Select(v => new School
                {
                    Id = v.Value,
                    Title = v.Key
                })
                .ToList();
        }

        public List<Student> GetStudents()
        {
            return _idGenerator
                .StudentsId
                .Select(v => new Student
                {
                    FirstName = v.Key,
                    Id = v.Value
                })
                .ToList();
        }

        public List<Subject> GetSubjects()
        {
            return _idGenerator
                .SubjectsId
                .Select(v => new Subject {Id = v.Value, Title = v.Key})
                .ToList();
        }

        public List<Teacher> GetTeachers()
        {
            return _idGenerator
                .TeachersId
                .Select(v => new Teacher {FirstName = v.Key, Id = v.Value})
                .ToList();
        }

        public List<YearInfo> GetYears()
        {
            return new List<YearInfo>
            {
                new YearInfo {FullTitle = "2016/2017", Id = 16},
                new YearInfo {FullTitle = "2017/2018", Id = 17},
                new YearInfo {FullTitle = "2018/2019", Id = 18}
            };
        }
    }
}