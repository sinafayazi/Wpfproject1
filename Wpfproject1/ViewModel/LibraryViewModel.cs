using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wpfproject1.Model;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Xml.Serialization;
using Wpfproject1.Command;
using System.ComponentModel;
using System.Windows;

namespace Wpfproject1.ViewModel
{
	public class LibraryViewModel : ViewModelBase
	{
		private Visibility isVisible;

		public Visibility IsVisible
		{
			get
			{
				return isVisible;
			}
			set
			{
				isVisible = value;
				OnPropertyChanged();
			}
		}
		private Library lib;
		public Library Lib
		{
			get
			{
				return lib;
			}
			set
			{
				lib = value;
				OnPropertyChanged();
			}
		}
		public LibraryViewModel()
		{
			Lib = new Library();
			LoadMetod();
			SaveCommand = new RelayCommand(SaveAction, CanSave);
			LoadCommand = new RelayCommand(LoadAction, CanLoad);
		}
		private bool CanSave(object parameter)
		{
			return string.IsNullOrEmpty(Lib["Name"]) &&
				string.IsNullOrEmpty(Lib["Address"]) &&
				string.IsNullOrEmpty(Lib["Tell"]) &&
				string.IsNullOrEmpty(Lib["Website"]);
		}
		private void SaveAction(object parameter)
		{
			SaveMethod();
		}
		public void SaveMethod()
		{
			StorageManager.Save(Lib);
			OnPropertyChanged("Libs");
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
			Lib = (Library)StorageManager.Load(Lib);
			Lib.PropertyChanged += Model_PropertyChanged;
		}
		private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			(SaveCommand as RelayCommand).RaiseCanExecuteChanged();
		}
	}
}
