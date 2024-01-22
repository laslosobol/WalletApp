using Microsoft.AspNetCore.Mvc;
using WalletApp.BLL.DTO;
using WalletApp.BLL.Interfaces;

namespace WalletApp.API.Controllers;

[ApiController]
[Route("/user")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("add")]
    public async Task Register(UserDto userDto)
    {
        var user = await _userService.CreateUserAsync(userDto);
    }
}