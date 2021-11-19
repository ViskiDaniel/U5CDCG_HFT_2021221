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
            else if (library.Book == null)
            {
                throw new NullReferenceException();
            }
            else if (library.Customer == null)
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

        public IEnumerable<Customer> olderCustomers()
        {
            var oldcus = from x in libRepo.ReadAll()
                         join z in custRepo.ReadAll()
                         on x.CustomerId equals z.CustomerId
                         where z.Age > 50
                         select z;
            return oldcus;
        }

        public IEnumerable<Customer> currentCustomers()
        {
            var current = from x in libRepo.ReadAll()
                      join z in custRepo.ReadAll()
                      on x.CustomerId equals z.CustomerId
                      where x.Customer.CustomerId==z.CustomerId
                      select z;
           return current;
        }

        public IEnumerable<Book> currTaken()
        {
            var tkn = from x in libRepo.ReadAll()
                      join z in bookRepo.ReadAll()
                      on x.BookId equals z.BookId
                      where z.BookId == x.Book.BookId
                      orderby z.Author
                      select z;
            return tkn;
        }

        public IEnumerable<Customer> emailHu()
        {
            var mail = from x in libRepo.ReadAll()
                       join z in custRepo.ReadAll()
                       on x.CustomerId equals z.CustomerId
                       where z.Email.ToUpper().Contains("HU")
                       select z;

            return mail;
        }






    }
}