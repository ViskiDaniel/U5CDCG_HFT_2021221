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
        RestService restService;

        public rsMenu(RestService restService)
        {
            this.restService = restService;
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
            .Add("Customer", () => createCustomer("customer"))
            .Add("Library", () => createLibrary("library"))
            .Add("Back to the main", ConsoleMenu.Close)
            .Show()
            );
            menu.Add("Update items", () => new ConsoleMenu()
            .Add("Book", ()=>updateBook("book"))
            .Add("Customer", () => updateCustomer("customer"))
            .Add("Library", () => updateLibrary("library"))
            .Add("Back to the main", ConsoleMenu.Close)
            .Show());
            menu.Add("Delete items", () => new ConsoleMenu()
            .Add("Book", () => deleteBook("book"))
            .Add("Customer", () => deleteCustomer("customer"))
            .Add("Library", ()=>deleteLibrary("library"))
            .Add("Back to the main", ConsoleMenu.Close)
            .Show());
            menu.Add("Non-CRUD methods", () => new ConsoleMenu()
            .Add("Emails with .hu in the domain", () => huEmailMenu("stat/emailhu"))
            .Add("Amount of customers", () => genderAvgMenu("stat/genderavg"))
            .Add("Current customers", () => currCustomersMenu("stat/currentcustomers"))
            .Add("Customers above the age of 50", () => olderCustomersMenu("stat/olderCustomers"))
            .Add("Our books from Lev Tolstoy", ()=>tolstoyMenu("stat/authorname"))
            .Add("Back to the main", ConsoleMenu.Close)
            .Show()); 
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
            Console.WriteLine("Creating....");
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
            Console.WriteLine("Gender of the customer: 0-Female, 1-Male");
            int genderint = int.Parse(Console.ReadLine());
            bool gender = false ;
            if (genderint == 1)
            {
                gender = true;
            }
            Console.WriteLine("Email of the customer");
            string email = Console.ReadLine();
            createCustomer.Name = name;
            createCustomer.Age = age;
            createCustomer.Gender = gender;
            createCustomer.Email = email;
            Console.Clear();
            Console.WriteLine("Creating....");
            restService.Post<Customer>(createCustomer, endpoint);
            Console.WriteLine("Customer succesfully added!");
            Console.ReadKey();
        }

        void createLibrary(string endpoint)
        {
            Console.Clear();
            Library createLibrary = new Library();
            Console.WriteLine("ID of the customer:");
            int cid = int.Parse(Console.ReadLine());
            Console.WriteLine("ID of the book:");
            int bid = int.Parse(Console.ReadLine());
            createLibrary.CustomerId = cid;
            createLibrary.BookId = bid;
            Console.Clear();
            Console.WriteLine("Creating....");
            restService.Post<Library>(createLibrary, endpoint);
            Console.WriteLine("Library succesfully added!");
            Console.ReadKey();
        }

        void updateBook(string endpoint)
        {
            Console.Clear();
            Book updated = new Book();
            Console.WriteLine("ID of the book:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Author of the book: ");
            string author = Console.ReadLine();
            Console.WriteLine("Title of the book");
            string title = Console.ReadLine();
            updated.Author = author;
            updated.Title = title;
            updated.BookId = id;
            Console.Clear();
            Console.WriteLine("Updating....");
            restService.Put<Book>(updated, endpoint);
            Console.WriteLine("Book succesfully updated!");
            Console.ReadKey();
        }

        void updateCustomer(string endpoint)
        {
            Console.Clear();
            Customer updateCustomer = new Customer();
            Console.WriteLine("ID of the customer");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Name of the customer");
            string name = Console.ReadLine();
            Console.WriteLine("Age of the customer");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Gender of the customer: 0-Female, 1-Male");
            int genderint = int.Parse(Console.ReadLine());
            bool gender = false;
            if (genderint == 1)
            {
                gender = true;
            }
            Console.WriteLine("Email of the customer");
            string email = Console.ReadLine();
            updateCustomer.CustomerId = id;
            updateCustomer.Name = name;
            updateCustomer.Age = age;
            updateCustomer.Gender = gender;
            updateCustomer.Email = email;
            Console.Clear();
            Console.WriteLine("Updating....");
            restService.Put<Customer>(updateCustomer, endpoint);
            Console.WriteLine("Customer succesfully updated!");
            Console.ReadKey();
        }

        void updateLibrary(string endpoint)
        {
            Console.Clear();
            Library updateLibrary = new Library();
            Console.WriteLine("ID of the library:");
            int lid = int.Parse(Console.ReadLine());
            Console.WriteLine("ID of the customer:");
            int cid = int.Parse(Console.ReadLine());
            Console.WriteLine("ID of the book:");
            int bid = int.Parse(Console.ReadLine());
            updateLibrary.ActionID = lid;
            updateLibrary.CustomerId = cid;
            updateLibrary.BookId = bid;
            Console.Clear();
            Console.WriteLine("Updating....");
            restService.Put<Library>(updateLibrary, endpoint);
            Console.WriteLine("Library succesfully updated!");
            Console.ReadKey();
        }

        void deleteBook(string endpoint)
        {
            Console.Clear();
            Console.WriteLine("ID of the book you want to delete:");
            int id = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Deleting...");
            restService.Delete(id, endpoint);
            Console.WriteLine("Book succesfully deleted!");
            Console.ReadKey();
        }

        void deleteCustomer(string endpoint)
        {
            Console.Clear();
            Console.WriteLine("ID of the customer you want to delete:");
            int id = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Deleting...");
            restService.Delete(id, endpoint);
            Console.WriteLine("Customer succesfully deleted!");
            Console.ReadKey();
        }

        void deleteLibrary(string endpoint)
        {
            Console.Clear();
            Console.WriteLine("ID of the library you want to delete:");
            int id = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Deleting...");
            restService.Delete(id, endpoint);
            Console.WriteLine("Library succesfully deleted!");
            Console.ReadKey();
        }

        void huEmailMenu(string endpoint)
        {
            Console.Clear();
            Console.WriteLine("Customers with .hu email addresses:");
            var huemail=restService.Get<object>(endpoint);
            foreach (var item in huemail)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }

        void genderAvgMenu(string endpoint)
        {
            Console.Clear();
            Console.WriteLine("Amount of customers: ");
            var customers = restService.Get<object>(endpoint);
            foreach (var item in customers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }


        void currCustomersMenu(string endpoint)
        {
            Console.Clear();
            Console.WriteLine("Our customers: ");
            var currcustomers = restService.Get<object>(endpoint);
            foreach (var item in currcustomers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }


        void olderCustomersMenu(string endpoint)
        {
            Console.Clear();
            Console.WriteLine("Our customers above the age of 50: ");
            var oldcustomers = restService.Get<object>(endpoint);
            foreach (var item in oldcustomers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }

        void tolstoyMenu(string endpoint)
        {
            Console.Clear();
            Console.WriteLine("Books of Lev Tolstoy: ");
            var tolstoy = restService.Get<object>(endpoint);
            foreach (var item in tolstoy)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }
}
