using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_HFT_2021221.Data
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Library> Libraries { get; set; }

        public LibraryDbContext()
        {
            this.Database.EnsureCreated();
        }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\U5CDCG_HFT_2021221_Database.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity
                .HasMany(b => b.Library)
                .WithOne(l => l.Book)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity
                .HasMany(c => c.Library)
                .WithOne(l => l.Customer)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity
                .HasOne(l=>l.Book)
                .WithMany(b=>b.Library)
                .HasForeignKey(l=>l.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity
                .HasOne(l=>l.Customer)
                .WithMany(b=>b.Library)
                .HasForeignKey(l=>l.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            var BookList = new List<Book> {
              new Book { BookId = 1, Author = "J. R. R. Tolkien", Title = "The Lord of the Rings", },
              new Book { BookId = 2, Author = "Emily Bronte", Title = "Wuthering Heights", },
              new Book { BookId = 3, Author = "J. K. Rowling", Title = "Harry Potter and the Order of the Phoenix", },
              new Book { BookId = 4, Author = "F. Scott Fitzgerld", Title = "The Great Gatsby", },
              new Book { BookId = 5, Author = "Herman Melville", Title = "Moby Dick", },
              new Book { BookId = 6, Author = "Daniel Defoe", Title = "Robinson Crusoe", },
              new Book { BookId = 7, Author = "Lev Tolstoy", Title = "War and Peace", },
              new Book { BookId = 8, Author = "Mark Twain", Title = "Huckleberry Finn", },
              new Book { BookId = 9, Author = "George Orwell", Title = "1984", },
              new Book { BookId = 10, Author = "Harper Lee", Title = "To Kill a Mockingbird", },
              new Book { BookId = 11, Author = "Charles Dickens", Title = "David Copperfield", },
              new Book { BookId = 12, Author = "Lev Tolstoy", Title = "Anna Karenina", },
              new Book { BookId = 13, Author = "Miguel de Cervantes", Title = "Don Quixote", },
              new Book { BookId = 14, Author = "Charlotte Bronte", Title = "Jane Eyre", },
              new Book { BookId = 15, Author = "Eric Knight", Title = "Lassie", },
              new Book { BookId = 16, Author = "Stendhal", Title = "The Red and the Black", },
              new Book { BookId = 17, Author = "Stephen King", Title = "It", },
              new Book { BookId = 18, Author = "James Joyce", Title = "Ulysses", },
              new Book { BookId = 19, Author = "Fyodor Dotoevsky", Title = "Crime and Punishment", },
              new Book { BookId = 20, Author = "Mary Shelley", Title = "Frankenstein", },
            };

            Customer c1 = new Customer() { CustomerId = 1, Name = "Kovács Jenő", Age = 23 };
            Customer c2 = new Customer() { CustomerId = 2, Name = "Tóth Géza", Age = 43 };
            Customer c3 = new Customer() { CustomerId = 3, Name = "Nagy Klaudia", Age = 52 };
            Customer c4 = new Customer() { CustomerId = 4, Name = "Kiss Kálmán", Age = 19 };
            Customer c5 = new Customer() { CustomerId = 5, Name = "Szabó Elemér", Age = 62 };
            Customer c6 = new Customer() { CustomerId = 6, Name = "Fodor József", Age = 27 };
            Customer c7 = new Customer() { CustomerId = 7, Name = "Horváth Ildikó", Age = 35 };
            Customer c8 = new Customer() { CustomerId = 8, Name = "Molnár Krisztina", Age = 31 };
            Customer c9 = new Customer() { CustomerId = 9, Name = "Kádár Béla", Age = 46 };
            Customer c10 = new Customer() { CustomerId = 10, Name = "Papp Károly", Age = 19 };
            Customer c11 = new Customer() { CustomerId = 11, Name = "Varga Dezső", Age = 27 };
            Customer c12 = new Customer() { CustomerId = 12, Name = "Juhász Ákos", Age = 34 };
            Customer c13 = new Customer() { CustomerId = 13, Name = "Farkas Anita", Age = 48 };
            Customer c14 = new Customer() { CustomerId = 14, Name = "Rácz Anna", Age = 57 };
            Customer c15 = new Customer() { CustomerId = 15, Name = "Fekete Péter", Age = 50 };
            Customer c16 = new Customer() { CustomerId = 16, Name = "Nemes Dénes", Age = 65 };
            Customer c17 = new Customer() { CustomerId = 17, Name = "Szalai Domonkos", Age = 24 };
            Customer c18 = new Customer() { CustomerId = 18, Name = "Fehér Viktória", Age = 75 };
            Customer c19 = new Customer() { CustomerId = 19, Name = "Orosz Tamás", Age = 51 };
            Customer c20 = new Customer() { CustomerId = 20, Name = "Vass Bendegúz", Age = 39};

            Library l1 = new Library() { ActionID = 1, BookId = BookList[15].BookId, CustomerId = c1.CustomerId };
            Library l2 = new Library() { ActionID = 2, BookId = BookList[5].BookId, CustomerId = c2.CustomerId };
            Library l3 = new Library() { ActionID = 3, BookId = BookList[11].BookId, CustomerId = c3.CustomerId };
            Library l4 = new Library() { ActionID = 4, BookId = BookList[12].BookId, CustomerId = c4.CustomerId };
            Library l5 = new Library() { ActionID = 5, BookId = BookList[19].BookId, CustomerId = c5.CustomerId };
            Library l6 = new Library() { ActionID = 6, BookId = BookList[17].BookId, CustomerId = c6.CustomerId };
            Library l7 = new Library() { ActionID = 7, BookId = BookList[4].BookId, CustomerId = c7.CustomerId };
            Library l8 = new Library() { ActionID = 8, BookId = BookList[1].BookId, CustomerId = c8.CustomerId };
            Library l9 = new Library() { ActionID = 9, BookId = BookList[8].BookId, CustomerId = c9.CustomerId };
            Library l10 = new Library() { ActionID = 10, BookId = BookList[3].BookId, CustomerId = c10.CustomerId };
            Library l11 = new Library() { ActionID = 11, BookId = BookList[16].BookId, CustomerId = c11.CustomerId };
            Library l12 = new Library() { ActionID = 12, BookId = BookList[10].BookId, CustomerId = c12.CustomerId };
            Library l13 = new Library() { ActionID = 13, BookId = BookList[6].BookId, CustomerId = c13.CustomerId };
            Library l14 = new Library() { ActionID = 14, BookId = BookList[7].BookId, CustomerId = c14.CustomerId };
            Library l15 = new Library() { ActionID = 15, BookId = BookList[2].BookId, CustomerId = c15.CustomerId };

            modelBuilder.Entity<Book>().HasData(BookList);
            modelBuilder.Entity<Customer>().HasData(c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c9, c20);
            modelBuilder.Entity<Library>().HasData(l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15);

        }

    }
}
