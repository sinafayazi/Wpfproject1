﻿using System;
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

namespace Wpfproject1.ViewModel
{
    class LibraryViewModel : ViewModelBase
    {
        public LibraryViewModel()
        {
            Lib = (Library)FirstLoadMetod();
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
                    LibTemp = (Library)Lib.Clone();
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
                    Writer.Dispose();
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
        }
    }
}
