using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice1
{
    internal class SingletonMaison
    {
        ObservableCollection<Maison> listemaisons;
        static SingletonMaison instance = null;

        public SingletonMaison()
        { 
            listemaisons = new ObservableCollection<Maison>();
            listemaisons.Add(new Maison("666666","condo","montreal","10","marche","quebec", "https://urlz.fr/syRC",60000,2,2,true));
            listemaisons.Add(new Maison("666666", "condo", "montreal","10","marche","quebec", "https://urlz.fr/syqd", 60000,2,2,false));
        }
        public static SingletonMaison getInstance()
        {
            if (instance == null)
                instance = new SingletonMaison();
            return instance;
        }

        public ObservableCollection<Maison> Listemaisons
        {
            get { return listemaisons; }
        }

        public void ajouter (Maison maison)
        {
            listemaisons.Add(maison);
        }
    }
}
