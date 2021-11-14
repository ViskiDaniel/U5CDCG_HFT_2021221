using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Data;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_HFT_2021221.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        LibraryDbContext context;
        public LibraryRepository(LibraryDbContext context)
        {
            this.context = context;
        }

        public void Create(Library library)
        {
            context.Libraries.Add(library);
            context.SaveChanges();
        }

        public void Delete(int libraryId)
        {
            context.Remove(Read(libraryId));
        }

        public Library Read(int libraryId)
        {
            return context.Libraries.FirstOrDefault(t => t.ActionID == libraryId);
        }

        public IQueryable<Library> ReadAll()
        {
            return context.Libraries;
        }

        public void Update(Library library)
        {
            var updated = Read(library.ActionID);
            updated.ActionID = library.ActionID;
            context.SaveChanges();
        }
    }
}
