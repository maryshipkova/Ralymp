using System;
using Microsoft.EntityFrameworkCore;
using Ralymp.DataAccessLayer;

namespace Ralymp.ExcelParser
{
    public class DatabaseUpdater
    {
        private readonly DbContextOptionsBuilder<RalympDbContext> _builder;

        public DatabaseUpdater()
        {
            _builder = new DbContextOptionsBuilder<RalympDbContext>();
            var connection =
                    "place_your_connect"
                ;

            _builder.UseSqlServer(connection);
        }

        public void DeleteAllData()
        {
            var localContext = new RalympDbContext(_builder.Options);
            localContext.Participations.RemoveRange(localContext.Participations);
            localContext.Teacher.RemoveRange(localContext.Teacher);
            localContext.Subject.RemoveRange(localContext.Subject);
            localContext.Student.RemoveRange(localContext.Student);
            localContext.School.RemoveRange(localContext.School);
            localContext.SaveChanges();
        }

        public void AddData(ModelsAggregator models)
        {
            var localContext = new RalympDbContext(_builder.Options);

            localContext.Teacher.AddRange(models.GetTeachers());
            UpdateIdentity(localContext, "Teacher");

            localContext.School.AddRange(models.GetSchools());
            UpdateIdentity(localContext, "School");

            localContext.Student.AddRange(models.GetStudents());
            UpdateIdentity(localContext, "Student");

            localContext.Subject.AddRange(models.GetSubjects());
            UpdateIdentity(localContext, "Subject");

            localContext.YearInfo.AddRange(models.GetYears());
            UpdateIdentity(localContext, "YearInfo");

            localContext.Participations.AddRange(models.GetParticipations());
            UpdateIdentity(localContext, "Participations");
        }

        private void UpdateIdentity(RalympDbContext context, string table)
        {
            context.Database.OpenConnection();
            try
            {
                string on = $"SET IDENTITY_INSERT [dbo].[{table}] ON";
                context.Database.ExecuteSqlCommand(on);

                context.SaveChanges();

                string off = $"SET IDENTITY_INSERT [dbo].[{table}] OFF";
                context.Database.ExecuteSqlCommand(off);
            }
            catch (Exception e)
            {
                context.Database.CloseConnection();
                Console.WriteLine(e.Message);
            }
        }
    }
}