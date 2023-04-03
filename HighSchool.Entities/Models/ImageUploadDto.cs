using System;
namespace HighSchool.Entities.Models
{
    public class ImageUploadDto
    {
        public ICollection<Image>? Images { get; set; }
        public ICollection<string>? ErrorMessages { get; set; }
    }
}

