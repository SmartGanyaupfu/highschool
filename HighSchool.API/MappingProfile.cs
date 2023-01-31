using System;
using AutoMapper;
using HighSchool.Entities.Models;
using HighSchool.Shared.DTOs;

namespace HighSchool.API
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Page, PageDto>();
            CreateMap<PageForCreationDto, Page>();
            CreateMap<PageForUpdateDto, Page>();

            CreateMap<Post, PostDto>();
            CreateMap<PostMV, PostMVDto>();
            CreateMap<PostForCreationDto, Post>();
            CreateMap<PostForUpdateDto, Post>();

            CreateMap<PostCat, PostCatDto>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();
            

            CreateMap<Image, ImageDto>();
        }
    }
}

