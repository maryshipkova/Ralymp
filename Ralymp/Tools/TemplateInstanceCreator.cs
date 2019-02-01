using System;
using System.Linq;
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

        public static TeacherRateRow[] GetTeacherRateRow(int count)
        {
            TeacherParticipation[] CreateTeacherParticipation(int c)
            {
                return Enumerable.Range(0, c)
                    .Select(_ => new TeacherParticipation()
                    {
                        StudentName = CreateRandomString(),
                        Place = Random.Next().ToString(),
                        SubjectName = CreateRandomString(),
                        Year = CreateRandomString()
                    })
                    .ToArray();
            }

            return Enumerable.Range(0, count)
                .Select(_ => new TeacherRateRow
                {
                    SchoolTitle = CreateRandomString(),
                    TeacherName = CreateRandomString(),
                    Participations = CreateTeacherParticipation(Random.Next(10))
                })
                .ToArray();
        }

        public static StudentProfileResponse GetStudentProfileResponse()
        {
            SubjectCategoryRow[] GetCategories(int c)
            {
                return Enumerable.Range(0, c)
                    .Select(_ => new SubjectCategoryRow()
                    {
                        Title = CreateRandomString(),
                        Value = Random.Next(10)
                    })
                    .ToArray();
            }

            return new StudentProfileResponse()
            {
                CategoryRows = GetCategories(5),
                Participation = CreateParticipation(Random.Next(10)),
                SchoolTitle = CreateRandomString(),
                StudentName = CreateRandomString(),
                StudentId = 1,
                TotalWinsOnCountryStage = Random.Next(10),
                TotalWinsOnMunicipalStage = Random.Next(10),
                TotalWinsOnRegionStage = Random.Next(10),
            };
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
    }
}
