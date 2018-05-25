using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using blog.Models;
using blog.Infra;
using blog.DAO;
using blog.Filtro;
using blog.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace projetos.dotnet.blogCore.projeto.blog.areas.admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PostController : Controller
    {
        private readonly PostDAO dao;
        private readonly UserManager<Usuario> manager;

        public PostController(PostDAO dao, UserManager<Usuario> manager)
        {
            this.dao = dao;
            this.manager = manager;
        }

        public IActionResult Index() {
            IList<Post> posts = dao.Lista();
            return View(posts);
        }

        public IActionResult Novo() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adiciona(Post post) {
            if(ModelState.IsValid) {
                Usuario usuario = await manager.GetUserAsync(User);
                dao.Adiciona(post, usuario);
                return RedirectToAction("Index");
            }
            return View("Novo", post);
        }

        public IActionResult Categoria([Bind(Prefix="id")] string categoria) {
            IList<Post> posts = dao.FiltraPorCategoria(categoria);
            return View("Index", posts);
        }

        [Route("/post/removendo/{id}")]
        [HttpGet]
        public IActionResult RemovePost(int id) {
            dao.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Visualiza(int id) {
            return View(dao.BuscaPorId(id));
        }

        [HttpPost]
        public IActionResult EditaPost(Post post) {
            if(ModelState.IsValid) {
                dao.Atualiza(post);
                return RedirectToAction("Index");
            }
            return View("Visualiza", post);
        }

        [HttpGet]
        public IActionResult PublicaPost(int id) {
            dao.Publica(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string termoDigitado)
        {
            var model = dao.ListaCategoriasQueContemTermo(termoDigitado);
            return Json(model);
        }

    }
}