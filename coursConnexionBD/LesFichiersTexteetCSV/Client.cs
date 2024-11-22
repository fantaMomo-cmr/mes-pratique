using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesFichiersTexteetCSV
{
    internal class Client
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }

        /* 2eme option ecrire une propriete */

        public string StringTXT
        {
            get
            {
                return $"{Prenom}-{Nom}";
            }
        }

        //premiere option pour ecrire ligne a ligne il faut definir un toString
        public override string ToString()
        {
            return $"{Prenom} {Nom}";
        }

        /* pour le fichier CSV on doit separer les colone par un ; */
        public string StringCSV
        {
            get
            {
                return $"{Prenom};{Nom}";
            }
        }
    }
}
