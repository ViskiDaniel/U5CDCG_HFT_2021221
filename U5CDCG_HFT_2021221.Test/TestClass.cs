using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Logic;
using U5CDCG_HFT_2021221.Models;
using U5CDCG_HFT_2021221.Repository;

namespace U5CDCG_HFT_2021221.Test
{
    [TestFixture]
    class TestClass
    {
        LibraryLogic libLog;
        BookLogic bookLog;
        CustomerLogic custLog;
        public TestClass()
        {


            Mock<ILibraryRepository> mockLibraryRepository = new Mock<ILibraryRepository>();
            Mock<IBookRepository> mockBookRepository = new Mock<IBookRepository>();
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();


            Book fakeBook1 = new Book { Author = "John Tolstoy", Title = "Example", BookId=1 };
            Book fakeBook2 = new Book { Author = "Jane Smith", Title = "Fight", BookId=2 };
            Customer fakeCustomer1 = new Customer { Name = "Jane Doe", Age = 20, Email = "janedoe@gmail.com" };
            Customer fakeCustomer2 = new Customer { Name = "John Doe", Age = 52, Email = "johndoe@gmail.hu", Gender=true };

            mockLibraryRepository.Setup((x) => x.Create(It.IsAny<Library>()));
            mockLibraryRepository.Setup((x) => x.ReadAll())
            .Returns(new List<Library>()
               {
                new Library { Book=fakeBook1, Customer=fakeCustomer1 },
                new Library {Book=fakeBook2, Customer=fakeCustomer2 }
                }
            .AsQueryable());

            mockCustomerRepository.Setup(x => x.Create(It.IsAny<Customer>()));
            mockCustomerRepository.Setup(x => x.Read(1))
            .Returns(new Customer { Name = "Jane Doe", Age = 20, Email = "janedoe@gmail.com" });
            mockCustomerRepository.Setup(x => x.Read(2))
            .Returns(new Customer { Name = "John Doe", Age = 52, Email = "johndoe@gmail.hu", Gender = true });

            mockBookRepository.Setup((y) => y.Create(It.IsAny<Book>()));
            mockBookRepository.Setup((y) => y.ReadAll())
                .Returns(new List<Book>()
                {
                    new Book{ Author=fakeBook1.Author, Title=fakeBook1.Title, BookId=fakeBook1.BookId },
                    new Book{ Author=fakeBook2.Author,  Title=fakeBook2.Title, BookId=fakeBook2.BookId}
                }.AsQueryable());

            mockBookRepository.Setup(y => y.Create(It.IsAny<Book>()));
            mockBookRepository.Setup(y => y.Read(1)).Returns(new Book { Author = "John Tolstoy", Title = "Example", BookId = 1 });

            mockCustomerRepository.Setup((z) => z.Create(It.IsAny<Customer>()));
            mockCustomerRepository.Setup((z) => z.ReadAll())
                .Returns(new List<Customer>()
                {
                    new Customer { Name=fakeCustomer2.Name,Age = fakeCustomer2.Age,Email = fakeCustomer2.Email },
                    new Customer { Name = fakeCustomer2.Name, Age = fakeCustomer2.Age, Email = fakeCustomer2.Email }
                }.AsQueryable());

            mockLibraryRepository.Setup((x) => x.Create(It.IsAny<Library>()));
            mockLibraryRepository.Setup(x => x.Read(1))
            .Returns
            (new Library { ActionID = 1, Book = fakeBook1, Customer = fakeCustomer1, BookId=fakeBook1.BookId, CustomerId=fakeCustomer1.CustomerId  });


            libLog = new LibraryLogic(mockLibraryRepository.Object, mockBookRepository.Object, mockCustomerRepository.Object);
            bookLog = new BookLogic(mockBookRepository.Object);
            custLog = new CustomerLogic(mockCustomerRepository.Object);

            var v = bookLog.Read(1);
            var v2 = bookLog.ReadAll();
            ;
        }

