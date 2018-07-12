using System.Collections.Generic;
using blog.Models;
using Xunit;

namespace blog.test.Models
{
    public class CategoriaComQuantidadeViewModelTest
    {
        [Fact]
        public void naoDeveriaTerCategoriaSeMandarUmListaVazia()
        {
            List<Post> posts = new List<Post>();
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            Assert.Empty(categoriaComQuantidade.GetCategorias());
        }

        [Fact]
        public void seListaTiverApenasUmPostDeveriaTerUmaCategoriaComUmDeQuantidade()
        {
            List<Post> posts = new List<Post>();
            posts.Add(new Post(){ Titulo = "Rei Leão", Resumo = "Filme sobre o leão Simba", Categoria = "Filme" });
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            Assert.Single(categoriaComQuantidade.GetCategorias(), "Filme");
            Assert.Equal(1, categoriaComQuantidade.GetQuantidadeDePostsDa("Filme"));
        }

        [Fact]
        public void seListaTiverVariosPostTodosComCategoriasDiferentesDeveriaTerTodasAsCategoriaComUmDeQuantidade()
        {
            List<Post> posts = new List<Post>();
            posts.Add(new Post(){ Titulo = "Rei Leão", Resumo = "Filme sobre o leão Simba", Categoria = "Filme" });
            posts.Add(new Post(){ Titulo = "We Will Rock You", Resumo = "Clássico do Queen", Categoria = "Música" });
            posts.Add(new Post(){ Titulo = "Simpsons", Resumo = "Comédia da família americana", Categoria = "Série" });
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            
            Assert.Contains("Filme", categoriaComQuantidade.GetCategorias());
            Assert.Contains("Música", categoriaComQuantidade.GetCategorias());
            Assert.Contains("Série", categoriaComQuantidade.GetCategorias());
            Assert.Equal(1, categoriaComQuantidade.GetQuantidadeDePostsDa("Filme"));
            Assert.Equal(1, categoriaComQuantidade.GetQuantidadeDePostsDa("Música"));
            Assert.Equal(1, categoriaComQuantidade.GetQuantidadeDePostsDa("Série"));
        }


        [Fact]
        public void seListaTiverVariosPostTodosComAMesmaCategoriasDeveriaTerUmaCategoriaComQuantidadeIgualAoNumeroDePosts()
        {
            List<Post> posts = new List<Post>();
            posts.Add(new Post(){ Titulo = "Rei Leão", Resumo = "Filme sobre o leão Simba", Categoria = "Filme" });
            posts.Add(new Post(){ Titulo = "Toy Story", Resumo = "Filme dos brinquedos", Categoria = "Filme" });
            posts.Add(new Post(){ Titulo = "ET", Resumo = "Clássico do Steven Spielberg", Categoria = "Filme" });
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            
            Assert.Single(categoriaComQuantidade.GetCategorias(), "Filme");  
            Assert.Equal(3, categoriaComQuantidade.GetQuantidadeDePostsDa("Filme"));
        }

        [Fact]
        public void seListaTiverVariosPostCategoriasVariadasDeveriaCadaCategoriaDeveTerASuaQuantidadeDeRepeticoes()
        {
            List<Post> posts = new List<Post>();
            posts.Add(new Post(){ Titulo = "Rei Leão", Resumo = "Filme sobre o leão Simba", Categoria = "Filme" });
            posts.Add(new Post(){ Titulo = "We Will Rock You", Resumo = "Clássico do Queen", Categoria = "Música" });
            posts.Add(new Post(){ Titulo = "ET", Resumo = "Clássico do Steven Spielberg", Categoria = "Filme" });
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            
            Assert.Contains("Filme", categoriaComQuantidade.GetCategorias());
            Assert.Contains("Música", categoriaComQuantidade.GetCategorias());
            Assert.Equal(2, categoriaComQuantidade.GetQuantidadeDePostsDa("Filme"));
            Assert.Equal(1, categoriaComQuantidade.GetQuantidadeDePostsDa("Música"));
        }

    }
}