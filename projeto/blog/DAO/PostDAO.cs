using System;
using System.Collections.Generic;
using blog.Infra;
using blog.Models;
using MySql.Data.MySqlClient;

namespace blog.DAO
{
    public class PostDAO
    {

        public IList<Post> Lista() {
            IList<Post> posts = new List<Post>();
            using(MySqlConnection connection = ConnectionFactory.CriaConexaoAberta()) {
                MySqlCommand comando = connection.CreateCommand();
                comando.CommandText = "select * from Posts";
                MySqlDataReader leitor = comando.ExecuteReader();
                while(leitor.Read()) {
                    Post post = new Post() {
                        Id = Convert.ToInt32(leitor["id"]),
                        Titulo = Convert.ToString(leitor["titulo"]),
                        Resumo = Convert.ToString(leitor["resumo"]),
                        Categoria = Convert.ToString(leitor["categoria"])
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
        public void Adiciona(Post post)
        {
            using (MySqlConnection connection = ConnectionFactory.CriaConexaoAberta())
            {
                MySqlCommand comando = connection.CreateCommand();
                comando.CommandText = "insert into Posts (Titulo, Resumo, Categoria) values (@titulo, @resumo, @categoria)";
                comando.Parameters.Add(new MySqlParameter("titulo", post.Titulo));
                comando.Parameters.Add(new MySqlParameter("resumo", post.Resumo));
                comando.Parameters.Add(new MySqlParameter("categoria", post.Categoria));
                comando.ExecuteNonQuery();
            }
        }
    }
}