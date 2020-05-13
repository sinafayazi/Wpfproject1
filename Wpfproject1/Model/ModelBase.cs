using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpfproject1.Model
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        protected void OnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged();
        }
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
        //    #region ctor

        //    public ModelBase()
        //    {
        //        IsSelected = false;
        //        _children = new ObservableCollection<ModelBase<T>>();
        //    }

        //    #endregion ctor

        //    #region fields

        //    private ModelBase<T> _parent;
        //    protected ObservableCollection<ModelBase<T>> _children;
        //    private bool _isSelected;

        //    #endregion fields

        //    #region properties

        //    public ModelBase<T> Parent
        //    {
        //        get { return _parent; }
        //        set
        //        {
        //            _parent = value;
        //            OnPropertyChanged("Parent");
        //        }
        //    }

        //    public IEnumerable<ModelBase<T>> Children
        //    {
        //        get { return _children; }
        //    }
        //    public bool IsSelected
        //    {
        //        get { return _isSelected; }
        //        set
        //        {
        //            _isSelected = value;
        //            OnPropertyChanged("IsSelected");
        //        }
        //    }

        //    #endregion properties

        //    #region static methods



        //    //public static ModelBase<T> GetSelectedNode(IEnumerable<ModelBase<T>> nodes)
        //    //{
        //    //    foreach (var node in nodes)
        //    //    {
        //    //        if (node.IsSelected)
        //    //            return node;

        //    //        var selectedChild = GetSelectedNode(node.Children);
        //    //        if (selectedChild != null)
        //    //            return selectedChild;
        //    //    }

        //    //    return null;
        //    //}


        //    #endregion static methods


        //}

        //public class ModelBase : ModelBase<Guid>
        //{
        //}
    }
}
