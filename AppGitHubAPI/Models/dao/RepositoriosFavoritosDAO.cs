using AppGitHubAPI.Models.repo_classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AppGitHubAPI.Models.dao
{
    public class RepositoriosFavoritosDAO
    {
        private List<Repositorio> repositorios;

        public RepositoriosFavoritosDAO()
        {
            this.carregaJson();
        }

        //Metodo responsavel por ler o arquivo json de repositorios favoritos
        private void carregaJson()
        {
            string path = "RepositoriosFavoritos.json";
            string jsonFromFile;
            using (var reader = new StreamReader(path))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            IEnumerable<Repositorio> dataProcessed = JsonConvert.DeserializeObject<IEnumerable<Repositorio>>(jsonFromFile);
            this.repositorios = dataProcessed.ToList();
        }

        //Metodo responsavel por escrever no arquivo json de repositorios favoritos
        private void atualizaJson()
        {
            string path = "RepositoriosFavoritos.json";
            //Limpando texto do arquivo
            System.IO.File.WriteAllText(path, "[  ]");
            //Escrevendo dados atualizados
            var jsonToWrite = JsonConvert.SerializeObject(this.repositorios, Formatting.Indented);

            using (var writer = new StreamWriter(path))
            {
                writer.Write(jsonToWrite);
            }
        }

        //Metodo responsavel por adicionar um repositorio no arquivo json
        public void adicionaFavorito(Repositorio repositorio)
        {
            repositorio.ehFavorito = true;
            this.repositorios.Add(repositorio);
            this.atualizaJson();
        }

        //Metodo responsavel por remover um repositorio no arquivo json
        public void removerFavorito(Repositorio repositorio)
        {
            repositorio.ehFavorito = false;
            this.repositorios.Remove(repositorio);
            this.atualizaJson();
        }

        //Metodo responsavel por retornar todos os dados do arquivo
        public List<Repositorio> readALL()
        {
            return this.repositorios;
        }

        //Metodo responsavel por verificar se um dado repositorio existe no banco
        public bool containsRepo(Repositorio repositorio)
        {
            return this.repositorios.Exists(e => (e.id == repositorio.id));
        }
    }

}
