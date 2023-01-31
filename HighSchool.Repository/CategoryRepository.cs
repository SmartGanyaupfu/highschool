using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class CategoryRepository : GenericRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateCategoryAsync(Category category)
        {
            Create(category);
        }

        public void DeleteCategoryAsync(Category category)
        {
            Delete(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync( bool trackChanges)
        {
            var categories = await FindAll( trackChanges).ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategoryIdAsync(int categoryId, bool trackChanges)
        {
            return await FindByCondition(c => c.CategoryId.Equals(categoryId), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<Category> GetCategorySlugAsync(string slug, bool trackChanges)
        {
            return await FindByCondition(c => c.Slug.Equals(slug), trackChanges).FirstOrDefaultAsync();
        }

        public void UpdateCategoryAsync(Category category)
        {
            Update(category);
        }
    }
}

