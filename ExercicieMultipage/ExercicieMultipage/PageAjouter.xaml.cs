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

namespace ExercicieMultipage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAjouter : Page
    {
        //double prix=0;
        public PageAjouter()
        {
            this.InitializeComponent();

        }

        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            tbl_erreuNom.Text = "";
            tbl_erreurPrix.Text = "";
            tbl_erreurEtat.Text = "";
            tbl_erreurCategorie.Text = "";
            double prix = 0;

            //---------------------------------------
            if (tbx_nom.Text.Trim() != "")
            {
                tbl_erreuNom.Text = "";
            }
            else
            {
                tbl_erreuNom.Text = "entrez le nom de votre article";
                valide = false;
            }
            //-------------------------------------------
            if (tbx_prix.Text.Trim() != "")
            {
                tbl_erreurPrix.Text = "";
            }
            else
            {
                tbl_erreurPrix.Text = "entrez le prix de l'article";
                valide = false;
            }

            //----------------------------------------
            if (listeEtat.SelectedItem != null)
            {
                tbl_erreurEtat.Text = "";
            }
            else
            {
                tbl_erreurEtat.Text = "vous devez selectionner l'etat de votre article";
                valide = false;
            }
            //---------------------------------------
            if (listeCategorie.SelectedItem != null)
            {
                tbl_erreurCategorie.Text = "";
            }
            else
            {
                tbl_erreurCategorie.Text = "vous devez selectionner une categorie";
                valide = false;
            }
            //---------------------------------------
            /*if(tbx_image.Text.Trim() != "")
            {
                tbl_erreurURL.Text = "";
            }*/
            // fait toutes les validation au niveau de l'image : lien, vide, espace
            if (Uri.IsWellFormedUriString(tbx_image.Text.Trim(), UriKind.Absolute) == false)
            {
                tbl_erreurURL.Text = "vous devez entrer l'URL d'un article";
                valide = false;
            }

            //---------------------------------------
            try
            {
                prix = Convert.ToDouble(tbx_prix.Text);
            }
            catch (FormatException)
            {
                tbl_erreurPrix.Text = "vous ne pouvez entrer que des nombres";
                valide = false;
            }
            if (prix >= 10 && prix <= 500)
            {
                tbl_erreurPrix.Text = "";
            }
            else
            {
                tbl_erreurPrix.Text = "le prix de votre article doit etre entre 10 et 500$";
                valide = false;
            }
            // ---------------------------------

            if (valide == true)
            {

                string nom = tbx_nom.Text;
                string etat = listeEtat.SelectedItem.ToString();
                string categorie = listeCategorie.SelectedItem.ToString();
                string image = tbx_image.Text;

                SingletonArticle.getInstance().ajouter(new Articles(nom, prix, etat, categorie, image));
                Frame.Navigate(typeof(PageAffichage));
            }
        }

  
    }
}
