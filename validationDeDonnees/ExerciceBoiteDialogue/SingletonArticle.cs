using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceBoiteDialogue
{
    internal class SingletonArticle
    {
        ObservableCollection<Article> listeArticles;
        static SingletonArticle instance = null;

        public SingletonArticle()
        {
            listeArticles = new ObservableCollection<Article>();
            listeArticles.Add(new Article("sourie", 15, "neuf", "Informatique", "https://www.grosbill.com/images_produits/1c3521b2-142a-4943-abc6-472666d79939.jpg"));
            listeArticles.Add(new Article("Marmite antiadhesive", 10, "neuf", "Cuisine", "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcRNm3Fj5gB8PU7xptEsQijWa61dZXuztTpM0QIEXts2OAdZd20OBu4_BghFd-oSxAORJo50yA_ObKGao6lAxfUnu6THhnTIbKN3jPvGW5GkoA2pUXo6QCMz"));
            listeArticles.Add(new Article("rateau a feuille", 15, "usagé", "Jardin", "https://m.media-amazon.com/images/I/71G7DaGXhgL._AC_SX679_.jpg"));
            listeArticles.Add(new Article("chaise bercante", 20, "neuf", "Meuble", "https://www.vitalmobility.ca/media/catalog/product/cache/0093b10637166c8b07efe20cb205a921/1/p/1plr925m-metro-saville-grey.jpg"));
        }
        
        public static SingletonArticle getInstance()
        {
            if(instance == null)
                instance = new SingletonArticle();
            return instance;
        }

        public ObservableCollection<Article> ListeArticles
        {
            get { return listeArticles; }
        }

        public void ajouter(Article article)
        {
            listeArticles.Add(article);
        }

        public void supprimer(Article article)
        {
            listeArticles.Remove(article);
        }
    }
}
