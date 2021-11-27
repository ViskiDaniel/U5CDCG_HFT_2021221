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


            Book fakeBook1 = new Book { Author = "John Tolstoy", Title = "Example" };
            Book fakeBook2 = new Book { Author = "Jane Smith", Title = "Fight" };
            Customer fakeCustomer1 = new Customer { Name = "Jane Doe", Age = 20, Email = "janedoe@gmail.com" };
            Customer fakeCustomer2 = new Customer { Name = "John Doe", Age = 52, Email = "johndoe@gmail.hu", Gender=true };

            mockLibraryRepository.Setup(x => x.Create(It.IsAny<Library>()));
            mockLibraryRepository.Setup(x => x.ReadAll())
            .Returns(new List<Library>()
               {
                new Library { Book=fakeBook1, Customer=fakeCustomer1 },
                new Library {Book=fakeBook2, Customer=fakeCustomer2 }
                }
            .AsQueryable());

            mockBookRepository.Setup(y => y.Create(It.IsAny<Book>()));
            mockBookRepository.Setup(y => y.ReadAll())
                .Returns(new List<Book>()
                {
                    new Book{ Author=fakeBook1.Author, Title=fakeBook1.Title },
                    new Book{ Author=fakeBook2.Author,  Title=fakeBook2.Title }
                }.AsQueryable());

            mockCustomerRepository.Setup(z => z.Create(It.IsAny<Customer>()));
            mockCustomerRepository.Setup(z => z.ReadAll())
                .Returns(new List<Customer>()
                {
                    new Customer { Name=fakeCustomer2.Name,Age = fakeCustomer2.Age,Email = fakeCustomer2.Email },
                    new Customer { Name = fakeCustomer2.Name, Age = fakeCustomer2.Age, Email = fakeCustomer2.Email }
                }.AsQueryable());


            libLog = new LibraryLogic(mockLibraryRepository.Object, mockBookRepository.Object, mockCustomerRepository.Object);
            bookLog = new BookLogic(mockBookRepository.Object);
            custLog = new CustomerLogic(mockCustomerRepository.Object);
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
            Assert.That(expected[0], Is.EqualTo(new KeyValuePair<string, int>("Nő", 1)));
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
        public void currentCustomers()
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
        public void LibraryTest(int customerId, int bookid, bool result)
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
    }
}
