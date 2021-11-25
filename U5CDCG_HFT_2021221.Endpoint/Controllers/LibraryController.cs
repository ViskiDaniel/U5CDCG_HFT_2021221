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
    public class LibraryController:ControllerBase
    {
        ILibraryLogic ll;

        public LibraryController(ILibraryLogic ll)
        {
            this.ll = ll;
        }

        [HttpGet]
        public IEnumerable<Library> Get()
        {
            return ll.ReadAll();
        }
        [HttpGet("{id")]
        public Library Get(int id)
        {
            return ll.Read(id);
        }


        [HttpPut]
        public void Put([FromBody] Library library)
        {
            ll.Update(library);
        }

        [HttpPost]
        public void Post([FromBody] Library library)
        {
            ll.Create(library);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ll.Delete(id);
        }


    }
}
