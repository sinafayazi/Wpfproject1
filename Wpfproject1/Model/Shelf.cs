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
    public class Shelf : ModelBase, IDataErrorInfo
    {
        private int count;
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                OnPropertyChanged();
            }
        }
        private string position;
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                OnPropertyChanged();
            }
        }
        private int level;
        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                OnPropertyChanged();
            }
        }
        private int floor;
        public int Floor
        {
            get
            {
                return floor;
            }
            set
            {
                floor = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Book> books;
        public ObservableCollection<Book> Books
        {
            get
            {
                return books;
            }
            set
            {
                books = value;
                books.CollectionChanged += OnCollectionChanged;
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
                    case "Count":
                        if (Count<0 || Count>100)
                        {
                            result = "Book Count is out of expected range (0,100)";
                        }
                        break;
                    case "Level":
                        if (Level < 0 || Level > 100)
                        {
                            result = "Level is out of expected range (0,100)";
                        }
                        break;
                    case "Position":
                        if (string.IsNullOrWhiteSpace(Position) )
                        {
                            result = "Position is required ";
                        }
                        else if (!Regex.IsMatch(Position, "^[a-zA-Z]+$"))
                        {
                            result = "Position must contain just alphabets";
                        }

                        break;
                    case "Floor":
                        if (Floor < 0 || Floor > 100)
                        {
                            result = "Floor is out of expected range (0,100)";

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

