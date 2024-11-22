using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class SingletonListe
    {
        ObservableCollection<string> liste;
        static SingletonListe instance = null; // objet de la classe liste

        public SingletonListe()
        {
            liste = new ObservableCollection<string>();
            liste.Add("marie");
            liste.Add("line");
            liste.Add("victor");
        }

        public static SingletonListe getInstance()
        {
            if (instance == null)
                instance = new SingletonListe();

            return instance;

        }

        public ObservableCollection<string> Liste { get { return liste; } }
        //cette ligne permet de faire la meme chose que celle ci
        /*public ObservableCollection<string> getListe()
        {
            return liste;
        }*/

        public void ajouter(string texte)
        {
            liste.Add(texte);
        }

        
    }
}
