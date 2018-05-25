using blog.DAO;
using blog.Models;
using blog.ViewModel;
using blog.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace projetos.dotnet.blogCore.projeto.blog.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<Usuario> manager;
        private readonly SignInManager<Usuario> signInManager;

        public UsuarioController(UserManager<Usuario> manager, SignInManager<Usuario> signInManager)
        {
            this.manager = manager;
            this.signInManager = signInManager;
        }
    
       [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.LoginName, model.Password, true, false);
                if(result.Succeeded) {
                    return RedirectToAction("Index", "Post", new { area = "Admin" });
                }
                else {
                    ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                }
            }
            return View("Login", model);
        } 

        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastra(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario() {
                    UserName = model.LoginName,
                    Email = model.Email
                };
                var result = await manager.CreateAsync(usuario, model.Senha);
                if(result.Succeeded) {
                    return RedirectToAction("Login");
                }
                else {
                    foreach(var erro in result.Errors) {
                        ModelState.AddModelError("", erro.Description);
                    }
                }
            }
            return View("Novo", model);
        }        
    }
}