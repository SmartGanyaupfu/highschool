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
    }
}

