using System;
namespace HighSchool.Shared.DTOs
{
    public class CategoryForCreationDto: BaseEntityDto
    {
        public CategoryForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
        public string? Name { get; set; }
        public string? Slug { get; set; }
    }
}

