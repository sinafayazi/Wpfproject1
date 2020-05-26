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
			SaveCommand = new RelayCommand(SaveAction, CanSave);
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
	}
}
