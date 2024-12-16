using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFantaMelanie
{
    internal class SingletonListe2
    {

        MySqlConnection con;

        ObservableCollection<Adherent> listeAdherents;
        ObservableCollection<Administrateur> lv_admin;

        static SingletonListe2 instance = null;

        public SingletonListe2()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2024_420335ri_eq5;Uid=2228749;Pwd=2228749;");
            listeAdherents = new ObservableCollection<Adherent>();
            lv_admin = new ObservableCollection<Administrateur>();
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

                DateTime d = (DateTime)r["date_naissance"];
                string date_naissance = d.ToString("dd MMMM yyyy");
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

        public void SelectionnerUnAdherent(string identifiantAdherent)
        {
            listeAdherents.Clear();
           
            
                MySqlCommand commande = new MySqlCommand("pro_idAdherent");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@unId_Adherent", identifiantAdherent);
                con.Open();
                commande.Prepare();
                MySqlDataReader r = commande.ExecuteReader();
                if (r.Read())
                {
                     
                   Adherent unAdherent = new Adherent()
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
            //return listeAdherents.Add(unAdherent);
        }




        /***************************************************************************/

        //retourne l'administrateur en question
        public ObservableCollection<Administrateur> GetAdministrateur()
        {
            lv_admin.Clear();
            retournerAdmin();
            return lv_admin;
        }

        // les informations de l'admin
        public void retournerAdmin()
        {
            lv_admin.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "select * from administrateur";
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                string idAdmin = r[0].ToString();
                string motPasse = r[1].ToString();

                Administrateur unAdmin = new Administrateur()
                {
                    Identifiant = idAdmin,
                    PassWord = motPasse,
                };
                lv_admin.Add(unAdmin);
            }
            r.Close();
            con.Close();

        }



        // Verifier l'existence de l'adhérent dans la bd
        public void VerifierAdherent(string identifiant)
        {
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT COUNT(*) FROM adherent WHERE id_adherent = @identifiant;";
            commande.Parameters.AddWithValue("@numeroAdherent", identifiant);

            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                string idAdherent = r[0].ToString();

                Adherent unAdherent = new Adherent()
                {
                    IdAdherent = idAdherent
                };
                listeAdherents.Add(unAdherent);
            }
            r.Close();
            con.Close();

        }

        /*****Page des statistiques***********************************/

        // Total adherent par activite
        public List<Adherent> nbrTotalAdherentActivite()
        {
            List<Adherent> totalParCat = new List<Adherent>();

            try
            {
                MySqlCommand commande = new MySqlCommand("nbr_total_participant_activite");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                commande.Prepare();

                MySqlDataReader r = commande.ExecuteReader();

                // Parcourir les résultats et ajouter chaque catégorie à la liste
                while (r.Read())
                {
                    string nomActivite = r["NomActivite"].ToString();
                    int total = Convert.ToInt32(r["NbrTotalParticipants"]);

                    Adherent unAdherent = new Adherent
                    {
                        NomActivite = $"{nomActivite}",
                        NbrTotalAdherent = total,
                    };

                    totalParCat.Add(unAdherent);
                }

                r.Close();
                con.Close();
            }
            catch
            {
                if (con.State == System.Data.ConnectionState.Open) // En cas d'erreur, fermer la connexion
                {
                    con.Close();
                }
            }

            return totalParCat;
        }

        // total des adherents
        public int GetTotalAdherents()
        {
            int totalAdherent = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand("nbr_total_adherents");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                commande.Prepare();
                totalAdherent = Convert.ToInt32(commande.ExecuteScalar());

                con.Close();
            }
            catch 
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return totalAdherent;
        }

        // total des activités
        public int GetTotalActivites()
        {
            int totalActivite = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand("nbr_total_activite");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                commande.Prepare();
                totalActivite = Convert.ToInt32(commande.ExecuteScalar());

                con.Close();
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return totalActivite;
        }

        // la moyenne des notes par activité
        public List<Adherent> getMoyenneNoteActivite()
        {
            List<Adherent> totalParCat = new List<Adherent>();

            try
            {
                MySqlCommand commande = new MySqlCommand("moyenne_notes_par_activite");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                commande.Prepare();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {
                    string nomActivite = r["NomActivite"].ToString();
                    double total = Convert.ToDouble(r["MoyenneNotes"]);

                    Adherent unAdherent = new Adherent
                    {
                        NomActivite = $"{nomActivite}",
                        MoyenneNotesParAct = total,
                    };

                    totalParCat.Add(unAdherent);
                }

                r.Close();
                con.Close();
            }
            catch
            {
                if (con.State == System.Data.ConnectionState.Open) // En cas d'erreur, fermer la connexion
                {
                    con.Close();
                }
            }

            return totalParCat;
        }

        // informations sur des adherents ayant participé au moins a une séance d'activité:
        public List<Adherent> GetlisteParticipantsSeance()
        {
            List<Adherent> listeParticipantsSeance = new List<Adherent>();
            try
            {
                MySqlCommand commande = new MySqlCommand("empl_part_seance");
                commande.Connection = con;
                commande.CommandType = CommandType.StoredProcedure;
                con.Open();
                commande.Prepare();
                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read())
                {
                    // ici on met les colonnes que retourne la procedure
                    string nomActivite = r["NomActivite"].ToString();
                    string nomcomplet = r["NomAdherent"].ToString();

                    DateTime d = (DateTime)r["date"];
                    string date_naissance = d.ToString("dd MMMM yyyy");
                    string adresse = r["heure_organisation"].ToString();

                    Adherent unAdherent = new Adherent
                    {
                        NomComplet = $"{nomcomplet}",
                        NomActivite = $"{nomActivite }  ",
                        
                        DateNaissance =  $"{ date_naissance }" ,
                        Adresse = $"{ adresse }"
                    };
                    listeParticipantsSeance.Add(unAdherent);
                }
                con.Close();
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return listeParticipantsSeance; 
        }

        //Afficher la moyenne globale 
        public double getMoyenneGlobale()
        {
            double moyenneGlobale = 0;
            try
            {
                MySqlCommand commande = new MySqlCommand("note_appreciation_globale");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                commande.Prepare();
                moyenneGlobale = Convert.ToDouble(commande.ExecuteScalar());
                con.Close();
            }
            catch
            {
                if (con.State == System.Data.ConnectionState.Open) // En cas d'erreur, fermer la connexion
                {
                    con.Close();
                }
            }
            return moyenneGlobale;
        }


        //-- une procedure qui recense l'activité ayant le plus grand nombre de seance organisée
        public Activite activitePlusGrandNbrSeance()
        {
            Activite uneActivite = null;
            double totalSeance = 0;
            try
            {
                MySqlCommand commande = new MySqlCommand("activite_plus_seances");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                commande.Prepare();
                MySqlDataReader r = commande.ExecuteReader();

                if (r.Read())
                {
                    string nom = r["Nom"].ToString();
                    string type = r["type"].ToString();
                    double cout_organisation = Convert.ToDouble(r["cout_organisation"]);
                    double prix_vente = Convert.ToDouble(r["prix_vente"]);
                    totalSeance = Convert.ToDouble(r[4]);
                    uneActivite = new Activite()
                    {
                        Nom = nom,
                        Type = type,
                        CoutOrganisation = cout_organisation,
                        PrixVente = prix_vente,
                        TotalSeance = totalSeance
                    };
                }
                r.Close();
                con.Close();
            }
            catch
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return uneActivite;
        }

        // Le nombre de séances moyen par activité
        public double nbrMoyenSeanceParActivite()
        {
            double moyenne = 0;

            MySqlCommand commande = new MySqlCommand("nombre_moyen_seances_par_activite");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();

            commande.Prepare();
            moyenne = Convert.ToDouble(commande.ExecuteScalar());
            con.Close();

            return moyenne;

        }



    }
    
}
