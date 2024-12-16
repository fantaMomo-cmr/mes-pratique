using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            if(Singleton.getInstance().GetUserConnecte() && Singleton.getInstance().Role == "admin")
            {
                ajoutActivite.Visibility = Visibility.Visible;
                btn_activite.Visibility = Visibility.Visible;
               //updateActivite.Visibility = Visibility.Visible;
            }
            else
            {
                ajoutActivite.Visibility = Visibility.Collapsed;
                btn_activite.Visibility = Visibility.Collapsed;
            }
        }

        private void lv_listeActivites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Singleton.getInstance().GetUserConnecte())
            {
                Activite activite = lv_listeActivites.SelectedItem as Activite;
                if (activite != null)
                {
                    Frame.Navigate(typeof(PageDetailActivite), activite);
                }
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NavigationViewItem navItem;

            foreach (var item in ServiceNavigation.getInstance().NavigationView.MenuItems)
            {
                if(item is NavigationViewItem) 
                {
                    navItem = item as NavigationViewItem;
                    if (navItem.Name == "ilisteActivite")
                    {
                        ServiceNavigation.getInstance().NavigationView.SelectedItem = navItem;
                        break;
                    }
                }
                
            }
            //if(Singleton.getInstance().AdherentConnecte != null)
                //ServiceNavigation.getInstance().NavigationView.Header = "BONJOUR " + Singleton.getInstance().GetUtilisateurConnecte;
          //  ServiceNavigation.getInstance().NavigationView.Header = "BONJOUR "+Singleton.getInstance().AdherentConnecte.Prenom + " "+Singleton.getInstance().AdherentConnecte.Nom;
        }


        // Ecrire dans un fichier CSV
        private async void btn_activite_Click(object sender, RoutedEventArgs e)
        {

            // Sélectionner où enregistrer le fichier
            var picker = new Windows.Storage.Pickers.FileSavePicker();
            picker.SuggestedFileName = "Liste des activités";
            picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });

            // Initialisation de la fenêtre
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(ClasseServices.mainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

            // Ouvrir la fenêtre de sélection du fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

            if (monFichier != null && lv_listeActivites.ItemsSource != null)
            {
                // Créer une liste pour stocker les lignes CSV
                List<string> lignes = new List<string>();
                lignes.Add("IdCtivite;Nom;Type;CoutOrganisation;PrixVente;Logo");

                if (lv_listeActivites.ItemsSource is ObservableCollection<Activite> activites)
                {
                    foreach (var activite in activites)
                    {
                        // Construire la ligne CSV pour chaque adhérent
                        string ligne = $"{activite.IdActivite};{activite.Nom};{activite.Type};{activite.CoutOrganisation};{activite.PrixVente};{activite.Logo}";
                        lignes.Add(ligne);
                    }
                    // Écrire les lignes dans le fichier CSV
                    await Windows.Storage.FileIO.WriteLinesAsync(monFichier, lignes);
                }
            }


        }
    }
}
