using ActionTest.API.Models;
using ActionTest.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionTest.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactService _contactService;

        public ContactsController(
            ILogger<ContactsController> logger,
            IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        [HttpGet()]
        public async Task<ActionResult> GetContacts()
        {
            var data = await _contactService.GetContactsAsync();
            return Ok(data);
        }

        [HttpGet()]
        public async Task<ActionResult> GetEnvironment()
        {
            var envName = await _contactService.GetEnvironmentAsync();
            return Ok(envName);
        }
    }
}
