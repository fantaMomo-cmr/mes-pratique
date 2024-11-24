using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFantaMelanie
{
    internal class Singleton
    {
        MySqlConnection con;

        ObservableCollection<Activite> listeActivites;
        /// <summary>
        /// ////////////////////////////////
        /// </summary>
        ObservableCollection<Seance> listeSeances;

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


    }
}
