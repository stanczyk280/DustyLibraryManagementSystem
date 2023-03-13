using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustyLibraryManagementSystem.Domain
{
    public class Client
    {
        public Person Person { get; set; }
        public Rental Rental { get; set; }
    }
}