        [Test]
        public void huTest()
        {            
            var expected = libLog.emailHu().ToList();
            Assert.That(expected[0].GetHashCode(), Is.EqualTo(new { _NAME = "John Doe", _EMAIL = "johndoe@gmail.hu", _TITLE = "Fight" }.GetHashCode()));
        }

        [Test]
        public void genderCountTest()
        {
            var expected = libLog.genderAvg().ToArray();
            Assert.That(expected[1], Is.EqualTo(new KeyValuePair<string, int>("Male", 1)));
        }

        [Test]
        public void authorNameTest()
        {
            var expected = libLog.booksOfTolstoy().ToArray();
            Assert.That(expected[0], Is.EqualTo(new KeyValuePair<string, string>("Jane Doe", "Example")));
        }

        [Test]
        public void oldTest()
        {
            var expected = libLog.olderCustomers().ToArray();
            Assert.That(expected[0].GetHashCode(), Is.EqualTo(new { _NAME = "John Doe", _AGE=52, _TITLE = "Fight" }.GetHashCode()));
        }

        [Test]
        public void currentCustomersTest()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("Jane Doe", "Example"));
            list.Add(new KeyValuePair<string, string>("John Doe", "Fight"));

            var expected = libLog.currentCustomers().ToList();
            Assert.That(expected, Is.EqualTo(list));
        }



        [TestCase("Author", "Title", true)]
        [TestCase("Author", null, false)]
        [TestCase(null, null, false)]
        [TestCase(null, "Title", false)]
        public void CreateBookTest(string name, string title, bool result)
        {
            if (result)
            {
                Assert.That(() =>
                {
                    bookLog.Create(new Book { Author = name, Title = title });
                }, Throws.Nothing);
            }
            else
            {
                Assert.That(() =>
                {
                    bookLog.Create(new Book { Author = name, Title = title });
                }, Throws.Exception);
            }
        }

        [TestCase("John Doe", 19, "johndoe@gmail.com", true, true)]
        [TestCase("John Doe", 19, null, true, false)]
        [TestCase("John Doe", 17, "johndoe@gmail.com", true, false)]
        [TestCase("John Doe", 19, "johndoe@gmail.commmmmmmmmmmmmmmmmmm", true, false)]
        [TestCase(null, 19, "johndoe@gmail.com", true, false)]
        [TestCase("John Doe", 19, "johndoezgmail.com", true, false)]
        public void CreateCustomerTest(string name, int age, string email, bool gender, bool result)
        {
            if (result)
            {
                Assert.That(() => { custLog.Create(new Customer { Name = name, Age = age, Email = email }); }, Throws.Nothing);
            }
            else
            {
                Assert.That(() => { custLog.Create(new Customer { Name = name, Age = age, Email = email }); }, Throws.Exception);
            }

        }

        [TestCase(1, 1, true)]
        [TestCase(-1, 1, false)]
        [TestCase(1, -1, false)]
        [TestCase(-1, -1, false)]
        [TestCase(null, -1, false)]
        [TestCase(-1, null, false)]
        [TestCase(null, null, false)]
        public void CreateLibraryTest(int customerId, int bookid, bool result)
        {
            if (result)
            {
                Assert.That(() => { libLog.Create(new Library { BookId = bookid, CustomerId = customerId }); }, Throws.Nothing);
            }
            else
            {
                Assert.That(() => { libLog.Create(new Library { BookId = bookid, CustomerId = customerId }); }, Throws.Exception);
            }
        }

        [Test]
        public void NullBookTest()
        {
            Assert.That(() => { bookLog.Create(new Book { Author = "Author", Title = "Title" }); }, Throws.Nothing);
            Assert.That(() => { bookLog.Create(new Book { }); }, Throws.Exception);
        }

        [Test]
        public void NullCustTest()
        {
            Assert.That(() => { custLog.Create(new Customer { Name = "John Doe", Age = 20, Email = "johndoe@gmail.com", Gender = true }); }, Throws.Nothing);
            Assert.That(() => { custLog.Create(new Customer { }); }, Throws.Exception);
        }

        [Test]
        public void NullLibTest()
        {
            Assert.That(() => { libLog.Create(new Library { CustomerId = 1, BookId = 1 }); }, Throws.Nothing);
            Assert.That(() => { libLog.Create(new Library { }); }, Throws.Exception);
        }
        
        [TestCase("John Tolstoyy", "Exxample", 1, true)]
        [TestCase(null, "Exxample", 1, false)]
        [TestCase("John Tolstoyy", null, 1, false)]
        [TestCase("John Tolstoyy", "Exxample", -1, false)]
        [TestCase("John Tolstoyy", "Exxample", 0, false)]
        [TestCase(null, null, null, false)]
        public void updateBookTest(string author, string title, int id, bool result)
        {
            

            Book fakeBook2 = new Book { Author = author, Title = title, BookId = id };

            if (result)
            {
                Assert.That(()=>bookLog.Update(fakeBook2), Throws.Nothing);
            }
            else
            {
                Assert.That(() => bookLog.Update(fakeBook2), Throws.Exception);
            }
        }

        [TestCase("John Doe", 19, "johndoe@gmail.com", true, true)]
        [TestCase("John Doe", 19, null, true, false)]
        [TestCase("John Doe", 17, "johndoe@gmail.com", true, false)]
        [TestCase("John Doe", 19, "johndoe@gmail.commmmmmmmmmmmmmmmmmm", true, false)]
        [TestCase(null, 19, "johndoe@gmail.com", true, false)]
        [TestCase("John Doe", 19, "johndoezgmail.com", true, false)]
        public void updateCustomerTest(string name, int age, string email, bool gender, bool result)
        {
            var expected = new Customer { Age = age, Email = email, Gender = gender, Name = name };

            if (result)
            {
                Assert.That(()=>custLog.Update(expected), Throws.Nothing);
            }
            else
            {
                Assert.That(() => custLog.Update(expected), Throws.Exception);

            }
        }

        [TestCase(1, 1, true)]
        [TestCase(-1, 1, false)]
        [TestCase(1, -1, false)]
        [TestCase(-1, -1, false)]
        [TestCase(null, -1, false)]
        [TestCase(-1, null, false)]
        [TestCase(null, null, false)]
        public void updateLibraryTest(int customerId, int bookid, bool result)
        {
            var expected=new Library { CustomerId = customerId, BookId = bookid, Book = new Book { Author = "John Tolstoy", Title = "Example", BookId = 1 }, Customer = new Customer { Name = "Jane Doe", Age = 20, Email = "janedoe@gmail.com" } };
        

            if (result)
            {
                Assert.That(() => libLog.Update(expected), Throws.Nothing);
            }
            else
            {
                Assert.That(() => libLog.Update(expected), Throws.Exception);
            }
        }

        [Test]
        public void customerReadTest()
        {
            var expected = new Customer { Name = "Jane Doe", Age = 20, Email = "janedoe@gmail.com" };

            Assert.That(custLog.Read(1).ToString().Equals(expected.ToString()));
        }

        [Test]
        public void bookReadTest()
        {
            var expected = new Book { Author = "John Tolstoy", Title = "Example", BookId = 1 };

            Assert.That(bookLog.Read(1).ToString().Equals(expected.ToString()));
        }

        [Test]
        public void libraryReadTest()
        {
            var book = new Book { Author = "John Tolstoy", Title = "Example", BookId = 1 };
            var customer = new Customer { Name = "Jane Doe", Age = 20, Email = "janedoe@gmail.com" };

            var expected = 
                new Library { ActionID = 1, 
                    Book = book ,
                    Customer = customer, 
                    BookId = book.BookId, CustomerId = customer.CustomerId };

            Assert.That(libLog.Read(1).ToString().Equals(expected.ToString()));
            
        }

}
}
