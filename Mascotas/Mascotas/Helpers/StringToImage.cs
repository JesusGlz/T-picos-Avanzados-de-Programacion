using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Mascotas.Helpers
{
    class StringToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Random random = new Random();
           
            switch (random.Next(0, 7))
            {
                case 1: return ImageSource.FromUri(new Uri("https://images.dog.ceo/breeds/poodle-toy/n02113624_3796.jpg"));
                case 2: return ImageSource.FromUri(new Uri("https://images.dog.ceo/breeds/hound-blood/n02088466_12003.jpg"));
                case 3: return ImageSource.FromUri(new Uri("https://images.dog.ceo/breeds/hound-ibizan/n02091244_595.jpg"));
                case 4: return ImageSource.FromUri(new Uri("https://images.dog.ceo/breeds/bluetick/n02088632_1541.jpg"));
                case 5: return ImageSource.FromUri(new Uri("https://images.dog.ceo/breeds/springer-english/n02102040_113.jpg"));
                case 6: return ImageSource.FromUri(new Uri("https://images.dog.ceo/breeds/weimaraner/n02092339_4271.jpg"));
                case 7: return ImageSource.FromUri(new Uri("https://images.dog.ceo/breeds/setter-gordon/n02101006_922.jpg"));
            }
            return ImageSource.FromUri(new Uri("https://images.dog.ceo/breeds/cotondetulear/IMG_20160830_202631573.jpg"));
            
        }
       

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
