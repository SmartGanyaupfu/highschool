using System;
namespace HighSchool.Shared.DTOs
{
    public class NextOfKinForCreationDto : PersonDto
    {
        public NextOfKinForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
    }
}

