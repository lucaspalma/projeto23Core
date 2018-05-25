using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using blog.Models;
using blog.Infra;
using blog.DAO;

namespace projetos.dotnet.blogCore.projeto.blog.areas.admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {

        public IActionResult Index() {
            PostDAO dao = new PostDAO();
            IList<Post> posts = dao.Lista();
            return View(posts);
        }

        public IActionResult Novo() {
            return View(new Post());
        }

        [HttpPost]
        public IActionResult Adiciona(Post post) {
            if(ModelState.IsValid) {
                PostDAO dao = new PostDAO();
                dao.Adiciona(post);
                return RedirectToAction("Index");
            }
            return View("Novo", post);
        }

        public IActionResult Categoria([Bind(Prefix="id")] string categoria) {
            PostDAO dao = new PostDAO();
            IList<Post> posts = dao.FiltraPorCategoria(categoria);
            return View("Index", posts);
        }

        [Route("/post/removendo/{id}")]
        [HttpGet]
        public IActionResult RemovePost(int id) {
            PostDAO dao = new PostDAO();
            dao.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Visualiza(int id) {
            PostDAO dao = new PostDAO();
            return View(dao.BuscaPorId(id));
        }

        [HttpPost]
        public IActionResult EditaPost(Post post) {
            if(ModelState.IsValid) {
                PostDAO dao = new PostDAO();
                dao.Atualiza(post);
                return RedirectToAction("Index");
            }
            return View("Visualiza", post);
        }

        [HttpGet]
        public IActionResult PublicaPost(int id) {
            PostDAO dao = new PostDAO();
            dao.Publica(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string termoDigitado)
        {
            PostDAO dao = new PostDAO();
            var model = dao.ListaCategoriasQueContemTermo(termoDigitado);
            return Json(model);
        }

    }
}