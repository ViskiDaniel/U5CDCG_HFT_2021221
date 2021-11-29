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

            var menu = new ConsoleMenu(args, 1);

            Book fakeBook1 = new Book { Author = "John Tolstoy", Title = "Example", BookId = 1 };
            rs.Put(fakeBook1, "book");
            


            menu.Add("customers", ()=> rs.Get<Customer>("customer"));
            menu.Add("books", () => rs.Get<Book>("book"));
            menu.Add("close", ConsoleMenu.Close).Configure(config=> {
                config.Selector = "--> ";
                config.EnableFilter = false;
                config.Title = "Submenu";
                config.EnableBreadcrumb = true;
                config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
            });

            menu.Show();


        }
    }
}
