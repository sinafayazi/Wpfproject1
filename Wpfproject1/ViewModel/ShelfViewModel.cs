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
using System.Windows;

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
			SaveCommand = new RelayCommand(SaveAction, CanSave);
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
			OnPropertyChanged("Libs");
		}
	}
}
