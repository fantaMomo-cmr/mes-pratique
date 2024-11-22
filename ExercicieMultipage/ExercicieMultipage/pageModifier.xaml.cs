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
using static System.Net.Mime.MediaTypeNames;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ExercicieMultipage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pageModifier : Page
    {
        Articles article;
        public pageModifier()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter != null)
            {
                article = (Articles)e.Parameter;
                modifieNom.Text = article.Nom;
                modifiePrix.Text = Convert.ToString(article.Prix);
                modifieEtat.SelectedItem = article.Etat;
                modifieCategorie.SelectedItem = article.Categorie;
                modifieImage.Text = article.Image;

            }

        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            tbl_erModifieNom.Text = "";
            tbl_erModifiePrix.Text = "";
            tbl_erModifieEtat.Text = "";
            tbl_erModifieCategorie.Text = "";
            tbl_erModifieURL.Text = "";
            double prixModifie = 0;

            if (modifieNom.Text.Trim() != "")
            {
                tbl_erModifieNom.Text = "";
            }
            else
            {
                tbl_erModifieNom.Text = "le champs ne peut pas etre vide";
                valide = false;
            }

            if (modifiePrix.Text.Trim() != "")
            {
                tbl_erModifiePrix.Text = "";
            }
            else
            {
                tbl_erModifiePrix.Text = "le champs ne peut etre vide";
                valide = false;
            }
            if (modifieEtat.SelectedIndex.ToString() != null)
            {
                tbl_erModifieEtat.Text = "";
            }
            else
            {
                tbl_erModifieEtat.Text = "vous devez choisir un etat";
                valide = false;
            }

            if (modifieCategorie.SelectedIndex.ToString() != null)
            {
                tbl_erModifieCategorie.Text = "";
            }
            else
            {
                tbl_erModifieCategorie.Text = "vous devez choisir une categarie";
                valide = false;
            }

            if (Uri.IsWellFormedUriString(modifieImage.Text.Trim(), UriKind.Absolute) == false)
            {
                tbl_erModifieURL.Text = "le champs ne peut pas etre vide";
                valide = false;
            }

            try
            {
                prixModifie = Convert.ToDouble(modifiePrix.Text);
            }
            catch (FormatException)
            {
                tbl_erModifiePrix.Text = "vous ne pouvez entrer que des nombre";
                valide = false;
            }

            if (prixModifie >= 10 && prixModifie <= 500)
            {
                tbl_erModifiePrix.Text = "";
            }
            else
            {
                tbl_erModifiePrix.Text = "le prix de votre article doit etre entre 10 et 500$";
                valide = false;
            }

            //---------------------------------
            if (valide == true)
            {
                article.Nom = modifieNom.Text;
                article.Prix = prixModifie;
                article.Etat = modifieEtat.SelectedItem.ToString();
                article.Categorie = modifieCategorie.SelectedItem.ToString();
                article.Image = modifieImage.Text;

                Frame.Navigate(typeof(PageAffichage));
            }

        }
    }
}
