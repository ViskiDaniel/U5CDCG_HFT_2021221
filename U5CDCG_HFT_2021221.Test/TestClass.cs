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
        LibraryLogic liblog;
        public TestClass()
        {


            Mock<ILibraryRepository> mockLibraryRepository = new Mock<ILibraryRepository>();
            Mock<IBookRepository> mockBookRepository = new Mock<IBookRepository>();
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();


            Book fakeBook1 = new Book { Author = "John Tolstoy", Title = "Example" };
            Book fakeBook2 = new Book { Author = "Jane Smith", Title = "Fight" };
            Customer fakeCustomer1 = new Customer { Name = "Jane Doe", Age = 20, Email = "janedoe@gmail.com" };
            Customer fakeCustomer2 = new Customer { Name = "John Doe", Age = 22, Email = "johndoe@gmail.hu" };

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
                    new Customer{ Name=fakeCustomer1.Name, Age=fakeCustomer1.Age, Email=fakeCustomer1.Email},
                    new Customer{ Name=fakeCustomer2.Name, Age=fakeCustomer2.Age, Email=fakeCustomer2.Email}
                }.AsQueryable());


            liblog = new LibraryLogic(mockLibraryRepository.Object, mockBookRepository.Object, mockCustomerRepository.Object);
        }

        [Test]
        public void huTest()
        {
            
            var expected = liblog.authorName();
            Assert.That(expected, Is.SameAs(liblog.authorName()));
        }

        [Test]
        public void CreateTest()
        {

        }
    }
}
