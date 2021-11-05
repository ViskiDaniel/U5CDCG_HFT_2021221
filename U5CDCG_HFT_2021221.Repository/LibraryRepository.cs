using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_HFT_2021221.Repository
{
    class LibraryRepository:ILibraryRepository
    {
        LibraryRepository context;
        public LibraryRepository(LibraryRepository context)
        {
            this.context = context;
        }

        public void Create(Library libraryId)
        {
            throw new NotImplementedException();
        }

        public void Delete(int libraryId)
        {
            throw new NotImplementedException();
        }

        public Library Read(int libraryId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Library> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Library library)
        {
            throw new NotImplementedException();
        }
    }
}
