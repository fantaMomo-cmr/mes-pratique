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

namespace ProjetFantaMelanie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAffichageActivite : Page
    {
        public PageAffichageActivite()
        {
            this.InitializeComponent();
            lv_listeActivites.ItemsSource = Singleton.getInstance().ListeActivites;
            
        }

        private void lv_listeActivites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activite activite = lv_listeActivites.SelectedItem as Activite;
            if (activite != null)
            {
                Frame.Navigate(typeof(PageDetailActivite), activite);  
            }
        }

        private async void deleteActivite_Click(object sender, RoutedEventArgs e)
        {
            // ouverture d'une boite de dialogue pour l'ajout
            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = mainScrol.XamlRoot;
            dialog.Title = "Attention";
            dialog.PrimaryButtonText = "oui";
            dialog.CloseButtonText = "non";
            dialog.DefaultButton = ContentDialogButton.Close;
            dialog.Content = "Desirez vous supprimer cette activité ?";

            ContentDialogResult resultat = await dialog.ShowAsync();
            if (resultat == ContentDialogResult.Primary)
            {
                Button button = sender as Button;

                Activite activite = button.DataContext as Activite;

                lv_listeActivites.SelectedItem = activite;

                Singleton.getInstance().supprimerActivite(activite);
                Frame.Navigate(typeof(PageAffichageActivite));
            }
            

        }

        private async void updateActivite_Click(object sender, RoutedEventArgs e)
        {
            // ouverture d'une boite de dialogue pour l'ajout
            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = mainScrol.XamlRoot;
            dialog.Title = "Attention";
            dialog.PrimaryButtonText = "oui";
            dialog.CloseButtonText = "non";
            dialog.DefaultButton = ContentDialogButton.Close;
            dialog.Content = "Desirez vous modifier cette activité ?";

            ContentDialogResult resultat = await dialog.ShowAsync();

            if (resultat == ContentDialogResult.Primary)
            {

                Button button = sender as Button;

                Activite activite = button.DataContext as Activite;

                lv_listeActivites.SelectedItem = activite;
                Frame.Navigate(typeof(PageModifieActivite),activite);
                
            }
        }

        private async void ajoutActivite_Click(object sender, RoutedEventArgs e)
        {
            // ouverture d'une boite de dialogue pour l'ajout
            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = mainScrol.XamlRoot;
            dialog.Title = "Attention";
            dialog.PrimaryButtonText = "oui";
            dialog.CloseButtonText = "non";
            dialog.DefaultButton = ContentDialogButton.Close;
            dialog.Content = "Desirez vous ajouter une activité ?";

            ContentDialogResult resultat = await dialog.ShowAsync();

            if(resultat == ContentDialogResult.Primary)
            {
                Frame.Navigate(typeof(pageAjoutActivite));
            }


           
        }
    }
}
