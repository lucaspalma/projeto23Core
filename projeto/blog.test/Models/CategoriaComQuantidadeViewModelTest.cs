using System.Collections.Generic;
using blog.Models;
using Xunit;

namespace blog.test.Models
{
    public class CategoriaComQuantidadeViewModelTest
    {
        private Post filmeReiLeao;
        private Post filmeToyStory;
        private Post filmeET;
        private Post musicaRockYou;
        private Post serieSimpsons;

        public CategoriaComQuantidadeViewModelTest()
        {
            this.filmeReiLeao = new Post(){ Titulo = "Rei Leão", Resumo = "Filme sobre o leão Simba", Categoria = "Filme" };
            this.filmeToyStory = new Post(){ Titulo = "Toy Story", Resumo = "Filme dos brinquedos", Categoria = "Filme" };
            this.filmeET = new Post(){ Titulo = "ET", Resumo = "Clássico do Steven Spielberg", Categoria = "Filme" };
            this.musicaRockYou = new Post(){ Titulo = "We Will Rock You", Resumo = "Clássico do Queen", Categoria = "Música" };
            this.serieSimpsons = new Post(){ Titulo = "Simpsons", Resumo = "Comédia da família americana", Categoria = "Série" };
        }

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
            List<Post> posts = new List<Post>() { filmeReiLeao };
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            Assert.Single(categoriaComQuantidade.GetCategorias(), "Filme");
            Assert.Equal(1, categoriaComQuantidade.GetQuantidadeDePostsDa("Filme"));
        }

        [Fact]
        public void seListaTiverVariosPostTodosComCategoriasDiferentesDeveriaTerTodasAsCategoriaComUmDeQuantidade()
        {
            List<Post> posts = new List<Post>() { filmeReiLeao, musicaRockYou, serieSimpsons };
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
            List<Post> posts = new List<Post>() { filmeReiLeao, filmeToyStory, filmeET };
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            Assert.Single(categoriaComQuantidade.GetCategorias(), "Filme");  
            Assert.Equal(3, categoriaComQuantidade.GetQuantidadeDePostsDa("Filme"));
        }

        [Fact]
        public void seListaTiverVariosPostCategoriasVariadasDeveriaCadaCategoriaDeveTerASuaQuantidadeDeRepeticoes()
        {
            List<Post> posts = new List<Post>() { filmeReiLeao, musicaRockYou, filmeET };
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            Assert.Contains("Filme", categoriaComQuantidade.GetCategorias());
            Assert.Contains("Música", categoriaComQuantidade.GetCategorias());
            Assert.Equal(2, categoriaComQuantidade.GetQuantidadeDePostsDa("Filme"));
            Assert.Equal(1, categoriaComQuantidade.GetQuantidadeDePostsDa("Música"));
        }

        [Fact]
        public void aListaDeCategoriasDeveriaVirEmOrdemAlfabetica()
        {
            List<Post> posts = new List<Post>() { serieSimpsons, filmeReiLeao, musicaRockYou, filmeET };
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            Assert.Contains("Filme", categoriaComQuantidade.GetCategorias());
            Assert.Collection(categoriaComQuantidade.GetCategorias(), 
                categoria => Assert.Equal("Filme", categoria),
                categoria => Assert.Equal("Música", categoria),
                categoria => Assert.Equal("Série", categoria)
            );
        }

    }
}