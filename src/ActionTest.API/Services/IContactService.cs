using ActionTest.API.Models;

namespace ActionTest.API.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetContactsAsync();
        Task<string> GetEnvironmentAsync();
    }
}
