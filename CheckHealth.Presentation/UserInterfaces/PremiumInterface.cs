using CheckHealth.Domain.Entities;
using CheckHealth.Service.Services;

namespace CheckHealth.Presentation.UserInterfaces
{
    public class PremiumInterface
    {
        UserPremiumService service = new UserPremiumService();
        UserPremium premium = new UserPremium();

        public void PremiumCreate()
        {
            Console.WriteLine("Enter all data");
            Console.Write("Enter the user's username: ");
            premium.UserName = Console.ReadLine();

            Console.Write("Enter the user's sleep time (in minutes): ");
            premium.SleepTime = (Console.ReadLine());

            Console.Write("Enter the user's activity level (in minutes per day): ");
            premium.Activity = Domain.Enums.Activities.Hard;

            Console.Write("Enter the user's age: ");
            premium.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter the user's eat type (Vegan/Vegetarian/Non-vegetarian): ");
            premium.EatType = Domain.Enums.EatMode.FastFood;

            Console.Write("Enter the user's gender (Male/Female/Other): ");
            premium.Gender = Domain.Enums.Genders.Male;

            Console.Write("Enter the user's heart rate (in BPM): ");
            premium.Heartrate = int.Parse(Console.ReadLine());

            Console.Write("Enter the user's height (in cm): ");
            premium.Height = int.Parse(Console.ReadLine());

            Console.Write("Is the user a premium member? (Y/N): ");
            premium.IsPremium = Domain.Enums.Premium.IsPremium;

            Console.Write("Enter the user's payment type (Credit Card/PayPal): ");
            premium.PaymentType = Domain.Enums.Payment.AnorBank;

            Console.Write("Enter the user's reading time (in minutes per day): ");
            premium.ReadingBook = (Console.ReadLine());

            Console.Write("Enter the user's shower time (in minutes): ");
            premium.ShowerTime = int.Parse(Console.ReadLine());

            Console.Write("Does the user use phone while walking? (Y/N): ");
            premium.UsePhone = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the user's walking time (in minutes per day): ");
            premium.Walking = int.Parse(Console.ReadLine());

            Console.Write("Enter the user's water intake (in liters per day): ");
            premium.Water = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the user's weight (in kg): ");
            premium.Weight = decimal.Parse(Console.ReadLine());

            service.CreateAsync(premium);
            Console.WriteLine("Succesfully created...");

        }
    }
}
