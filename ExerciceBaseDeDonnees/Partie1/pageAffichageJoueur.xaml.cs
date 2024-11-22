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
    public sealed partial class pageAffichageJoueur : Page
    {
        public pageAffichageJoueur()
        {
            this.InitializeComponent();
            lv_listeJoueur.ItemsSource = SingletonEquipeetJoueur.getInstance().ListeJoueurs;
        }

        private void deleteJoueur_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            //DataContext représente l'élément parent
            Joueur joueur = button.DataContext as Joueur;

            //permet de s'assurer que nous avons un élément sélectionné
            lv_listeJoueur.SelectedItem = joueur;


            SingletonEquipeetJoueur.getInstance().supprimerJoueur(joueur);
            // Frame.Navigate(typeof(pageAffichage));
        }

        private void lv_listeJoueur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // pour la navigation vers la page de miseAjour
            Joueur joueur = lv_listeJoueur.SelectedItem as Joueur;
            if(joueur != null)
            {
                Frame.Navigate(typeof(pageMiseAJour), joueur);
            }
        }
    }
}
