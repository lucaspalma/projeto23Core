using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using blog.DAO;
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

    }
}
