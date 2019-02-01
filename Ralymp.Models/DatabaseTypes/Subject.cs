using Ralymp.Models.InterimTypes;

namespace Ralymp.Models.DatabaseTypes
{
    public class Subject
    {
        public int Id { get; set; }

        //TODO: Move SubjectType to Participation and rename to CompetitionType
        public SubjectType Type { get; set; }
        public string Title { get; set; }
    }
}