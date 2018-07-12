using System.Collections.Generic;
using System.Linq;
using blog.Models;

namespace blog.Models
{
    public class CategoriaComQuantidadeViewModel
    {
        private Dictionary<string, int> categoriaPorQuantidade;

        public CategoriaComQuantidadeViewModel(IList<Post> posts)
        {
            categoriaPorQuantidade = new Dictionary<string, int>();
            foreach(Post post in posts) 
            {
                if(categoriaPorQuantidade.ContainsKey(post.Categoria)) {
                    int quantidade = categoriaPorQuantidade[post.Categoria];
                    categoriaPorQuantidade.Remove(post.Categoria);
                    categoriaPorQuantidade.Add(post.Categoria, quantidade + 1);
                }
                else {
                    categoriaPorQuantidade.Add(post.Categoria, 1);
                }
            }
        }

        public IList<string> GetCategorias() {
            return categoriaPorQuantidade.Keys.ToList();
        }

        public int GetQuantidadeDePostsDa(string categoria) {
            return categoriaPorQuantidade[categoria];
        }

    }
}