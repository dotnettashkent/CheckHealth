using CheckHealth.DAL.Repositories;
using CheckHealth.Domain.Entities;
using CheckHealth.Domain.Enums;
using CheckHealth.Service.DTOs;
using CheckHealth.Service.Helpers;
using CheckHealth.Service.Interfaces;

namespace CheckHealth.Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly GenericRepository<User> adminRepository;
        public async Task<GenericResponse<User>> CreateAsync(AdminDto adminDto)
        {
            var user = (await adminRepository.GetAllAsync()).FirstOrDefault(u => u.UserName == adminDto.UserName);

            if (user is not null)
            {
                return new GenericResponse<User>
                {
                    StatusCode = 405,
                    Message = "User is already created",
                    Value = null
                };
            }

            var newUser = new User
            {
                CreatedAt = DateTime.Now,
                userRole = UserRole.Admin,
                Email = adminDto.Email,
                FirstName = adminDto.FirstName,
                LastName = adminDto.LastName,
                Password = adminDto.Password,
                PhoneNumber = adminDto.PhoneNumber,
                UserName = adminDto.UserName
            };

            var result = await adminRepository.CreateAsync(newUser);
            return new GenericResponse<User>
            {
                StatusCode = 200,
                Message = "Succes created",
                Value = result
            };
        }

        public async Task<GenericResponse<User>> DeleteAsync(long id)
        {
            var model = await this.adminRepository.GetAsync(id);
            if (model is null)
                return new GenericResponse<User>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Value = null
                };

            await this.adminRepository.DeleteAsync(id);
            return new GenericResponse<User>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }

        public async Task<GenericResponse<List<User>>> GetAllAsync(Predicate<User> predicate)
        {
            var result = await this.adminRepository.GetAllAsync(predicate);
            return new GenericResponse<List<User>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = result
            };
        }

        public async Task<GenericResponse<User>> GetAsync(long id)
        {
            var model = await this.adminRepository.GetAsync(id);
            if (model is null)
                return new GenericResponse<User>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Value = null
                };

            return new GenericResponse<User>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }

        public async Task<GenericResponse<User>> UpdateAsync(long id, AdminDto adminDto)
        {
            var users = await adminRepository.GetAllAsync();
            var user = users.FirstOrDefault(c => c.Id == id);

            if (user is null)
                return new GenericResponse<User>
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Value = null
                };

            if (user.UserName != adminDto.UserName)
            {
                var userWithUsername = users.FirstOrDefault(c => c.UserName == adminDto.UserName);

                if (userWithUsername is not null)
                    return new GenericResponse<User>
                    {
                        StatusCode = 405,
                        Message = "Username is taken",
                        Value = null
                    };
            }

            user.FirstName = adminDto.FirstName;
            user.LastName = adminDto.LastName;
            user.PhoneNumber = adminDto.PhoneNumber;
            user.UserName = adminDto.UserName;
            user.Password = adminDto.Password;
            user.UpdatedAt = DateTime.Now;
            user.Email = adminDto.Email;
            var result = await adminRepository.UpdateAsync(user);

            return new GenericResponse<User>
            {
                StatusCode = 200,
                Message = "Succes",
                Value = result
            };
        }
    }
}
