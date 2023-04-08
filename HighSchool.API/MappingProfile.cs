using System;
using AutoMapper;
using HighSchool.Entities.Models;
using HighSchool.Shared.DTOs;
using MailKit.Security;

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

            CreateMap<Student, StudentDto>();
            CreateMap<StudentMV, StudentMVDto>();
            CreateMap<StudentForCreationDto, Student>();
            CreateMap<StudentForUpdateDto, Student>();

            CreateMap<Staff, StaffDto>();
            CreateMap<TeacherMV, TeacherMVDto>();
            CreateMap<StaffForCreationDto, Staff>();
            CreateMap<StaffForUpdateDto, Staff>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();


            CreateMap<AllocatedResource, AllocatedResourceDto>();
            CreateMap<AllocatedResourceForCreationDto, AllocatedResource>();
            CreateMap<AllocatedResourceForUpdateDto, AllocatedResource>();

            CreateMap<Course, CourseDto>();
            CreateMap<CourseForCreationDto, Course>();
            CreateMap<CourseForUpdateDto, Course>();
            CreateMap<CourseMV, CourseMVDto>();

            CreateMap<CourseWorkReport, CourseWorkReportDto>();
            CreateMap<CourseWorkReportForCreationDto, CourseWorkReport>();
            CreateMap<CourseForUpdateDto, CourseWorkReport>();

            CreateMap<EmployeeType, EmployeeTypeDto>();
            CreateMap<EmployeeTypeForCreationDto, EmployeeType>();
            CreateMap<EmployeeTypeForUpdateDto, EmployeeType>();

            CreateMap<StudentClass, GradeDto>();
            CreateMap<GradeMV, GradeMVDto>();
            CreateMap<GradeForCreationDto, StudentClass>();
            CreateMap<GradeForUpdateDto, StudentClass>();

            CreateMap<Graduate, GraduateDto>();
            CreateMap<GraduateMV, GraduateMVDto>();
            CreateMap<GraduateForCreationDto, Graduate>();
            CreateMap<GraduateForUpdateDto, Graduate>();

            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceForCreationDto, Invoice>();
            CreateMap<InvoiceForUpdateDto, Invoice>();

            CreateMap<InvoiceItem, InvoiceItemDto>();
            CreateMap<InvoiceItemForCreationDto, InvoiceItem>();
            CreateMap<InvoiceItemForUpdateDto, InvoiceItem>();

            CreateMap<LessonPlan, LessonPlanDto>();
            CreateMap<LessonPlanForCreationDto, LessonPlan>();
            CreateMap<LessonPlanForUpdateDto, LessonPlan>();

            CreateMap<NextOfKin, NextOfKinDto>();
            CreateMap<NextOfKinForCreationDto, NextOfKin>();
            CreateMap<NextOfKinForUpdateDto, NextOfKin>();

            CreateMap<Note, NoteDto>();
            CreateMap<NoteForCreationDto,Note>();
            CreateMap<NoteForUpdateDto, Note>();

            CreateMap<WidgetForCreationDto, Widget>();
            CreateMap<WidgetForUpdateDto, Widget>();

            CreateMap<ContentBlockForCreationDto, ContentBlock>();
            CreateMap<ContentBlockForUpdateDto, ContentBlock>();

            CreateMap<FeeCategory, FeeCategoryDto>();
            CreateMap<FeeCategoryForCreationDto, FeeCategory>();
            CreateMap<FeeCategoryForUpdateDto, FeeCategory>();

            CreateMap<Image, ImageDto>();
            CreateMap<ImageForUpdateDto, Image>();
        }
    }
}

