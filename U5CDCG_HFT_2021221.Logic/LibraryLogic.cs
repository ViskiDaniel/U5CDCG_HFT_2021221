using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;
using U5CDCG_HFT_2021221.Repository;

namespace U5CDCG_HFT_2021221.Logic
{
    class LibraryLogic : ILibraryLogic
    {
        ILibraryRepository LibRepo;

        public LibraryLogic(ILibraryRepository librep)
        {
            LibRepo = librep;
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
                LibRepo.Create(library);
            }
            
        }

        public void Delete(int libraryId)
        {
            if(libraryId <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                LibRepo.Delete(libraryId);
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
                return LibRepo.Read(libraryId);
            }
        }

        public IQueryable<Library> ReadAll()
        {
            return LibRepo.ReadAll();
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
            else if(library.BookId <=0 || library.CustomerId <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                LibRepo.Update(library);
            }
            
        }
    }
}
