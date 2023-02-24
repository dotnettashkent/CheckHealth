using CheckHealth.Service.DTOs;
using CheckHealth.Service.Helpers;

namespace CheckHealth.Service.Interfaces
{
    public interface IUserPremiumService
    {
        public interface UserPremiumService
        {
            Task<GenericResponse<UserPremium>> CreateAsync(UserPremium userPremiumDto);
            Task<GenericResponse<UserPremium>> DeleteAsync(long id);
            Task<GenericResponse<UserPremium>> UpdateAsync(long id, UserPremium userPremiumDto);
            Task<GenericResponse<UserPremium>> GetAsync(long id);
            Task<GenericResponse<List<UserPremium>>> GetAllAsync(Predicate<UserPremium> predicate);
        }
    }
}
