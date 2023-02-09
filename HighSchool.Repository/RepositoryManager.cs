using System;
using System.Diagnostics;
using HighSchool.Contracts;

namespace HighSchool.Repository
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class RepositoryManager:IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IPageRepository> _pageRepository;
        private readonly Lazy<IPostRepository> _postRepository;
        private readonly Lazy<IPostCatRepository> _postCatRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IStudentRepository> _studentRepository;
        private readonly Lazy<IStaffRepository> _staffRepository;
        private readonly Lazy<INextOfKinRepository> _nextOfKinRepository;
        private readonly Lazy<IContentBlockRepository> _contentBlockRepository;
        private readonly Lazy<ICourseRepository> _courseRepository;
        private readonly Lazy<IEmployeeTypeRepository> _employeeTypeRepository;
        private readonly Lazy<IAllocatedResourceRepository> _resource;
        private readonly Lazy<IAnswerRepository> _answer;
        private readonly Lazy<IQuestionRepository> _questionRepository;
        private readonly Lazy<ILessonPlanRepository> _lesson;
        private readonly Lazy<INoteRepository> _noteRepository;
        private readonly Lazy<IWidgetRepository> _widgetRepository;
        private readonly Lazy<IInvoiceRepository> _invoiceRepository;
        private readonly Lazy<IPaymentRepository> _paymentRepository;
        private readonly Lazy<ICourseWorkReportRepository> _courseWorkReportRepository;
        private readonly Lazy<IGradeRepository> _gradeRepository;
        private readonly Lazy<IStaffCourseRepository> _staffCourseRepository;
        private readonly Lazy<IStudentGradeRepository> _studentGradeRepository;
        private readonly Lazy<IStudentGraduateRepository> studentGraduateRepository;

       // private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IImageRepository> _imageRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _pageRepository = new Lazy<IPageRepository>(() => new PageRepository(repositoryContext));
            _postRepository = new Lazy<IPostRepository>(() => new PostRepository(repositoryContext));
            _imageRepository = new Lazy<IImageRepository>(() => new ImageRepository(repositoryContext));
            _postCatRepository = new Lazy<IPostCatRepository>(() => new PostCatRepository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
            _studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(repositoryContext));
            _staffRepository = new Lazy<IStaffRepository>(() => new StaffRepository(repositoryContext));
            _nextOfKinRepository = new Lazy<INextOfKinRepository>(() => new NextOfKinRepository(repositoryContext));
            _contentBlockRepository = new Lazy<IContentBlockRepository>(() => new ContentBlockRepository(repositoryContext));
            _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(repositoryContext));
            _employeeTypeRepository = new Lazy<IEmployeeTypeRepository>(() => new EmployeeTypeRepository(repositoryContext));
            _resource = new Lazy<IAllocatedResourceRepository>(() => new AllocatedResourceRepository(repositoryContext));
            _answer = new Lazy<IAnswerRepository>(() => new AnswerRepository(repositoryContext));
            _questionRepository = new Lazy<IQuestionRepository>(() => new QuestionRepository(repositoryContext));
            _lesson = new Lazy<ILessonPlanRepository>(() => new LessonPlanRepository(repositoryContext));
            _noteRepository = new Lazy<INoteRepository>(() => new NoteRepository(repositoryContext));
            _widgetRepository = new Lazy<IWidgetRepository>(() => new WidgetRepository(repositoryContext));
            _invoiceRepository = new Lazy<IInvoiceRepository>(() => new InvoiceRepository(repositoryContext));
            _paymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(repositoryContext));
            _courseWorkReportRepository = new Lazy<ICourseWorkReportRepository>(() => new CourseWorkReportRepository(repositoryContext));
            _gradeRepository = new Lazy<IGradeRepository>(() => new HClassRepository(repositoryContext));
            _staffCourseRepository = new Lazy<IStaffCourseRepository>(() => new StaffCourseRepository(repositoryContext));
            _studentGradeRepository = new Lazy<IStudentGradeRepository>(() => new StudentGradeRepository(repositoryContext));
            this.studentGraduateRepository = new Lazy<IStudentGraduateRepository>(() => new StudentGraduateRepository(repositoryContext));

        }

        public IPageRepository Page => _pageRepository.Value;

        public IPostRepository Post => _postRepository.Value;

        public IImageRepository Image => _imageRepository.Value;

        public IPostCatRepository PostCat => _postCatRepository.Value;

        public ICategoryRepository Category => _categoryRepository.Value;

        public IStudentRepository Student => _studentRepository.Value;

        public IStaffRepository Staff => _staffRepository.Value;

        public INextOfKinRepository NextOfKin => _nextOfKinRepository.Value;

        public IContentBlockRepository ContentBlock => _contentBlockRepository.Value;

        public ICourseRepository Course => _courseRepository.Value;

        public IEmployeeTypeRepository EmployeeType => _employeeTypeRepository.Value;

        public IAllocatedResourceRepository AllocatedResource => _resource.Value;

        public IAnswerRepository Answer => _answer.Value;

        public IQuestionRepository Question => _questionRepository.Value;

        public ILessonPlanRepository LessonPlan => _lesson.Value;

        public INoteRepository Note => _noteRepository.Value;

        public IWidgetRepository Widget => _widgetRepository.Value;

        public IInvoiceRepository Invoice => _invoiceRepository.Value;

        public IPaymentRepository Payment => _paymentRepository.Value;

        public ICourseWorkReportRepository CourseWorkReport => _courseWorkReportRepository.Value;

        public IGradeRepository Grade => _gradeRepository.Value;

        public IStaffCourseRepository StaffCourse => _staffCourseRepository.Value;

        public IStudentGradeRepository StudentGrade => _studentGradeRepository.Value;

        public IStudentGraduateRepository StudentGraduate => this.studentGraduateRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}

