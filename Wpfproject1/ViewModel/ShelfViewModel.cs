using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wpfproject1.Model;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Wpfproject1.ViewModel
{
    class ShelfViewModel : ViewModelBase
    {
		public ShelfViewModel()
		{
			
			model = lib.Shelves.Last();

			if (lib.Shelves.Last().Books == null)
			{
				lib.Shelves.Last().Books = new ObservableCollection<Book>()
			{ new Book()
			}; 
			}
		}
		private Shelf shelf;

		public Shelf Shelf
		{
			get { return shelf; }
			set { shelf = value; OnPropertyChanged(); }

		}


	}
}
