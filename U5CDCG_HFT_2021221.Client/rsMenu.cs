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
        //Book bookUpdate;
        //Book bookCreate;
        //Customer customerUpdate;
        //Customer customerCreate;
        //Library libraryUpdate;
        //Library libraryCreate;
        RestService restService;

        public rsMenu(RestService restService)
        {
            this.restService = restService;
            //bookUpdate = new Book();
            //bookCreate = new Book();
            //customerCreate = new Customer();
            //customerUpdate = new Customer();
            //libraryCreate = new Library();
            //libraryUpdate = new Library();
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
            menu.Add("Add items", () => new ConsoleMenu()
            .Add("Book", () => createBook("book"))
            .Add("Back to the main", ConsoleMenu.Close)
            .Show()
            );
            menu.Add("Close the window", ConsoleMenu.Close);
            menu.Show();            
        }
        void getAll<T>(List<T> list)
        {
            Console.Clear();
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        void getOneBook<T>(T item)
        {
            Console.Clear();
            Console.WriteLine("ID of the required item: ");
            int id=int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(restService.Get<Book>(id, "book").ToString());
            Console.ReadKey();
        }
        void getOneCustomer<T>(T item)
        {
            Console.Clear();
            Console.WriteLine("ID of the required item: ");
            int id = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(restService.Get<Customer>(id, "customer").ToString());
            Console.ReadKey();
        }
        void getOneLibrary<T>(T item)
        {
            Console.Clear();
            Console.WriteLine("ID of the required item: ");
            int id = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(restService.Get<Library>(id, "library").ToString());
            Console.ReadKey();
        }
        void createBook(string endpoint) 
        {
            Console.Clear();
            Book createBook = new Book();
            Console.WriteLine("Author of the book: ");
            string author = Console.ReadLine();
            Console.WriteLine("Title of the book");
            string title = Console.ReadLine();
            createBook.Author = author;
            createBook.Title = title;
            Console.Clear();
            Console.WriteLine("Updating....");
            restService.Post<Book>(createBook, endpoint);
            Console.WriteLine("Book succesfully added!");
            Console.ReadKey();
        }

        void createCustomer(string endpoint)
        {
            Console.Clear();
            Customer createCustomer = new Customer();
            Console.WriteLine("Name of the customer");
            string name = Console.ReadLine();
            Console.WriteLine("Age of the customer");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Gender of the customer: 1-Male, 2-Female");

            Console.WriteLine("Email of the customer");
            string email = Console.ReadLine();
            createCustomer.Name = name;
            createCustomer.Age = age;
            createCustomer.Gender = name;
            createCustomer.Email = email;
            Console.Clear();
            Console.WriteLine("Updating....");
            restService.Post<Customer>(createCustomer, endpoint);
            Console.WriteLine("Book succesfully added!");
            Console.ReadKey();
        }
    }
}
