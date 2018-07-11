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
        [HttpGet]
        public IActionResult GetAllPosts() {
            IList<Post> posts = dao.Lista();
            return Ok(posts);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetById(int id) {
            return Ok(dao.BuscaPorId(id));
        }

        [Route("new")]
        [HttpPost]
        public IActionResult InsertPosts([FromBody] Post post) {
            if(ModelState.IsValid) {
                dao.Adiciona(post);
                return CreatedAtAction("GetById", new {id = post.Id}, post);
            }
            return BadRequest(ModelState);
        }

    }
}