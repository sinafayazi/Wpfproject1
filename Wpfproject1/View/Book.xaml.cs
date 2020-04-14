using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;
using Wpfproject1.ViewModel;

namespace Wpfproject1
{
    /// <summary>
    /// Interaction logic for book.xaml
    /// </summary>
    public partial class Book : UserControl
    {
        BookViewModel bookViewModel = new BookViewModel();
        
        public Book()
        {
            InitializeComponent();
            DataContext = bookViewModel;
           
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xml (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    XmlSerializer serializer =
                    new XmlSerializer(typeof(Book));
                    TextWriter writer = new StreamWriter(saveFileDialog.FileName);
                    Book book = new Book();
                    serializer.Serialize(writer, book);
                }
                finally
                {

                }
            }
        }
    }
}
