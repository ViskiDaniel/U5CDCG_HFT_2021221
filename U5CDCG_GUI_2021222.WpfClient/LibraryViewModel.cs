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
    class LibraryViewModel : ObservableRecipient
    {
        public RestCollection<Library> Librarylist { get; set; }

        private Library selectedLibrary;

        public ICommand CreateLibrary { get; set; }

        public ICommand DeleteLibrary { get; set; }

        public ICommand UpdateLibrary { get; set; }

        public Library SelectedLibrary
        {
            get { return selectedLibrary; }
            set
            {
                if (value != null)
                {
                    selectedLibrary = new Library()
                    {
                        Book = value.Book,
                        Customer = value.Customer,
                        BookId = value.BookId,
                        CustomerId = value.CustomerId,
                        ActionID = value.ActionID
                    };
                }
                OnPropertyChanged();
                (DeleteLibrary as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public LibraryViewModel()
        {
            Librarylist = new RestCollection<Library>("http://localhost:64653/", "library", "hub");

            CreateLibrary = new RelayCommand(() =>
            {
                Librarylist.Add(new Library() { BookId = selectedLibrary.BookId, CustomerId = selectedLibrary.CustomerId });
            });

            DeleteLibrary = new RelayCommand(() =>
            {
                Librarylist.Delete(selectedLibrary.ActionID);
            },
              () =>
              {
                  return SelectedLibrary != null;
              });

            UpdateLibrary = new RelayCommand(() =>
            {
                Librarylist.Update(selectedLibrary);
            });

        }

    }
}
