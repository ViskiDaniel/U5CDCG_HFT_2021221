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


            Book fakeBook1 = new Book { Author = "John Smith", Title = "Example" };
            Book fakeBook2 = new Book { Author = "Jane Smith", Title = "Fight" };
            Customer fakeCustomer1 = new Customer { Name = "Jane Doe", Age = 20, Email = "janedoe@gmail.com" };
            Customer fakeCustomer2 = new Customer { Name = "John Doe", Age = 22, Email = "johndoe@gmail.com" };

            mockLibraryRepository.Setup(x => x.Create(It.IsAny<Library>()));
            mockLibraryRepository.Setup(x => x.ReadAll())
            .Returns(new List<Library>() 
            {new Library { Book=fakeBook1, Customer=fakeCustomer1 }, 
             new Library {Book=fakeBook2, Customer=fakeCustomer2 }}
            .AsQueryable());

            liblog = new LibraryLogic(mockLibraryRepository.Object, mockBookRepository.Object, mockCustomerRepository.Object);
        }

    }
}
