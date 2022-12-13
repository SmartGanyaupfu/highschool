using System;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HighSchool.Repository.SeedDataConfig
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasData(
                new Page
                {
                    PageId = Guid.NewGuid(),
                    Title = "Home",
                    Slug = "home",
                    Content = "The innner part of the solar cookker is made of mirroes",
                  FeatureImageId=1,
                    MetaDescription = "The inner was the inner",
                    MetaKeyWords = "test,tets,done",


                },
                     new Page
                     {
                         PageId = Guid.NewGuid(),
                         Title = "About",
                         Slug = "about",
                         Content = "The innner part of the solar cookker is made of mirroes",
                            FeatureImageId=1,
                         MetaDescription = "The inner was the inner",
                         MetaKeyWords = "test,tets,done",


                     }
                     ,
                          new Page
                          {
                              PageId = Guid.NewGuid(),
                              Title = "Contact",
                              Slug = "contact",
                              Content = "The innner part of the solar cookker is made of mirroes",
                             
                              MetaDescription = "The inner was the inner",
                              MetaKeyWords = "test,tets,done",


                          }
                );
        }
    }
}

