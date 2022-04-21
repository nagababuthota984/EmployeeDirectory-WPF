﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace EmployeeDirectory_WPF.Converters
{
    public class SalaryRangeConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (decimal.TryParse(value.ToString(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var range))
                {
                    if (range < 20000)
                        return "below20000";
                    else if (range < 40000)
                        return "below40000";
                    else if (range > 40000)
                        return "above40000";
                }
            }
            return null;
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
