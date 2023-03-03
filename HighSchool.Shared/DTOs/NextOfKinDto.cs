using System;
namespace HighSchool.Shared.DTOs
{
    public class NextOfKinDto : PersonDto
    {
        public int NextOfKinId { get; set; }
        public Guid StudentId { get; set; }
    }
}

