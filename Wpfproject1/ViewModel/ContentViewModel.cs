using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpfproject1.Command;
using Wpfproject1.Model;

namespace Wpfproject1.ViewModel
{

    public class ContentViewModel : ViewModelBase
    {
        private Content content;

        public Content Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                OnPropertyChanged();
            }
        }
        private static ModelBase  model;

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
                UpdateVisibility();
            }
        }
        private LibraryViewModel libraryViewModel;

        public LibraryViewModel LibraryViewModel
        {
            get { return libraryViewModel; }
            set { libraryViewModel = value;
                OnPropertyChanged();
                
            }
        }
        private ShelfViewModel shelfViewModel;

        public ShelfViewModel ShelfViewModel
        {
            get { return shelfViewModel; }
            set
            {
                shelfViewModel = value;
                OnPropertyChanged();
                
            }
        }
        private BookViewModel bookViewModel;

        public BookViewModel BookViewModel
        {
            get { return bookViewModel; }
            set
            {
                bookViewModel = value;
                OnPropertyChanged();
                
            }
        }

        //private Library lib;
        //public Library Lib
        //{
        //    get
        //    {
        //        return lib;
        //    }
        //    set
        //    {
        //        lib = value;
        //        OnPropertyChanged();
        //    }
        //}
        //private Shelf shelf;
        //public Shelf Shelf
        //{
        //    get
        //    {
        //        return shelf;
        //    }
        //    set
        //    {
        //        shelf = value;
        //        OnPropertyChanged();
        //    }

        //}
        //private Book book;
        //public Book Book
        //{
        //    get
        //    {
        //        return book;
        //    }
        //    set
        //    {
        //        book = value;
        //        OnPropertyChanged();
        //    }
        //}
       
        public ContentViewModel()
        {
            Content = new Content();
            LibraryViewModel = new LibraryViewModel();
            ShelfViewModel = new ShelfViewModel();
            BookViewModel = new BookViewModel();

            LoadMetod();

        }
        public void LoadMetod()
        {
            Content = (Content)StorageManager.Load(typeof(Content));
            //Lib = Content.Libs.Last();
            //Shelf = Content.Libs.Last().Shelves.Last();
            //Book = Content.Libs.Last().Shelves.Last().Books.Last();

        }
        public void UpdateVisibility()
        {
            LibraryViewModel.IsVisible = Visibility.Collapsed;
            ShelfViewModel.IsVisible = Visibility.Collapsed;
            BookViewModel.IsVisible = Visibility.Collapsed;

            if (model is Library)
            {
                
                LibraryViewModel.IsVisible = Visibility.Visible;
                LibraryViewModel.Lib = (Library)model;
            }
            else if (model is Shelf)
            {

                ShelfViewModel.IsVisible = Visibility.Visible;
                ShelfViewModel.Shelf = (Shelf)model;
            }
            else if (model is Book)
            {

                BookViewModel.IsVisible = Visibility.Visible;
                BookViewModel.Book = (Book)model;
            }
            

        }
        public ModelBase DataUpdate(Type type)
        {
            if (model != null)
            {
                if (type == typeof(Book))
                {

                    return (Book)model;
                }
                else if (type == typeof(Shelf))
                {

                    return (Shelf)model;
                }
                else if (type == typeof(Library))
                {

                    return (Library)model;
                }
                return (Content)model;
            }
            else
            {
                Content = (Content)StorageManager.Load(typeof(Content));

                if (type == typeof(Book))
                {

                    return Content.Libs.Last().Shelves.Last().Books.Last();
                }
                else if (type == typeof(Shelf))
                {

                    return Content.Libs.Last().Shelves.Last();
                }
                else if (type == typeof(Library))
                {

                    return Content.Libs.Last();
                }
                return Content;
            }
        }

    }

}
