using System;
namespace HighSchool.Contracts
{
    public interface IRepositoryManager
    {
        Task SaveAsync();
        IPageRepository Page { get; }
        IPostRepository Post { get; }

        IImageRepository Image { get; }
        IPostCatRepository PostCat { get; }
        ICategoryRepository Category { get; }
        IStudentRepository Student { get; }
        IStaffRepository Staff { get; }
        INextOfKinRepository NextOfKin { get; }
        IContentBlockRepository ContentBlock { get; }
        ICourseRepository Course { get; }
        IEmployeeTypeRepository EmployeeType { get; }
    }
}

