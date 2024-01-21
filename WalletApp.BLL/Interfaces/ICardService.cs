using WalletApp.BLL.DTO;

namespace WalletApp.BLL.Interfaces;

public interface ICardService
{
    Task<CardDto> GetCardByIdAsync(int id);
    Task<IEnumerable<CardDto>> GetAllCardsAsync();
    Task UpdateCardAsync(CardDto cardDto);
    Task DeleteCardByIdAsync(int id);
    Task<CardDto> CreateCardAsync(CardDto cardDto);
}