using System;
namespace HighSchool.Shared.DTOs
{
    public class FeeCategoryAmountDto:BaseEntityDto
    {
        public int FeeCategoryAmountId { get; set; }
        public double? Amount { get; set; }
        public int StudentLevelId { get; set; }
        public StudentLevelDto? StudentLevel { get; set; }
        public int? FeeCategoryId { get; set; }
        public FeeCategoryDto? FeeCategory { get; set; }
    }
}

