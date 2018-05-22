using System;
using System.Collections.Generic;
using System.Linq;
using blog.Infra;
using blog.Models;
using Microsoft.EntityFrameworkCore;
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

        public IList<Post> FiltraPorCategoria(string categoria) {
            using(BlogContext contexto = new BlogContext()) {
                return contexto.Posts.Where(post => post.Categoria.Contains(categoria)).ToList();
            }
        }

        public Post BuscaPorId(int id) {
            using (BlogContext contexto = new BlogContext())
            {
                return contexto.Posts.Find(id);
            }
        }

        public void Remove(int id) {
            using (BlogContext contexto = new BlogContext())
            {
                Post post = contexto.Posts.Find(id);
                contexto.Posts.Remove(post);
                contexto.SaveChanges();
            }
        }

        public void Atualiza(Post post) {
            using (BlogContext contexto = new BlogContext())
            {
                contexto.Entry(post).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Publica(int id)
        {
            using (BlogContext contexto = new BlogContext())
            {
                Post post = contexto.Posts.Find(id);
                post.DataPublicacao = DateTime.Now;
                post.Publicado = true;
                contexto.SaveChanges();
            }
        }
    }
}