using System;
using System.Linq;
using blog.Infra;
using blog.Models;

namespace blog.DAO
{
    public class UsuarioDAO
    {
        private BlogContext contexto;

        public UsuarioDAO(BlogContext contexto)
        {
            this.contexto = contexto;
        }

        public Usuario Busca(string login, string senha)
        {
            return contexto.Usuarios
                        .Where(usuario => usuario.Nome.Equals(login) && usuario.Senha.Equals(senha))
                        .FirstOrDefault<Usuario>();
        }

        public void Adiciona(Usuario usuario)
        {
            contexto.Usuarios.Add(usuario);
            contexto.SaveChanges();
        }
    }
}