using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpfproject1.Model
{
    public class Library : ModelBase
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }
        private string tell;
        public string Tell
        {
            get
            {
                return tell;
            }
            set
            {
                tell = value;
                OnPropertyChanged();
            }
        }
        private string website;
        public string Website
        {
            get
            {
                return website;
            }
            set
            {
                website = value;
                OnPropertyChanged();
            }
        }
        private bool hasTable;
        public bool HasTable
        {
            get
            {
                return hasTable;
            }
            set
            {
                hasTable = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Shelf> shelves;
        public ObservableCollection<Shelf> Shelves
        {
            get
            {
                return shelves;
            }
            set
            {
                shelves = value;
                shelves.CollectionChanged += OnCollectionChanged;
            }
        }

    }
}
