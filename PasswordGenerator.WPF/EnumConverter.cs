using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace PasswordGenerator.WPF {
    public class EnumConverter : MarkupExtension, IValueConverter {
        public Type Type { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if(Type == null) {
                throw new ArgumentNullException(nameof(Type));
            }
            if(value == null) {
                return null;
            }
            if(value.GetType() != Type) {
                throw new ArgumentException();
            }
            return value.ToString();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if(Type == null) {
                throw new ArgumentNullException(nameof(Type));
            }
            if(value == null) {
                return null;
            }
            return Enum.Parse(Type, value.ToString());
        }
    }
}