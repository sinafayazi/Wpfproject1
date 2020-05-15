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
		public static void Save(ModelBase instance)
		{

			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Filter = "xml (*.xml)|*.xml"
			};
			if (saveFileDialog.ShowDialog() == true)
			{

				XmlSerializer serializer = new XmlSerializer(typeof(Content));

				ContentTemp = (Content)Load(ContentTemp);

				if (instance is Book)
				{

					ContentTemp.Libs[(instance as Book).LibIndex].Shelves[(instance as Book).ParentIndex].Books[(instance as Book).Index] = ((Book)instance);
				}
				else if (instance is Shelf)
				{

					ContentTemp.Libs[(instance as Shelf).ParentIndex].Shelves[(instance as Shelf).Index] = ((Shelf)instance);
				}
				else if (instance is Library)
				{

					ContentTemp.Libs[(instance as Library).Index] = ((Library)instance);
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
		public static object Load(ModelBase instance)
		{
			Content ContentTemp = new Content();
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
						new Library() { Name = "First" , Index = 0 , Shelves =new ObservableCollection<Shelf>()
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
					},
						new Library() {Index = 1, Name = "Second" ,Shelves =new ObservableCollection<Shelf>()
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


				};
				}
				IsFirst = false;
				if (instance is Book)
				{

					return ContentTemp.Libs[(instance as Book).LibIndex].Shelves[(instance as Book).ParentIndex].Books[(instance as Book).Index] ;
				}
				else if (instance is Shelf)
				{

					return ContentTemp.Libs[(instance as Shelf).ParentIndex].Shelves[(instance as Shelf).Index] ;
				}
				else if (instance is Library)
				{

					return ContentTemp.Libs[(instance as Library).Index] ;
				}
				else
				{
					return ContentTemp;
				}
				
			}
			else
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Content));
				if (FliePath == null)
				{
					ContentTemp.Libs = new ObservableCollection<Library>()
					{
						new Library() { Name = "First" , Index = 0 , Shelves =new ObservableCollection<Shelf>()
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
					},
						new Library() {Index = 1, Name = "Second" ,Shelves =new ObservableCollection<Shelf>()
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


				};

					if (instance is Book)
					{

						return ContentTemp.Libs[(instance as Book).LibIndex].Shelves[(instance as Book).ParentIndex].Books[(instance as Book).Index];
					}
					else if (instance is Shelf)
					{

						return ContentTemp.Libs[(instance as Shelf).ParentIndex].Shelves[(instance as Shelf).Index];
					}
					else if (instance is Library)
					{

						return ContentTemp.Libs[(instance as Library).Index];
					}
					else
					{
						return ContentTemp;
					}
				}
				FileStream reader = new FileStream(FliePath, FileMode.Open);
				ContentTemp = (Content)serializer.Deserialize(reader);
				reader.Close();
				reader.Dispose();
				
				if (instance is Book)
				{

					return ContentTemp.Libs[(instance as Book).LibIndex].Shelves[(instance as Book).ParentIndex].Books[(instance as Book).Index];
				}
				else if (instance is Shelf)
				{

					return ContentTemp.Libs[(instance as Shelf).ParentIndex].Shelves[(instance as Shelf).Index];
				}
				else if (instance is Library)
				{

					return ContentTemp.Libs[(instance as Library).Index];
				}
				else
				{
					return ContentTemp;
				}
			}
		}
	}
}
