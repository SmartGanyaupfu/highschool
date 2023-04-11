using System;
namespace HighSchool.Shared.DTOs
{
    public class SchoolTermForCreationDto:BaseEntityDto
    {
        public SchoolTermForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
        public string? Name { get; set; }
    }
}

