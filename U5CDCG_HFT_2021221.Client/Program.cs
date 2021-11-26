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

            Console.WriteLine(db.Books.Count());

            LibraryLogic liblog = new LibraryLogic(new LibraryRepository(db), new BookRepository(db), new CustomerRepository(db));

            var zzz = liblog.olderCustomers();

            List<Customer> zzz2=zzz.ToList();
            foreach (var item in zzz2)
            {
                Console.WriteLine("{0} --- {1}", item.Age, item.Name);
            }


            var ddd = liblog.currentCustomers();

            Console.WriteLine("---------------------------------------------------");

            List<Customer> ddd2 = ddd.ToList();

            foreach (var item in ddd2)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("---------------------------------------------------");

            var ooo = liblog.currTaken();

            List<Book> ooo2 = ooo.ToList();
            foreach (var item in ooo2)
            {
                Console.WriteLine("{0} --- {1}", item.Author, item.Title);
            }

            Console.WriteLine("---------------------------------------------------");
            var qqq = liblog.emailHu().ToList();
            foreach (var item in qqq)
            {
                Console.WriteLine("{0} - {1}", item.Name, item.Email);
            }
            Console.WriteLine("---------------------------------------------------");

            var ttt = liblog.authorName().ToList();
            foreach (var item in ttt)
            {
                Console.WriteLine("{0} --- {1}", item.Author, item.Title);
            }


            

        }
    }
}
