using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using projetos.dotnet.blogCore.projeto.blog.Models;

namespace projetos.dotnet.blogCore.projeto.blog.Controllers
{
    public class PostController : Controller
    {
        
        public IActionResult Index() {
            IList<Post> lista = new List<Post>();
            lista.Add(new Post() { Titulo = "Harry Potter 1", Resumo = "Pedra Filosofal", Categoria = "Filme, Livro" });
            lista.Add(new Post() { Titulo = "Cassino Royale", Resumo = "007", Categoria = "Filme" });
            lista.Add(new Post() { Titulo = "Monge e o Executivo", Resumo = "Romance sobre Liderança", Categoria = "Livro" });
            lista.Add(new Post() { Titulo = "New York, New York", Resumo = "Sucesso de Frank Sinatra", Categoria = "Música" });
            ViewBag.Posts = lista;
            return View();    
        }

    }
}