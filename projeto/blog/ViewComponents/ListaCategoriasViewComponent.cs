using System.Collections.Generic;
using System.Threading.Tasks;
using blog.DAO;
using blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog.ViewComponents
{
    public class ListaCategoriasViewComponent : ViewComponent
    {
        private readonly PostDAO dao;


        public ListaCategoriasViewComponent(PostDAO dao)
        {
            this.dao = dao;
        }

        public IViewComponentResult Invoke()
        {
            var posts = dao.ListaPublicados();
            CategoriaComQuantidadeViewModel categoriaPorQuantidade = new CategoriaComQuantidadeViewModel(posts);
            return View(categoriaPorQuantidade);
        }
    }
}