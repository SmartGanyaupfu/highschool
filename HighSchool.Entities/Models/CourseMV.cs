using System;
namespace HighSchool.Entities.Models
{
    public class CourseMV
    {
        public Course? Course { get; set; }

        //public int? CategoryId { get; set; }

        public ICollection<Staff>? Teachers { get; set; }
    }
}

