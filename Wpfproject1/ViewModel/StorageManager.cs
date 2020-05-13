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
        static Content ContentTemp;
        public static void Save(object instance)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "xml (*.xml)|*.xml"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
               
                XmlSerializer serializer = new XmlSerializer(typeof(Content));

                ContentTemp = (Content)Load(typeof(Content));
                if (ContentTemp.Libs == null)
                {
                    ContentTemp.Libs = new ObservableCollection<Library>()
                    { new Library()};
                }
                if (ContentTemp.Libs.Last().Shelves == null)
                {
                    ContentTemp.Libs.Last().Shelves = new ObservableCollection<Shelf>()
            { new Shelf()
            };
                }
                if (ContentTemp.Libs.Last().Shelves.Last().Books== null)
                {
                    ContentTemp.Libs.Last().Shelves.Last().Books = new ObservableCollection<Book>()
            { new Book()
            };
                }
                if (instance is Book)
                {

                    ContentTemp.Libs.Last().Shelves.Last().Books.Add((Book)instance);
                }
                else if (instance is Shelf)
                {
                    
                    ContentTemp.Libs.Last().Shelves.Add((Shelf)instance);
                }
                else if(instance is Library)
                {
                   
                    ContentTemp.Libs.Add((Library)instance);
                }
                else
                {
                    ContentTemp = (Content)instance;
                }
                StreamWriter Writer = new StreamWriter(saveFileDialog.FileName);
                FliePath = saveFileDialog.FileName;
                serializer.Serialize(Writer, ContentTemp);
                Writer.Close();
                Writer.Dispose();
            }
        }
        public static object Load(Type type)
        {
            Content ContentTemp = new Content();
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
                    XmlSerializer serializer = new XmlSerializer(typeof(Content));
                    FileStream reader = new FileStream(FliePath, FileMode.Open);
                    ContentTemp = (Content)serializer.Deserialize(reader);
                    reader.Close();
                    reader.Dispose();
                }
                else
                {
                    ContentTemp.Libs = new ObservableCollection<Library>()
                    {
                        new Library() { Name = "First" }

                };

                    ContentTemp.Libs.Last().Shelves = new ObservableCollection<Shelf>()
                        { new Shelf(){ Position = "First" }};
                    ContentTemp.Libs.Last().Shelves.Last().Books = new ObservableCollection<Book>()
                        { new Book() { BookName = "First" } };
                }
                IsFirst = false;
                if (type == typeof(Book))
                {
                    BookTemp = (Book)ContentTemp.Libs.Last().Shelves.Last().Books.Last();
                    return BookTemp;
                }
                else if (type == typeof(Shelf))
                {
                    ShelfTemp = (Shelf)ContentTemp.Libs.Last().Shelves.Last();
                    return ShelfTemp;
                }
                else if (type == typeof(Library))
                {
                    LibTemp = ContentTemp.Libs.Last();
                    return LibTemp;
                }
                return ContentTemp;
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Content));
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
                    else if (type == typeof(Library))
                    {
                        
                        return LibTemp;
                    }
                    return ContentTemp;
                }
                FileStream reader = new FileStream(FliePath, FileMode.Open);
                ContentTemp = (Content)serializer.Deserialize(reader);
                reader.Close();
                reader.Dispose();
                if (ContentTemp.Libs == null)
                {

                        ContentTemp.Libs = new ObservableCollection<Library>()
                    { new Library()}; 
                    
                }
                if (ContentTemp.Libs.Last().Shelves.Count == 0)
                {
                    ContentTemp.Libs.Last().Shelves = new ObservableCollection<Shelf>()
            { new Shelf()
            };
                }
                if (ContentTemp.Libs.Last().Shelves.Last().Books == null)
                {
                    ContentTemp.Libs.Last().Shelves.Last().Books = new ObservableCollection<Book>()
            { new Book()
            };
                }
                if (type == typeof(Book))
                {
                    BookTemp = (Book)ContentTemp.Libs.Last().Shelves.Last().Books.Last();
                    return BookTemp;
                }
                else if (type == typeof(Shelf))
                {
                    ShelfTemp = (Shelf)ContentTemp.Libs.Last().Shelves.Last();
                    return ShelfTemp;
                }
                else if (type == typeof(Library))
                {
                    LibTemp = ContentTemp.Libs.Last();
                    return LibTemp;
                }
                return ContentTemp;
            }
        }
    }
}
