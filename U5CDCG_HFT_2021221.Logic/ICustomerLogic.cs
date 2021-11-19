using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_HFT_2021221.Logic
{
    interface ICustomerLogic
    {
        void Create(Customer customer);
        void Delete(int customerId);
        Customer Read(int customerId);
        IQueryable<Customer> ReadAll();
        void Update(Customer customer);
    }
}
