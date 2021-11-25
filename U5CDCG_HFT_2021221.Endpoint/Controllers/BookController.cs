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
    public class BookController:ControllerBase
    {
        IBookLogic bl;

        public BookController(IBookLogic bl)
        {
            this.bl = bl;
        }

        [HttpGet("{id")]
        public Book Get(int id)
        {
            return bl.Read(id);
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bl.ReadAll();
        }

        [HttpPut]
        public void Put([FromBody] Book book)
        {
            bl.Update(book);
        }

        [HttpPost]
        public void Post([FromBody] Book book)
        {
            bl.Create(book);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.Delete(id);
        }
    }
}
