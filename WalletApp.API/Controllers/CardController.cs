using Microsoft.AspNetCore.Mvc;
using WalletApp.BLL.DTO;
using WalletApp.BLL.Interfaces;

namespace WalletApp.API.Controllers;

[ApiController]
[Route("/card")]
public class CardController : Controller
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }
    [HttpPost("add")]
    public async Task Register(CardDto cardDto)
    {
        var user = await _cardService.CreateCardAsync(cardDto);
    }
}