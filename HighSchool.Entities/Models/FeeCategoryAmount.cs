using System;
namespace HighSchool.Entities.Models
{
    public class FeeCategoryAmount: BaseEntity
    {
        public int FeeCategoryAmountId { get; set; }
        public double? Amount { get; set; }
        public int StudentLevelId { get; set; }
        public StudentLevel? StudentLevel { get; set; }
        public int FeeCategoryId { get; set; }
        public FeeCategory? FeeCategory { get; set; }
    }
}

