using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpfproject1.Model;
namespace Wpfproject1.ViewModel
{
    class BookViewModel : ViewModelBase
    {
		private Model.Book book;

		public Model.Book Book
		{
			get { return book; }
			set { book = value; }
		}

	}
}
