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
    public sealed partial class PageModifier : Page
    {
        Article article;
        public PageModifier()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter != null)
            {
                article = (Article)e.Parameter;
                tbx_modifNom.Text = article.Nom;
                tbx_modifPrix.Text = Convert.ToString(article.Prix);
                modifEtat.SelectedItem = article.Etat;
                modCategorie.SelectedItem = article.Categorie;
                tbx_modifUrl.Text = article.Image;
            }
        }

        private async void valider_Click(object sender, RoutedEventArgs e)
        {
            // ouverture une boite de dialogue pour la suppression

            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = valider.XamlRoot;
            dialog.Title = "Attention";
            dialog.PrimaryButtonText = "oui";
            dialog.CloseButtonText = "non";
            dialog.DefaultButton = ContentDialogButton.Close;
            dialog.Content = "Voulez appliquer les modifications ?";

            ContentDialogResult resultat = await dialog.ShowAsync();

            if (resultat == ContentDialogResult.Primary)
            {



                bool valide = true;
                tbl_erMofNom.Text = "";
                tbl_erMofPrix.Text = "";
                tbl_erMofEtat.Text = "";
                tbl_erMofCategorie.Text = "";
                tbl_erMofUrl.Text = "";
                double prixModifie = 0;

                if (tbx_modifNom.Text.Trim() != "")
                {
                    tbl_erMofNom.Text = "";
                }
                else
                {
                    tbl_erMofNom.Text = "le champs ne peut pas etre vide";
                    valide = false;
                }

                if (tbx_modifPrix.Text.Trim() != "")
                {
                    tbl_erMofPrix.Text = "";
                }
                else
                {
                    tbl_erMofPrix.Text = "le champs ne peut etre vide";
                    valide = false;
                }
                if (modifEtat.SelectedIndex.ToString() != null)
                {
                    tbl_erMofEtat.Text = "";
                }
                else
                {
                    tbl_erMofEtat.Text = "vous devez choisir un etat";
                    valide = false;
                }

                if (modCategorie.SelectedIndex.ToString() != null)
                {
                    tbl_erMofCategorie.Text = "";
                }
                else
                {
                    tbl_erMofCategorie.Text = "vous devez choisir une categarie";
                    valide = false;
                }

                if (Uri.IsWellFormedUriString(tbx_modifUrl.Text.Trim(), UriKind.Absolute) == false)
                {
                    tbl_erMofUrl.Text = "le champs ne peut pas etre vide";
                    valide = false;
                }

                try
                {
                    prixModifie = Convert.ToDouble(tbx_modifPrix.Text);
                }
                catch (FormatException)
                {
                    tbl_erMofPrix.Text = "vous ne pouvez entrer que des nombre";
                    valide = false;
                }

                if (prixModifie >= 10 && prixModifie <= 500)
                {
                    tbl_erMofPrix.Text = "";
                }
                else
                {
                    tbl_erMofPrix.Text = "le prix de votre article doit etre entre 10 et 500$";
                    valide = false;
                }

                //---------------------------------
                if (valide == true)
                {
                    article.Nom = tbx_modifNom.Text;
                    article.Prix = prixModifie;
                    article.Etat = modifEtat.SelectedItem.ToString();
                    article.Categorie = modCategorie.SelectedItem.ToString();
                    article.Image = tbx_modifUrl.Text;

                    Frame.Navigate(typeof(PageAffichage));
                }
            }
        }
    }
}
