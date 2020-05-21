using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
				UpdateCommands();
				model.PropertyChanged += Model_PropertyChanged;
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
		
			
		
			LoadMetod();
			LoadCommand = new RelayCommand(LoadAction, CanLoad);

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
			if (Model is Library)
			{
				Model = (Library)StorageManager.Load(Model);
			}
			else if (Model is Shelf)
			{
				Model = (Shelf)StorageManager.Load(Model);
			}
			else if (Model is Book)
			{
				Model = (Book)StorageManager.Load(Model);
			}
			else
			{
				Content = (Content)StorageManager.Load(Content);
			}
			
		}

		private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (Model is Library)
			{
				LibraryViewModel.Lib = (Library)Model;
			}
			else if (Model is Shelf)
			{
				ShelfViewModel.Shelf = (Shelf)Model;

			}
			else if (Model is Book)
			{
				BookViewModel.Book = (Book)Model;
			}
			(SaveCommand as RelayCommand).RaiseCanExecuteChanged();

		}

		public void UpdateCommands()
		{

			if (Model is Library)
			{
				LibraryViewModel = new LibraryViewModel
				{
					Lib = (Library)Model
				};
				SaveCommand = LibraryViewModel.SaveCommand;
				
			}
			else if (Model is Shelf)
			{
				ShelfViewModel = new ShelfViewModel
				{
					Shelf = (Shelf)Model
				};
				SaveCommand = ShelfViewModel.SaveCommand;

			}
			else if (Model is Book)
			{
				BookViewModel = new BookViewModel
				{
					Book = (Book)Model
				};
				SaveCommand = BookViewModel.SaveCommand;
			}
		}
	}
}
