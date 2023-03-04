using System;
namespace HighSchool.Shared.DTOs
{
    public class WidgetForCreationDto:BaseEntityDto
    {
        public WidgetForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
        public string? MissionStatemnetBlockId { get; set; }
        public string? VissionBlockId { get; set; }
        public string? ValuesBlockId { get; set; }
        public string? LogoUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? YouTubeUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FooterOneBlockId { get; set; }
        public string? FooterTwoBlockId { get; set; }
        public string? FooterThreeBlockId { get; set; }
        public string? HomePageId { get; set; }
        public string? ContactPageId { get; set; }
        public string? IntroText { get; set; }
        public string? SloganText { get; set; }
        public string? FooterCopyrightBlockId { get; set; }
        public string? HomePageSize { get; set; }
        public string? PostPageSize { get; set; }
    }
}

