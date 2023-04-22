using Raven.Identity;

namespace DustyLibraryManagementSystem.Domain
{
    public class AppUser : IdentityUser
    {
        public const string AdminRole = "Admin";
        public const string ManagerRole = "Manager";
        public string FullName { get; set; }
    }
}