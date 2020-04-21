﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wpfproject1.Model;
using System.Threading.Tasks;
using System.IO;

namespace Wpfproject1.ViewModel
{
    class LibraryViewModel : ViewModelBase
    {

		private Library library;

		public LibraryViewModel()
		{
			model = new Library();
			
		}
		public Library Library
		{
			get { return library; }
			set { library = value; OnPropertyChanged(); }
		}
	
	}
}
