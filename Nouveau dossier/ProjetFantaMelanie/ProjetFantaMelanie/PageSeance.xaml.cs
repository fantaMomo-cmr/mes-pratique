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
    public sealed partial class PageSeance : Page
    {
        public PageSeance()
        {
            this.InitializeComponent();
            lv_listeSeance.ItemsSource = Singleton.getInstance().ListeSeances;
        }

        private void supprimer_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            Seance seance = button.DataContext as Seance;

            lv_listeSeance.SelectedItem = seance;

            Singleton.getInstance().supprimerSeance(seance);
            Frame.Navigate(typeof(PageSeance));

        }

        private async void modifier_Click(object sender, RoutedEventArgs e)
        {
            // ouverture d'une boite de dialogue pour l'ajout
            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = mainSrol.XamlRoot;
            dialog.Title = "Attention";
            dialog.PrimaryButtonText = "oui";
            dialog.CloseButtonText = "non";
            dialog.DefaultButton = ContentDialogButton.Close;
            dialog.Content = "Desirez vous modifier cette activité ?";

            ContentDialogResult resultat = await dialog.ShowAsync();

            if (resultat == ContentDialogResult.Primary)
            {

                Button button = sender as Button;

                Seance seance = button.DataContext as Seance;

                lv_listeSeance.SelectedItem = seance;
                Frame.Navigate(typeof(PageModifieSeance), seance);

            }


        }
    }
}
