using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Markup;


namespace vierOpeenRij.libb
{
    public class IntToImageSourceConverter
    {
      public static string imagePathYellow = "Images/Geel.png",
                  imagePathRed = "Images/Rood.png",
                imagePathEmpty = "Images/Empty.png";

       public static ImageSource Convert(int value)
        {
            switch (value)
            {
                case 1:
                    return SetImage(imagePathYellow);
                case 2:
                    return SetImage(imagePathRed);
                case 0:
                default:
                    return SetImage(imagePathEmpty);
            }
        }

        //public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //{
        //    return 1;
        //}

        public static BitmapImage SetImage(string relativePath)   //nog private zetten
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri("pack://siteoforigin:,,,/" + relativePath, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            return bitmapImage;
        }
    }
}
