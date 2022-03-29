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
    class CustomerViewModel : ObservableRecipient
    {
        public RestCollection<Customer> Customerlist { get; set; }

        private Customer selectedCustomer;
        public ICommand CreateCustomer { get; set; }
        public ICommand DeleteCustomer { get; set; }
        public ICommand UpdateCustomer { get; set; }

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (value != null)
                {
                    selectedCustomer = new Customer()
                    {
                        Name = value.Name,
                        Age = value.Age,
                        CustomerId = value.CustomerId,
                        Email = value.Email,
                        Gender = value.Gender
                    };
                }
                OnPropertyChanged();
                (DeleteCustomer as RelayCommand).NotifyCanExecuteChanged();
            }
            
        }

        public CustomerViewModel()
        {
            Customerlist = new RestCollection<Customer>("http://localhost:64653/", "customer", "hub");

            CreateCustomer = new RelayCommand(() =>
              {
                  Customerlist.Add(new Customer()
                  {
                      Age = selectedCustomer.Age,
                      Email = selectedCustomer.Email,
                      Gender = selectedCustomer.Gender,
                      Name = selectedCustomer.Name
                  });
              });

            DeleteCustomer = new RelayCommand(() =>
              {
                  Customerlist.Delete(selectedCustomer.CustomerId);
              },
              () =>
              {
                  return SelectedCustomer != null;
              });

            UpdateCustomer = new RelayCommand(() =>
              {
                  Customerlist.Update(selectedCustomer);
              });
        }
    }
}
