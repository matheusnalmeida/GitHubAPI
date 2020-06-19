using Xunit;
using AppGitHubAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestProject1
{
    public class GitHubInfoControllerTests
    {
        [Fact]
        public void TestMeusRepositoriosView()
        {
            var controller = new GitHubInfoController();
            var result = controller.MeusRepositorios() as ViewResult;
            Assert.Equal("MeusRepositorios", result.ViewName);
        }

        [Fact]
        public void TestProcessarFavoritosView()
        {
            var controller = new GitHubInfoController();
            var result = controller.ProcessarFavorito(245853788) as ViewResult;
            Assert.Equal("Index", result.ViewName);
        }

        [Fact]
        public void TestListarFavoritosView()
        {
            var controller = new GitHubInfoController();
            var result = controller.ListarFavoritos() as ViewResult;
            Assert.Equal("ListarFavoritos", result.ViewName);
        }

        [Fact]
        public void TestBuscarRepositorioView()
        {
            var controller = new GitHubInfoController();
            var result = controller.BuscarRepositorio("teste") as ViewResult;
            Assert.Equal("Index", result.ViewName);
        }

        [Fact]
        public void TestRepositoryDetailsView()
        {
            var controller = new GitHubInfoController();
            var result = controller.RepositoryDetails(245853788) as ViewResult;
            Assert.Equal("RepositoryDetails", result.ViewName);
        }
    }
}
