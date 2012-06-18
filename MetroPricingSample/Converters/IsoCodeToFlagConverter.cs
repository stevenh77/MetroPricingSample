using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MetroPricingSample.Converters
{
    public class IsoCodeToFlagConverter : IValueConverter
    {
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
		    string uri;
		    BitmapImage image;
            try
            {
                uri = string.Format("../Assets/Images/{0}.png", value);
                image = new BitmapImage(new Uri(uri, UriKind.Relative));
            }
            catch
            {
                uri = string.Format("../Assets/Images/{0}.png", "UNK");
                image = new BitmapImage(new Uri(uri, UriKind.Relative));
            }

            return image;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
