using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using blog.Models;
using blog.Infra;
using blog.DAO;

namespace projetos.dotnet.blogCore.projeto.blog.Controllers
{
    public class PostController : Controller
    {

        public IActionResult Index() {
            PostDAO dao = new PostDAO();
            IList<Post> posts = dao.Lista();
            return View(posts);
        }

        public IActionResult Novo() {
            return View();
        }

        [HttpPost]
        public IActionResult Adiciona(Post post) {
            PostDAO dao = new PostDAO();
            dao.Adiciona(post);
            return RedirectToAction("Index");
        }

    }
}