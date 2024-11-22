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
    public sealed partial class MonDialogueAjout : ContentDialog
    {
        public string Nom { get; set; }
        public double Prix { get; set; }
        public string Etat { get; set; }
        public string Categorie { get; set; }
        public string Url { get; set; }
        public MonDialogueAjout()
        {
            this.InitializeComponent();

        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            bool valide = true;
            tbl_erNom.Text = "";
            tbl_erPrix.Text = "";
            tbl_erEtat.Text = "";
            tbl_erCategorie.Text = "";
            tbl_erUrl.Text = "";
            double prix = 0;

            if (tbx_nom.Text.Trim() != "")
            {
                tbl_erNom.Text = "";
            }
            else
            {
                tbl_erNom.Text = "vous de devez donner un nom a votre article";
                valide = false;
            }
           
            if (tbx_prix.Text.Trim() != "")
            {
                tbl_erPrix.Text = "";
            }
            else
            {
                tbl_erPrix.Text = "votre article doit avoir un prix";
                valide = false;
            }
            if (etat.SelectedItem != null)
            {
                tbl_erEtat.Text = "";
            }
            else
            {
                tbl_erEtat.Text = "vous devez selectionner l'etat de votre article";
                valide = false;
            }
            if (categorie.SelectedItem != null)
            {
                tbl_erCategorie.Text = "";
            }
            else
            {
                tbl_erCategorie.Text = "vous devez selectionner une categorie";
                valide = false;
            }
            if (Uri.IsWellFormedUriString(tbx_url.Text.Trim(), UriKind.Absolute) == false)
            {
                tbl_erUrl.Text = "vous devez entre un URL";
                valide = false;
            }
            try
            {
                prix = Convert.ToDouble(tbx_prix.Text);
            }
            catch (FormatException)
            {
                tbl_erPrix.Text = "vous ne pouvez entrer que des nombres";
                valide = false;
            }
            if(prix >= 10 && prix <= 500)
            {
                tbl_erPrix.Text = "";
            }
            else
            {
                tbl_erPrix.Text = "le prix doit etre entre 10 et 500 $";
                valide=false;
            }
            // -------------------------------------------
            if(valide == true)
            {
                Nom = tbx_nom.Text;
                Prix = prix;
                Etat = etat.SelectedItem.ToString();
                Categorie = categorie.SelectedItem.ToString();
                Url = tbx_url.Text;

                SingletonArticle.getInstance().ajouter(new Article(Nom, Prix, Etat, Categorie, Url));
            }
            
            
        }
        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            if (args.Result == ContentDialogResult.Primary)
            {
                if (string.IsNullOrWhiteSpace(Nom))
                    args.Cancel = true;
            }
            else
                args.Cancel = false;
        }


    }
}
