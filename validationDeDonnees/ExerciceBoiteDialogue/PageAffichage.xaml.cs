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

namespace ExerciceBoiteDialogue
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAffichage : Page
    {
        public PageAffichage()
        {
            this.InitializeComponent();
            lv_listeArticles.ItemsSource = SingletonArticle.getInstance().ListeArticles;
        }

        private void lv_listeArticles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Article article = (Article)lv_listeArticles.SelectedItem;
            if(article != null)
            {
                Frame.Navigate(typeof(DetailArticle), article);
            }
        }

        private async void ajouter_Click(object sender, RoutedEventArgs e)
        {
            // ma propre boite
            MonDialogueAjout dialog = new MonDialogueAjout();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Ajout d'article";
            dialog.CloseButtonText = "Annuler";
            dialog.PrimaryButtonText = "ajouter";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();

        }
    }
}
