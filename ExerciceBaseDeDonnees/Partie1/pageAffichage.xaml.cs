using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySqlX.XDevAPI;
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
    public sealed partial class pageAffichage : Page
    {
        public pageAffichage()
        {
            this.InitializeComponent();
            gv_listeEquipe.ItemsSource = SingletonEquipeetJoueur.getInstance().ListeEquipes;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            //DataContext représente l'élément parent
            Equipe equipe = button.DataContext as Equipe;

            //permet de s'assurer que nous avons un élément sélectionné
            gv_listeEquipe.SelectedItem = equipe;


            SingletonEquipeetJoueur.getInstance().supprimer(equipe);
           // Frame.Navigate(typeof(pageAffichage));
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pageAjouter));
        }

        private void gv_listeEquipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // pour la navigation vers la page de EQUIPEetJOUEUR

            Equipe equipe = gv_listeEquipe.SelectedItem as Equipe;
            if(equipe != null)
            {
                Frame.Navigate(typeof(pageAffichageEQUIPEetJOUEUR), equipe);
            }
        }
    }
}
