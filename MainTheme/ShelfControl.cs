using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MainTheme
{
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
			Path tin = (Path)GetTemplateChild("tin");
			tin.Margin = new Thickness()
			{
				Left = 0,
				Right = 0,
				Top = 0,
				Bottom = 0
			};
			X = 0;
			Y = 0;
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			ShelfControlMoveMethod(e);
		}
		private void ShelfControlMoveMethod(MouseEventArgs e)
		{
			Path tin = (Path)GetTemplateChild("tin");
			Border path = (Border)GetTemplateChild("Center");
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				if (tin != null)
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
						tin.Margin = new Thickness()
						{
							Left = posX - actWidth / 2,
							Right = -1*(posX - actWidth / 2),
							Top = posY - actHeight / 2,
							Bottom= -1*(posY - actHeight / 2)
						};
						X = posX >= 5 * actWidth / 9 ||
							posX <= 4 * actWidth / 9 ?
							(posX - actWidth / 2) / R : 0;
						Y = posY >= 5 * actHeight / 9 ||
							posY <= 4 * actHeight / 9 ?
							-1 * (posY - actHeight / 2) / R : 0;
					}
					else
					{
						tin.Margin = new Thickness()
						{
							Left = cos * R,
							Right = -1 * (cos * R),
							Top = sin * R,
							Bottom = -1 * (sin * R)
						};
						X = cos;
						Y = -1 * sin;
					}
				}
			}
			else
			{
				tin.Margin = new Thickness()
				{
					Left = 0,
					Right = 0,
					Top = 0,
					Bottom = 0
				};
				X = 0;
				Y = 0;
			}
		}
	}
}
