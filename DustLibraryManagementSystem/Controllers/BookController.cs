using DustyLibraryManagementSystem.Domain;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace DustLibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IAsyncDocumentSession session;

        public BookController(IAsyncDocumentSession Session)
        {
            session = Session;
        }

        public async Task<IActionResult> Index()
        {
            var books = await session
                .Query<Book>()
                .ToListAsync();
            return View(books);
        }
    }
}