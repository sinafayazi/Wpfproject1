using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpfproject1.Model
{
    public class Shelf : ModelBase
	{
		private int count;
		public int Count
		{
			get { return count; }
			set { count = value; OnPropertyChanged(); }
		}
		private string position;
		public string Position
		{
			get { return position; }
			set { position = value; OnPropertyChanged(); }
		}
		private string level;
		public string Level
		{
			get { return level; }
			set { level = value; OnPropertyChanged(); }
		}
		private int floor;
		public int Floor
		{
			get { return floor; }
			set { floor = value; OnPropertyChanged(); }
		}
		private ObservableCollection<Book> books;

		public ObservableCollection<Book> Books
		{
			get { return books; }
			set
			{
				books = value;
				books.CollectionChanged += OnCollectionChanged;
			}
		}

	}
}

