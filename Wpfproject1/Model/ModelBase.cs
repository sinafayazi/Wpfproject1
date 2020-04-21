using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpfproject1.Model
{
    public class ModelBase : INotifyPropertyChanged
    {
        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value;  }
        }
        //private TextWriter writer;
        //public TextWriter Writer
        //{
        //    get { return writer; }
        //    set { writer = value; }
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        protected void OnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged();
        }
    }
}
