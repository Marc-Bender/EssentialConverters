using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace EssentialConverters
{
    public class CentsToEuroStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (
                    (value is not null)
                 && (value is Int64 cents)
               )
            {
                Int64 euros = cents / 100;
                byte rest = (byte)(cents % 100);
                var de = new CultureInfo("de-DE");
                return string.Format(de, "{0:N0},{1:00}", euros, rest);
            }
            else return "0,00";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str && str != "")
            {
                try
                {
                    Int64 centsValue = 0;
                    Int64.TryParse(str.Replace(",", "").Replace(".", ""), out centsValue);
                    return centsValue;
                }
                catch
                {
                    // may be reached if the value contains some invalid characters eg. the * was pressed on the letter side of the keyboard not the numpad...
                }
            }
            return 0;
        }
    }
}
