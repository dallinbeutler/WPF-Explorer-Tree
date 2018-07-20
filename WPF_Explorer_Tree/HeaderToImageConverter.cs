using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WPF_Explorer_Tree
{
    #region HeaderToImageConverter

    [ValueConversion(typeof(string), typeof(bool))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

         Uri uri = new Uri("pack://application:,,,/Images/folder.png");
         BitmapImage source = new BitmapImage(uri);

         if (value != null)
         {
            var s = value as string;
            if(s.Length<4)
            //if (s.Contains(@":\"))
            {
               uri = new Uri("pack://application:,,,/Images/diskdrive.png");
               source = new BitmapImage(uri);
               return source;
            }
            else
            {
               if (File.Exists(s))
               {
                  return BitmapTools.ToBitmapSource( System.Drawing.Icon.ExtractAssociatedIcon(s).ToBitmap());
               }
               else
               {
                  return source;
               }
            }
         }

         return source;
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }



   }
      static class BitmapTools
      {

         // at class level;
         [System.Runtime.InteropServices.DllImport("gdi32.dll")]
         public static extern bool DeleteObject(IntPtr hObject);    // https://stackoverflow.com/a/1546121/194717


         /// <summary> 
         /// Converts a <see cref="System.Drawing.Bitmap"/> into a WPF <see cref="BitmapSource"/>. 
         /// </summary> 
         /// <remarks>Uses GDI to do the conversion. Hence the call to the marshalled DeleteObject. 
         /// </remarks> 
         /// <param name="source">The source bitmap.</param> 
         /// <returns>A BitmapSource</returns> 
         public static System.Windows.Media.Imaging.BitmapSource ToBitmapSource(this System.Drawing.Bitmap source)
         {
            var hBitmap = source.GetHbitmap();
            var result = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

            DeleteObject(hBitmap);

            return result;
         }
      }

    #endregion // DoubleToIntegerConverter


}