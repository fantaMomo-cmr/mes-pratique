using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFantaMelanie
{
    internal class Singleton
    {
        static MySqlConnection con;

        ObservableCollection<Activite> listeActivites;
       
        ObservableCollection<Seance> listeSeances;

        ObservableCollection<Adherent> listeAdherents;

        ObservableCollection<Participation> listeParticipations;

        Adherent adherentConnecter;

        // creation de l'objet personne connecter
        //PersonneConnecte personneConnecte;
        public PersonneConnecte PersonneConnecte { get; set; }

        //ObservableCollection<Administrateur> listeadministrateurs;


        static Singleton instance = null;

        public Singleton()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2024_420335ri_eq5;Uid=2228749;Pwd=2228749;");
            listeActivites = new ObservableCollection<Activite>();
            ////////////////////////////////
            listeSeances = new ObservableCollection<Seance>();
        }
        public static Singleton getInstance() 
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }

        public ObservableCollection<Activite> ListeActivites
        {
            get 
            {
                chargerDonneesActivites();
                return listeActivites; 
            }
        }
        // ////////////////
        public ObservableCollection<Seance> ListeSeances
        {
            get
            {
                chargerDonneesSeance();
                return listeSeances;
            }
        }
        public ObservableCollection<Seance> SeanceId(Activite uneAct)
        {
           
                afficherSeance(uneAct.IdActivite);
                return listeSeances;
          
        }

        public ObservableCollection<Adherent> ListeAdherents
        {
            get
            {
                chargerDonneesAdherent();
                return listeAdherents;
            }
        }

        public ObservableCollection<Participation> ListeParticipation
        {
            get
            { 
                return listeParticipations;
            }
        }

        /* ---------------------- methode set et get de l'utilisateur connecté --------------------------------------*/
        // si il y a un user connecter afficher ou cacher 
        public bool userConnecte = false;
        public void SetUserConnecte(bool value)
        {
            this.userConnecte = value;
        }
        public bool GetUserConnecte()
        {
           return this.userConnecte;
        }

        // pour voir le role (adherent ou Admin

        private string role;

        public string Role { get => role; set => role = value; }

        /******************************************************************/
         private Frame frame = null;
        
        //public  void SetUtilisateurConnecte(string utilisateurEnLigne)
        //{

        //   // this.utilisateurActif = utilisateurEnLigne;
        //}
         

        public Adherent AdherentConnecte { get { return adherentConnecter; } }

        public Frame Frame { get => frame; set => frame = value; }

        //****************************************************************************************************


        public void chargerDonneesActivites()
        {
            listeActivites.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "select * from Activite;";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                string idActivite = r[0].ToString();
                string nomActivite = r[1].ToString();
                string typeActivite = r[2].ToString();
                double coutOrganisation = Convert.ToDouble(r[3].ToString());
                double prixVente = Convert.ToDouble(r[4].ToString());
                string logo = r[5].ToString();

                Activite activite = new Activite()
                {
                    IdActivite = idActivite,
                    Nom = nomActivite,
                    Type = typeActivite,
                    CoutOrganisation = coutOrganisation,
                    PrixVente = prixVente,
                    Logo = logo
                };

                listeActivites.Add(activite);
            }

            r.Close();
            con.Close();

        }
        // ////////////////////////////////////////////////
        
        public void chargerDonneesSeance()
        {
            listeSeances.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = $"select * from seance";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            { 
                string idSeance = r[0].ToString();
                string idActivite = r[1].ToString();
                string dateSeance = r[2].ToString();
                string heure = r[3].ToString();
                int nbrPlace = Convert.ToInt32(r[4].ToString());

                Seance seance = new Seance()
                {
                    Id_seance =idSeance,
                    Id_activite = idActivite,
                    DateSeance = dateSeance,
                    Heure = heure,
                    Nbr_place = nbrPlace
                };

                listeSeances.Add(seance);
            }
            r.Close();
            con.Close();

        }

        public void chargerDonneesAdherent()
        {
            listeAdherents.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = $"select * from adherent";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                string idAdherent = r[0].ToString();
                string prenom = r[1].ToString();
                string nom = r[2].ToString();
                string adresse = r[3].ToString();
                string dateNaissance = r[4].ToString();
                int age = Convert.ToInt32(r[5].ToString());

                Adherent adherent = new Adherent()
                {
                    IdAdherent = idAdherent,
                    Prenom = prenom,
                    Nom = nom,
                    Adresse = adresse,
                    DateNaissance = dateNaissance,
                    Age = age
                };

                listeAdherents.Add(adherent);
            }
            r.Close();
            con.Close();
        }
        //public void chargerDonneesparticipation()
        //{
        //    listeAdherents.Clear();
        //    MySqlCommand commande = new MySqlCommand();
        //    commande.Connection = con;
        //    commande.CommandText = $"select * from adherent";
        //    con.Open();
        //    MySqlDataReader r = commande.ExecuteReader();
        //    while (r.Read())
        //    {
        //        string idAdherent = r[0].ToString();
        //        string prenom = r[1].ToString();
        //        string nom = r[2].ToString();
        //        string adresse = r[3].ToString();
        //        string dateNaissance = r[4].ToString();
        //        int age = Convert.ToInt32(r[5].ToString());

        //        Adherent adherent = new Adherent()
        //        {
        //            IdAdherent = idAdherent,
        //            Prenom = prenom,
        //            Nom = nom,
        //            Adresse = adresse,
        //            DateNaissance = dateNaissance,
        //            Age = age
        //        };

        //        listeAdherents.Add(adherent);
        //    }
        //    r.Close();
        //    con.Close();
        //}

        public void ajouterActivite(Activite activite)
        {
            string nom = activite.Nom;
            string type = activite.Type;
            double coutOrganisation = activite.CoutOrganisation;
            double prixVente = activite.PrixVente;
            string logo = activite.Logo;

            try
            {
                MySqlCommand commande = new MySqlCommand("pro_ajout_activite");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@unNom", nom);
                commande.Parameters.AddWithValue("@unType", type);
                commande.Parameters.AddWithValue("@unCoutOrganisation", coutOrganisation);
                commande.Parameters.AddWithValue("@unPrixVente", prixVente);
                commande.Parameters.AddWithValue("@unLogo", logo);

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }


        public void supprimerActivite(Activite activite)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"delete from activite where id_activite='{activite.IdActivite}'";

                con.Open();
                int i = commande.ExecuteNonQuery();

                con.Close();

                ListeActivites.Remove(activite);
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        public void updateActivite(Activite activite)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"update activite set nom = '{activite.Nom}', type = '{activite.Type}', cout_organisation ='{activite.CoutOrganisation}', prix_vente ='{activite.PrixVente}', logo ='{activite.Logo}' where id_activite = '{activite.IdActivite}'";

                con.Open();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        // liste des seances pour une activite souhaité

        public void afficherSeance(string idDeActivite)
        {
            listeSeances.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = $"select * from seance where id_activite='{idDeActivite}'";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                string idSeance = r[0].ToString();
                string idActivite = r[1].ToString();
                string dateActivite = r[2].ToString();
                string heureSeance = r[3].ToString();
                int nbrPlace = Convert.ToInt32(r[4].ToString());

                Seance seance = new Seance()
                { 
                    Id_seance = idSeance,
                    Id_activite = idActivite,
                    DateSeance = dateActivite,
                    Heure = heureSeance,
                    Nbr_place = nbrPlace

                };

                
                listeSeances.Add(seance);
            }
            r.Close();
            con.Close();
        }

        /*********************************************************************/
        public bool AuthAdmin(string idAdmin, string password)
        {
            try
            {

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = $"select * from administrateur where id_admin=@id_admin and mot_de_passe =@password";
                commande.Parameters.AddWithValue("@id_admin", idAdmin);
                commande.Parameters.AddWithValue("@password", password);
                con.Open();

                MySqlDataReader r = commande.ExecuteReader();
                if (r.Read())
                {
                    // save du nom, prenom, role de l'administrateur
                    PersonneConnecte = new PersonneConnecte
                    {
                        Prenom = "Admin",
                        Nom = "Admin",
                        Role = "Administrateur"
                    };

                    SetUserConnecte(true);

                    return true;
                }
            }
            catch (Exception ex)
            {
                // Gestion de l'exception
            }
            finally
            {
                // Ferme la connexion dans tous les cas
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return false;
        }


        public void  SelectionnerUnAdherent(string identifiantAdherent)
        {
            adherentConnecter = null;
            Adherent adherent = new Adherent();
            MySqlCommand commande = new MySqlCommand("pro_idAdherent");
            commande.Connection = con;
            commande.CommandType = System.Data.CommandType.StoredProcedure;
            commande.Parameters.AddWithValue("@unId_Adherent", identifiantAdherent);
            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                adherent = new Adherent()
                {
                    IdAdherent = r[0].ToString(),
                    Prenom = r[1].ToString(),
                    Nom = r[2].ToString(),
                    Adresse = (r[3].ToString()),
                    DateNaissance = (r[4].ToString()),
                    Age = Convert.ToInt32(r[5].ToString())
                };
                adherentConnecter = adherent;

                // save du nom, prenom, role de l'adherent
                PersonneConnecte = new PersonneConnecte
                {
                    Prenom = adherent.Prenom,
                    Nom = adherent.Nom,
                    Role = "Adherent"
                };

                SetUserConnecte(true);

            }
            r.Close();
            con.Close();
           
        }

        public void ajouterParticipant( Participation participation)
        {
            string idSeance = participation.Id_seance;
            string idAdherent = participation.Id_adherent;

            try
            {
                MySqlCommand commande = new MySqlCommand("pro_insertParticipant");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@uneSeance", idSeance);
                commande.Parameters.AddWithValue("@unAdherent", idAdherent);

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public void supprimerSeance(Seance seance)
        {
            string idSeance = seance.Id_seance;
            try
            {
                MySqlCommand commande = new MySqlCommand("pro_supprimeParticipantavantSance");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@uneSeance", idSeance);


                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }



        public List<string> selectionnerIDActiviteDansSeance()
        {
            List<string> listeActivite = new List<string>();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "select id_activite from seance";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader(); // retourne un tableau 
            while (r.Read())
            {
                string activite = r[0].ToString();

                listeActivite.Add(activite);
            }

            r.Close(); //  ferme le read
            con.Close(); // ferme la connexion. toujours a la fin 

            return listeActivite;
        }

        public void updateSeance(Seance seance)
        {
            string idSeance = seance.Id_seance;
            string idActivite = seance.Id_activite;
            string date = seance.DateSeance;
            string heure = seance.Heure;
            int nbrPlace = seance.Nbr_place;

            try
            {
                MySqlCommand commande = new MySqlCommand("pro_updateSeance");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                commande.Parameters.AddWithValue("@uneSeance", idSeance);
                commande.Parameters.AddWithValue("@uneActivite", idActivite);
                commande.Parameters.AddWithValue("@uneDate", date);
                commande.Parameters.AddWithValue("@uneHeure", heure);
                commande.Parameters.AddWithValue("@unNbrPlace", nbrPlace);

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
             
        }


    }
}
