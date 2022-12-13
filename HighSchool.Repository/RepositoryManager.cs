using System;
using HighSchool.Contracts;

namespace HighSchool.Repository
{
    public class RepositoryManager:IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IPageRepository> _pageRepository;
        private readonly Lazy<IPostRepository> _postRepository;

       // private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<IImageRepository> _imageRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _pageRepository = new Lazy<IPageRepository>(() => new PageRepository(repositoryContext));
            _postRepository = new Lazy<IPostRepository>(() => new PostRepository(repositoryContext));
            _imageRepository = new Lazy<IImageRepository>(() => new ImageRepository(repositoryContext));
        }

        public IPageRepository Page => _pageRepository.Value;

        public IPostRepository Post => _postRepository.Value;

        public IImageRepository Image => _imageRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}

