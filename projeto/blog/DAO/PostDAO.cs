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
        private readonly BlogContext contexto;

        public PostDAO(BlogContext contexto)
        {
            this.contexto = contexto;
        }

        public IList<Post> Lista() {
            return contexto.Posts.ToList();
        }

        public IList<Post> ListaPublicados()
        {
            return contexto.Posts.Where(p => p.Publicado).OrderByDescending(p => p.DataPublicacao).ToList();
        }

        public IList<Post> BuscaPeloTermo(string termo)
        {
            return contexto.Posts
                        .Where(p => (p.Publicado) && (p.Titulo.Contains(termo) || p.Resumo.Contains(termo)))
                        .Select(p => p)
                        .ToList();
        }

        public void Adiciona(Post post, Usuario usuario)
        {
            contexto.Attach(usuario);
            post.Autor = usuario;
            contexto.Posts.Add(post);
            contexto.SaveChanges();
        }

        public IList<Post> FiltraPorCategoria(string categoria) {
            return contexto.Posts.Where(post => post.Categoria.Contains(categoria)).ToList();
        }

        public Post BuscaPorId(int id) {
            return contexto.Posts.Find(id);
        }

        public void Remove(int id) {
            Post post = contexto.Posts.Find(id);
            contexto.Posts.Remove(post);
            contexto.SaveChanges();
        }

        public void Atualiza(Post post) {
            contexto.Entry(post).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Publica(int id)
        {
            Post post = contexto.Posts.Find(id);
            post.DataPublicacao = DateTime.Now;
            post.Publicado = true;
            contexto.SaveChanges();
        }

        public IList<string> ListaCategoriasQueContemTermo(string termo)
        {
            return contexto.Posts
                        .Where(p => p.Categoria.Contains(termo))
                        .Select(p => p.Categoria)
                        .Distinct()
                        .ToList();
        }
    }
}