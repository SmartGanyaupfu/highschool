using System;
using HighSchool.Contracts;

namespace HighSchool.Repository
{
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

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}

