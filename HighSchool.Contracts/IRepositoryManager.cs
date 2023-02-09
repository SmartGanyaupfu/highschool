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
        IAllocatedResourceRepository AllocatedResource { get; }
        IAnswerRepository Answer { get; }
        IQuestionRepository Question { get; }
        ILessonPlanRepository LessonPlan { get; }
        INoteRepository Note { get; }
        IWidgetRepository Widget { get; }
        IInvoiceRepository Invoice { get; }
        IPaymentRepository Payment { get; }
        ICourseWorkReportRepository CourseWorkReport { get; }
        IGradeRepository Grade { get; }
        IStaffCourseRepository StaffCourse { get; }
        IStudentGradeRepository StudentGrade { get; }
        IStudentGraduateRepository StudentGraduate { get; }
    }
}

