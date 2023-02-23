using CheckHealth.Domain.Commons;
using CheckHealth.Domain.Enums;

namespace CheckHealth.Domain.Entities
{
    public class UserPremium : Auditable
    {
        public string UserName { get; set; }
        public long UserId { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public Genders Gender { get; set; }
        public int Walking { get; set; }
        public decimal Water { get; set; }
        public Activities Activity { get; set; }
        public string SleepTime { get; set; }
        public decimal Heartrate { get; set; }
        public EatMode EatType { get; set; }
        public string ReadingBook { get; set; }
        public int ShowerTime { get; set; }
        public decimal UsePhone { get; set; }
        public Payment PaymentType { get; set; }
        public Premium IsPremium { get; set; }
    }
}
