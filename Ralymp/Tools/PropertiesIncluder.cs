using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ralymp.Models.DatabaseTypes;

namespace Ralymp.Tools
{
    public static class PropertiesIncluder
    {
        public static IQueryable<Student> IncludeProperty(this DbSet<Student> table)
        {
            return table
                .Include(s => s.School)
                .Include(s => s.ParticipationList)
                    .ThenInclude(p => p.Subject)
                .Include(s => s.ParticipationList)
                    .ThenInclude(p => p.Teacher)
                .Include(s => s.ParticipationList)
                    .ThenInclude(p => p.YearInfo);
        }
    }
}