using System;
using HighSchool.Entities.Models;

namespace HighSchool.Contracts
{
    public interface IWidgetRepository
    {
        Task<Widget> GetWidgetAsync( bool trackChanges);
        void CreateWidgetAsync(Widget widget);
        
        void UpdateWidgetAsync(Widget widget);
    }
}

