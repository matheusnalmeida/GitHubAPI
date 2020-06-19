using AppGitHubAPI.Models.dao;
using AppGitHubAPI.Models.repo_classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AppGitHubAPI.Models.api_requisition_classes
{
    public class BuscarRepositoriosNome : IApiRequisitionInterface<List<Repositorio>>
    {
        //Nome do repositorio a ser buscado
        private string nomeRepositorio;

        public BuscarRepositoriosNome(string nomeRepositorio) {
            this.nomeRepositorio = nomeRepositorio;
        }

        public List<Repositorio> RealizaConexao()
        {
            string urlReq = String.Format("https://api.github.com/search/repositories?q={0}+in:name", this.nomeRepositorio);
            HttpWebRequest requestObj = (HttpWebRequest)WebRequest.Create(urlReq);
            requestObj.UserAgent = "request";
            requestObj.Method = "GET";
            HttpWebResponse responseObjGet = (HttpWebResponse)requestObj.GetResponse();
            string strresulttest = null;
            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresulttest = sr.ReadToEnd();
                sr.Close();
            }


            FindRepos repositorios = JsonConvert.DeserializeObject<FindRepos>(strresulttest);
            RepositoriosFavoritosDAO repositoriosFavoritos = new RepositoriosFavoritosDAO();

            //Marcando como favorito os repositorios encontrados que ja foram selecionados como favoritos
            foreach (Repositorio repositorio in repositorios.items) {
                if (repositoriosFavoritos.readALL().Contains(repositorio))
                {
                    repositorio.ehFavorito = true;
                }
                else {
                    repositorio.ehFavorito = false;
                }
            }

            return repositorios.items;
        }
    }
}
