using System;
namespace HighSchool.Shared.DTOs
{
    public class PersonDto:BaseEntityDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Phone { get; set; }

        public string? EmailAddress { get; set; }

        public string? NationalIdentityNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string? Summary { get; set; }

        public int? FeatureImageId { get; set; }

        //public ProfileImage ProfileImage { get; set; }
        public string? Gender { get; set; }
        public string? Title { get; set; }
        public string? MiddleName { get; set; }
        public string? MaidenName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Website { get; set; }
        public string? Skype { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
        public string? LinkedIn { get; set; }
        public string? YouTube { get; set; }
        public string? Slug { get; set; }


        public int? AddressId { get; set; }
    }
}

