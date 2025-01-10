using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCRUD.Data;
using WebAppCRUD.Models;

namespace WebAppCRUD.Controllers;

public class UsersController : Controller
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(User user, string confirmPassword)
    {
        if (user.PasswordHash != confirmPassword)
        {
            ModelState.AddModelError(string.Empty, "Passwords do not match");
            return View(user);
        }

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string email, string PasswordHash)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(PasswordHash, user.PasswordHash))
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View();
        }

        HttpContext.Session.SetInt32("UserId", user.Id);
        return RedirectToAction("Index", "Contacts");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
