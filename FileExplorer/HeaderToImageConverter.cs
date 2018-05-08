using FileExplorer.FileSystem.Data;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace FileExplorer
{
    [ValueConversion(typeof(DataItem), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = "Images/Light/appbar.server.png";

            switch ((DataType)value)
            {
                case DataType.Drive:
                    image = "Images/Light/appbar.server.png";
                    break;
                case DataType.Folder:
                    image = "Images/Light/appbar.folder.png";
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
