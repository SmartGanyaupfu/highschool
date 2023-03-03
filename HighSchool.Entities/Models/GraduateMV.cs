using System;
namespace HighSchool.Entities.Models
{
    public class GraduateMV
    {
        public Graduate? Graduate { get; set; }


        public ICollection<Student>? Students { get; set; }
    }
}

