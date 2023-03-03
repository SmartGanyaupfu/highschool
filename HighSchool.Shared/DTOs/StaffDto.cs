using System;
namespace HighSchool.Shared.DTOs
{
    public class StaffDto:PersonDto
    {
        public Guid StaffId { get; set; }
        public string? JobTitle { get; set; }
        public string? Employer { get; set; }
        public string? MaritalStatus { get; set; }

        public int EmployeeTypeId { get; set; }
        public EmployeeTypeDto? EmployeeType { get; set; }
        public ICollection<LessonPlanDto>? LessonPlans { get; set; }
    }
}

