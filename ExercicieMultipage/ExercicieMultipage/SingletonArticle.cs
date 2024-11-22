using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicieMultipage
{
    internal class SingletonArticle
    {
        ObservableCollection<Articles> listeArticles;
        static SingletonArticle instance = null;

        public SingletonArticle()
        {
            listeArticles = new ObservableCollection<Articles>();
            listeArticles.Add(new Articles("sourie", 15, "neuf", "informatique", "https://www.grosbill.com/images_produits/1c3521b2-142a-4943-abc6-472666d79939.jpg"));
            listeArticles.Add(new Articles("Marmite antiadhesive", 10, "neuf", "cuisine", "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcRNm3Fj5gB8PU7xptEsQijWa61dZXuztTpM0QIEXts2OAdZd20OBu4_BghFd-oSxAORJo50yA_ObKGao6lAxfUnu6THhnTIbKN3jPvGW5GkoA2pUXo6QCMz"));
            listeArticles.Add(new Articles("rateau a feuille", 15, "usage", "jardin", "https://m.media-amazon.com/images/I/71G7DaGXhgL._AC_SX679_.jpg"));
            listeArticles.Add(new Articles("chaise bercante", 20, "neuf", "meuble", "https://www.vitalmobility.ca/media/catalog/product/cache/0093b10637166c8b07efe20cb205a921/1/p/1plr925m-metro-saville-grey.jpg"));

        }
        public static SingletonArticle getInstance()
        {
            if(instance == null)
                instance = new SingletonArticle();
            return instance;
        }
        public ObservableCollection<Articles> ListeArticles // en majuscule car c'est une propriete
        {
            get { return listeArticles; }
        }
        public void ajouter(Articles article)
        {
            listeArticles.Add(article);
        }

        public void supprimer(Articles article)
        {
            listeArticles.Remove(article);
        }
        
    }
}
