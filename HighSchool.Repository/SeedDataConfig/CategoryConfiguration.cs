using System;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HighSchool.Repository.SeedDataConfig
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Mobile",
                    Slug="mobile-app"



                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Web",
                    Slug = "web"

                }
                );
        }
    }
}

