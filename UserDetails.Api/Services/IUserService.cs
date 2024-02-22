using UserDetails.Api.Models;

namespace UserDetails.Api.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int userId);
        Task<UserDto> CreateUser(UserDto user);
        Task<int> UpdateUser(UserDto user);
        Task<int> DeleteUser(int userId);
    }
}
