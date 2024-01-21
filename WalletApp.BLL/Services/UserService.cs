using WalletApp.BLL.DTO;
using WalletApp.BLL.Interfaces;
using WalletApp.BLL.Mappers;
using WalletApp.DAL.Interfaces;

namespace WalletApp.BLL.Services;

public class UserService : IUserService
{
    private IUnitOfWork _unitOfWork;
    private UserMapper _userMapper;
    public UserMapper UserMapper => _userMapper ?? new UserMapper();
    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        var entity = await _unitOfWork.UserRepository.GetByIdAsync(id);
        if (entity is null) throw new Exception();
        return UserMapper.Map(entity);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var entity = await _unitOfWork.UserRepository.GetAllAsync();
        var result = entity.Select(el => UserMapper.Map(el)).ToList();

        return result;
    }

    public async Task UpdateUserAsync(UserDto userDto)
    {
        var user = UserMapper.Map(userDto);

        _unitOfWork.UserRepository.Update(user);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteUserByIdAsync(int id)
    {
        var entity = await _unitOfWork.UserRepository.GetByIdAsync(id);
        if (entity is null)
            throw new Exception();
        _unitOfWork.UserRepository.Delete(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task<UserDto> CreateUserAsync(UserDto userDto)
    {
        var user = UserMapper.Map(userDto);

        await _unitOfWork.UserRepository.InsertAsync(user);
        await _unitOfWork.CommitAsync();
        return UserMapper.Map(user);
    }
}