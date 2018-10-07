using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Nim.UI.Converters
{
    class IntToImagesConverter : IValueConverter
    {
        private static readonly BitmapImage SharedImage;
        static IntToImagesConverter()
        {
            SharedImage = new BitmapImage(new Uri(@"Resources\donut.png", UriKind.Relative));
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int actual)
            {
                var collectionOfImages = new List<Image>();
                for (int i = 0; i < actual; i++)
                {
                    var image = new Image()
                    {
                        Height = 50,
                        Width = 50,
                        Source = SharedImage,
                       Visibility = Visibility.Visible
                    };

                    collectionOfImages.Add(image);
                }
                return collectionOfImages;
            }
            else if (value is string special && !(special is null))
            {
                return special.ToCharArray();
            }

            throw new ArgumentException("value must be an integer");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as List<object>)?.Count ?? 0;
        }
    }
}
