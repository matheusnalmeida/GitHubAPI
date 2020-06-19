using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppGitHubAPI.Models;
using AppGitHubAPI.Models.repo_classes;
using System.Security.Principal;
using AppGitHubAPI.Models.api_requisition_classes;
using AppGitHubAPI.Models.dao;

namespace AppGitHubAPI.Controllers
{
    public class GitHubInfoController : Controller
    {
        public IActionResult Index()
        {
            ViewData["listaDeBuscados"] = new List<Repositorio>();
            return View();
        }

        public IActionResult MeusRepositorios() {
            MeusRepositorios apiRequisition = new MeusRepositorios();
            List<Repositorio> listaDeRepositorios = apiRequisition.RealizaConexao();
            ViewData["listaDeRepositorios"] = listaDeRepositorios;
            ViewData["quantidadeDeRepo"] = listaDeRepositorios.Capacity;
            return View("MeusRepositorios");
        }

        public IActionResult ProcessarFavorito(int repositorio) {
            BuscarRepositorioID buscarRepositorioID = new BuscarRepositorioID(repositorio);
            RepositoriosFavoritosDAO repositoriosFavoritosDAO = new RepositoriosFavoritosDAO();
            Repositorio repositorioEncontrado = buscarRepositorioID.RealizaConexao();
            if (repositoriosFavoritosDAO.containsRepo(repositorioEncontrado))
            {
                repositoriosFavoritosDAO.removerFavorito(repositorioEncontrado);
            }
            else {
                repositoriosFavoritosDAO.adicionaFavorito(repositorioEncontrado);
            }
            ViewData["listaDeBuscados"] = new List<Repositorio>();
            return View("Index");
        }

        public IActionResult ListarFavoritos()
        {
            RepositoriosFavoritosDAO buscarRepositorios = new RepositoriosFavoritosDAO();
            List<Repositorio> favoritos = buscarRepositorios.readALL();
            ViewData["listaDeFavoritos"] = favoritos;
            return View("ListarFavoritos");
        }

        public IActionResult BuscarRepositorio(string nomeRepositorio) {
            BuscarRepositoriosNome buscarRepositorios = new BuscarRepositoriosNome(nomeRepositorio);
            List<Repositorio> result = buscarRepositorios.RealizaConexao();
            ViewData["listaDeBuscados"] = result;
            return View("Index");
        }

        public IActionResult RepositoryDetails(int repositoyID) {
            BuscarRepositorioID buscarRepositorioID = new BuscarRepositorioID(repositoyID);
            Repositorio repositorio = buscarRepositorioID.RealizaConexao();
            BuscarContribuidores buscarContribuidores = new BuscarContribuidores(repositorio.owner.login,repositorio.name);
            List<Usuario> listaDeContribuidores = buscarContribuidores.RealizaConexao();
            ViewData["repositorio"] = repositorio;
            ViewData["listaDeContribuidores"] = listaDeContribuidores;
            return View("RepositoryDetails");
        }
    }
}
