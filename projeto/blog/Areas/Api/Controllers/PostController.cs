using System.Collections.Generic;
using blog.DAO;
using blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace projetos.dotnet.blogCore.projeto.blog.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("/api/[controller]")]
    public class PostController : ControllerBase
    {
        
        private readonly PostDAO dao;

        public PostController(PostDAO dao)
        {
            this.dao = dao;
        }

        [Route("list")]
        public IActionResult GetAllPosts() {
            IList<Post> posts = dao.Lista();
            return Ok(posts);
        }

    }
}