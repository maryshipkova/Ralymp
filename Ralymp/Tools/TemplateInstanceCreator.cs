using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ralymp.Models.InterimTypes;
using Ralymp.Models.ResponseTypes;

namespace Ralymp.Tools
{
    public static class TemplateInstanceCreator
    {
        private static readonly Random Random = new Random();

        public static StudentRateRow[] GetStudentRateRow(int count)
        {
            return Enumerable.Range(0, count)
                .Select(_ => new StudentRateRow
                {
                    SchoolTitle = CreateRandomString(),
                    Participation = CreateParticipation(Random.Next(10)),
                    StudentName = CreateRandomString()
                })
                .ToArray();
        }

        private static StudentParticipation[] CreateParticipation(int count)
        {
            return Enumerable.Range(0, count)
                .Select(_ => new StudentParticipation
                {
                    Place = Random.Next().ToString(),
                    SubjectName = CreateRandomString(),
                    Year = CreateRandomString()
                })
                .ToArray();
        }

        public static TeacherRateRow[] GetTeacherRateRow(int count)
        {
            return Enumerable.Range(0, count)
                .Select(_ => new TeacherRateRow
                {
                    SchoolTitle = CreateRandomString(),
                    TeacherName = CreateRandomString(),
                    Participations = CreateTeacherParticipation(Random.Next(10))
                })
                .ToArray();
        }

        private static TeacherParticipation[] CreateTeacherParticipation(int count)
        {
            return Enumerable.Range(0, count)
                .Select(_ => new TeacherParticipation()
                {
                    StudentName = CreateRandomString(),
                    Place = Random.Next().ToString(),
                    SubjectName = CreateRandomString(),
                    Year = CreateRandomString()
                })
                .ToArray();
        }

        public static string CreateRandomString(int size = 15)
        {
            const string chars = "qwertyuiopasdfghjklzxcvbnmABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            char[] value = Enumerable
                .Range(1, size)
                .Select(s => chars[Random.Next(chars.Length)])
                .ToArray();
            return new string(value);
        }
    }
}
