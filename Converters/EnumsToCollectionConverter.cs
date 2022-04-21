using System;
using System.Linq;
using System.Windows.Markup;

namespace EmployeeDirectory_WPF.Converters
{
    public class EnumsToCollectionConverter : MarkupExtension
    {
        private Type EnumType { get; set; }
        public EnumsToCollectionConverter(Type type)
        {
            EnumType = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetNames(EnumType).ToList();
        }
    }
}
