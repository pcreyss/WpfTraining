using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfEvent
{
    class CustomConverter : IValueConverter
    {
        public object ConvertBack(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
        {
            if (value == null) return Binding.DoNothing;
            switch (value.ToString())
            {
                case "64":
                    return "Registry64";
                case "32":
                    return "Registry32";
                case "Default":
                    return "DefaultValue";

                default:
                    return Binding.DoNothing;
            }
        }

        public object Convert(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "Registry64":
                    return "64";
                case "Registry32":
                    return "32";
                case "DefaultValue":
                    return "Default";

                default:
                    return "Default";
            }
        }


    }
}
