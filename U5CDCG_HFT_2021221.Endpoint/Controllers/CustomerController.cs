using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Logic;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController:ControllerBase
    {
        ICustomerLogic cl;

        public CustomerController(ICustomerLogic cl)
        {
            this.cl = cl;
        }

        [HttpGet("{id")]
        public Customer Get(int id)
        {
            return cl.Read(id);
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return cl.ReadAll();
        }

        [HttpPut]
        public void Put([FromBody] Customer customer)
        {
            cl.Update(customer);
        }

        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            cl.Create(customer);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
