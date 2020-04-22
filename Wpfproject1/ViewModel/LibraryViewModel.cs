using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wpfproject1.Model;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;

namespace Wpfproject1.ViewModel
{
    class LibraryViewModel : ViewModelBase
    {

		private Library library;

		public LibraryViewModel()
		{
			
			lib = new Library();
			model = lib;
			 lib= (Library)LoadMetod();
			model = lib;

			if (lib.Shelves == null)
			{
				lib.Shelves = new ObservableCollection<Shelf>()
			{ new Shelf()
			}; 
			}
			
			


		}
		public Library Library
		{
			get { return library; }
			set { library = value; OnPropertyChanged(); }
		}
	
	}
}
