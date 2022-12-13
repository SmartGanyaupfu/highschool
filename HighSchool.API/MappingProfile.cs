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
            //CreateMap<PageForCreationDto, Page>();
            //CreateMap<PageForUpdateDto, Page>();

            CreateMap<Image, ImageDto>();
        }
    }
}

