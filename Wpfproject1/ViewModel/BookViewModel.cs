using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            return true;
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
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Library));
                    LibTemp.Shelves.Last().Books.Add(Book);
                    if (Writer == null)
                    {
                        Writer = new StreamWriter(saveFileDialog.FileName);
                        serializer.Serialize(Writer, LibTemp);
                    }
                    else
                    {
                        serializer.Serialize(Writer, LibTemp);
                    }
                }
                finally
                {
                    Writer.Close();
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
        }
    }
}
