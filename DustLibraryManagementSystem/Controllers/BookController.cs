using DustyLibraryManagementSystem.Domain;
using DustyLibraryManagementSystem.Indexes;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System.Net;

namespace DustyLibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IAsyncDocumentSession session;

        public BookController(IAsyncDocumentSession Session)
        {
            session = Session;
        }

        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await session
                .Query<Book>()
                .ToListAsync();
            return View(books);
        }

        public async Task<ActionResult<List<Book>>> GetAllBooksByTitleAndAuthor()
        {
            var books = await session
                    .Query<Book, Books_ByTitleAndAuthor>()
                    .ToListAsync();
            return View(books);
        }

        public async Task<ActionResult<Book>> GetBook(string id)
        {
            var book = await session.LoadAsync<Book>(id);
            return book;
        }

        public async Task<ActionResult> DeleteBook(string? id)
        {
            var book = await session.LoadAsync<Book>(id);
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteBookConfirmed(string id)
        {
            var book = await session.LoadAsync<Book>(id);
            session.Delete(book);
            await session.SaveChangesAsync();
            return View();
        }
    }
}