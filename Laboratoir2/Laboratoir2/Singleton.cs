using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoir2
{
    internal class Singleton
    {
        MySqlConnection con;

        ObservableCollection<Produit> listeProduits;
        
        static Singleton instance = null;

        public Singleton()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=420345ri_gr00002_2228749-fanta-hadizatou-momo-mohamadou;Uid=2228749;Pwd=2228749;");

            listeProduits = new ObservableCollection<Produit>();
        }

        public static Singleton getInstance()
        {
            if(instance == null)
                instance = new Singleton();
            return instance;
        }

        
        public ObservableCollection<Produit> Listeproduits
        {
            get 
            {
                chargerDonneesProduits();
                return listeProduits; 
            }
        }

        public void chargerDonneesProduits()
        {
            listeProduits.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "select * from produits";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                string nom = r[0].ToString();
                double prix = Convert.ToDouble(r[1].ToString());
                string categorie = r[2].ToString();

                listeProduits.Add(new Produit(nom, prix, categorie));
            }
            r.Close();
            con.Close();
        }

        public void ajouterProduit(Produit produit)
        {
            string nom = produit.Nom;
            double prix = Convert.ToDouble(produit.Prix);
            string categorie = produit.Categorie;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"insert into produits values(@nom, @prix, @categorie)";
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prix", prix);
                commande.Parameters.AddWithValue("@categorie", categorie);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery(); // retourne le nombre de ligne affecté par notre requete

                con.Close();
            }
            catch(Exception ex)
            {
                if (con.State == System.Data.ConnectionState.Open) // pour verifier l'etat de la connexion . et aussi if elle est ouverte ferme avce le con.close().
                    con.Close();
            }
        }

        public void supprimer(Produit produit)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"DELETE FROM produits WHERE nom = '{produit.Nom}'";

                con.Open();
                int i = commande.ExecuteNonQuery();

                con.Close();

                Listeproduits.Remove(produit);
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        public List<string> selectionnerCategorieProduit()
        {
            List<string> listeCategoriesProduit = new List<string>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "select distinct categorie from produits";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader(); // retourne un tableau 
            while (r.Read())
            {
                string categorie = r[0].ToString();

                listeCategoriesProduit.Add(categorie);
            }

            r.Close(); //  ferme le read
            con.Close(); // ferme la connexion. toujours a la fin 

            return listeCategoriesProduit;
        }

        public void rechercherCategorie(string categorieProduit)
        {
            ObservableCollection<Produit> listeRecherche = new ObservableCollection<Produit>();
            listeProduits.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = $"select * from produits where categorie = '{categorieProduit}'";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader(); // retourne un tableau 
            while (r.Read())
            {
                string nom = r[0].ToString();
                double prix = Convert.ToDouble(r[1].ToString());
                string categorie = r[2].ToString();



                listeProduits.Add(new Produit(nom, prix, categorie));

            }

            r.Close(); //  ferme le read
            con.Close(); // ferme la connexion. toujours a la fin 

        }

        public void recherchePrix(double prix1, double prix2)
        {
            listeProduits.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = $"select * from produits where prix between {prix1} and {prix2}";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader(); // retourne un tableau 
            while (r.Read())
            {
                string nom = r[0].ToString();
                double prix = Convert.ToDouble(r[1].ToString());
                string categorie = r[2].ToString();



                listeProduits.Add(new Produit(nom, prix, categorie));

            }

            r.Close(); //  ferme le read
            con.Close(); // ferme la connexion. toujours a la fin 
        }

        public int totalProduits()
        {
            int nombreTotal =0;

            listeProduits.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "select count(*) from produits";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            if (r.Read())
            {
                nombreTotal = Convert.ToInt32(r[0].ToString());
            }
            r.Close();
            con.Close();
            return nombreTotal;
        }

        public List<string> NombreCategories()
        {
            List<string> listeproduitCategorie = new List<string>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = $"select count(*), categorie from produits group by categorie";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader(); // retourne un tableau 
            while (r.Read())
            {
                int nbr = Convert.ToInt32(r[0].ToString());
                string categorie = r[1].ToString();

                string liste = categorie+ "    "+ nbr ;


                listeproduitCategorie.Add(liste);
            }

            r.Close(); //  ferme le read
            con.Close(); // ferme la connexion. toujours a la fin 

            return listeproduitCategorie;

        }

        public List<string> produitPlusChere()
        {
           
            List<string> produitPlusChere = new List<string>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = $"select * from produits order by prix desc limit 1";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader(); // retourne un tableau 
            if(r.Read())
            {
                string nom = r[0].ToString();
                double prix = Convert.ToDouble(r[1].ToString());
                string categorie = r[2].ToString();

                string lepluschere = nom + " " + prix + "$ " + categorie;

                produitPlusChere.Add(lepluschere);
            }

            r.Close(); //  ferme le read
            con.Close(); // ferme la connexion. toujours a la fin

            return produitPlusChere;
        }



        


    }
}
