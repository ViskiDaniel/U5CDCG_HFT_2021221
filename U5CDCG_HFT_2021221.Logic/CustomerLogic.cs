using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;
using U5CDCG_HFT_2021221.Repository;

namespace U5CDCG_HFT_2021221.Logic
{
    class CustomerLogic : ICustomerLogic

    {
        ICustomerRepository CusRepo;

        public CustomerLogic(ICustomerRepository cusrepo)
        {
            CusRepo = cusrepo;
        }
        public void Create(Customer customer)
        {
            if (customer == null)
            {
                throw new NullReferenceException();
            }
            else if (customer.Age < 18)
            {
                throw new ArgumentOutOfRangeException("Must be older than 18");
            }
            else if (customer.Name == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                CusRepo.Create(customer);
            }
           
        }

        public void Delete(int customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            CusRepo.Delete(customerId);
        }

        public Customer Read(int customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentOutOfRangeException();

            }
            else
            {
                return CusRepo.Read(customerId);
            }
            
        }

        public IEnumerable<Customer> ReadAll()
        {
            return CusRepo.ReadAll();
        }

        public void Update(Customer customer)
        {

            if (customer == null)
            {
                throw new NullReferenceException();
            }
            else if (customer.Age < 18)
            {
                throw new ArgumentOutOfRangeException("Must be older than 18");
            }
            else if (customer.Name == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                CusRepo.Update(customer);
            }
        }
    }
}
