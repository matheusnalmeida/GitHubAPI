﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AppGitHubAPI.Models.dao;
using AppGitHubAPI.Models.repo_classes;
using Newtonsoft.Json;

namespace AppGitHubAPI.Models.api_requisition_classes
{
    public class BuscarRepositorioID : IApiRequisitionInterface<Repositorio>
    {
        //Nome do repositorio a ser buscado
        private int idRepositorio;

        public BuscarRepositorioID(int idRepositorio)
        {
            this.idRepositorio = idRepositorio;
        }

        public Repositorio RealizaConexao()
        {
            string urlReq = String.Format("https://api.github.com/repositories/{0}", this.idRepositorio);
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

            Repositorio repositorio = JsonConvert.DeserializeObject<Repositorio>(strresulttest);
            RepositoriosFavoritosDAO repositoriosFavoritos = new RepositoriosFavoritosDAO();

            //Marcando como favorito o repositorio encontrado caso o mesmo esteja na lista de favoritos
            if (repositoriosFavoritos.readALL().Contains(repositorio))
            {
                repositorio.ehFavorito = true;
            }
            else
            {
                repositorio.ehFavorito = false;
            }
            return repositorio;
        }
    }
}
