using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_HFT_2021221.Logic
{
    interface ILibraryLogic
    {
        void Create(Library libraryId);
        void Delete(int libraryId);
        Library Read(int libraryId);
        IQueryable<Library> ReadAll();
        void Update(Library library);
    }
}
