using CheckHealth.Domain.Entities;
using CheckHealth.Service.DTOs;
using CheckHealth.Service.Helpers;

namespace CheckHealth.Service.Interfaces
{
    public interface IAdminService
    {
        Task<GenericResponse<User>> CreateAsync(AdminDto adminDto);
        Task<GenericResponse<User>> DeleteAsync(long id);
        Task<GenericResponse<User>> UpdateAsync(long id, AdminDto adminDto);
        Task<GenericResponse<User>> GetAsync(long id);
        Task<GenericResponse<List<User>>> GetAllAsync(Predicate<User> predicate);
    }
}
