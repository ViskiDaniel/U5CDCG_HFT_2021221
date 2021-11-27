using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Logic;

namespace U5CDCG_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController:ControllerBase
    {
        ILibraryLogic libLog;

        public StatController(ILibraryLogic libLog)
        {
            this.libLog = libLog;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> authorName()
        {
            return libLog.booksOfTolstoy();
        }

        [HttpGet]
        public IEnumerable<object> olderCustomers()
        {
            return libLog.olderCustomers();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> currentCustomers()
        {
            return libLog.currentCustomers();
        }
        [HttpGet]
        public IEnumerable<object> emailHu()
        {
            return libLog.emailHu();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> genderAvg()
        {
            return libLog.genderAvg();
        }
    }
}
