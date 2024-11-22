using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace notesBD
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        MySqlConnection con;
        public MainWindow()
        {
            this.InitializeComponent();
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=420345ri_gr00002_2228749-fanta-hadizatou-momo-mohamadou;Uid=2228749;Pwd=2228749;");
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {

            /* pour l'ancienne facon*/

            lv_lites.Items.Clear(); // pour reinitialiser la liste a chaque fois
            // connexion a la base de données comme en web
          

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from clients";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader(); // retourne un tableau 
            /*
           r.Read(); // read == ajouter permet de lire une ligne et les els de la ligne ( il lit une seule fois). type de retoure=booleen. donc utilise une boucle


           //tbl_texte.Text = r["nom"].ToString(); // renvoie le nom de la premiere personne
           int id = (int)r["id"]; // ou encore  int id = (int)r[0]; pour la position dans notre tableau ou encore  int id = r.GetInt32("id"(methode qui retoure un type)
           string nom = r["nom"].ToString();
           string prenom = r["prenom"].ToString();
           string email = r["email"].ToString();

           tbl_texte.Text = $"{id}- {prenom} {nom} - {email}";

           r.Close(); //  ferme le read
           con.Close(); // ferme la connexion. toujours a la fin 

           */

            // lire chaque ligne et l'ajouter a ma liste. la bouble nous permet de lire chaque ligne de la table
            while (r.Read())
            {
                int id = (int)r["id"]; // ou encore  int id = (int)r[0]; pour la position dans notre tableau ou encore  int id = r.GetInt32("id"(methode qui retoure un type)
                string nom = r[1].ToString();
                string prenom = r["prenom"].ToString();
                string email = r["email"].ToString();

                string texte = $"{id}- {prenom} {nom} - {email}";

                lv_lites.Items.Add(texte);

            }


            r.Close(); //  ferme le read
            con.Close(); // ferme la connexion. toujours a la fin 

        }

        private void btn_ajout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into clients values(1,'doe','john','mail@mail.com')";

                con.Open();
               int i= commande.ExecuteNonQuery(); // retourne le nombre de ligne affecté par notre requete

                con.Close();
            }
            catch (Exception ex)
            {
                tbl_texte.Text = ex.Message;
                if(con.State == System.Data.ConnectionState.Open) // pour verifier l'etat de la connexion . et aussi if elle est ouverte ferme avce le con.close().
                con.Close();
            }

        }

        private void btn_miseJour_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "update clients set email = 'nouveau@mail.com' where id = 3";

                con.Open();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "DELETE FROM clients WHERE id = 3";

                con.Open();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }
    }
}
