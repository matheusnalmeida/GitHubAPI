using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AppGitHubAPI.Models.api_requisition_classes;
using AppGitHubAPI.Models.dao;
using AppGitHubAPI.Models.repo_classes;
using Newtonsoft.Json;

namespace AppGitHubAPI.Models
{
    public class MeusRepositorios : IApiRequisitionInterface<List<Repositorio>>
    {

        public List<Repositorio> RealizaConexao()
        {
            string urlReq = String.Format("https://api.github.com/users/matheusnalmeida/repos");
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
            IEnumerable<Repositorio> repositorios = JsonConvert.DeserializeObject<IEnumerable<Repositorio>>(strresulttest);
            RepositoriosFavoritosDAO repositoriosFavoritos = new RepositoriosFavoritosDAO();

            //Marcando como favorito os repositorios encontrados que ja foram selecionados como favoritos
            foreach (Repositorio repositorio in repositorios.ToList())
            {
                if (repositoriosFavoritos.readALL().Contains(repositorio))
                {
                    repositorio.ehFavorito = true;
                }
                else
                {
                    repositorio.ehFavorito = false;
                }
            }
            return repositorios.ToList();
        }
    }
}
