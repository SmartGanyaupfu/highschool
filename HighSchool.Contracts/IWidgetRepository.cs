using System;
using HighSchool.Entities.Models;

namespace HighSchool.Contracts
{
    public interface IWidgetRepository
    {
        Task<Widget> GetWidgetAsync( bool trackChanges);
        void CreateWidgetAsync(Widget widget);
        Task<Widget> GetWidgetByIdAsync(int widgetId,bool trackChanges);
        void UpdateWidgetAsync(Widget widget);
    }
}

