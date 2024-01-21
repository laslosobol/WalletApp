using WalletApp.BLL.DTO;
using WalletApp.DAL.Entities;

namespace WalletApp.BLL.Mappers;

public class CardMapper : GenericMapper<Card, CardDto>
{
    public override Card Map(CardDto dtoEntity) => new Card()
    {
        Id = dtoEntity.Id,
        Balance = dtoEntity.Balance,
        UserId = dtoEntity.UserId
    };

    public override CardDto Map(Card dataEntity) => new CardDto()
    {
        Id = dataEntity.Id,
        Balance = dataEntity.Balance,
        UserId = dataEntity.UserId
    };
}