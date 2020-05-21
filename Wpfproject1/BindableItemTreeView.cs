using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Navigation;

namespace Wpfproject1
{
	public class BindableItemTreeView : TreeView
	{
		public static void SetTreeViewSelectedItem(DependencyObject obj, object value)
		{
			obj.SetValue(TreeViewSelectedItemProperty, value);
		}
		public static readonly DependencyProperty TreeViewSelectedItemProperty =
			DependencyProperty.Register("TreeViewSelectedItem", typeof(object), typeof(BindableItemTreeView), new PropertyMetadata(new object(), TreeViewSelectedItemChanged));
		public static void TreeViewSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
				(sender as TreeView).SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(TreeViewItemChange);
		}
		static void TreeViewItemChange(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			SetTreeViewSelectedItem(sender as TreeView, e.NewValue);
		}
	}
}
