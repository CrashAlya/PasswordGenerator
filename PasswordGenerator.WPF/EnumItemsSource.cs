using System;
using System.Windows.Markup;

namespace PasswordGenerator.WPF {
    public class EnumItemsSource : MarkupExtension {
        public EnumItemsSource(Type type) {
            this.type = type;
        }

        readonly Type type;

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return Enum.GetValues(type);
        }
    }
}