using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SaiboNiuMa.UI.MarkupInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SaiboNiuMa.UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpdateMindExpressPage : Page, IMarkUpMenu
    {
        public ObservableCollection<string> ColumnHeaders { get; } = new() { "Name", "Age", "Country" };
        public ObservableCollection<Person> Data { get; } = new();
        public UpdateMindExpressPage()
        {
            InitializeComponent();
            // 预填数据（也可以在构造前初始化，但确保类型正确）
            Data.Add(new Person { Name = "Alice", Age = 25, Country = "USA" });
            Data.Add(new Person { Name = "Bob", Age = 30, Country = "UK" });
            Data.Add(new Person { Name = "Charlie", Age = 28, Country = "Canada" });
        }
    }

    public class Person
    {
        public bool IsSelected { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    }
}
