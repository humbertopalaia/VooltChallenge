using Moq;
using VooltChallenge.Domain.Dtos;
using VooltChallenge.Domain.Entities;
using VooltChallenge.Domain.Entities.Blocks;
using VooltChallenge.Infra.Exceptions;
using VooltChallenge.Infra.Repository;
using VooltChallenge.Service;

namespace VooltChallenge.Test.Services;
public class PartitionBlocksServiceTest
{

    [Fact]
    public void Create_PartitionBlock_ReturnsNewEntity()
    {
        //Arrange
        Mock<IRepository<PartitionBlocks>> repositoryMock = new();

        var createdEntity = new PartitionBlocks
        {
            Key = string.Empty,
            ServicesBlocks = [],
            WebSiteHeaderBlocks = [],
            WebSiteHeroBlocks = []
        };

        const string key = "TestKey";
        

        repositoryMock.Setup(repository => repository.Save(It.IsAny<PartitionBlocks>()))
            .Callback(new InvocationAction(invocation =>
            {
                createdEntity.Key = key;
            })
        ).Returns(() => createdEntity);


        var customerService = new PartitionBlocksService(repositoryMock.Object);

        //Act
        var resultEntity = customerService.Create(key);

        //Assert
        Assert.Equal(key, resultEntity.Key);
    }

    [Fact]
    public void Create_PartitionBlock_WhenKeyHasBlankSpace_ThrowsException()
    {
        //Arrange
        Mock<IRepository<PartitionBlocks>> repositoryMock = new();

        const string key = "Test Key";

        var customerService = new PartitionBlocksService(repositoryMock.Object);

        //Act and Assert
        Assert.Throws<NotAcceptableException>(() => customerService.Create(key));
    }

    [Fact]
    public void Create_PartitionBlock_WhenKeyAlreadyExists_ThrowsException()
    {
        //Arrange
        const string key = "TestKey";
        
        Mock<IRepository<PartitionBlocks>> repositoryMock = new();

        var foundEntity = new PartitionBlocks { Key = key, ServicesBlocks = [], WebSiteHeaderBlocks = [], WebSiteHeroBlocks = [] };

        repositoryMock.Setup(repository => repository.GetByKey(It.IsAny<string>())).Returns(() => foundEntity);

        var customerService = new PartitionBlocksService(repositoryMock.Object);

        //Act and Assert
        Assert.Throws<NotAcceptableException>(() => customerService.Create(key));
    }


    //[Fact]
    //public void Delete_Customer_Successfull()
    //{
    //    //Arrange
    //    Mock<IRepository<Customer>> repositoryMock = new();

    //    var customersList = new List<Customer>();
    //    customersList = GetCustomerListMock();

    //    var foundEntity = new Customer { Id = 0, Name = "Test"};

    //    repositoryMock.Setup(repository => repository.Delete(It.IsAny<Customer>()))
    //        .Callback(new InvocationAction(invocation =>
    //        {
    //            var entity = (Customer)invocation.Arguments[0];
    //            customersList.Remove(entity);
    //        })
    //    );

    //    repositoryMock.Setup(repository => repository.GetById(It.IsAny<int>()))
    //        .Callback(new InvocationAction(invocation =>
    //        {
    //            var id = (int)invocation.Arguments[0];
    //            foundEntity = customersList.Where(customer => customer.Id == id).FirstOrDefault();
    //        })
    //        ).Returns(() => foundEntity);

    //    var customerService = new CustomerService(repositoryMock.Object);

    //    //Act
    //    customerService.Delete(1);

    //    //Assert
    //    Assert.Single(customersList);
    //    Assert.Equal(2, customersList.First().Id);
    //}


    //[Fact]
    //public void Delete_Customer_ThrowsNotFound()
    //{
    //    //Arrange
    //    Mock<IRepository<Customer>> repositoryMock = new();

    //    repositoryMock.Setup(repository => repository.GetById(It.IsAny<int>()))
    //        .Returns(() => null);

    //    var customerService = new CustomerService(repositoryMock.Object);

    //    //Act / Assert
    //    Assert.Throws<NotFoundException>(() => customerService.Delete(99));
    //}

    //private static List<Customer> GetCustomerListMock()
    //{
    //    var mockList = new List<Customer>
    //    {
    //        new() { Id = 1, Name = "Test 1" },
    //        new() { Id = 2, Name = "Test 2" }
    //    };

    //    return mockList;
    //}
}
