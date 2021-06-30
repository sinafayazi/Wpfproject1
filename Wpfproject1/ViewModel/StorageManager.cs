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
		static Content ContentTemp = new Content
		{
			Libs = new ObservableCollection<Library>()
				{
					new Library()
						{
							Name = "First" , Index = 0,Shelves = new ObservableCollection<Shelf>()
							{
								new Shelf()
								{
									Index = 0,ParentIndex = 0, Books = new ObservableCollection<Book>()
									{
										new Book() {Index = 0,ParentIndex = 0,LibIndex=0 },
									}
								}
							}
						}
						,
						new Library()
							{
								Index = 1, Name = "Second" ,Shelves = new ObservableCollection<Shelf>()
							{
								new Shelf()
								{
									Index = 0,ParentIndex = 1, Books = new ObservableCollection<Book>()
									{
										new Book() {Index = 0,ParentIndex = 0,LibIndex=1 },
									}
								}
							}


							}
					}
		};
		public static void Save(ModelBase instance)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Filter = "xml (*.xml)|*.xml"
			};
			if (saveFileDialog.ShowDialog() == true)
			{
				FliePath = saveFileDialog.FileName;
				XmlSerializer serializer = new XmlSerializer(typeof(Content));
				using (StreamWriter Writer = new StreamWriter(FliePath))
				{
					serializer.Serialize(Writer, ContentTemp);
					Writer.Close();
					Writer.Dispose();
				}
			}
		}
		public static object Load(ModelBase instance)
		{
			Content content = new Content
			{
				Libs = new ObservableCollection<Library>()
		 			{
		 				new Library()
		 {
		 	Name = "First" , Index = 0 ,
		 						Shelves = new ObservableCollection<Shelf>()
		 					{
		 					new Shelf(){Index = 0,ParentIndex = 0, Position = "FirstShelf", Books = new ObservableCollection<Book>()
		 					{
		 						new Book() {Index = 0,ParentIndex = 0,LibIndex=0, BookName = "Programming" },
		 						new Book() {Index = 1,ParentIndex = 0,LibIndex=0, BookName = "StrengthOfMaterials" },
		 					} },
		 					new Shelf(){Index = 1,ParentIndex = 0, Position = "SecondShelf", Books = new ObservableCollection<Book>()
		 					{
		 						new Book() {Index = 0,ParentIndex = 1,LibIndex=0, BookName = "FluidMechanic" },
		 						new Book() {Index = 1,ParentIndex = 1,LibIndex=0, BookName = "DifferentialEquations" },
		 					} },
		 					}
		 						}
		 					,
		 					new Library()
							{
		 					Index = 1, Name = "Second" ,Shelves = new ObservableCollection<Shelf>()
		 					{
		 					new Shelf(){Index = 0,ParentIndex = 1, Position = "ThirdShelf", Books = new ObservableCollection<Book>()
		 					{
		 						new Book() {Index = 0,ParentIndex = 0,LibIndex=1, BookName = "Physics" },
		 						new Book() {Index = 1,ParentIndex = 0,LibIndex=1, BookName = "Chem" },
		 					}
		 					},
		 					new Shelf(){Index = 1,ParentIndex = 1, Position = "ForthShelf" , Books = new ObservableCollection<Book>()
		 					{
		 						new Book() {Index = 0,ParentIndex = 1,LibIndex=1, BookName = "Math" },
		 						new Book() {Index = 1,ParentIndex = 1,LibIndex=1, BookName = "Statics" },
		 					}},
		 					} },
		 				}
			};
			if (IsFirst == true)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog
				{
					Filter = "xml (*.xml)|*.xml"
				};
				if (openFileDialog.ShowDialog() == true)
				{
					XmlSerializer serializer = new XmlSerializer(typeof(Content));
					FliePath = openFileDialog.FileName;
					StreamReader reader = new StreamReader(FliePath);
					content = (Content)serializer.Deserialize(reader);
					reader.Close();
					reader.Dispose();
				}
				IsFirst = false;
			}
			else
			{
				
				if (FliePath != null)
				{
					XmlSerializer serializer = new XmlSerializer(typeof(Content));
					StreamReader reader = new StreamReader(FliePath);
					content = (Content)serializer.Deserialize(reader);
					reader.Close();
					reader.Dispose();

				}
				else
				{
					
				}
			}
			if (instance is Book)
			{
				return ContentTemp.Libs[(instance as Book).LibIndex]
					.Shelves[(instance as Book).ParentIndex].Books[(instance as Book).Index];
			}
			else if (instance is Shelf)
			{
				ObservableCollection<Book> booksTemp = new ObservableCollection<Book>();
				foreach (Book book in content.Libs[(instance as Shelf).ParentIndex]
					.Shelves[(instance as Shelf).Index].Books)
				{
					booksTemp.Add(new Book()
					{
						Author = book.Author,
						BookName = book.BookName,
						Category = book.Category,
						Email = book.Email,
						Genre = book.Genre,
						Index = book.Index,
						Language = book.Language,
						ParentIndex = book.ParentIndex,
						LibIndex = book.LibIndex,
						Publisher = book.Publisher
					});
				}
				ContentTemp.Libs[(instance as Shelf).ParentIndex]
					.Shelves[(instance as Shelf).Index].Books.Clear();
				ContentTemp.Libs[(instance as Shelf).ParentIndex]
					.Shelves[(instance as Shelf).Index].Books = booksTemp;
				return ContentTemp.Libs[(instance as Shelf).ParentIndex]
					.Shelves[(instance as Shelf).Index];
			}
			else if (instance is Library)
			{
				ObservableCollection<Shelf> shelvesTemp = new ObservableCollection<Shelf>();
				foreach (Shelf shelf in content.Libs[(instance as Library).Index].Shelves)
				{
					shelvesTemp.Add(new Shelf()
					{
						Index = shelf.Index,
						Position = shelf.Position,
						Count = shelf.Count,
						Floor = shelf.Floor,
						ParentIndex = shelf.ParentIndex,
						Level = shelf.Level,
						Books = new ObservableCollection<Book> { new Book() }
					});
				}
				ContentTemp.Libs[(instance as Library).Index].Shelves.Clear();
				ContentTemp.Libs[(instance as Library).Index].Shelves = shelvesTemp;
				return ContentTemp.Libs[(instance as Library).Index];
			}
			else
			{
				return ContentTemp;
			}
		}
	}
}
