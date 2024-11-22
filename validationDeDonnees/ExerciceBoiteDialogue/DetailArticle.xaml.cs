using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
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
    public sealed partial class DetailArticle : Page
    {
        Article article;
        public DetailArticle()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            article = (Article)e.Parameter;
            tbl_detailNom.Text = article.Nom;
            tbl_detailPrix.Text = Convert.ToString(article.Prix);
            tbl_detailEtat.Text =article.Etat;
            tbl_detailCategorie.Text = article.Categorie;
            Uri uri = new Uri(article.Image);
            img.Source = new BitmapImage(uri);

        }

        private async void supprimer_Click(object sender, RoutedEventArgs e)
        {
            // ouverture une boite de dialogue pour la suppression

            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = mainGrid.XamlRoot;
            dialog.Title = "Attention";
            dialog.PrimaryButtonText = "oui";
            dialog.CloseButtonText = "non";
            dialog.DefaultButton = ContentDialogButton.Close;
            dialog.Content = "Voulez vous supprimer cet articles ?";

            ContentDialogResult resultat = await dialog.ShowAsync();

            if(resultat == ContentDialogResult.Primary)
            {
                SingletonArticle.getInstance().supprimer(article);
                Frame.Navigate(typeof(PageAffichage));
            }
        }
        private void modifier_Click(object sender, RoutedEventArgs e)
        {
            if(article != null)
            {
                Frame.Navigate(typeof(PageModifier), article);
            }
        }
    }
}
