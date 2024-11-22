using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceCollection
{
    // tres important de mettre la classe en public en rempllacant (internal partial class Employes) par (public class Employes)
    public class Employes
    {
        string matricule;
        string nom;
        string prenom;
        string departement;
        
        public Employes()
        {
            this.matricule = "";
            this.nom = "";
            this.prenom = "";
            this.departement = "";
        }
        public Employes(string matricule, string nom, string prenom, string departement)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
            this.departement = departement;
        }
        public string Matricule
        {
            get => matricule;

            set
            {
                matricule = value;
            }
        }
        public string Nom
        {
            get => nom;
            set
            {
                nom = value;
            }
        }
        public string Prenom
        {
            get => prenom;
            set
            {
                prenom = value;
                
            }
        }
        public string Departement
        {
            get => departement;
            set
            {
                departement = value;
                
            }
        }

        public string NomComplet
        {
            get { return prenom + " " + nom; }
        }
    }
}
