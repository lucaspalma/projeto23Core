using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using blog.DAO;
using blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PostDAO dao = new PostDAO();
            return View(dao.ListaPublicados());
        }

        public ActionResult Busca(string termo)
        {
            PostDAO dao = new PostDAO();
            IList<Post> posts = dao.BuscaPeloTermo(termo);
            return View("Index", posts);
        }

    }
}
