using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpfproject1.Model;
namespace Wpfproject1.ViewModel
{
    public class BookViewModel : ViewModelBase
    {
		public BookViewModel()
		{
			
			model = lib.Shelves.Last().Books.Last();


		}
		private Book book;

		public Book Book
		{
			get { return book; }
			set { book = value; OnPropertyChanged(); }
		}
		

	}
}
