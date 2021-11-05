using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;
using U5CDCG_HFT_2021221.Data;

namespace U5CDCG_HFT_2021221.Repository
{
    class BookRepository : IBookRepository
    {
        LibraryDbContext context;

        public BookRepository(LibraryDbContext context)
        {
            this.context = context;
        }
        public void Create(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void Delete(int bookId)
        {
            context.Remove(Read(bookId));

        }

        public Book Read(int bookId)
        {
            return context.Books.FirstOrDefault(t => t.BookId == bookId);
        }

        public IQueryable<Book> ReadAll()
        {
            return context.Books;
        }

        public void Update(Book book)
        {
            var updated = Read(book.BookId);
            updated.BookId = book.BookId;
            context.SaveChanges();
        }
    }
}
