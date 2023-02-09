namespace HighSchool.Entities.Models
{
    public class StudentGraduate
    {
        public int StudentGraduateId { get; set; }

        public int GraduateId { get; set; }
        public Graduate? Graduate { get; set; }

        public Guid StudentId { get; set; }
        public Student? Student { get; set; }
    }
}