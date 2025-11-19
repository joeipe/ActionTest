using ActionTest.API.Models;

namespace ActionTest.API.Services
{
    public class ContactService : IContactService
    {
        private readonly IConfiguration _configuration;

        public ContactService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            var data = await Task.FromResult(new List<Contact> { new Contact { Id = 1, FirstName = "Joe", LastName = "Ipe", DoB = "26/04/1981" } });
            return data;
        }

        public async Task<string> GetEnvironmentAsync()
        {
            var envName = await Task.FromResult(_configuration["EnvironmentName"]);
            return envName;
        }
    }
}
