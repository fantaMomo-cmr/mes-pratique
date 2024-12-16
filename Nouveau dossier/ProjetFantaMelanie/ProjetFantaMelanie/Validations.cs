using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFantaMelanie
{
    class Validations
    {

        public static bool isNomValide(string nom)
        {
            if (!string.IsNullOrEmpty(nom.Trim()))
                return true;
            else
                return false;
        }

        public static bool isPrenomValide(string prenom)
        {
            if (!string.IsNullOrEmpty(prenom.Trim()))
                return true;
            else
                return false;
        }

        public static bool isDateNaisValide(string dateNais)
        {
            DateTime date;
            // Vérifier si la chaîne n'est pas vide ou null et si elle peut être convertie en une date valide
            if (!string.IsNullOrEmpty(dateNais.Trim()) && DateTime.TryParse(dateNais, out date))
                return true;
            else
                return false;
        }


        public static bool isLienValide(string lien)
        {
            if (Uri.IsWellFormedUriString(lien, UriKind.Absolute))
                return true;
            else
                return false;
        }

    }
}
