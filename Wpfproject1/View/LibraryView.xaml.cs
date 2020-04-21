﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpfproject1.ViewModel;

namespace Wpfproject1
{
    /// <summary>
    /// Interaction logic for library.xaml
    /// </summary>
    public partial class LibraryView : UserControl
    {
        LibraryViewModel libraryViewModel = new LibraryViewModel();
        public LibraryView()
        {
            InitializeComponent();
            DataContext = libraryViewModel;
        }
    }
}
