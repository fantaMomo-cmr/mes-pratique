using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1
{
    internal class Joueur
    {
        string matricul, nom, prenom, dateNaissance;
        // partie 3 j'ajoute la colone nomEquipe
        string nomEquipe;

        public Joueur()
        {
            this.matricul = "";
            this.nom = "";
            this.prenom = "";
            this.dateNaissance = "";
            // partie 3
            this.nomEquipe = "";
        }
        public Joueur(string matricul, string nom, string prenom, string dateNaissance, string nomEquipe)
        {
            this.matricul = matricul;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaissance = dateNaissance;
            this.nomEquipe = nomEquipe;
        }

        public string Matricul
        {
            get { return this.matricul; }
            set { this.matricul = value; }
        }
        public string Nom
        {
            get { return this.nom; }
            set
            {
                this.nom = value;
            }
        }
        public string Prenom
        {
            get { return this.prenom; }
            set { this.prenom = value; }
        }
        public string DateNaissance
        {
            get { return this.dateNaissance; }
            set
            {
                this.dateNaissance = value;
            }
        }

        public string NomEquipe
        {
            get { return this.nomEquipe; }
            set { this.nomEquipe = value; }
        }


    }
}
