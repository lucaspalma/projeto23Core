using blog.DAO;
using blog.Models;
using blog.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace projetos.dotnet.blogCore.projeto.blog.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioDAO dao;

        public UsuarioController(UsuarioDAO dao)
        {
            this.dao = dao;
        }
    
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
                Usuario usuario = dao.Busca(model.LoginName, model.Password);
                if(usuario != null) {
                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));
                    return RedirectToAction("Index", "Post", new { area = "Admin" });
                }
                else {
                    ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                }
            }
            return View("Login", model);
        } 
    }
}