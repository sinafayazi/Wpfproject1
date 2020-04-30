using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Wpfproject1.Model;
using Wpfproject1.ViewModel;

namespace Wpfproject1
{
    public class StorageManager : ViewModelBase
    {
        static bool IsFirst = true;
        public static string FliePath;
        public static void Save(object instance)
        {
            Library LibTemp = new Library();
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "xml (*.xml)|*.xml"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Library));

                LibTemp = (Library)Load(typeof(Library));
                if (LibTemp.Shelves == null)
                {
                    LibTemp.Shelves = new ObservableCollection<Shelf>()
                        { new Shelf()};
                }
                if (LibTemp.Shelves.Last().Books == null)
                {
                    LibTemp.Shelves.Last().Books = new ObservableCollection<Book>()
                        { new Book() };
                }
                if (instance is Book)
                {

                    LibTemp.Shelves.Last().Books.Add((Book)instance);
                }
                else if (instance is Shelf)
                {
                    LibTemp.Shelves.Add((Shelf)instance);
                }
                else
                {
                    LibTemp = (Library)instance;
                }
                StreamWriter Writer = new StreamWriter(saveFileDialog.FileName);
                serializer.Serialize(Writer, LibTemp);
                Writer.Close();
                Writer.Dispose();
            }
        }
        public static object Load(Type type)
        {
            Library LibTemp = new Library();
            Book BookTemp = new Book();
            Shelf ShelfTemp = new Shelf();
            if (IsFirst == true)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "xml (*.xml)|*.xml"
                };
                if (openFileDialog.ShowDialog() == true)
                {
                    FliePath = openFileDialog.FileName;
                    XmlSerializer serializer = new XmlSerializer(typeof(Library));
                    FileStream reader = new FileStream(FliePath, FileMode.Open);
                    LibTemp = (Library)serializer.Deserialize(reader);
                    reader.Close();
                    reader.Dispose();
                }
                else
                {
                    LibTemp.Shelves = new ObservableCollection<Shelf>()
                        { new Shelf() };
                    LibTemp.Shelves.Last().Books = new ObservableCollection<Book>()
                        { new Book() };
                }
                IsFirst = false;
                if (type == typeof(Book))
                {
                    BookTemp = (Book)LibTemp.Shelves.Last().Books.Last();
                    return BookTemp;
                }
                else if (type == typeof(Shelf))
                {
                    ShelfTemp = (Shelf)LibTemp.Shelves.Last();
                    return ShelfTemp;
                }
                return LibTemp;
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Library));
                if (FliePath == null)
                {
                    if (type == typeof(Book))
                    {

                        return BookTemp;
                    }
                    else if (type == typeof(Shelf))
                    {

                        return ShelfTemp;
                    }
                    return LibTemp;
                }
                FileStream reader = new FileStream(FliePath, FileMode.Open);
                LibTemp = (Library)serializer.Deserialize(reader);
                reader.Close();
                reader.Dispose();
                if (LibTemp.Shelves == null)
                {
                    LibTemp.Shelves = new ObservableCollection<Shelf>()
            { new Shelf()
            };
                }
                if (LibTemp.Shelves.Last().Books.Count == 0)
                {
                    LibTemp.Shelves.Last().Books = new ObservableCollection<Book>()
            { new Book()
            };
                }
                if (type == typeof(Book))
                {
                    BookTemp = (Book)LibTemp.Shelves.Last().Books.Last();
                    return BookTemp;
                }
                else if (type == typeof(Shelf))
                {
                    ShelfTemp = (Shelf)LibTemp.Shelves.Last();
                    return ShelfTemp;
                }
                return LibTemp;
            }
        }
    }
}
