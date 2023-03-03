using System;
namespace HighSchool.Shared.DTOs
{
    public class StaffForUpdateDto:PersonDto
    {
        public StaffForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }

        public string? JobTitle { get; set; }
        public string? Employer { get; set; }
        public string? MaritalStatus { get; set; }

        public int EmployeeTypeId { get; set; }

        public ICollection<Guid>? CourseIds { get; set; }
    }
}

