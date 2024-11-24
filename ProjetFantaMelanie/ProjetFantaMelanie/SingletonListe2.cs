using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFantaMelanie
{
    internal class SingletonListe2
    {

        MySqlConnection con;

        ObservableCollection<Adherent> listeAdherents;

        static SingletonListe2 instance = null;

        public SingletonListe2()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2024_420335ri_eq5;Uid=2228749;Pwd=2228749;");
            listeAdherents = new ObservableCollection<Adherent>();
        }
        public static SingletonListe2 getInstance()
        {
            if (instance == null)
                instance = new SingletonListe2();
            return instance;
        }

        //

        // Création de la methode pour recuperer tous les adhérents

        public void chargerDonneesAdherents()
        {
            listeAdherents.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "select * from adherent;";
            con.Open();

            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                string idAdherent = r[0].ToString();
                string prenom = r[1].ToString();
                string nom = r[2].ToString();
                string adresse = (r[3].ToString());
                string date_naissance = (r[4].ToString());
                int age = Convert.ToInt32(r[5].ToString());

                Adherent unAdherent = new Adherent()
                {
                    IdAdherent = idAdherent,
                    Prenom = prenom,
                    Nom = nom,
                    Adresse = adresse,
                    DateNaissance = date_naissance,
                    Age = age
                };
                listeAdherents.Add(unAdherent);
            }

            r.Close();
            con.Close();

        }

        //retourne la liste des Adherents
        public ObservableCollection<Adherent> GetListeAdherents()
        {
            listeAdherents.Clear();
            chargerDonneesAdherents();
            return listeAdherents;
        }

        // Retourner un adhérenent à une position spécifique
        public Adherent getAdherent(int position)
        {
            return listeAdherents[position];
        }


        //supprime un unAdherent  à une position précise
        public void supprimer(Adherent unAdherent)
        {

            try // en cas d'erreur ferme la connection
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"delete from  adherent where id_adherent = '{unAdherent.IdAdherent}' ";

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();
                listeAdherents.Remove(unAdherent);
                con.Close();
            }
            catch
            {
                if (con.State == System.Data.ConnectionState.Open) // si la connection est ouverte ferme
                    con.Close();
            }


        }

        // Ajouter un adhérent
        public void ajouterAdherent(Adherent unAdherent)
        {

            try // en cas d'erreur ferme la connection
            {

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into adherent(prenom,nom,adresse,date_naissance) values(@prenom, @nom,@adresse, @dateNaissance)";
                commande.Parameters.AddWithValue("@nom", unAdherent.Nom);
                commande.Parameters.AddWithValue("@prenom", unAdherent.Prenom);
                commande.Parameters.AddWithValue("@dateNaissance", unAdherent.DateNaissance);
                commande.Parameters.AddWithValue("@adresse", unAdherent.Adresse);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch
            {
                if (con.State == System.Data.ConnectionState.Open) // si la connection est ouverte ferme
                    con.Close();
            }
        }

        // Modifier un adhérent

        public void modifierAdherent(Adherent unAdherent)
        {

            try // en cas d'erreur ferme la connection
            {

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "update adherent set prenom=@prenom,nom=@nom,adresse=@adresse,date_naissance=@dateNaissance where id_adherent=@id_adherent";
                commande.Parameters.AddWithValue("@id_adherent", unAdherent.IdAdherent);
                commande.Parameters.AddWithValue("@prenom", unAdherent.Prenom);
                commande.Parameters.AddWithValue("@nom", unAdherent.Nom);
                commande.Parameters.AddWithValue("@dateNaissance", unAdherent.DateNaissance);
                commande.Parameters.AddWithValue("@adresse", unAdherent.Adresse);

                con.Open();
                commande.Prepare();
                commande.ExecuteNonQuery();

                con.Close();
            }
            catch
            {
                if (con.State == System.Data.ConnectionState.Open) // si la connection est ouverte ferme
                    con.Close();
            }
        }

        // Recuperer les informations d'un adhérent
        public Adherent infosAdherent(string identifiant)
        {
            Adherent unAdherent = null;
            try // en cas d'erreur ferme la connection
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "IdentifiantAdherent";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@id_adherent", identifiant);
                con.Open();
                commande.Prepare();
                MySqlDataReader r = commande.ExecuteReader();
                if (r.Read())
                {
                    unAdherent = new Adherent()
                    {
                        IdAdherent = r[0].ToString(),
                        Prenom = r[1].ToString(),
                        Nom = r[2].ToString(),
                        Adresse = (r[3].ToString()),
                        DateNaissance = (r[4].ToString()),
                        Age = Convert.ToInt32(r[5].ToString())
                    };
                }
                r.Close();
                con.Close();
            }
            catch
            {
                if (con.State == System.Data.ConnectionState.Open) // si la connection est ouverte ferme
                    con.Close();
            }
            return unAdherent;
        }



    }







    
}
