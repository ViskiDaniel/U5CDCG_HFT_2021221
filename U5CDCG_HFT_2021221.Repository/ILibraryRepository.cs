using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;
using U5CDCG_HFT_2021221.Data;

namespace U5CDCG_HFT_2021221.Repository
{
    interface ILibraryRepository
    {
        void Create(Library libraryId);
        void Delete(int libraryId);
        Library Read(int libraryId);
        IQueryable<Library> ReadAll();
        void Update(Library library);
    }
}
