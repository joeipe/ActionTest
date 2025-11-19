using ActionTest.API.Models;
using ActionTest.API.Services;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;

namespace ActionTest.UnitTests.Services
{
    public class ContactServiceShould
    {
        private static IConfiguration _configuration = null!;

        public ContactServiceShould()
        {
            var inMemorySettings = new Dictionary<string, string> 
            {
                {"EnvironmentName", "Tst"}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }

        [Fact]
        public async void GetContactsSuccessfully()
        {
            //Arrange
            var data = new List<Contact> { new Contact { Id = 1, FirstName = "Joe", LastName = "Ipe", DoB = "26/04/1981" } };

            //Act
            var sut = new ContactService(_configuration);
            var result = await sut.GetContactsAsync();

            //Assert
            result.Count().Should().Be(1);
            result.First().FirstName.Should().Be("Joe");
        }

        [Fact]
        public async void GetEnvironmentSuccessfully()
        {
            //Arrange
            var data = "Tst";

            //Act
            var sut = new ContactService(_configuration);
            var result = await sut.GetEnvironmentAsync();

            //Assert
            result.Should().BeSameAs(data);
        }
    }
}