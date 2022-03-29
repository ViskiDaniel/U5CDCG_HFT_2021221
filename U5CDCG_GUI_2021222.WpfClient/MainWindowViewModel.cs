using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_GUI_2021222.WpfClient
{
    public class MainWindowViewModel:ObservableRecipient
    {
        public RestCollection<Book> Booklist { get; set; }

        public RestCollection<Customer> Customerlist { get; set; }

        private Book selectedBook;

        private Customer selectedCustomer;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set { if (value != null) 
                {
                    selectedBook = new Book()
                    {
                        Title = value.Title,
                        Author = value.Author,
                        BookId=value.BookId
                    };
                };
                OnPropertyChanged();     
                (DeleteBook as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (value != null)
                {
                    selectedCustomer = new Customer()
                    {
                        Name = value.Name, Age=value.Age, CustomerId=value.CustomerId, Email=value.Email, Gender=value.Gender
                        
                    };
                    OnPropertyChanged();
                    //TODO: írd meg a maradékot, meg h egy ablabkól érd el az egészet
                }
            }
        }


        public ICommand CreateBook { get; set; }

        public ICommand DeleteBook { get; set; }

        public ICommand UpdateBook { get; set; }      


        public MainWindowViewModel()
        {
            Booklist = new RestCollection<Book>("http://localhost:64653/", "book", "hub");
            CreateBook = new RelayCommand(() =>
              {
                  Booklist.Add(new Book()
                  {
                      Author = selectedBook.Author,
                      Title=selectedBook.Title
                  });
              });

            DeleteBook= new RelayCommand(()=>
            {
                Booklist.Delete(selectedBook.BookId);
            },
            () =>
            {
                return SelectedBook != null;
            });

            UpdateBook = new RelayCommand(() =>
              {
                  Booklist.Update(selectedBook);
              });
        }
    }
}
