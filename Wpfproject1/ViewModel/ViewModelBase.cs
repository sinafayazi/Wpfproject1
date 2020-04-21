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


    public class ViewModelBase : ModelBase, INotifyPropertyChanged 
    {
        public ICommand SaveCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ModelBase model { get; set; }
        public TextWriter writer { get; set; }

        public ViewModelBase()
        {
            SaveCommand = new RelayCommand(SaveAction, CanSave,true);
        }

        private bool CanSave(object parameter)
        {
            return true;
        
        }
        private void SaveAction(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xml (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(model.GetType());
                    if (writer == null)
                    {

                        
                        writer = new StreamWriter(saveFileDialog.FileName,true);

                        serializer.Serialize(writer, model); 
                    }
                    else
                    {
                        serializer.Serialize(writer, model);
                    }
                }
                finally
                {
                    writer.Close();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected new void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        protected new void OnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged();
        }


    }

}
