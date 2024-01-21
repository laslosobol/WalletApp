using Microsoft.AspNetCore.Mvc;

namespace WalletApp.API.Controllers;

[ApiController]
[Route("/walletapp")]
public class WalletAppController : Controller
{
    [HttpGet("/card/{cardId}/list")]
    public async Task<IActionResult> GetListTransactions(int cardId)
    {
        return Ok("Hello");
    }

    [HttpGet("/card/{cardId}/transaction/{transactionId}")]
    public async Task<IActionResult> GetTransactionDetails(int cardId, int transactionId)
    {
        return Ok("Hello");
    } 
}