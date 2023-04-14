using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustyLibraryManagementSystem.Domain
{
    public class BookQuantity
    {
        public uint Quantity { get; set; }
        public uint Borrowed { get; set; }

        public uint Available { get => Quantity - Borrowed; }
    }

    public class Book
    {
        public string Id { get; set; }
        public BookQuantity BookQuantity { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime Published { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}