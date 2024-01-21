using WalletApp.BLL.DTO;

namespace WalletApp.BLL.Interfaces;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(int id);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task UpdateUserAsync(UserDto userDto);
    Task DeleteUserByIdAsync(int id);
    Task<UserDto> CreateUserAsync(UserDto userDto);
}