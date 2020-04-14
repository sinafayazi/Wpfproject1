using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpfproject1.ViewModel
{
    class ShelfViewModel : ViewModelBase
    {
		private Model.Shelf shelf;

		public Model.Shelf Shelf
		{
			get { return shelf; }
			set { shelf = value; OnPropertyChanged(); }

		}


	}
}
