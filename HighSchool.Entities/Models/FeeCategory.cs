using System;
namespace HighSchool.Entities.Models
{
    public class FeeCategory: BaseEntity
    {
        public int FeeCategoryId { get; set; }
        public string? Name { get; set; }
    }
}

