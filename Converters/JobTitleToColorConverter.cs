using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace EmployeeDirectory_WPF.Converters
{
    public class JobTitleToColorConverter : MarkupExtension, IValueConverter
    {
        public static Random random = new Random();
        public static Dictionary<string, SolidColorBrush> colors = new Dictionary<string, SolidColorBrush>();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            KeyValuePair<string,SolidColorBrush> job = colors.FirstOrDefault(clrs => clrs.Key.Contains(value.ToString(), StringComparison.CurrentCultureIgnoreCase));
            if(job.Key==null)
            {
                colors.Add(value.ToString(),new SolidColorBrush(Color.FromRgb((byte)random.Next(1,255),(byte)random.Next(1,255),(byte)random.Next(1,255))));
            }
            return colors[value.ToString()];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
