using blog.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace projetos.dotnet.blogCore.projeto.blog.Controllers
{
    public class UsuarioController : Controller
    {
        
       [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Post", new { area = "Admin" });
            } 
            return View("Login", model);
        } 
    }
}