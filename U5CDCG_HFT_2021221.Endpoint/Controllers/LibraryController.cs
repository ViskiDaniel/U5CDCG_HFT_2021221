using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Endpoint.Services;
using U5CDCG_HFT_2021221.Logic;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LibraryController:ControllerBase
    {
        ILibraryLogic ll;
        private readonly IHubContext<SignalRHub> hub;

        public LibraryController(ILibraryLogic ll, IHubContext<SignalRHub> hub)
        {
            this.ll = ll;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Library> Get()
        {
            return ll.ReadAll();
        }

        [HttpGet("{id}")]
        public Library Get(int id)
        {
            return ll.Read(id);
        }


        [HttpPut]
        public void Put([FromBody] Library library)
        {
            ll.Update(library);
            this.hub.Clients.All.SendAsync("LibraryUpdated", library);
        }

        [HttpPost]
        public void Post([FromBody] Library library)
        {
            ll.Create(library);
            this.hub.Clients.All.SendAsync("LibraryAdded", library);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleted = ll.Read(id);
            ll.Delete(id);
            this.hub.Clients.All.SendAsync("LibraryDeleted", deleted);
        }


    }
}
