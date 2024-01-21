using WalletApp.BLL.DTO;

namespace WalletApp.BLL.Interfaces;

public interface ITransactionService
{
    Task<TransactionDto> GetTransactionByIdAsync(int id);
    Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync();
    Task UpdateTransactionAsync(TransactionDto transactionDto);
    Task DeleteTransactionByIdAsync(int id);
    Task<TransactionDto> CreateTransactionAsync(TransactionDto transactionDto);
}