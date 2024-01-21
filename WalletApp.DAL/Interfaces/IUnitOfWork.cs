using WalletApp.DAL.Entities;

namespace WalletApp.DAL.Interfaces;

public interface IUnitOfWork
{
    IRepository<User> UserRepository { get; }
    IRepository<Card> CustomerRepository { get; }
    IRepository<Transaction> CourierRepository { get; }
    
    Task CommitAsync();
    Task RollbackAsync();
}