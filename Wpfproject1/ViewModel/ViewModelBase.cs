using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using Wpfproject1.Command;
using Wpfproject1.Model;
namespace Wpfproject1.ViewModel
{
    public class ViewModelBase : ModelBase
    {
        public ICommand SaveCommand
        {
            get;
            set;
        }
        public ICommand LoadCommand
        {
            get;
            set;
        }
        private Library lib = new Library();
        public Library Lib
        {
            get
            {
                return lib;
            }
            set
            {
                lib = value;
                OnPropertyChanged();
            }
        }
        public static Library LibTemp = new Library();
        private Shelf shelf;
        public Shelf Shelf
        {
            get
            {
                return shelf;
            }
            set
            {
                shelf = value;
                OnPropertyChanged();
            }

        }
        public static Shelf ShelfTemp = new Shelf();
        private Book book;
        public Book Book
        {
            get
            {
                return book;
            }
            set
            {
                book = value;
                OnPropertyChanged();
            }
        }
        public static Book BookTemp = new Book();

        public ViewModelBase()
        {
        }
        public ModelBase FirstLoadMetod()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "xml (*.xml)|*.xml"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Library));
                    FileStream reader = new FileStream(openFileDialog.FileName, FileMode.Open);
                    Lib = (Library)serializer.Deserialize(reader);
                    LibTemp = (Library)Lib.Clone();
                    reader.Close();
                    reader.Dispose();
                }
                finally
                {
                }
            }
            else
            {
                LibTemp.Shelves = new ObservableCollection<Shelf>()
            { new Shelf()
            };
                LibTemp.Shelves.Last().Books = new ObservableCollection<Book>()
            { new Book()
            };
            }
            if (LibTemp.Shelves.Count == 0)
            {
                LibTemp.Shelves = new ObservableCollection<Shelf>()
            { new Shelf()
            };
            }
            if (LibTemp.Shelves.Last().Books == null)
            {
                LibTemp.Shelves.Last().Books = new ObservableCollection<Book>()
            { new Book()
            };
            }

            ShelfTemp = (Shelf)LibTemp.Shelves.Last();
            BookTemp = (Book)LibTemp.Shelves.Last().Books.Last();
            
            return LibTemp;
        }

     
    }
}
