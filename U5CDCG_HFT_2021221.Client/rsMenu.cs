using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_HFT_2021221.Client
{
    class rsMenu
    {
        Book bookUpdate;
        Book bookCreate;
        Customer customerUpdate;
        Customer customerCreate;
        Library libraryUpdate;
        Library libraryCreate;
        RestService restService;

        public rsMenu(RestService restService)
        {
            this.restService = restService;
            bookUpdate = new Book();
            bookCreate = new Book();
            customerCreate = new Customer();
            customerUpdate = new Customer();
            libraryCreate = new Library();
            libraryUpdate = new Library();
        }


        public void startUp()
        {
            ConsoleMenu menu = new ConsoleMenu();
            menu.Add("List of items",
                () => new ConsoleMenu()
                .Add("List of books", () => getAll<Book>(restService.Get<Book>("book")))
                .Add("List of customers", () => getAll<Customer>(restService.Get<Customer>("customer")))
                .Add("List of libraries", () => getAll<Library>(restService.Get<Library>("library")))
                .Add("Back to the main", ConsoleMenu.Close)
                .Show()
                );
            menu.Add("Get one item", () => new ConsoleMenu()
                .Add("Book", () => getOneBook("book"))
                .Add("Customer", () => getOneCustomer("customer"))
                .Add("Library", () => getOneLibrary("library"))
                .Add("Back to the main", ConsoleMenu.Close)
                .Show()
                );
            menu.Add("Close the window", ConsoleMenu.Close);
            menu.Show();

            
        }


        public void getAll<T>(List<T> list)
        {
            Console.Clear();
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        public void getOneBook<T>(T item)
        {
            Console.Clear();
            Console.WriteLine("ID of the required item: ");
            int id=int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(restService.Get<Book>(id, "book").ToString());
            Console.ReadKey();
        }
        public void getOneCustomer<T>(T item)
        {
            Console.Clear();
            Console.WriteLine("ID of the required item: ");
            int id = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(restService.Get<Customer>(id, "customer").ToString());
            Console.ReadKey();
        }
        public void getOneLibrary<T>(T item)
        {
            Console.Clear();
            Console.WriteLine("ID of the required item: ");
            int id = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(restService.Get<Library>(id, "library").ToString());
            Console.ReadKey();
        }
    }
}
