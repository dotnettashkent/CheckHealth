using CheckHealth.DAL.Repositories;
using CheckHealth.Domain.Entities;
using CheckHealth.Service.Helpers;
using CheckHealth.Service.Interfaces;


namespace CheckHealth.Service.Services
{
    public class UserPremiumService : IUserPremiumService
    {
        private readonly GenericRepository<Domain.Entities.UserPremium> userPremiumRepository;
        public async Task<GenericResponse<Domain.Entities.UserPremium>> CreateAsync(Domain.Entities.UserPremium userPremiumDto)
        {
            var user = (await userPremiumRepository.GetAllAsync()).FirstOrDefault(u => u.UserName == userPremiumDto.UserName);

            if (user is not null)
            {
                return new GenericResponse<UserPremium>
                {
                    StatusCode = 405,
                    Message = "User is already created",
                    Value = null
                };
            }

            var newUser = new UserPremium
            {
                CreatedAt = DateTime.Now,
                SleepTime = userPremiumDto.SleepTime,
                Activity = userPremiumDto.Activity,
                Age = userPremiumDto.Age,
                EatType = userPremiumDto.EatType,
                Gender = userPremiumDto.Gender,
                Heartrate = userPremiumDto.Heartrate,
                Height = userPremiumDto.Height,
                IsPremium = userPremiumDto.IsPremium,
                PaymentType = userPremiumDto.PaymentType,
                ReadingBook = userPremiumDto.ReadingBook,
                ShowerTime = userPremiumDto.ShowerTime,
                UsePhone = userPremiumDto.UsePhone,
                UserName = userPremiumDto.UserName,
                Walking = userPremiumDto.Walking,
                Water = userPremiumDto.Water,
                Weight = userPremiumDto.Weight,
            };

            var result = await userPremiumRepository.CreateAsync(newUser);
            return new GenericResponse<UserPremium>
            {
                StatusCode = 200,
                Message = "Succes created",
                Value = result
            };
        }

        public async Task<GenericResponse<Domain.Entities.UserPremium>> DeleteAsync(long id)
        {
            var model = await this.userPremiumRepository.GetAsync(id);
            if (model is null)
                return new GenericResponse<UserPremium>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Value = null
                };

            await this.userPremiumRepository.DeleteAsync(id);
            return new GenericResponse<UserPremium>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }

        public async Task<GenericResponse<List<Domain.Entities.UserPremium>>> GetAllAsync(Predicate<Domain.Entities.UserPremium> predicate)
        {
            var result = await this.userPremiumRepository.GetAllAsync(predicate);
            return new GenericResponse<List<UserPremium>>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = result
            };
        }

        public async Task<GenericResponse<Domain.Entities.UserPremium>> GetAsync(long id)
        {
            var model = await this.userPremiumRepository.GetAsync(id);
            if (model is null)
                return new GenericResponse<UserPremium>()
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Value = null
                };

            return new GenericResponse<UserPremium>()
            {
                StatusCode = 200,
                Message = "Success",
                Value = model
            };
        }

        public async Task<GenericResponse<Domain.Entities.UserPremium>> UpdateAsync(long id, Domain.Entities.UserPremium userPremiumDto)
        {
            var users = await userPremiumRepository.GetAllAsync();
            var user = users.FirstOrDefault(c => c.Id == id);

            if (user is null)
                return new GenericResponse<UserPremium>
                {
                    StatusCode = 404,
                    Message = "User is not found",
                    Value = null
                };

            if (user.UserName != userPremiumDto.UserName)
            {
                var userWithUsername = users.FirstOrDefault(c => c.UserName == userPremiumDto.UserName);

                if (userWithUsername is not null)
                    return new GenericResponse<UserPremium>
                    {
                        StatusCode = 405,
                        Message = "Username is taken",
                        Value = null
                    };
            }


            user.Activity = userPremiumDto.Activity;
            user.UserName = userPremiumDto.UserName;
            user.UsePhone = userPremiumDto.UsePhone;
            user.IsPremium = userPremiumDto.IsPremium;
            user.Water = userPremiumDto.Water;
            user.SleepTime = userPremiumDto.SleepTime;
            user.EatType = userPremiumDto.EatType;
            user.Gender = userPremiumDto.Gender;
            user.Age = userPremiumDto.Age;
            user.Heartrate = userPremiumDto.Heartrate;
            user.PaymentType = userPremiumDto.PaymentType;
            user.ReadingBook = userPremiumDto.ReadingBook;
            user.Walking = userPremiumDto.Walking;
            user.ShowerTime = userPremiumDto.ShowerTime;
            user.Weight = userPremiumDto.Weight;
            user.Height = userPremiumDto.Height;

            var result = await userPremiumRepository.UpdateAsync(user);

            return new GenericResponse<UserPremium>
            {
                StatusCode = 200,
                Message = "Succes",
                Value = result
            };
        }
    }
}
