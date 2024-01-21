using WalletApp.BLL.DTO;
using WalletApp.DAL.Entities;

namespace WalletApp.BLL.Mappers;

public class UserMapper : GenericMapper<User, UserDto>
{
    public override User Map(UserDto dtoEntity) => new User()
    {
        Id = dtoEntity.Id,
        Name = dtoEntity.Name,
        CreationDate = dtoEntity.CreationDate
    };

public override UserDto Map(User dataEntity) => new UserDto()
    {
        Id = dataEntity.Id,
        Name = dataEntity.Name,
        CreationDate = dataEntity.CreationDate
    };
}