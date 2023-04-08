using System;
namespace HighSchool.Shared.DTOs
{
    public class FeeCategoryDto:BaseEntityDto
    {
        public int FeeCategoryId { get; set; }
        public string? Name { get; set; }
    }
}

