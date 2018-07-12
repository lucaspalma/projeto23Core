using System.Collections.Generic;
using blog.Models;
using FluentAssertions;
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
            categoriaComQuantidade.GetCategorias().Should().BeEmpty();
        }

        [Fact]
        public void seListaTiverApenasUmPostDeveriaTerUmaCategoriaComUmDeQuantidade()
        {
            List<Post> posts = new List<Post>() { filmeReiLeao };
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            categoriaComQuantidade.GetCategorias().Should().ContainSingle("Filme");
            categoriaComQuantidade.GetQuantidadeDePostsDa("Filme").Should().Be(1);
        }

        [Fact]
        public void seListaTiverVariosPostTodosComCategoriasDiferentesDeveriaTerTodasAsCategoriaComUmDeQuantidade()
        {
            List<Post> posts = new List<Post>() { filmeReiLeao, musicaRockYou, serieSimpsons };
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            categoriaComQuantidade.GetCategorias().Should().BeEquivalentTo("Filme", "Música", "Série");
            categoriaComQuantidade.GetQuantidadeDePostsDa("Filme").Should().Be(1);
            categoriaComQuantidade.GetQuantidadeDePostsDa("Música").Should().Be(1);
            categoriaComQuantidade.GetQuantidadeDePostsDa("Série").Should().Be(1);
        }


        [Fact]
        public void seListaTiverVariosPostTodosComAMesmaCategoriasDeveriaTerUmaCategoriaComQuantidadeIgualAoNumeroDePosts()
        {
            List<Post> posts = new List<Post>() { filmeReiLeao, filmeToyStory, filmeET };
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            categoriaComQuantidade.GetCategorias().Should().BeEquivalentTo("Filme");  
            categoriaComQuantidade.GetQuantidadeDePostsDa("Filme").Should().Be(3);
        }

        [Fact]
        public void seListaTiverVariosPostCategoriasVariadasDeveriaCadaCategoriaDeveTerASuaQuantidadeDeRepeticoes()
        {
            List<Post> posts = new List<Post>() { filmeReiLeao, musicaRockYou, filmeET };
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            categoriaComQuantidade.GetCategorias().Should().BeEquivalentTo("Filme", "Música");
            categoriaComQuantidade.GetQuantidadeDePostsDa("Filme").Should().Be(2);
            categoriaComQuantidade.GetQuantidadeDePostsDa("Música").Should().Be(1);
        }

        [Fact]
        public void aListaDeCategoriasDeveriaVirEmOrdemAlfabetica()
        {
            List<Post> posts = new List<Post>() { serieSimpsons, filmeReiLeao, musicaRockYou, filmeET };
            CategoriaComQuantidadeViewModel categoriaComQuantidade = new CategoriaComQuantidadeViewModel(posts);
            categoriaComQuantidade.GetCategorias().Should().BeInAscendingOrder();
        }

    }
}