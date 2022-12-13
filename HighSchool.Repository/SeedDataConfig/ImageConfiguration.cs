using System;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HighSchool.Repository.SeedDataConfig
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(
                new Image
                {
                    ImageId = 1,
                    Name="My-seed-Image",
                    AltText="Test",
                    ImageUrl= "https://learn.microsoft.com/en-us/shows/azure-sql-for-beginners/media/azuresqlforbeginners-2020-511x287.png"



                },
                new Image
                {
                    ImageId = 2,
                    Name = "My-seed-Image 2nd",
                    AltText = "Test 2",
                    ImageUrl = "https://learn.microsoft.com/en-us/shows/azure-sql-for-beginners/media/azuresqlforbeginners-2020-511x287.png"



                }
                );
        }
    }
}

