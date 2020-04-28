using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Wpfproject1.Command;
using Wpfproject1.Model;
namespace Wpfproject1.ViewModel
{
    public class BookViewModel : ViewModelBase
    {
        public BookViewModel()
        {
            LoadMetod();
            SaveCommand = new RelayCommand(SaveAction, CanSave);
            LoadCommand = new RelayCommand(LoadAction, CanLoad);
        }
        private bool CanSave(object parameter)
        {
            return string.IsNullOrEmpty(Book["BookName"]) 
                && string.IsNullOrEmpty(Book["Author"]) 
                && string.IsNullOrEmpty(Book["Category"]) 
                && string.IsNullOrEmpty(Book["Genre"]) 
                && string.IsNullOrEmpty(Book["Email"]) 
                && string.IsNullOrEmpty(Book["Publisher"]);
        }
        private void SaveAction(object parameter)
        {
            SaveMethod();
        }
        public void SaveMethod()
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "xml (*.xml)|*.xml"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                StreamWriter Writer;
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Library));
                    LibTemp.Shelves.Last().Books.Add(Book);

                    Writer = new StreamWriter(saveFileDialog.FileName);
                    serializer.Serialize(Writer, LibTemp);
                    Writer.Close();
                    Writer.Dispose();
                }

                finally
                {

                }
            }
        }
        private bool CanLoad(object parameter)
        {
            return true;
        }
        private void LoadAction(object parameter)
        {
            LoadMetod();
        }
        public void LoadMetod()
        {
            Book = (Book)BookTemp.Clone();
            Book.PropertyChanged += Model_PropertyChanged;

        }
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            (SaveCommand as RelayCommand).RaiseCanExecuteChanged();
        }
    }
}
