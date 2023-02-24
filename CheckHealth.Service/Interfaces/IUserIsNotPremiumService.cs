using CheckHealth.Domain.Entities;
using CheckHealth.Service.DTOs;
using CheckHealth.Service.Helpers;

namespace CheckHealth.Service.Interfaces
{
    public interface IUserIsNotPremiumService
    {
        Task<GenericResponse<UserIsNotPremium>> CreateAsync(UserIsNotPremiumDto userIsNotPremiumDto);
        Task<GenericResponse<UserIsNotPremium>> DeleteAsync(long id);
        Task<GenericResponse<UserIsNotPremium>> UpdateAsync(long id, UserIsNotPremiumDto userIsNotPremiumDto);
        Task<GenericResponse<UserIsNotPremium>> GetAsync(long id);
        Task<GenericResponse<List<UserIsNotPremium>>> GetAllAsync(Predicate<UserIsNotPremium> predicate);
    }
}
