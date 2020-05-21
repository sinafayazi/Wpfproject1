using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MainTheme.Helper
{
	class Converters : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (targetType != typeof(Color))
				throw new NotImplementedException();
			double val = Int32.Parse((value).ToString())*255/100;
			byte rr = System.Convert.ToByte(val);
			var gg = 255 - val;
			byte bb = 0; 
			Color cc = Color.FromRgb(rr, System.Convert.ToByte(gg) , bb);
			return cc;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
