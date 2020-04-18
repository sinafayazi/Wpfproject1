using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
			 Book = new Book();
		}
		private Book book;

		public Book Book
		{
			get { return book; }
			set { book = value; OnPropertyChanged(); }
		}
		private ObservableCollection<Book> books;

		public ObservableCollection<Book> Books
		{
			get { return books; }
			set { books = value; }
		}

	}
}
