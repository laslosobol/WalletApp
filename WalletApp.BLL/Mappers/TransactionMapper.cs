using WalletApp.BLL.DTO;
using WalletApp.DAL.Entities;

namespace WalletApp.BLL.Mappers;

public class TransactionMapper : GenericMapper<Transaction, TransactionDto>
{
    public override Transaction Map(TransactionDto dtoEntity) => new Transaction()
    {
        Id = dtoEntity.Id,
        Name = dtoEntity.Name,
        Description = dtoEntity.Description,
        CardId = dtoEntity.CardId,
        Type = dtoEntity.Type,
        Value = dtoEntity.Value,
        IsPending = dtoEntity.IsPending,
        AuthorizedUser = dtoEntity.AuthorizedUser,
        Icon = dtoEntity.Icon,
        CreatedAt = dtoEntity.CreatedAt
    };

    public override TransactionDto Map(Transaction dataEntity) => new TransactionDto()
    {
        Id = dataEntity.Id,
        Name = dataEntity.Name,
        Description = dataEntity.Description,
        CardId = dataEntity.CardId,
        Type = dataEntity.Type,
        Value = dataEntity.Value,
        IsPending = dataEntity.IsPending,
        AuthorizedUser = dataEntity.AuthorizedUser,
        Icon = dataEntity.Icon,
        CreatedAt = dataEntity.CreatedAt
    };
}