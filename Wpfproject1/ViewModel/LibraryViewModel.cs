using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wpfproject1.Model;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Xml.Serialization;
using Wpfproject1.Command;
using System.ComponentModel;

namespace Wpfproject1.ViewModel
{
    class LibraryViewModel : ViewModelBase
    {
        public LibraryViewModel()
        {
            FirstLoadMetod();
            //Lib = (Library)FirstLoadMetod();
            LoadMetod();
            SaveCommand = new RelayCommand(SaveAction, CanSave);
            LoadCommand = new RelayCommand(LoadAction, CanLoad);
        }
        private bool CanSave(object parameter)
        {
            return string.IsNullOrEmpty(Lib["Name"]) && 
                string.IsNullOrEmpty(Lib["Address"]) && 
                string.IsNullOrEmpty(Lib["Tell"]) &&
                string.IsNullOrEmpty(Lib["Website"]);
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
                    LibTemp = (Library)Lib.Clone();


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
            Lib = (Library)LibTemp.Clone();
            Lib.PropertyChanged += Model_PropertyChanged;
        }
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            (SaveCommand as RelayCommand).RaiseCanExecuteChanged();
        }
    }
}
