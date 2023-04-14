using DustyLibraryManagementSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DustyLibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IAsyncDocumentSession session;
        private readonly string collectionName = "employees/";

        public EmployeeController(IAsyncDocumentSession Session)
        {
            session = Session;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            var employees = await session
                .Query<Employee>()
                .ToListAsync();
            return employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(string id)
        {
            id = collectionName + id;
            var employee = await session.LoadAsync<Employee>(id);
            return employee;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async void Post([FromBody] Employee newEmployee)
        {
            await session.StoreAsync(newEmployee);
            await session.SaveChangesAsync();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            id = collectionName + id;
            session.Delete(id);
            await session.SaveChangesAsync();
        }
    }
}