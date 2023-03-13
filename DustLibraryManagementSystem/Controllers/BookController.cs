using DustyLibraryManagementSystem.Domain;
using DustyLibraryManagementSystem.Indexes;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace DustyLibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IAsyncDocumentSession session;

        public BookController(IAsyncDocumentSession Session)
        {
            session = Session;
        }

        public async Task<IActionResult> GetBooks()
        {
            var books = await session
                .Query<Book>()
                .ToListAsync();
            return View(books);
        }

        public async Task<IActionResult> GetAllBooksByTitleAndAuthor()
        {
            var books = await session
                    .Query<Book, Books_ByTitleAndAuthor>()
                    .ToListAsync();
            return View(books);
        }

        public async Task<IActionResult> GetBook(string id)
        {
            var book = await session.LoadAsync<Book>(id);
            return View(book);
        }

        public async Task<bool> DeleteBook(string id)
        {
            var book = await session.LoadAsync<Book>(id);

            try
            {
                session.Delete(book);
                await session.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new NullReferenceException(id);
            }
        }
    }
}