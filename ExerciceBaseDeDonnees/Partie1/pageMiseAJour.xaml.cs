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
    public sealed partial class pageMiseAJour : Page
    {
        Joueur joueur;
        public pageMiseAJour()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if(e.Parameter is not null) // recupere les paramttre du joueur
            joueur = (Joueur)e.Parameter;
            tbl_matricule.Text = joueur.Matricul;
            tbl_nom.Text = joueur.Nom;
            tbl_prenom.Text = joueur.Prenom;
            tbl_dateNaissance.Text = joueur.DateNaissance;
            com_nomEquipe.ItemsSource = SingletonEquipeetJoueur.getInstance().selectionnerNomEquipe();
            com_nomEquipe.SelectedItem = joueur.NomEquipe;
        }

        private void btn_enregister_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            tbl_erreurEqupe.Text = "";

            if(com_nomEquipe.SelectedItem == null)
            {
                tbl_erreurEqupe.Text = "vous devez attribuer un joueur a une equipe";
                valide = false;
            }

            if (valide == true)
            {
                //joueur.Matricul = tbl_matricule.Text;
                //joueur.Nom = tbl_nom.Text;
                //joueur.Prenom = tbl_prenom.Text;
                //joueur.DateNaissance = tbl_dateNaissance.Text;
                joueur.NomEquipe = com_nomEquipe.SelectedItem.ToString();

                SingletonEquipeetJoueur.getInstance().updateJoueur(joueur);

                Frame.Navigate(typeof(pageAffichageJoueur));
            }

        }
    }
}
