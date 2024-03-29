﻿using WalletApp.DAL.Context;
using WalletApp.DAL.Entities;
using WalletApp.DAL.Interfaces;
using WalletApp.DAL.Repository;

namespace WalletApp.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext _context;

    private IRepository<User> _userRepository;
    public IRepository<User> UserRepository => _userRepository ??= new GenericRepository<User>(_context);
    
    private IRepository<Card> _cardRepository;
    public IRepository<Card> CardRepository => _cardRepository ??= new GenericRepository<Card>(_context);
    
    private IRepository<Transaction> _transactionRepository;
    public IRepository<Transaction> TransactionRepository => _transactionRepository ??= new GenericRepository<Transaction>(_context);
    
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task RollbackAsync()
    {
        await _context.DisposeAsync();
    }

    private bool disposed = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);

    }

    public void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        disposed = true;
    }
}