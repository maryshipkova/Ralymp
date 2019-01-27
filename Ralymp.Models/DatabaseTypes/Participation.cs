using Ralymp.Models.InterimTypes;

namespace Ralymp.Models.DatabaseTypes
{
    public class Participation
    {
        public int Id { get; set; }

        public int Place { get; set; }
        public OlympLevel Level { get; set; }

        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public YearInfo YearInfo { get; set; }
    }
}