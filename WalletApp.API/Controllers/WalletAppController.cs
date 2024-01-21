using Microsoft.AspNetCore.Mvc;
using WalletApp.BLL.Interfaces;
using WalletApp.BLL.Services;

namespace WalletApp.API.Controllers;

[ApiController]
[Route("/walletapp")]
public class WalletAppController(IWalletAppService walletAppService) : Controller
{
    [HttpGet("/card/{cardId}/list")]
    public async Task<IActionResult> GetListTransactions(int cardId) =>
        Ok(await walletAppService.GetTransactionsList(cardId));

    [HttpGet("/card/{cardId}/transaction/{transactionId}")]
    public async Task<IActionResult> GetTransactionDetails(int transactionId) =>
        Ok(await walletAppService.GetTransactionDetail(transactionId));
}