using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using adminMeuApp.Models;
using adminMeuApp.Models.Infraestrutura.Autenticacao;
using adminMeuApp.Models.Infraestrutura.Database;

namespace adminMeuApp.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("/login/logar")]
    [HttpPost]
    public IActionResult Logar(string login, string password)
    {

        if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            ViewBag.Error = "Digite o login e a senha";
        }
        else
        {
            var adms = new BancoContexto().Administradores.Where(a => a.Email == login && a.Senha == password).ToList();
            if(adms.Count > 0)
            {
                this.HttpContext.Response.Cookies.Append("adm_cms", adms.First().Id.ToString(), new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    HttpOnly = true
                });
                Response.Redirect("/");
            }
            else
            {
                ViewBag.Error = "login ou senha inválidos";
            }
        }
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}