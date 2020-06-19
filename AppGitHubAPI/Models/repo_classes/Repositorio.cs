using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppGitHubAPI.Models.repo_classes
{
    public class Repositorio
    {
        public int id { get; set; }
        public string name { get; set; }
        public Usuario owner { get; set; }
        public string description { get; set; }
        public string contributors_url { get; set; }
        public DateTime updated_at { get; set; }
        public string language { get; set; }
        public bool ehFavorito { get; set; }
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Repositorio p = (Repositorio)obj;
                return (this.id == p.id);
            }
        }
    }
}
