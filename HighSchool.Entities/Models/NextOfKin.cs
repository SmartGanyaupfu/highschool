using System;
namespace HighSchool.Entities.Models
{
    public class NextOfKin : Person
    {
        public int NextOfKinId { get; set; }
        public Guid StudentId { get; set; }
    }
}