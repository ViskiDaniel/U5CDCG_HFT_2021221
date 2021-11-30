using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;
using U5CDCG_HFT_2021221.Repository;


namespace U5CDCG_HFT_2021221.Logic
{
    public class LibraryLogic : ILibraryLogic
    {
        ILibraryRepository libRepo;
        IBookRepository bookRepo;
        ICustomerRepository custRepo;

        public LibraryLogic(ILibraryRepository librep, IBookRepository bookrep, ICustomerRepository cusrep)
        {
            libRepo = librep;
            bookRepo = bookrep;
            custRepo = cusrep;
        }

        public void Create(Library library)
        {
            if (library.BookId <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (library.CustomerId <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                libRepo.Create(library);
            }

        }

        public void Delete(int libraryId)
        {
            if (libraryId <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                libRepo.Delete(libraryId);
            }

        }

        public Library Read(int libraryId)
        {
            if (libraryId <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return libRepo.Read(libraryId);
            }
        }

        public IEnumerable<Library> ReadAll()
        {
            return libRepo.ReadAll();
        }

        public void Update(Library library)
        {
            if (library == null)
            {
                throw new NullReferenceException();
            }
            else if (library.BookId <= 0 || library.CustomerId <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                libRepo.Update(library);
            }
        }

        public IEnumerable<object> olderCustomers()
        {
            var oldcus = from x in libRepo.ReadAll()
                             //join z in custRepo.ReadAll()
                             //on x.CustomerId equals z.CustomerId
                         where x.Customer.Age > 50
                         select new
                         {
                             _NAME = x.Customer.Name,
                             _AGE=x.Customer.Age,
                             _TITLE=x.Book.Title
                         };
            return oldcus;
        }




        public IEnumerable<KeyValuePair<string, string>> currentCustomers()
        {
            var current = from x in libRepo.ReadAll()
                          //join z in custRepo.ReadAll()
                          //on x.CustomerId equals z.CustomerId
                          //where x.Customer.CustomerId == z.CustomerId
                          select new KeyValuePair<string, string>
                          (x.Customer.Name, x.Book.Title);
           return current;
        }

        public IEnumerable<KeyValuePair<string, int>> genderAvg()
        {
            var avg = from x in libRepo.ReadAll()
                      group x by x.Customer.Gender
                      into g
                      select new  KeyValuePair<string, int>(newValue(g.Key), g.Count());                      
                     
            return avg;
        }

        static string newValue(bool value)
        {
            if (value)
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }

        public IEnumerable<object> emailHu()
        {
            var mail = from x in libRepo.ReadAll()
                           //join z in custRepo.ReadAll()
                           //on x.CustomerId equals z.CustomerId
                       where x.Customer.Email.ToUpper().Contains("HU")
                       select new { 
                           _NAME=x.Customer.Name,
                           _EMAIL=x.Customer.Email,
                           _TITLE=x.Book.Title
                       };

            return mail;
        }

        public IEnumerable<KeyValuePair<string, string>> booksOfTolstoy()
        {
            var aut = from x in libRepo.ReadAll()
                      //join z in bookRepo.ReadAll()
                      //on x.BookId equals z.BookId
                      where x.Book.Author.ToUpper().Contains("TOLSTOY")
                      select new KeyValuePair<string, string>
                      (x.Customer.Name, x.Book.Title);
            return aut;

        }






    }
}