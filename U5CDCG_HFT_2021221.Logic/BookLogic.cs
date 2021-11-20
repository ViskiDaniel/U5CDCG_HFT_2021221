using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;
using U5CDCG_HFT_2021221.Repository;

namespace U5CDCG_HFT_2021221.Logic
{
    public class BookLogic : IBookLogic
    {
        IBookRepository BookRep;

        public BookLogic(IBookRepository bookrep)
        {
            BookRep = bookrep;
        }

        public void Create(Book book)
        {
            if (book.Author == null)
            {
                throw new NullReferenceException();
            }
            else if (book.Title == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                BookRep.Create(book);
            }
            
        }

        public void Delete(int bookId)
        {
            if (bookId < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                BookRep.Delete(bookId);
            }

        }

        public Book Read(int bookId)
        {
            if (bookId < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return BookRep.Read(bookId);
            }
            
        }

        public IEnumerable<Book> ReadAll()
        {
            return BookRep.ReadAll();
        }

        public void Update(Book book)
        {
            if (book == null)
            {
                throw new NullReferenceException();
            }
            else if (book.Author == null)
            {
                throw new NullReferenceException();
            }
            else if (book.Title == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                BookRep.Update(book);
            }
            
        }
    }
}
