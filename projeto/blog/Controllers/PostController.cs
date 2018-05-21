using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using blog.Models;
using blog.Infra;
using blog.DAO;

namespace projetos.dotnet.blogCore.projeto.blog.Controllers
{
    public class PostController : Controller
    {
        private IList<Post> lista;

        public PostController()
        {
            lista = new List<Post>();
            lista.Add(new Post() { Titulo = "Harry Potter 1", Resumo = "Pedra Filosofal", Categoria = "Filme, Livro" });
            lista.Add(new Post() { Titulo = "Cassino Royale", Resumo = "007", Categoria = "Filme" });
            lista.Add(new Post() { Titulo = "Monge e o Executivo", Resumo = "Romance sobre Liderança", Categoria = "Livro" });
            lista.Add(new Post() { Titulo = "New York, New York", Resumo = "Sucesso de Frank Sinatra", Categoria = "Música" }); 
        }

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
            lista.Add(post);
            return View("Index", lista);
        }

    }
}