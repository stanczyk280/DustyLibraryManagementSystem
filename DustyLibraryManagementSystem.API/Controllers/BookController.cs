using DustyLibraryManagementSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DustyLibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : RavenController
    {
        private readonly string collectionName = "books/";

        public BookController(IAsyncDocumentSession Session) : base(Session)
        {
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<Book>> Get()
        {
            var books = await session
                .Query<Book>()
                .ToListAsync();
            return books;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<Book> Get(string id)
        {
            id = collectionName + id;
            var book = await session.LoadAsync<Book>(id);
            return book;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task Post([FromBody] Book newBook)
        {
            await session.StoreAsync(newBook);
            await session.SaveChangesAsync();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            session.Delete(id);
            await session.SaveChangesAsync();
        }
    }
}