using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_HFT_2021221.Logic
{
    public interface IBookLogic
    {
        void Create(Book book);
        void Delete(int bookId);
        Book Read(int bookId);
        IEnumerable<Book> ReadAll();
        void Update(Book book);

    }
}
