using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1
{
    public class Equipe
    {
        string nom, ville, logo;

        public Equipe()
        {
            this.nom = "";
            this.ville = "";
            this.logo = "";
        }

        public Equipe(string nom, string ville, string logo)
        {
            this.nom = nom;
            this.ville = ville;
            this.logo = logo;
        }

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }

        public string Ville
        {
            get { return this.ville; }
            set { this.ville = value; }
        }

        public string Logo
        {
            get { return this.logo; }
            set
            {
                this.logo = value;
            }
        }
    }
}
