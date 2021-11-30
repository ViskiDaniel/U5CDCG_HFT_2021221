using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Data;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_HFT_2021221.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        LibraryDbContext context;
        public CustomerRepository(LibraryDbContext context)
        {
            this.context = context;
        }
        public void Create(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void Delete(int customerId)
        {
            context.Remove(Read(customerId));
            context.SaveChanges();
        }

        public Customer Read(int customerId)
        {
            return context.Customers.FirstOrDefault(x => x.CustomerId == customerId);
        }

        public IQueryable<Customer> ReadAll()
        {
            return context.Customers;
        }

        public void Update(Customer customer)
        {
            var updated = Read(customer.CustomerId);
            updated.Age = customer.Age;
            updated.CustomerId = customer.CustomerId;
            updated.Email = customer.Email;
            updated.Gender = customer.Gender;
            updated.Name = customer.Name;
            context.SaveChanges();
        }
    }
}
