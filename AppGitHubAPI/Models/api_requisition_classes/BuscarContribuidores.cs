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
    public class BuscarContribuidores : IApiRequisitionInterface<List<Usuario>>
    {
        private string loginUser;
        private string repoName;

        public BuscarContribuidores(string loginUser, string repoName) {
            this.loginUser = loginUser;
            this.repoName = repoName;
        }

        public List<Usuario> RealizaConexao()
        {
        
            string urlReq = String.Format("https://api.github.com/repos/{0}/{1}/contributors", this.loginUser,this.repoName);
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

            IEnumerable<Usuario> contribuidores = JsonConvert.DeserializeObject<IEnumerable<Usuario>>(strresulttest);

            return contribuidores.ToList();
        }
    }
}
