using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;
using U5CDCG_HFT_2021221.Repository;

namespace U5CDCG_HFT_2021221.Logic
{
    class BookLogic : IBookLogic
    {
        IBookRepository BookRep;

        public BookLogic(IBookRepository bookrep)
        {
            BookRep = bookrep;
        }

        public void Create(Book book)
        {
            BookRep.Create(book);
        }

        public void Delete(int bookId)
        {
            BookRep.Delete(bookId);
        }

        public Book Read(int bookId)
        {
            return BookRep.Read(bookId);
        }

        public IQueryable<Book> ReadAll()
        {
            return BookRep.ReadAll();
        }

        public void Update(Book book)
        {
            BookRep.Update(book);
        }
    }
}
