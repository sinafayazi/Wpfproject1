using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wpfproject1.Model
{
	public class Library : ModelBase, IDataErrorInfo
	{
		public int Index
		{
			get;
			set;
		}

		private string name;
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
				OnPropertyChanged();
			}
		}
		private string address;
		public string Address
		{
			get
			{
				return address;
			}
			set
			{
				address = value;
				OnPropertyChanged();
			}
		}
		private string tell;
		public string Tell
		{
			get
			{
				return tell;
			}
			set
			{
				tell = value;
				OnPropertyChanged();
			}
		}
		private string website;
		public string Website
		{
			get
			{
				return website;
			}
			set
			{
				website = value;
				OnPropertyChanged();
			}
		}
		private bool hasTable;
		public bool HasTable
		{
			get
			{
				return hasTable;
			}
			set
			{
				hasTable = value;
				OnPropertyChanged();
			}
		}
		private ObservableCollection<Shelf> shelves;
		public ObservableCollection<Shelf> Shelves
		{
			get
			{
				return shelves;
			}
			set
			{
				shelves = value;
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

					case "Name":
						if (string.IsNullOrWhiteSpace(Name))
						{
							result = "Name is required";
						}
						else if (!Regex.IsMatch(Name, "^[a-zA-Z]+$"))
						{
							result = "Name must contain just alphabets";
						}
						break;
					case "Address":
						if (string.IsNullOrWhiteSpace(Address))
						{
							result = "Address is required";
						}
						else if (!Regex.IsMatch(Address, "^[a-zA-Z]+$"))
						{
							result = "Address must contain just alphabets";
						}
						break;
					case "Tell":
						if (string.IsNullOrWhiteSpace(Tell))
						{
							result = "Tell is required";
						}
						else if (!Regex.IsMatch(Tell, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"))
						{
							result = "Tell is invalid ex: (2177234567)";
						}
						break;
					case "Website":

						if (string.IsNullOrWhiteSpace(Website))
						{
							result = "Website is required";
						}
						else if (!Regex.IsMatch(Website, @"^(http|http(s)?://)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?"))
						{
							result = "Website is invalid";
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
