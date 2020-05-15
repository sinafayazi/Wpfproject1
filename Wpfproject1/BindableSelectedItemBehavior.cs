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
    public class BindableSelectedItemBehavior 
    {

        public static object GetTreeViewSelectedItem(DependencyObject obj)
        {
            return (object)obj.GetValue(TreeViewSelectedItemProperty);
        }

        public static void SetTreeViewSelectedItem(DependencyObject obj, object value)
        {
            obj.SetValue(TreeViewSelectedItemProperty, value);
        }

        public static readonly DependencyProperty TreeViewSelectedItemProperty =
            DependencyProperty.RegisterAttached("TreeViewSelectedItem", typeof(object), typeof(BindableSelectedItemBehavior), new PropertyMetadata(new object(), TreeViewSelectedItemChanged));

        public static void TreeViewSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TreeView treeView = sender as TreeView;
            if (treeView == null)
            {
                return;
            }

            treeView.SelectedItemChanged -= new RoutedPropertyChangedEventHandler<object>(treeView_SelectedItemChanged);
            treeView.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(treeView_SelectedItemChanged);

            TreeViewItem thisItem = treeView.ItemContainerGenerator.ContainerFromItem(e.NewValue) as TreeViewItem;
            if (thisItem != null)
            {
                thisItem.IsSelected = true;
                return;
            }

            for (int i = 0; i < treeView.Items.Count; i++)
                SelectItem(e.NewValue, treeView.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem);

        }

        static void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView treeView = sender as TreeView;
            SetTreeViewSelectedItem(treeView, e.NewValue);
        }

        private static bool SelectItem(object o, TreeViewItem parentItem)
        {
            if (parentItem == null)
                return false;

            bool isExpanded = parentItem.IsExpanded;
            if (!isExpanded)
            {
                parentItem.IsExpanded = true;
                parentItem.UpdateLayout();
            }

            TreeViewItem item = parentItem.ItemContainerGenerator.ContainerFromItem(o) as TreeViewItem;
            if (item != null)
            {
                item.IsSelected = true;
                return true;
            }

            bool wasFound = false;
            for (int i = 0; i < parentItem.Items.Count; i++)
            {
                
                    TreeViewItem itm = parentItem.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;
               
                var found = SelectItem(o, itm);
                if (itm != null)
                {
                    if (!found)
                        itm.IsExpanded = false;
                    else
                        wasFound = true; 
                }
            }

            return wasFound;
        }
        //#region SelectedItem Property


        //public object SelectedItem
        //{
        //    get { return (object)GetValue(SelectedItemProperty); }
        //    set { SetValue(SelectedItemProperty, value); }
        //}

        //public static readonly DependencyProperty SelectedItemProperty =
        //    DependencyProperty.Register("SelectedItem", typeof(object), typeof(BindableSelectedItemBehavior), new UIPropertyMetadata(null, OnSelectedItemChanged));

        //private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        //{
        //    var behavior = sender as BindableSelectedItemBehavior;
        //    if (behavior == null) return;
        //    var tree = behavior.AssociatedObject;
        //    if (tree == null) return;
        //    if (e.NewValue == null)
        //        foreach (var item in tree.Items.OfType<TreeViewItem>())
        //            item.SetValue(TreeViewItem.IsSelectedProperty, false);
        //    var treeViewItem = e.NewValue as TreeViewItem;
        //    if (treeViewItem != null)
        //        treeViewItem.SetValue(TreeViewItem.IsSelectedProperty, true);
        //    else
        //    {
        //        var itemsHostProperty = tree.GetType().GetProperty("ItemsHost", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        //        if (itemsHostProperty == null) return;
        //        var itemsHost = itemsHostProperty.GetValue(tree, null) as Panel;
        //        if (itemsHost == null) return;
        //        foreach (var item in itemsHost.Children.OfType<TreeViewItem>())
        //        {
        //            if (WalkTreeViewItem(item, e.NewValue))
        //                break;
        //        }
        //    }
        //}

        //public static bool WalkTreeViewItem(TreeViewItem treeViewItem, object selectedValue)
        //{
        //    if (treeViewItem.DataContext == selectedValue)
        //    {
        //        treeViewItem.SetValue(TreeViewItem.IsSelectedProperty, true);
        //        treeViewItem.Focus();
        //        return true;
        //    }
        //    var itemsHostProperty = treeViewItem.GetType().GetProperty("ItemsHost", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        //    if (itemsHostProperty == null) return false;
        //    var itemsHost = itemsHostProperty.GetValue(treeViewItem, null) as Panel;
        //    if (itemsHost == null) return false;
        //    foreach (var item in itemsHost.Children.OfType<TreeViewItem>())
        //    {
        //        if (WalkTreeViewItem(item, selectedValue))
        //            break;
        //    }
        //    return false;
        //}
        //#endregion

        //protected override void OnAttached()
        //{
        //    base.OnAttached();
        //    this.AssociatedObject.SelectedItemChanged += OnTreeViewSelectedItemChanged;
        //}

        //protected override void OnDetaching()
        //{
        //    base.OnDetaching();
        //    if (this.AssociatedObject != null)
        //    {
        //        this.AssociatedObject.SelectedItemChanged -= OnTreeViewSelectedItemChanged;
        //    }
        //}

        //private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        //{
        //    this.SelectedItem = e.NewValue;
        //}

    }
}
