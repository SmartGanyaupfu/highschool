using System;
namespace HighSchool.Entities.Models
{
    public class GradeMV
    {
        public StudentClass? Grade { get; set; }


        public ICollection<Student>? Students { get; set; }
    }
}

