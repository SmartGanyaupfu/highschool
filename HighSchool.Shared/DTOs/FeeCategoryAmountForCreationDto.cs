using System;
namespace HighSchool.Shared.DTOs
{
    public class FeeCategoryAmountForCreationDto:BaseEntityDto
    {
        public FeeCategoryAmountForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
        public int FeeCategoryAmountId { get; set; }
        public double Amount { get; set; }
        public int StudentLevelId { get; set; }
        public int FeeCategoryId { get; set; }
    }
}

