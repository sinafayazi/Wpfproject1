using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wpfproject1.Model;
using System.Threading.Tasks;

namespace Wpfproject1.ViewModel
{
    class ShelfViewModel : ViewModelBase
    {
		private Shelf shelf;

		public Shelf Shelf
		{
			get { return shelf; }
			set { shelf = value; OnPropertyChanged(); }

		}


	}
}
