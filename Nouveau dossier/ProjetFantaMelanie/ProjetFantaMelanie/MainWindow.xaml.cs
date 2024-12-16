using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFantaMelanie
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        Adherent adhrentConnecter = new Adherent();
        public MainWindow()
        {
            this.InitializeComponent();
            ServiceNavigation.getInstance().NavigationView = navView;
            ClasseServices.mainWindow = this;
            Singleton.getInstance().Frame = mainFrame;
            //adhrentConnecter = Singleton.adherentConnecter;
            mainFrame.Navigate(typeof(PageAffichageActivite));
            ServiceNavigation.getInstance().affichageVisiteur();
        }

        private async void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "ilisteActivite":
                    mainFrame.Navigate(typeof(PageAffichageActivite));
                    break;

                case "iListeAdherent":
                    mainFrame.Navigate(typeof(AfficherAdherent));
                    break;
                case "iListeSeance":
                    mainFrame.Navigate(typeof(PageSeance));
                    break;
                case "iStatistique":
                    mainFrame.Navigate(typeof(AfficherStatistiques));
                    break;

                case "iconnexion":
                    MonDialogueConnexion dialogue = new MonDialogueConnexion();
                    dialogue.XamlRoot = mainFrame.XamlRoot;
                    dialogue.Title = "Se connecter";
                    dialogue.PrimaryButtonText = "Connexion";
                    dialogue.CloseButtonText = "Annuler";
                    dialogue.DefaultButton = ContentDialogButton.Close;

                    var resultat = await dialogue.ShowAsync();
                 
                    break;
                case "iDeconnexion":
                    ServiceNavigation.getInstance().affichageVisiteur();
                    Singleton.getInstance().SetUserConnecte(false);
                    ServiceNavigation.getInstance().cleanUserOnLogout();
                    mainFrame.Navigate(typeof(PageAffichageActivite));
                    break;
            }
        }

        private async void navView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            //var item = (NavigationViewItem);
            switch (args.InvokedItem)
            {
                //case "iconnexion":
                //    MonDialogueConnexion dialogue = new MonDialogueConnexion();
                //    dialogue.XamlRoot = mainFrame.XamlRoot;
                //    dialogue.Title = "Se connecter";
                //    dialogue.PrimaryButtonText = "Connexion";
                //    dialogue.CloseButtonText = "Annuler";
                //    dialogue.DefaultButton = ContentDialogButton.Close;

                //    var resultat = await dialogue.ShowAsync();
                //    //tbl_adherent.Text = Singleton.getInstance().AdherentConnecte.Prenom + " " + Singleton.getInstance().AdherentConnecte.Nom;
                //    break;

                case "ilisteActivite":
                    mainFrame.Navigate(typeof(PageAffichageActivite));
                    break;

                case "iListeAdherent":
                    mainFrame.Navigate(typeof(AfficherAdherent));
                    break;
                case "iListeSeance":
                    mainFrame.Navigate(typeof(PageSeance));
                    break;
                case "iStatistique":
                    mainFrame.Navigate(typeof(AfficherStatistiques));
                    break;

                case "iconnexion":
                    MonDialogueConnexion dialogue = new MonDialogueConnexion();
                    dialogue.XamlRoot = mainFrame.XamlRoot;
                    dialogue.Title = "Se connecter";
                    dialogue.PrimaryButtonText = "Connexion";
                    dialogue.CloseButtonText = "Annuler";
                    dialogue.DefaultButton = ContentDialogButton.Close;

                    var resultat = await dialogue.ShowAsync();

                    break;
                case "iDeconnexion":
                    ServiceNavigation.getInstance().affichageVisiteur();
                    Singleton.getInstance().SetUserConnecte(false);
                    mainFrame.Navigate(typeof(PageAffichageActivite));
                    break;
            }
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(PageParticipant));
        }
    }
}
