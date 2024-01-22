using WalletApp.BLL.Entities;
using WalletApp.BLL.Interfaces;
using WalletApp.BLL.Utils;
using WalletApp.DAL.Interfaces;

namespace WalletApp.BLL.Services;

public class WalletAppService : IWalletAppService
{
    private IUnitOfWork _unitOfWork;

    public WalletAppService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<TransactionListResponse> GetTransactionsList(int cardId)
    {
        var card = await _unitOfWork.CardRepository.GetByIdAsync(cardId);
        var user = await _unitOfWork.UserRepository.GetByIdAsync(card.UserId);
        var allTransactions = await _unitOfWork.TransactionRepository.GetAllAsync();

        var transactions = allTransactions.Where(_ => _.CardId == cardId)
            .OrderByDescending(_ => _.CreatedAt).Take(10);

        var result = new TransactionListResponse()
        {
            CardBalance = card.Balance,
            Available = 1500 - card.Balance,
            DailyPoints = PointHelper.CalculatePoints(user.CreationDate),
            TransactionDetailResponses = new List<TransactionDetailResponse>()
        };

        foreach (var transaction in transactions)
        {
            result.TransactionDetailResponses.Add(new TransactionDetailResponse()
            {
                Name = transaction.Name,
                Value = transaction.Value,
                CreatedAt = transaction.CreatedAt,
                Status = transaction.Status,
                IsPending = transaction.IsPending,
                AuthorizedUser = transaction.AuthorizedUser
            });
        }

        return result;
    }

    public async Task<TransactionDetailResponse> GetTransactionDetail(int transactionId)
    {
        var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(transactionId);
        return new TransactionDetailResponse()
        {
            Name = transaction.Name,
            Value = transaction.Value,
            CreatedAt = transaction.CreatedAt,
            Status = transaction.Status,
            IsPending = transaction.IsPending,
            AuthorizedUser = transaction.AuthorizedUser
        };
    }
}