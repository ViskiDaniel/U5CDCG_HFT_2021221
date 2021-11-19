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
            LibRepo.Create(library);
        }

        public void Delete(int libraryId)
        {
            LibRepo.Delete(libraryId);
        }

        public Library Read(int libraryId)
        {
            return LibRepo.Read(libraryId);
        }

        public IQueryable<Library> ReadAll()
        {
            return LibRepo.ReadAll();
        }

        public void Update(Library library)
        {
            LibRepo.Update(library);
        }
    }
}
