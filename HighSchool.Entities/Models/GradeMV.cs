using System;
namespace HighSchool.Entities.Models
{
    public class GradeMV
    {
        public Grade? Grade { get; set; }


        public ICollection<Student>? Students { get; set; }
    }
}

