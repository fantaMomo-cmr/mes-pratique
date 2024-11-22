using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice2
{
    internal class SingletonCegep
    {
        ObservableCollection<Cegep> listeCegep;
        static SingletonCegep instance = null;

        public SingletonCegep()
        {
            listeCegep = new ObservableCollection<Cegep>();
            listeCegep.Add(new Cegep("Cégep de la Gaspésie et des Île", "https://fedecegeps.ca/wp-content/uploads/2019/06/gaspe-300x80.jpg"));
            listeCegep.Add(new Cegep("Cégep de Matane", "https://fedecegeps.ca/wp-content/uploads/2019/06/cegep-de-la-pocatiere-1-300x135.jpg"));
            listeCegep.Add(new Cegep("Cégep de La Pocatière", "https://fedecegeps.ca/wp-content/uploads/2019/08/cegepmatane-couleur-300x84.jpg"));
        }
        public static SingletonCegep getInstance()
        {
            if (instance == null)
                instance = new SingletonCegep();
            return instance;
        }
        public ObservableCollection<Cegep> ListeCegep
        {
            get { return listeCegep; }
        }

        public void ajouter(Cegep cegep)
        {
            listeCegep.Add(cegep);
        }

        public void supprimer(Cegep cegep)
        {
            listeCegep.Remove(cegep);
        }
    }
}
