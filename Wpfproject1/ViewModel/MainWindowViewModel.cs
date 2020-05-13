using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpfproject1.Model;

namespace Wpfproject1.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        
        private ModelBase model;
        public ModelBase Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                OnPropertyChanged();
            }
        }
        
    }
}
