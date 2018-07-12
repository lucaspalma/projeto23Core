using System.Collections.Generic;
using blog.DAO;
using blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace projetos.dotnet.blogCore.projeto.blog.Areas.Api.Controllers
{
    [Area("Api")]
    [Route("/api/[controller]")]
    [ApiController]
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
            dao.Adiciona(post);
            return CreatedAtAction("GetById", new {id = post.Id}, post);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdatePosts(int id, [FromBody] Post post) {
            if(dao.BuscaPorId(id) == null) {
                return NotFound();
            }
            post.Id = id;
            dao.Atualiza(post);
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeletePost(int id) {
            if(dao.BuscaPorId(id) == null) {
                return NotFound();
            }
            dao.Remove(id);
            return NoContent();
        }

    }
}