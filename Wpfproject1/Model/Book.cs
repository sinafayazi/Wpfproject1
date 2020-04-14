using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpfproject1.Model
{
	public enum Languages
	{
		English,
		Persian,
		Arabic
	}
	class Book : ModelBase
    {
		
		private string bookName;
		public string BookName
		{
			get { return bookName; }
			set { bookName = value; OnPropertyChanged(); }
		}
		private string author;
		public string Author
		{
			get { return author; }
			set { author = value; OnPropertyChanged(); }
		}
		private string category;
		public string Category
		{
			get { return category; }
			set { category = value; OnPropertyChanged(); }
		}
		private string publisher;
		public string Publisher
		{
			get { return publisher; }
			set { publisher = value; OnPropertyChanged(); }
		}
		private Languages language;
		public Languages Language
		{
			get => language;
			set
			{
				language = value;
				OnPropertyChanged();
			}
		}
		private string genre;
		public string Genre
		{
			get { return genre; }
			set { genre = value; OnPropertyChanged(); }
		}

		
	}
}
