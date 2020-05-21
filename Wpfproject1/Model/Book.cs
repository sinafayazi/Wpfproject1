using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wpfproject1.Model
{
	public enum Languages
	{
		English,
		Persian,
		Arabic
	}
	public class Book : ModelBase, IDataErrorInfo
	{
		public int Index
		{
			get;
			set;
		}
		public int ParentIndex
		{
			get;
			set;
		}
		public int LibIndex
		{
			get;
			set;
		}
		private string bookName;
		public string BookName
		{
			get
			{
				return bookName;
			}
			set
			{
				bookName = value;
				OnPropertyChanged();
			}
		}
		private string author;
		public string Author
		{
			get
			{
				return author;
			}
			set
			{
				author = value;
				OnPropertyChanged();
			}
		}
		private string category;
		public string Category
		{
			get
			{
				return category;
			}
			set
			{
				category = value;
				OnPropertyChanged();
			}
		}
		private string publisher;
		public string Publisher
		{
			get
			{
				return publisher;
			}
			set
			{
				publisher = value;
				OnPropertyChanged();
			}
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
			get
			{
				return genre;
			}
			set
			{
				genre = value;
				OnPropertyChanged();
			}
		}
		private string email;
		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
				OnPropertyChanged();
			}
		}
		
		public string Error
		{
			get
			{
				return null;
			}
		}
		public string this[string PropertyName]
		{
			get
			{
				string result = string.Empty;
				switch (PropertyName)
				{
					case "BookName":
						if (string.IsNullOrWhiteSpace(BookName))
						{
							result = "BookName is required";
						}
						else if (!Regex.IsMatch(BookName, "^[a-zA-Z]+$"))
						{
							result = "BookName must contain just alphabets";
						}
						break;
					case "Author":
						if (string.IsNullOrWhiteSpace(Author))
						{
							result = "Author is required";
						}
						else if (!Regex.IsMatch(Author, "^[a-zA-Z]+$"))
						{
							result = "Author must contain just alphabets";
						}
						break;
					case "Category":
						if (string.IsNullOrWhiteSpace(Category))
						{
							result = "Category is required";
						}
						else if (!Regex.IsMatch(Category, "^[a-zA-Z]+$"))
						{
							result = "Category must contain just alphabets";
						}
						break;
					case "Genre":
						if (string.IsNullOrWhiteSpace(Genre))
						{
							result = "Genre is required";
						}
						else if (!Regex.IsMatch(Genre, "^[a-zA-Z]+$"))
						{
							result = "Genre must contain just alphabets";
						}
						break;
					case "Email":
						if (string.IsNullOrWhiteSpace(Email))
						{
							result = "Email is required";
						}
						else if (!Regex.IsMatch(Email,
							@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
						{
							result = "Email is not valid";
						}
						break;
					case "Publisher":
						if (string.IsNullOrWhiteSpace(Publisher))
						{
							result = "Publisher is required";
						}
						else if (!Regex.IsMatch(Publisher, "^[a-zA-Z]+$"))
						{
							result = "Publisher must contain just alphabets";
						}
						break;
					default:
						break;
				}
				return result;
			}
		}
	}
}
