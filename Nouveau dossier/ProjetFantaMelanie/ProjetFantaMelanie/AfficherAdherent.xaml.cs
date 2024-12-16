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
    public sealed partial class AfficherAdherent : Page
    {
       
        public AfficherAdherent()
        {
            this.InitializeComponent();
            lv_listeAdherents.ItemsSource = SingletonListe2.getInstance().GetListeAdherents();
        }

        private void btn_supprimer_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            // c'est l'elément parent
            Adherent unAdherent = button.DataContext as Adherent;

            // se rassurer qu'un element est selectionné
            lv_listeAdherents.SelectedItem = unAdherent;
            SingletonListe2.getInstance().supprimer(unAdherent);
        }

        private async void btn_modifier_Click(object sender, RoutedEventArgs e)
        {
            // ouverture d'une boite de dialogue pour l'ajout
            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Attention";
            dialog.PrimaryButtonText = "oui";
            dialog.CloseButtonText = "non";
            dialog.DefaultButton = ContentDialogButton.Close;
            dialog.Content = "Desirez vous modifier cet adhérent ?";

            ContentDialogResult resultat = await dialog.ShowAsync();

            if (resultat == ContentDialogResult.Primary)
            {

                Button button = sender as Button;

                Adherent unAdherent = button.DataContext as Adherent;

                lv_listeAdherents.SelectedItem = unAdherent;
                Frame.Navigate(typeof(ModifierAdherent), unAdherent);

            }
           
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            MonDialogueAdherent dialogue = new MonDialogueAdherent();
            dialogue.XamlRoot = this.XamlRoot;
            dialogue.Title = "Nouveau adhérent";
            dialogue.PrimaryButtonText = "Ajouter";
            dialogue.CloseButtonText = "Annuler";
            dialogue.DefaultButton = ContentDialogButton.Close;

            var resultat = await dialogue.ShowAsync();
        }

     
        // Ecrire dans un fichier CSV
        private async void btn_adherent_Click(object sender, RoutedEventArgs e)
        {
            // Sélectionner où enregistrer le fichier
            var picker = new Windows.Storage.Pickers.FileSavePicker();
            picker.SuggestedFileName = "Liste des adhérents";
            picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });

            // Initialisation de la fenêtre
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(ClasseServices.mainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

            // Ouvrir la fenêtre de sélection du fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

            if (monFichier != null && lv_listeAdherents.ItemsSource != null)
            {
                // Créer une liste pour stocker les lignes CSV
                List<string> lignes = new List<string>();

                // Ajouter l'en-tête du fichier CSV
                lignes.Add("IdAdherent;Prenom;Nom;Adresse;DateNaissance;Age");

                if (lv_listeAdherents.ItemsSource is ObservableCollection<Adherent> adherents)
                {
                    // Parcourir chaque adhérent et créer une ligne CSV
                    foreach (var adherent in adherents)
                    {
                        // Construire la ligne CSV pour chaque adhérent
                        string ligne = $"{adherent.IdAdherent};{adherent.Prenom};{adherent.Nom};{adherent.Adresse};{adherent.DateNaissance};{adherent.Age}";
                        lignes.Add(ligne);
                    }

                    // Écrire les lignes dans le fichier CSV
                    await Windows.Storage.FileIO.WriteLinesAsync(monFichier, lignes);
                }
            }




        }
    }
}
