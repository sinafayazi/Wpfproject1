using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        private static Library Lib;

        public static  Library lib
        {
            get { return Lib; }
            set { Lib = value;  }
        }

        private ModelBase Model;
        public ModelBase model
        {
            get { return Model; }
            set { Model = value; OnPropertyChanged(); }
        }
        public TextWriter writer { get; set; }
        public FileStream reader { get; set; }

        public ViewModelBase()
        {
            SaveCommand = new RelayCommand(SaveAction, CanSave,true);
            LoadCommand = new RelayCommand(LoadAction, CanLoad, true);
        }

        private bool CanSave(object parameter)
        {
            return true;
        
        }
        
        private void SaveAction(object parameter)
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
                    if (writer == null)
                    {

                        
                        writer = new StreamWriter(saveFileDialog.FileName);

                        serializer.Serialize(writer, lib); 
                    }
                    else
                    {
                        serializer.Serialize(writer, lib);
                    }
                }
                finally
                {
                    writer.Close();
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

        public ModelBase LoadMetod()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "xml (*.xml)|*.xml"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(model.GetType());
                    FileStream reader = new FileStream(openFileDialog.FileName, FileMode.Open);


                    model = (Library)serializer.Deserialize(reader);
                    
                    

                }
                finally
                {

                }

            }
            return model;
        }

    }

}
