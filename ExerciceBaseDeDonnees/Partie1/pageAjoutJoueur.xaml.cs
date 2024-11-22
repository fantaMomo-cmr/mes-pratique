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

namespace Partie1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pageAjoutJoueur : Page
    {
        Joueur joueur;
        public pageAjoutJoueur()
        {
            this.InitializeComponent();
            joueur = new Joueur();
            datepiker.MaxYear = new DateTimeOffset( new DateTime(2007, 12, 31));
            datepiker.MinYear = new DateTimeOffset(new DateTime(1997, 12, 20));
        }

        private void ajouterJoueur_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
          
            tblErreurNom.Text = "";
            tblErreurPre.Text = "";
            tblErreurDate.Text = "";

            //-------------------------------------------
            if (tbx_nom.Text.Trim() == "")
            {
                tblErreurNom.Text = "entrez le nom du joueur";
                valide = false;
            }

            if (tbx_prenom.Text.Trim() == "")
            {
                tblErreurPre.Text = "entrez le prenom du joueur";
                valide = false;
            }

            if(datepiker.SelectedDate == null)
            {
                tblErreurDate.Text = "vous devez choisir la date de naissance du joueur";
                valide = false;
            }
         
            if (valide == true)
            {
               
                joueur.Nom = tbx_nom.Text;
                joueur.Prenom = tbx_prenom.Text;
                joueur.DateNaissance = datepiker.Date.ToString("d");
               

                SingletonEquipeetJoueur.getInstance().ajouterJoueur(joueur);
                Frame.Navigate(typeof(pageAffichageJoueur));
            }

        }
    }
}
