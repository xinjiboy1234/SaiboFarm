using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaiboNiuMa.Converters
{
    public class IconKeyToSymbolConverter : IValueConverter
    {
        static readonly Dictionary<string, Symbol> _symbolMap = [];

        static IconKeyToSymbolConverter()
        {
            var names = Enum.GetValues(typeof(Symbol)).Cast<Symbol>();
            foreach (var name in names)
            {
                _symbolMap.Add(name.ToString(), name);
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var key = value as string;
            if (_symbolMap.TryGetValue(key ?? string.Empty, out var symbol))
                return symbol;

            return Symbol.List;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
