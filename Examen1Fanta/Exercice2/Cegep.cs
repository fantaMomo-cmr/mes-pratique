using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice2
{
    internal class Cegep
    {
        string nom;
        string logo;

        public Cegep()
        {
            this.nom = "";
            this.logo = "";
        }
        public Cegep(string nom, string logo)
        {
            this.nom = nom;
            this.logo = logo;
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }
    }
}
