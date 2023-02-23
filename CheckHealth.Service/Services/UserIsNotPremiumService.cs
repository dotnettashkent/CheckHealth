using CheckHealth.DAL.IRepositories;
using CheckHealth.DAL.Repositories;
using CheckHealth.Domain.Entities;
using CheckHealth.Domain.Enums;
using CheckHealth.Service.DTOs;
using CheckHealth.Service.Helpers;
using CheckHealth.Service.Interfaces;

namespace CheckHealth.Service.Services
{
    public class UserIsNotPremiumService : IUserIsNotPremiumService
    {
        private readonly GenericRepository<UserIsNotPremium> userIsNotPremiumRepository;
        public async Task<GenericResponse<UserIsNotPremium>> CreateAsync(UserIsNotPremiumDto userIsNotPremiumDto)
        {
            var user = (await userIsNotPremiumRepository.GetAllAsync()).FirstOrDefault(u => u.UserName == userIsNotPremiumDto.UserName);

            if (user is not null)
            {
                return new GenericResponse<UserIsNotPremium>
                {
                    StatusCode = 405,
                    Message = "User is already created",
                    Value = null
                };
            }

            var newUser = new UserIsNotPremium
            {
                CreatedAt = DateTime.Now,
                UserName = userIsNotPremiumDto.UserName,
                Age= userIsNotPremiumDto.Age,
                Gender= userIsNotPremiumDto.Gender,
                Height= userIsNotPremiumDto.Height,
                Password= userIsNotPremiumDto.Password,
                Weight= userIsNotPremiumDto.Weight,
                IsPremium = userIsNotPremiumDto.IsPremium
            };

            var result = await userIsNotPremiumRepository.CreateAsync(newUser);
            return new GenericResponse<UserIsNotPremium>
            {
                StatusCode = 200,
                Message = "Succes created",
                Value = result
            };
        }

        public async Task<GenericResponse<UserIsNotPremium>> DeleteAsync(long id)
        {
            var model = await this.userIsNotPremiumRepository.GetAsync(id);
            if (model is null)
                return new GenericResponse<UserIsNotPremium>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Value = null
                };

            await this.userIsNotPremiumRepository.DeleteAsync(id);
            return new GenericResponse<UserIsNotPremium>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }

        public async Task<GenericResponse<List<UserIsNotPremium>>> GetAllAsync(Predicate<UserIsNotPremium> predicate)
        {
            var result = await this.userIsNotPremiumRepository.GetAllAsync(predicate);
            return new GenericResponse<List<UserIsNotPremium>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = result
            };
        }

        public async Task<GenericResponse<UserIsNotPremium>> GetAsync(long id)
        {
            var model = await this.userIsNotPremiumRepository.GetAsync(id);
            if (model is null)
                return new GenericResponse<UserIsNotPremium>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Value = null
                };

            return new GenericResponse<UserIsNotPremium>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }

        public async Task<GenericResponse<UserIsNotPremium>> UpdateAsync(long id, UserIsNotPremiumDto userIsNotPremiumDto)
        {
            var users = await userIsNotPremiumRepository.GetAllAsync();
            var user = users.FirstOrDefault(c => c.Id == id);

            if (user is null)
                return new GenericResponse<UserIsNotPremium>
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Value = null
                };

            if (user.UserName != userIsNotPremiumDto.UserName)
            {
                var userWithUsername = users.FirstOrDefault(c => c.UserName == userIsNotPremiumDto.UserName);

                if (userWithUsername is not null)
                    return new GenericResponse<UserIsNotPremium>
                    {
                        StatusCode = 405,
                        Message = "Username is taken",
                        Value = null
                    };
            }


            user.Height = userIsNotPremiumDto.Height;
            user.Weight = userIsNotPremiumDto.Weight;
            user.Age = userIsNotPremiumDto.Age;
            user.Gender = userIsNotPremiumDto.Gender;
            user.UpdatedAt = DateTime.Now;
            user.IsPremium = Premium.IsNotPremium;
            user.UserName = userIsNotPremiumDto.UserName;
            user.Password = userIsNotPremiumDto.Password;
            var result = await userIsNotPremiumRepository.UpdateAsync(user);

            return new GenericResponse<UserIsNotPremium>
            {
                StatusCode = 200,
                Message = "Succes",
                Value = result
            };
        }
    }
}
