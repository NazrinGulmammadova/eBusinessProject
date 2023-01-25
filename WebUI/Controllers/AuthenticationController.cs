using eBusiness.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class AuthenticationController : Controller
{
    private readonly UserManager<UserSide> _user;
    private readonly SignInManager<UserSide> _signInManager;

    public AuthenticationController(UserManager<UserSide> user, SignInManager<UserSide> signInManager)
    {
        _user = user;
        _signInManager = signInManager;
    }

    public IActionResult Register()
    {
        return View();
    }
    //[HttpPost]
    //[ValidateAntiForgeryToken]
}
