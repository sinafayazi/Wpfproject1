using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpfproject1.ViewModel
{
    class LibraryViewModel : ViewModelBase
    {
		private Model.Library library;

		public Model.Library Library
		{
			get { return library; }
			set { library = value; OnPropertyChanged(); }
		}

	}
}
