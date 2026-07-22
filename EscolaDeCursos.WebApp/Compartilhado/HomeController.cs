using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Compartilhado.Apresentacao;


[Authorize]
public class HomeController : Controller
{
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }
}
