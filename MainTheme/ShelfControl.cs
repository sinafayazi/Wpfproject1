using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainTheme
{
	/// <summary>
	/// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
	///
	/// Step 1a) Using this custom control in a XAML file that exists in the current project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:MainTheme"
	///
	///
	/// Step 1b) Using this custom control in a XAML file that exists in a different project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:MainTheme;assembly=MainTheme"
	///
	/// You will also need to add a project reference from the project where the XAML file lives
	/// to this project and Rebuild to avoid compilation errors:
	///
	///     Right click on the target project in the Solution Explorer and
	///     "Add Reference"->"Projects"->[Select this project]
	///
	///
	/// Step 2)
	/// Go ahead and use your control in the XAML file.
	///
	///     <MyNamespace:CustomControl1/>
	///
	/// </summary>
	public class ShelfControl : Control
	{
		public static readonly DependencyProperty HorizontalProperty =
			DependencyProperty.Register(
			"X", typeof(double),
			 typeof(ShelfControl)
		);
		public static readonly DependencyProperty VerticalProperty =
			 DependencyProperty.Register(
			"Y", typeof(double),
			typeof(ShelfControl)
		);


		static ShelfControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ShelfControl), new FrameworkPropertyMetadata(typeof(ShelfControl)));
		}
		public double X
		{
			get
			{
				return (double)GetValue(HorizontalProperty);
			}
			set
			{
				SetValue(HorizontalProperty, value);

			}
		}
		public double Y
		{
			get
			{
				return (double)GetValue(VerticalProperty);
			}
			set
			{
				SetValue(VerticalProperty, value);
			}
		}
		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			ShelfControlMoveMethod(e);
		}
		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{

			Grid thumb = (Grid)GetTemplateChild("dragable");
			thumb.RenderTransform = new TranslateTransform(0, 0);
			X = 0;
			Y = 0;

		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			ShelfControlMoveMethod(e);
		}
		private void ShelfControlMoveMethod(MouseEventArgs e)
		{
			Grid thumb = (Grid)GetTemplateChild("dragable");
			Viewbox tin = (Viewbox)GetTemplateChild("tin");
			Ellipse path = (Ellipse)GetTemplateChild("Center");
			TextBox ix = (TextBox)GetTemplateChild("X");
			TextBox vay = (TextBox)GetTemplateChild("Y");
			//ix.Text = X.ToString(); // e.GetPosition(path).X.ToString();
			//vay.Text = Y.ToString(); //(e.GetPosition(path).Y).ToString();

			if (e.LeftButton == MouseButtonState.Pressed)
			{


				if (thumb != null)
				{

					Point mousePoint = e.GetPosition(path);

					double posY = mousePoint.Y;
					double actHeight = path.ActualHeight;
					double posX = mousePoint.X;
					double actWidth = path.ActualWidth;
					double R = (actHeight / 2) - tin.ActualWidth / 2;
					double distance = Math.Sqrt(Math.Pow(posX - (actHeight / 2), 2) + Math.Pow(posY - (actWidth / 2), 2));
					double sin = (posY - actHeight / 2) / distance;
					double cos = (posX - actWidth / 2) / distance;
					if (Math.Sqrt(Math.Pow(posX - (actHeight / 2), 2) + Math.Pow(posY - (actWidth / 2), 2)) <= R)
					{
						thumb.RenderTransform = new TranslateTransform(posX - actWidth / 2, posY - actHeight / 2);
						X = posX >= 5 * actWidth / 9 ||
							posX <= 4 * actWidth / 9 ?
							(posX - actWidth / 2) / R : 0;
						Y = posY >= 5 * actHeight / 9 ||
							posY <= 4 * actHeight / 9 ?
							-1 * (posY - actHeight / 2) / R : 0;
					}
					else
					{
						thumb.RenderTransform = new TranslateTransform(cos * R, sin * R);
						X = cos;
						Y = -1 * sin;
					}
				}
			}
			else
			{
				thumb.RenderTransform = new TranslateTransform(0, 0);
				X = 0;
				Y = 0;
			}

		}
	}

}
