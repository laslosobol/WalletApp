using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Mvc;
using WalletApp.BLL.Interfaces;
using WalletApp.BLL.Services;

namespace WalletApp.API.Controllers;

[ApiController]
[Route("/walletapp")]
public class WalletAppController : Controller
{
    private IWalletAppService _walletAppService;
    public WalletAppController(IWalletAppService walletAppService)
    {
        _walletAppService = walletAppService;
    }
    [HttpGet("/card/{cardId}/list")]
    public async Task<IActionResult> GetListTransactions(int cardId) =>
        Ok(await _walletAppService.GetTransactionsList(cardId));

    [HttpGet("/transaction/{transactionId}")]
    public async Task<IActionResult> GetTransactionDetails(int transactionId) =>
        Ok(await _walletAppService.GetTransactionDetail(transactionId));
}