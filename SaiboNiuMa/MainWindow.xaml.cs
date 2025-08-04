using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Saibo.DataService.Services;
using Saibo.ViewModel;
using SaiboNiuMa.Caches;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SaiboNiuMa
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private MainWindowViewModel MainWindowViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            SetTitleBar(titleBar);
            BindMenu();
        }

        private void BindMenu()
        {
            var menuService = new MenuService();
            var menu = menuService.GetMenusAsync().GetAwaiter().GetResult();
            if (menu?.Count > 0)
            {
                var temp = new MainWindowViewModel();
                foreach (var m in menu)
                {
                    if (!MenuCache.MenuMap.TryGetValue(m.PageName, out var pt))
                    {
                        continue;
                    }

                    var menuViewModel = new MenuViewModel
                    {
                        Name = m.Name,
                        Glyph = m.Glyph,
                        Tooltip = m.Tooltip,
                        PageName = m.PageName,
                        PageType = Type.GetType(pt)
                    };
                    temp.Menus.Add(menuViewModel);
                }

                var firstCategory = temp.Menus.First();
                MainWindowViewModel = temp;
                MainWindowViewModel.SelectedItem = firstCategory;
            }
        }

        private void OnPaneDisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args)
        {
            if (sender.PaneDisplayMode == NavigationViewPaneDisplayMode.Top)
            {
                titleBar.IsPaneToggleButtonVisible = false;
            }
            else
            {
                titleBar.IsPaneToggleButtonVisible = true;
            }
        }

        private void TabView_TabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            //sender.TabItems.Remove(args.Tab);
            if (args.Item is MenuViewModel tab)
            {
                MainWindowViewModel.RemoveTabCommand.Execute(tab);
            }
        }

        private void TabView_BringIntoViewRequested(UIElement sender, BringIntoViewRequestedEventArgs args)
        {
            // The TabView control is firing this event when TabWidthMode is set to `SizeToContent` or `Compact`.
            // This will work around an auto-scroll issue when the page is loaded.
            args.Handled = true;
        }
    }
}
