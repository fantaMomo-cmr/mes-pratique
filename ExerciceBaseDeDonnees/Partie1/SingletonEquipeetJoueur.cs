using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1
{
    internal class SingletonEquipeetJoueur
    {
        MySqlConnection con;
        
        //collection pour les equipes
        ObservableCollection<Equipe> listeEquipes;

        // collection pour les joueurs
        ObservableCollection<Joueur> listeJoueurs;
        static SingletonEquipeetJoueur instance = null;

        public SingletonEquipeetJoueur()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=420345ri_gr00002_2228749-fanta-hadizatou-momo-mohamadou;Uid=2228749;Pwd=2228749;");
            
            // pour mes deux table
            listeEquipes = new ObservableCollection<Equipe>();
            listeJoueurs = new ObservableCollection<Joueur>();
        
        }

        public static SingletonEquipeetJoueur getInstance()
        {
            if(instance == null)
                instance = new SingletonEquipeetJoueur();
            return instance;
        }
        /* ---------------------------------- charger les données de la table equipe dans ma liste ------------------------------------------- */
        public ObservableCollection<Equipe> ListeEquipes
        {
            get 
            {
                chargerDonnees();
                return listeEquipes; 
            }
        }

        /* ---------------------------------- charger les données de la table joueur dans ma liste ------------------------------------------- */
        public ObservableCollection <Joueur> ListeJoueurs
        {
            get 
            { 
                chargerDonneesJoueur();
                return listeJoueurs; 
            }
        }

        /* ---------------------------------- charger les données pour table equipe ------------------------------------------- */
        public void chargerDonnees()
        {
            listeEquipes.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from equipe";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader(); // retourne un tableau 
            while (r.Read())
            {
                string nom = r[0].ToString();
                string ville = r[1].ToString();
                string logo = r[2].ToString();
           

                listeEquipes.Add(new Equipe(nom, ville, logo));
            }

            r.Close(); //  ferme le read
            con.Close(); // ferme la connexion. toujours a la fin 

        }
        /* ---------------------------------- charger les données pour table joueur ------------------------------------------- */
        public void chargerDonneesJoueur()
        {
            listeJoueurs.Clear();
            MySqlCommand commandeSelectJoueur = new MySqlCommand();
            commandeSelectJoueur.Connection = con;
            commandeSelectJoueur.CommandText = "SELECT * FROM joueur";
            con.Open();
            MySqlDataReader r = commandeSelectJoueur.ExecuteReader();
            while (r.Read())
            {
                string matricule = r[0].ToString();
                string nom = r[1].ToString();
                string prenom = r[2].ToString();
                DateTime d = (DateTime)r[3];
                string dateNaissance = d.ToString("d");
                // partie3
                string nomEquipe = r[4].ToString();

                listeJoueurs.Add(new Joueur(matricule, nom, prenom, dateNaissance,nomEquipe));
            }
            r.Close();
            con.Close();

        }

        public void ajouter(Equipe equipe)
        {
            string nom = equipe.Nom;
            string ville = equipe.Ville;
            string logo = equipe.Logo;
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"insert into equipe values(@nom, @ville, @logo)";
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@ville", ville);
                commande.Parameters.AddWithValue("@logo", logo);


                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery(); // retourne le nombre de ligne affecté par notre requete

                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == System.Data.ConnectionState.Open) // pour verifier l'etat de la connexion . et aussi if elle est ouverte ferme avce le con.close().
                    con.Close();
            }
        }
        /* ---------------------------------- ajouter les données pour table joueur ------------------------------------------- */

        public void ajouterJoueur(Joueur joueur)
        {
            string matricule = joueur.Matricul;
            string nom = joueur.Nom;
            string prenom = joueur.Prenom;
            string dateNaissance = joueur.DateNaissance;
            Boolean valide = true;
            do
            {
                char n = joueur.Nom[0];
                char p = joueur.Prenom[0];
                string nbrtrois = new Random().Next(100, 999).ToString();
                matricule = n.ToString() + p.ToString() + nbrtrois;

                try
                {
                    MySqlCommand commande = new MySqlCommand();
                    commande.Connection = con;
                    commande.CommandText = "select * from joueur where matricule=@matricule'";
                    commande.Parameters.AddWithValue("@matricule", matricule);
                    con.Open();
                    MySqlDataReader r = commande.ExecuteReader();
                    if (r.Read())
                    {
                        valide = false;
                    }
                    r.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    if (con.State == System.Data.ConnectionState.Open) // pour verifier l'etat de la connexion . et aussi if elle est ouverte ferme avec le con.close().
                        con.Close();

                }
            }
            while (!valide);
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into joueur (matricule, nom, prenom, date_naissance) values(@matricule,@nom, @prenom, @dateNaissance) ";
                commande.Parameters.AddWithValue("@matricule", matricule);
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);
                commande.Parameters.AddWithValue("@dateNaissance", dateNaissance);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                //message d'erreur
                if (con.State == System.Data.ConnectionState.Open) // pour verifier l'etat de la connexion . et aussi if elle est ouverte ferme avec le con.close().
                    con.Close();
            }
        }

        public void supprimer(Equipe equipe)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"DELETE FROM equipe WHERE nom = '{equipe.Nom}'";

                con.Open();
                int i = commande.ExecuteNonQuery();

                con.Close();

                listeEquipes.Remove(equipe);
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        /* ---------------------------------- supprimer les données pour table joueur ------------------------------------------- */
        public void supprimerJoueur(Joueur joueur)
        {
            try
            {
                MySqlCommand commandesupJ = new MySqlCommand();
                commandesupJ.Connection = con;
                commandesupJ.CommandText = $"DELETE FROM joueur WHERE matricule = '{joueur.Matricul}'";

                con.Open();
                int i = commandesupJ.ExecuteNonQuery();

                con.Close();

                listeJoueurs.Remove(joueur);
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        public void rechercher(string recherVille)
        {
            listeEquipes.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = $"Select * from equipe WHERE ville='{recherVille}'";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader(); // retourne un tableau 
            while (r.Read())
            {
                string nom = r[0].ToString();
                string ville = r[1].ToString();
                string logo = r[2].ToString();



                listeEquipes.Add(new Equipe(nom, ville, logo));

            }

            r.Close(); //  ferme le read
            con.Close(); // ferme la connexion. toujours a la fin 
        }

       //             mise a jour des données dans la table joueur pour la colone nomEquipe
       public void updateJoueur(Joueur joueur)
        {
            try
            {
                MySqlCommand commandeUpJ = new MySqlCommand();
                commandeUpJ.Connection = con;
                commandeUpJ.CommandText = $"update joueur set nomEquipe = '{joueur.NomEquipe}' where matricule = '{joueur.Matricul}'";

                con.Open();
                int i = commandeUpJ.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        // pour selectionner le nom des equipe et remplire mon combox pour la mise a jour
        public List<string> selectionnerNomEquipe()
        {
            List<string> listeNomsEquipes = new List<string>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select nom from equipe";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader(); // retourne un tableau 
            while (r.Read())
            {
                string nom = r[0].ToString();

                listeNomsEquipes.Add(nom);
            }

            r.Close(); //  ferme le read
            con.Close(); // ferme la connexion. toujours a la fin 

            return listeNomsEquipes;
        }

        // pour afficher l'ecquipe et le liste de ses joueur
        public List<string> AfficheEquipeJoueur(string equipe)
        {
            List<string> listeEquipesEquipeJoueur = new List<string>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = $"select e.nom, j.prenom, j.nom, j.matricule from equipe e inner join joueur j on e.nom = j.nomEquipe where e.nom = '{equipe}'";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader(); // retourne un tableau 
            while (r.Read())
            {
                string nomE = r[0].ToString();
                string prenomJ = r[1].ToString();
                string nomJ = r[2].ToString();

                string listeJoueur = nomE + " " + prenomJ + " " + nomJ;
                
                listeEquipesEquipeJoueur.Add(listeJoueur);
            }

            r.Close(); //  ferme le read
            con.Close(); // ferme la connexion. toujours a la fin 

            return listeEquipesEquipeJoueur;
        }


    }
}
