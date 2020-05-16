using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpfproject1.Command;
using Wpfproject1.Model;

namespace Wpfproject1.ViewModel
{

	public class ContentViewModel : ViewModelBase
	{
		private Content content;

		public Content Content
		{
			get
			{
				return content;
			}
			set
			{
				content = value;
				OnPropertyChanged();
			}
		}
		private static ModelBase model;

		public ModelBase Model
		{
			get
			{
				return model;
			}
			set
			{
				model = value;
				OnPropertyChanged();
				UpdateVisibility();
				model.PropertyChanged += Lib_PropertyChanged;
			}
		}
		private LibraryViewModel libraryViewModel;

		public LibraryViewModel LibraryViewModel
		{
			get
			{
				return libraryViewModel;
			}
			set
			{
				libraryViewModel = value;
				OnPropertyChanged();

			}
		}
		private ShelfViewModel shelfViewModel;

		public ShelfViewModel ShelfViewModel
		{
			get
			{
				return shelfViewModel;
			}
			set
			{
				shelfViewModel = value;
				OnPropertyChanged();

			}
		}
		private BookViewModel bookViewModel;

		public BookViewModel BookViewModel
		{
			get
			{
				return bookViewModel;
			}
			set
			{
				bookViewModel = value;
				OnPropertyChanged();

			}
		}
		public ContentViewModel()
		{
			Content = new Content();
			LibraryViewModel = new LibraryViewModel();
			ShelfViewModel = new ShelfViewModel();
			BookViewModel = new BookViewModel();
			LoadMetod();
		}
		public void LoadMetod()
		{
			Content = (Content)StorageManager.Load(Content);
		}

		private void Lib_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			(LibraryViewModel.SaveCommand as RelayCommand).RaiseCanExecuteChanged();
			(ShelfViewModel.SaveCommand as RelayCommand).RaiseCanExecuteChanged();
			(BookViewModel.SaveCommand as RelayCommand).RaiseCanExecuteChanged();
		}

		public void UpdateVisibility()
		{
			LibraryViewModel.IsVisible = Visibility.Collapsed;
			ShelfViewModel.IsVisible = Visibility.Collapsed;
			BookViewModel.IsVisible = Visibility.Collapsed;

			if (model is Library)
			{

				LibraryViewModel.IsVisible = Visibility.Visible;
				LibraryViewModel.Lib = (Library)model;
			}
			else if (model is Shelf)
			{

				ShelfViewModel.IsVisible = Visibility.Visible;
				ShelfViewModel.Shelf = (Shelf)model;

			}
			else if (model is Book)
			{

				BookViewModel.IsVisible = Visibility.Visible;
				BookViewModel.Book = (Book)model;
			}
		}
	}
}
