using CheckHealth.Domain.Commons;
using CheckHealth.Domain.Enums;

namespace CheckHealth.Domain.Entities
{
    public class User : Auditable
    {
        public UserRole userRole { get; set; }
        public Premium IsPremium { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
