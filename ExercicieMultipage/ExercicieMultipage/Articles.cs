using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicieMultipage
{
    public class Articles
    {
        string nom, etat, categorie, image;
        double prix;

        public Articles() 
        {
            this.nom = "";
            this.prix =0;
            this.etat = "";
            this.categorie = "";
            this.image = "";
        }
        public Articles(string nom, double prix, string etat, string categorie, string image)
        {
            this.nom = nom;
            this.prix = prix;
            this.etat = etat;
            this.categorie = categorie;
            this.image = image;
        }

        public string Nom
        {
            get { return this.nom; }
            set
            {
                this.nom = value;
            }
        }

        public double Prix 
        { 
            get { return this.prix; }
            set { this.prix = value; }
        }

        public string Etat
        {
            get { return this.etat; }
            set { this.etat = value; }
        }

        public string Categorie
        {
            get { return this.categorie; }
            set
            {
                this.categorie = value;
            }
        }

        public string Image
        {
            get { return this.image; }
            set
            {
                this.image = value;
            }
        }
    }
}
