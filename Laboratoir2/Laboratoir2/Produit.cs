using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoir2
{
    internal class Produit
    {
        string nom, categorie;
        double prix;

        public Produit()
        {
            this.nom = "";
            this.prix = 0;
            this.categorie = "";
        }

        public Produit(string nom, double prix, string categorie)
        {
            this.nom = nom;
            this.prix = prix;
            this.categorie = categorie;
            
        }

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public double Prix 
        { 
            get { return this.prix; }
            set { this.prix = value; }
        }
        public string Categorie
        {
            get { return this.categorie; }
            set { this.categorie = value; }
        }
    }

    
}
