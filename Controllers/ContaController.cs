using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LojaMVC.Models;

namespace LojaMVC.Controllers
{
    public class ContaController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ContaController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var resultado = await _signInManager.PasswordSignInAsync(email, senha, false, false);
            if (resultado.Succeeded)
                return RedirectToAction("Index", "Produtos");

            ViewBag.Erro = "E-mail ou senha incorretos.";
            return View();
        }

        public IActionResult Cadastro() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(string nomeCompleto, string email, string senha)
        {
            var user = new ApplicationUser { UserName = email, Email = email, NomeCompleto = nomeCompleto };
            var resultado = await _userManager.CreateAsync(user, senha);

            if (resultado.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Produtos");
            }

            ViewBag.Erros = resultado.Errors.Select(e => e.Description).ToList();
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}