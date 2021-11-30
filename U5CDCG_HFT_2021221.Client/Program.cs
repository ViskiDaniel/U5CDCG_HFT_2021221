using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Data;
using U5CDCG_HFT_2021221.Logic;
using U5CDCG_HFT_2021221.Models;
using U5CDCG_HFT_2021221.Repository;

namespace U5CDCG_HFT_2021221.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            LibraryDbContext db = new LibraryDbContext();
            RestService rs = new RestService("http://localhost:64653/");

            var books = rs.Get<Book>("books");
            var customers = rs.Get<Customer>("customers");
            var libraries = rs.Get<Library>("libraries");

            rsMenu menu = new rsMenu(rs);

            menu.startUp();



        }
    }
}
