using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFantaMelanie
{
    internal class Activite
    {
        //string idActivite, nom, type, logo;
        //double coutOrganisation, prixVente;

        //public Activite()
        //{
        //    this.idActivite = "";
        //    this.nom = "";
        //    this.type = "";
        //    this.logo = "";
        //    this.coutOrganisation = 0;
        //    this.prixVente = 0;
        //}
        //public Activite(string idActivite, string nom, string type, double coutOrganisation, double prixVente, string logo)
        //{
        //    this.idActivite = idActivite;
        //    this.nom = nom;
        //    this.type = type;
        //    this.coutOrganisation = coutOrganisation;
        //    this.prixVente = prixVente;
        //    this.logo = logo;
        //}

        public string IdActivite
        {
            get; /*{ return this.idActivite; }*/
            set; /*{ this.idActivite = value; }*/
        }

        public string Nom
        {
            get;/* { return this.nom; }*/
            set; /*{ this.nom = value; }*/
        }

        public string Type
        {
            get; /*{ return this.type; }*/
            set;/* { this.nom = value; }*/
        }

        public double CoutOrganisation
        {
            get; /*{ return this.coutOrganisation; }*/
            set; /*{ this.coutOrganisation = value; }*/
        }

        public double PrixVente
        {
            get; /*{ return this.prixVente; }*/
            set; /*{ this.prixVente = value; }*/
        }

        public string Logo
        {
            get; /*{ return this.logo; }*/
            set; /*{ this.logo = value; }*/
        }

        //public string PrixComplet
        //{
        //    get { return prixVente + " $"; }
        //}
    }
}
