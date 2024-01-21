using WalletApp.DAL.Entities;

namespace WalletApp.DAL.Interfaces;

public interface IUnitOfWork
{
    IRepository<User> UserRepository { get; }
    IRepository<Card> CardRepository { get; }
    IRepository<Transaction> TransactionRepository { get; }
    
    Task CommitAsync();
    Task RollbackAsync();
}