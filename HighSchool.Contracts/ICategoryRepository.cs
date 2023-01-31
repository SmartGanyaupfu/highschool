using System;
using HighSchool.Entities.Models;

namespace HighSchool.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync( bool trackChanges);
        Task<Category> GetCategoryIdAsync(int categoryId, bool trackChanges);
        Task<Category> GetCategorySlugAsync(string slug, bool trackChanges);
        void CreateCategoryAsync(Category category);
        void DeleteCategoryAsync(Category category);
        void UpdateCategoryAsync(Category category);
    }
}

