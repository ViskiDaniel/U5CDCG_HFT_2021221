using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_HFT_2021221.Logic
{
    public interface ILibraryLogic
    {
        void Create(Library libraryId);
        void Delete(int libraryId);
        Library Read(int libraryId);
        IEnumerable<Library> ReadAll();
        void Update(Library library);
        IEnumerable<KeyValuePair<string, string>> booksOfTolstoy();
        IEnumerable<KeyValuePair<string, string>> currentCustomers();
        IEnumerable<object> olderCustomers();
        IEnumerable<object> emailHu();
        IEnumerable<KeyValuePair<string, int>> genderAvg();
    }
}
