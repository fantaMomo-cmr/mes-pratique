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

        private void btn_modifier_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ModifierAdherent));
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
    }
}
