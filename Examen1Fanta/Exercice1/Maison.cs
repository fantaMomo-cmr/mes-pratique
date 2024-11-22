using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1
{
    internal class Maison
    {
        string numeroReference, typeMaison, ville, numeroRue, nomRue, province, photo;
        double prix;
        int nbrChambre, nbrSalleBain;
        bool garage;
        string vrai = "avec garage";
        string faux = "sans garage";
        public Maison()
        {
            this.numeroReference = "";
            this.typeMaison = "";
            this.ville = "";
            this.numeroRue = "";
            this.nomRue = "";
            this.province = "";
            this.photo = "";
            this.prix = 0;
            this.nbrChambre = 0;
            this.nbrSalleBain = 0;
            this.garage = true;
         }

        public Maison(string numeroReference, string typeMaison, string ville, string numeroRue, string nomRue, string province, string photo, double prix, int nbrChambre, int nbrSalleBain, bool garage)
        {
            this.numeroReference = numeroReference;
            this.typeMaison = typeMaison;
            this.ville = ville;
            this.numeroRue = numeroRue;
            this.nomRue = nomRue;
            this.province = province;
            this.photo = photo;
            this.prix = prix;
            this.nbrChambre = nbrChambre;
            this.nbrSalleBain = nbrSalleBain;
            this.garage = garage;
        }
        public string NumeroReference
        {
            get { return numeroReference; }
            set { numeroReference = value; }
        }
        public string TypeMaison
        {
            get { return typeMaison; }
            set { typeMaison = value; }
        }
        public string Ville
        {
            get { return ville; }
            set { ville = value;}
        }
        public string NumeroRue
        {
            get { return numeroRue; }
            set
            {
               numeroRue = value;
            }
        }
        public string NomRue
        {
            get { return nomRue; }
            set
            {
               nomRue = value;
            }
        }
        public string Province
        {
            get { return province; }
            set
            {
                province = value;
            }
        }
        public string Photo
        {
            get { return photo; }
            set
            {
                photo = value;
            }
        }
        public double Prix
        {
            get { return prix; }
            set
            {
                prix = value;
            }
        }
        public int NbrChambre
        {
            get { return nbrChambre; }
            set { nbrChambre = value; }
        }
        public int NbrSalleBain
        {
            get { return nbrSalleBain; }
            set
            {
                nbrSalleBain = value;
            }
        }
        public bool Garage
        {
            get
            {
                if(garage == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                garage = value;
            }
        }
    }
}
