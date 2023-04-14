using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustyLibraryManagementSystem.Domain
{
    public class Rental
    {
        public string Id { get; set; }
        public string BookId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}