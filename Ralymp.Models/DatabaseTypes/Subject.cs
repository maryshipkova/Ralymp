using Ralymp.Models.InterimTypes;

namespace Ralymp.Models.DatabaseTypes
{
    public class Subject
    {
        public int Id { get; set; }

        public SubjectType Type { get; set; }
        public string Title { get; set; }
    }
}