using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Nim.UI.Converters
{
    class IntToImagesConverter : IValueConverter
    {
        private static readonly BitmapImage SharedImage;
        static IntToImagesConverter()
        {
            Uri uri = new Uri(Path.Combine(Environment.CurrentDirectory, "Resources", "doughnut.jpg"), UriKind.Absolute);
            SharedImage = new BitmapImage(uri);

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int actual)
            {
                var collectionOfImages = new List<UIElement>();
                for (int i = 0; i < actual; i++)
                {
                    var image = new Image()
                    {
                        Source = SharedImage,
                        Width = 50,
                        Height = 50
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
