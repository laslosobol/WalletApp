using WalletApp.BLL.DTO;
using WalletApp.BLL.Interfaces;
using WalletApp.BLL.Mappers;
using WalletApp.DAL.Interfaces;

namespace WalletApp.BLL.Services;

public class CardService : ICardService
{
    private IUnitOfWork _unitOfWork;
    private CardMapper _cardMapper;
    public CardMapper CardMapper => _cardMapper ?? new CardMapper();
    public async Task<CardDto> GetCardByIdAsync(int id)
    {
        var entity = await _unitOfWork.CardRepository.GetByIdAsync(id);
        if (entity is null) throw new Exception();
        return CardMapper.Map(entity);
    }

    public async Task<IEnumerable<CardDto>> GetAllCardsAsync()
    {
        var entity = await _unitOfWork.CardRepository.GetAllAsync();
        var result = entity.Select(el => CardMapper.Map(el)).ToList();

        return result;
    }

    public async Task UpdateCardAsync(CardDto cardDto)
    {
        var card = CardMapper.Map(cardDto);

        _unitOfWork.CardRepository.Update(card);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteCardByIdAsync(int id)
    {
        var entity = await _unitOfWork.CardRepository.GetByIdAsync(id);
        if (entity is null)
            throw new Exception();
        _unitOfWork.CardRepository.Delete(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task<CardDto> CreateCardAsync(CardDto cardDto)
    {
        var card = CardMapper.Map(cardDto);

        await _unitOfWork.CardRepository.InsertAsync(card);
        await _unitOfWork.CommitAsync();
        return CardMapper.Map(card);
    }
}