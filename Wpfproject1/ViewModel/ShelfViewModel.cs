using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wpfproject1.Model;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;
using Wpfproject1.Command;
using System.ComponentModel;

namespace Wpfproject1.ViewModel
{
    public class ShelfViewModel : ViewModelBase
    {
        private Shelf shelf;
        public Shelf Shelf
        {
            get
            {
                return shelf;
            }
            set
            {
                shelf = value;
                OnPropertyChanged();
            }

        }
        public ShelfViewModel()
        {
            Shelf = new Shelf();
            LoadMetod();
            SaveCommand = new RelayCommand(SaveAction, CanSave);
            LoadCommand = new RelayCommand(LoadAction, CanLoad);
        }
        private bool CanSave(object parameter)
        {
            return string.IsNullOrEmpty(Shelf["Count"])
                && string.IsNullOrEmpty(Shelf["Level"])
                && string.IsNullOrEmpty(Shelf["Position"])
                && string.IsNullOrEmpty(Shelf["Floor"]);
        }
        private void SaveAction(object parameter)
        {
            SaveMethod();
        }
        public void SaveMethod()
        {
            StorageManager.Save(Shelf);
        }
        private bool CanLoad(object parameter)
        {
            return true;
        }
        private void LoadAction(object parameter)
        {
            LoadMetod();
        }
        public void LoadMetod()
        {
            Shelf = (Shelf)StorageManager.Load(typeof(Shelf));
            Shelf.PropertyChanged += Model_PropertyChanged;
        }
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            (SaveCommand as RelayCommand).RaiseCanExecuteChanged();
        }

    }
}
