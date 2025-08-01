using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saibo.ViewModel;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<MenuBaseViewModel> menus = [];

    [ObservableProperty]
    private ObservableCollection<MenuBaseViewModel> tabs = [];

    [ObservableProperty]
    private MenuBaseViewModel selectedItem = new();

    partial void OnSelectedItemChanged(MenuBaseViewModel? oldValue, MenuBaseViewModel newValue)
    {
        if (newValue is MenuViewModel m)
        {
            if (Tabs.Any(t => ((MenuViewModel)t).Name == m.Name))
            {
                // 如果已经存在该标签页，则不添加
                return;
            }
            Tabs.Add(newValue);
            Debug.WriteLine(((MenuViewModel)newValue).Name);
        }
    }

    [RelayCommand]
    private void RemoveTab(MenuBaseViewModel tab)
    {
        if (tab != null && Tabs.Contains(tab))
        {
            Tabs.Remove(tab);
        }
    }

}

public class MenuBaseViewModel { }

public class MenuViewModel : MenuBaseViewModel
{
    public string Name { get; set; }
    public string Tooltip { get; set; }
    public string Glyph { get; set; }
    public string PageName { get; set; }
    public Type PageType { get; set; }
}

public class SeparatorViewModel : MenuBaseViewModel { }

public class HeaderViewModel : MenuBaseViewModel
{
    public string Name { get; set; }
}
