using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Exercice1
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            liste_maison.ItemsSource = SingletonMaison.getInstance().Listemaisons;
        }

        private void garage_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void garage_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void soumettre_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            tbl_numeroRef.Text = "";
            tbl_typeMaison.Text = "";
            tbl_erreurNumeroRue.Text = "";
            tbl_Nomrue.Text = "";
            tbl_erreurville.Text = "";
            tbl_erreurProvince.Text = "";
            tbl_erreurUrl.Text = "";
            double prix = 0;
            int nbrChambre = 0;
            int nbrSalleBain = 0;


            if(tbx_numeroRef.Text.Trim() == "")
            {
                tbl_numeroRef.Text = "Vous devez entrer le numero de red=ference de la maison";
                valide = false;
            }

            if (liste_maison.SelectedItem == null)
            {
                tbl_typeMaison.Text = "faite un choix";
                valide = false;
            }
            // -----------------------------------
            if (double.TryParse(tbx_Prix.Text, out prix) == false)
            {
                tbl_Prix.Text = " entrez un chiffre";
                valide = false;
            }
            //******************************************


            if (tbx_Ville.Text.Trim() == "")
            {
                tbl_erreurville.Text = "entre la ville";
                valide = false;
            }

            if (tbx_NumeroRue.Text.Trim()=="")
            {
                tbl_erreurNumeroRue.Text = "entre le numero de la rue";
                valide = false;
            }
            if (tbx_Nomrue.Text.Trim() == "")
            {
                tbl_Nomrue.Text = "entre le nom de la rue";
                valide = false;
            }
            if (listeProvince.SelectedItem == null)
            {
                tbl_erreurProvince.Text = "faite un choix de province";
                valide = false;
            }

            if (Int32.TryParse(tbx_NbrChambre.Text, out nbrChambre) == false)
            {
                tbl_erreurNbrChambre.Text = " entrez un chiffre";
                valide = false;
            }
            else if (nbrChambre < 1 || nbrChambre > 7)
            {
                tbl_erreurNbrChambre.Text = "entrez un chiffre compris entre 1 et 7";
                valide = false;
            }

            if (Int32.TryParse(tbx_NbrSalleBain.Text, out nbrSalleBain) == false)
            {
                tbl_erreurSalleBain.Text = " entrez un chiffre";
                valide = false;
            }
            else if (nbrSalleBain < 1 || nbrSalleBain > 4)
            {
                tbl_erreurSalleBain.Text = "entrez un chiffre compris entre 1 et 4";
                valide = false;
            }


            if (Uri.IsWellFormedUriString(tbx_photo.Text.Trim(), UriKind.Absolute) == false)
            {
                tbl_erreurUrl.Text = "vous devez entrer l'URL du joueur";
                valide = false;
            }

           


            if (valide == true)
            {
                string numeroRef = tbx_numeroRef.Text;
                string typeMaison = liste_maison.SelectedItem.ToString();
                string ville = tbx_Ville.Text;
                string numRue = tbx_NumeroRue.Text;
                string nomRue = tbx_Nomrue.Text;
                string Province = listeProvince.SelectedItem.ToString();
                string photo = tbx_photo.Text;
                bool garage = false;

                SingletonMaison.getInstance().ajouter(new Maison(numeroRef, typeMaison, ville, numRue, nomRue, photo, Province, prix,nbrChambre,nbrSalleBain,garage));
                
            }
        }

        private void lv_listMaison_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Maison maison = lv_listMaison.SelectedItem as Maison;
        }
    }
}
