using Saibo.DataService.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saibo.DataService.Services
{
    public class MenuService
    {
        public async Task<List<Menu>> GetMenusAsync()
        {
            var menuList = new List<Menu>();
            Menu firstCategory = new Menu { Name = "Home", Glyph = "Home", Tooltip = "This is category 1", PageName = "HomePage" };
            menuList.Add(firstCategory);
            menuList.Add(new Menu { Name = "Category 2", Glyph = "Keyboard", Tooltip = "This is category 2", PageName = "SendBotMessagePage" });
            menuList.Add(new Menu { Name = "Category 3", Glyph = "Library", Tooltip = "This is category 3", PageName = "HomePage" });
            menuList.Add(new Menu { Name = "Category 4", Glyph = "Mail", Tooltip = "This is category 4", PageName = "SendBotMessagePage" });

            await Task.CompletedTask;

            return menuList;
        }
    }
}
