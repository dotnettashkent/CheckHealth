using CheckHealth.Domain.Enums;

namespace CheckHealth.Service.DTOs
{
    public class UserIsNotPremiumDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public long UserId { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public Genders Gender { get; set; }
        public Premium IsPremium { get; set; }
    }

}
