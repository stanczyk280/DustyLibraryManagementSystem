using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents.Session;

namespace DustyLibraryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RavenController : ControllerBase
    {
        public IAsyncDocumentSession session { get; private set; }

        public RavenController(IAsyncDocumentSession Session)
        {
            Session = session;
            session.Advanced.WaitForIndexesAfterSaveChanges(timeout: TimeSpan.FromSeconds(5), throwOnTimeout: false);
        }
    }
}