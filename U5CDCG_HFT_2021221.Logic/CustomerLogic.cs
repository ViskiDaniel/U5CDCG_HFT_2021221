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
            CusRepo.Create(customer);
        }

        public void Delete(int customerId)
        {
            CusRepo.Delete(customerId);
        }

        public Customer Read(int customerId)
        {
            return CusRepo.Read(customerId);
        }

        public IQueryable<Customer> ReadAll()
        {
            return CusRepo.ReadAll();
        }

        public void Update(Customer customer)
        {
            CusRepo.Update(customer);
        }
    }
}
