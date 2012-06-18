using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using MetroPricingSample.Models;

namespace MetroPricingSample.Converters
{
    public class StatusToIconConverter : IValueConverter
    {
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
		    string uri;
		    BitmapImage image;

            try
            {
                string file;

                switch ((Status) value)
                {
                    case Status.Decrease:
                        file = "DOWN";
                        break;
                    
                    case Status.Increase:
                        file = "UP";
                        break;
                    
                    case Status.NoChange:
                        file = "LEVEL";
                        break;
                    
                    default:
                        file = "UNK";
                        break;
                }
                uri = string.Format("../Assets/Images/{0}.png", file);
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