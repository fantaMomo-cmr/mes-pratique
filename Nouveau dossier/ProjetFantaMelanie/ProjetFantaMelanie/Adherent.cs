﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFantaMelanie
{
    internal class Adherent
    {
        public string IdAdherent { get; set; }

        public string Prenom { get; set; }

        public string Nom {get; set;}

        public string Adresse { get; set; }

        public string DateNaissance { get; set; }

        public int Age { get; set; }

        public string NomActivite { get; set; }

        public int NbrTotalAdherent { get; set; }

        public double MoyenneNotesParAct { get; set; }

        // Nom complet des adhérents
        public string NomComplet {  get; set; }
    
    }
}
