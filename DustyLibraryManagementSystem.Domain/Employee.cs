using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustyLibraryManagementSystem.Domain
{
    public class Employee
    {
        public Person Person { get; set; }
        public string AccessLevel { get; set; }
    }
}