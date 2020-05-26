using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using Wpfproject1.Command;
using Wpfproject1.Model;
namespace Wpfproject1.ViewModel
{
	public class BookViewModel : ViewModelBase
	{
		private Book book;
		public Book Book
		{
			get
			{
				return book;
			}
			set
			{
				book = value;
				OnPropertyChanged();
			}
		}
		public BookViewModel()
		{
			Book = new Book();
			SaveCommand = new RelayCommand(SaveAction, CanSave);
		}
		private bool CanSave(object parameter)
		{
			return string.IsNullOrEmpty(Book["BookName"])
				&& string.IsNullOrEmpty(Book["Author"])
				&& string.IsNullOrEmpty(Book["Category"])
				&& string.IsNullOrEmpty(Book["Genre"])
				&& string.IsNullOrEmpty(Book["Email"])
				&& string.IsNullOrEmpty(Book["Publisher"]);
		}
		private void SaveAction(object parameter)
		{
			SaveMethod();
		}
		public void SaveMethod()
		{
			StorageManager.Save(Book);
			OnPropertyChanged("Libs");
		}
	}
}
