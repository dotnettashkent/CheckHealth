using CheckHealth.Service.DTOs;
using CheckHealth.Service.Services;

namespace CheckHealth.Presentation.UserInterfaces
{
    public class AdminInterface
    {
        AdminDto admin = new AdminDto();
        AdminService adminService = new AdminService();

        public void adminCreate()
        {
            Console.WriteLine("Enter your user-name");
            admin.UserName = Console.ReadLine();
            Console.WriteLine("Enter your password");
            admin.Password = Console.ReadLine();
            Console.WriteLine("Enter your email");
            admin.Email = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            admin.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your first name");
            admin.FirstName = Console.ReadLine();
            Console.WriteLine("Enter your last name");
            admin.LastName = Console.ReadLine();
            adminService.CreateAsync(admin);
            Console.WriteLine("Succesfully....");
        }
        public void adminUpdate()
        {
            Console.WriteLine("Enter your user-name");
            admin.UserName = Console.ReadLine();
            Console.WriteLine("Enter your password");
            admin.Password = Console.ReadLine();
            Console.WriteLine("Enter your email");
            admin.Email = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            admin.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your first name");
            admin.FirstName = Console.ReadLine();
            Console.WriteLine("Enter your last name");
            admin.LastName = Console.ReadLine();
            Console.WriteLine("Enter updated id...");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();
            adminService.UpdateAsync(id, admin);
            Console.WriteLine("Succesfully");
        }
        public void adminDelete()
        {
            Console.WriteLine("ENter deleted id ...");
            int id = int.Parse(Console.ReadLine());
            adminService.DeleteAsync(id);
            Console.WriteLine("Succesfully deleted...");
        }

        public async void GetAllAdmin()
        {
            var all = (await adminService.GetAllAsync(p => true)).Value;

            if (all.Count == 0)
            {
                Console.WriteLine("Not found...");
            }
            else
            {
                foreach (var user in all)
                {
                    Console.WriteLine($"ID: {user.Id}, Name: {user.FirstName}, Email: {user.Email} , User password {user.Password} ");
                }
            }
        }
    }
}
