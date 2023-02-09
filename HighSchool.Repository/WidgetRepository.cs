using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class WidgetRepository : GenericRepositoryBase<Widget>, IWidgetRepository
    {
        public WidgetRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateWidgetAsync(Widget widget)
        {
            Create(widget);
        }

        public async Task<Widget> GetWidgetAsync(bool trackChanges)
        {
            var widgets = await FindAll(trackChanges).ToListAsync();

            return (widgets.FirstOrDefault());
        }

        public void UpdateWidgetAsync(Widget widget)
        {
            Update(widget);
        }
    }
}

