using System;
namespace HighSchool.Shared.DTOs
{
    public class FeeCategoryAmountForUpdateDto:BaseEntityDto
    {
        public FeeCategoryAmountForUpdateDto()
        {
        }
        
        public double? Amount { get; set; }
        public int StudentLevelId { get; set; }

        public int? FeeCategoryId { get; set; }
    }
}

