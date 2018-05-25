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
        private readonly PostDAO dao;

        public HomeController(PostDAO dao)
        {
            this.dao = dao;
        }
        public IActionResult Index()
        {
            return View(dao.ListaPublicados());
        }

        public ActionResult Busca(string termo)
        {
            IList<Post> posts = dao.BuscaPeloTermo(termo);
            return View("Index", posts);
        }

    }
}
