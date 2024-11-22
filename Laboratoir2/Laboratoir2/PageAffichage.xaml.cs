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

namespace Laboratoir2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAffichage : Page
    {
        public PageAffichage()
        {
            this.InitializeComponent();
            lv_listeProduits.ItemsSource = Singleton.getInstance().Listeproduits;
        }

        private void lv_listeProduits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void deleteProduit_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            //DataContext représente l'élément parent
            Produit produit = button.DataContext as Produit;

            //permet de s'assurer que nous avons un élément sélectionné
            lv_listeProduits.SelectedItem = produit;


            Singleton.getInstance().supprimer(produit);
        }

        private async void chargerCSV_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.FileTypeFilter.Add(".csv");

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(ClasseService.mainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            //sélectionne le fichier à lire
            Windows.Storage.StorageFile monFichier = await picker.PickSingleFileAsync();


            //ouvre le fichier et lit le contenu
            if (monFichier != null)
            {
                var lignes = await Windows.Storage.FileIO.ReadLinesAsync(monFichier);


                foreach (var ligne in lignes)
                {
                    var v = ligne.Split(";");
                    Singleton.getInstance().ajouterProduit(new Produit { Nom = v[0], Prix = Convert.ToDouble(v[1]), Categorie = v[2]});
                }
                Singleton.getInstance().chargerDonneesProduits();
            }

        }
    }
}
