using Microsoft.EntityFrameworkCore;
using Ralymp.Models.DatabaseTypes;

namespace Ralymp.DataAccessLayer
{
    public class RalympDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ralymp.db");
        }

        public DbSet<Participation> Participations { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
    }
}
