using WalletApp.BLL.Entities;

namespace WalletApp.BLL.Interfaces;

public interface IWalletAppService
{
    public Task<TransactionListResponse> GetTransactionsList(int cardId);
    public Task<TransactionDetailResponse> GetTransactionDetail(int transactionId);
}