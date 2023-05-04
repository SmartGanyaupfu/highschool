using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentForCreationDto:PersonDto
    {
        public StudentForCreationDto()
        {
            DateCreated = DateTime.Now;
        }

    }
}

