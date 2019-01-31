using Ralymp.Models.InterimTypes;

namespace Ralymp.ExcelParser
{
    public class ParticipationRow
    {
        public string StudentName { get; set; }
        public string School { get; set; }
        public string Form { get; set; }
        public string Teacher { get; set; }
        public string Subject { get; set; }
        public int Place { get; set; }
        public int Year { get; set; }
        public SubjectType SubjectType { get; set; }
    }
}