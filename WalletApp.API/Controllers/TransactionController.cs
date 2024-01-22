using Microsoft.AspNetCore.Mvc;
using WalletApp.BLL.DTO;
using WalletApp.BLL.Interfaces;

namespace WalletApp.API.Controllers;

[ApiController]
[Route("/transaction")]
public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }
    [HttpPost("add")]
    public async Task Register(TransactionDto transactionDto)
    {
        var user = await _transactionService.CreateTransactionAsync(transactionDto);
    }
}