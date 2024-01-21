using WalletApp.BLL.DTO;
using WalletApp.BLL.Interfaces;
using WalletApp.BLL.Mappers;
using WalletApp.DAL.Interfaces;

namespace WalletApp.BLL.Services;

public class TransactionService : ITransactionService
{
    private IUnitOfWork _unitOfWork;
    private TransactionMapper _transactionMapper;
    public TransactionMapper TransactionMapper => _transactionMapper ?? new TransactionMapper();
    public async Task<TransactionDto> GetTransactionByIdAsync(int id)
    {
        var entity = await _unitOfWork.TransactionRepository.GetByIdAsync(id);
        if (entity is null) throw new Exception();
        return TransactionMapper.Map(entity);
    }

    public async Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync()
    {
        var entity = await _unitOfWork.TransactionRepository.GetAllAsync();
        var result = entity.Select(el => TransactionMapper.Map(el)).ToList();

        return result;
    }

    public async Task UpdateTransactionAsync(TransactionDto transactionDto)
    {
        var transaction = TransactionMapper.Map(transactionDto);

        _unitOfWork.TransactionRepository.Update(transaction);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteTransactionByIdAsync(int id)
    {
        var entity = await _unitOfWork.TransactionRepository.GetByIdAsync(id);
        if (entity is null)
            throw new Exception();
        _unitOfWork.TransactionRepository.Delete(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task<TransactionDto> CreateTransactionAsync(TransactionDto transactionDto)
    {        
        var transaction = TransactionMapper.Map(transactionDto);
        await _unitOfWork.TransactionRepository.InsertAsync(transaction);
        await _unitOfWork.CommitAsync();
        return TransactionMapper.Map(transaction);
    }
}