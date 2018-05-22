using System;
using System.Collections.Generic;
using System.Linq;
using blog.Infra;
using blog.Models;
using MySql.Data.MySqlClient;

namespace blog.DAO
{
    public class PostDAO
    {

        public IList<Post> Lista() {
            using(BlogContext contexto = new BlogContext()) {
                return contexto.Posts.ToList();
            }
        }
        public void Adiciona(Post post)
        {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Posts.Add(post);
                contexto.SaveChanges();
            }
        }
    }
}