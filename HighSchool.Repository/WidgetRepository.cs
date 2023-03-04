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

        public async Task<Widget> GetWidgetByIdAsync(int widgetId, bool trackChanges)
        {
            return await FindByCondition(w=>w.WidgetId.Equals(widgetId),trackChanges).SingleOrDefaultAsync();

           
        }

        public void UpdateWidgetAsync(Widget widget)
        {
            Update(widget);
        }
    }
}

