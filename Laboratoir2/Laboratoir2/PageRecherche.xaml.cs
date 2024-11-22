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
    public sealed partial class PageRecherche : Page
    {
        Produit produit;
        public PageRecherche()
        {
            this.InitializeComponent();
            lv_rechercheProduits.ItemsSource = Singleton.getInstance().Listeproduits;

            // pour recuperer la liste des caategories
            List<string> categories = Singleton.getInstance().selectionnerCategorieProduit();

            cb_CategorieProduit.ItemsSource = categories;

            
        }

        private void Nomrecherche_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            tbl_erreurCategorie.Text = "";

            if (cb_CategorieProduit.SelectedItem == null)
            {
                tbl_erreurCategorie.Text = "Selectionmnez une catégorie";
                valide = false;
            }

            if (valide == true)
            Singleton.getInstance().rechercherCategorie(cb_CategorieProduit.SelectedItem.ToString());
        }

        private void prixrecherche_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            tbl_erreurPetitPrix.Text = "";
            tbl_erreurGrandPrix.Text = "";
            tbl_erreurGrand.Text = "";
            double nbrPetit = 0;
            double nbrGrand = 0;

            if(double.TryParse(tbx_Petitprix.Text, out nbrPetit) == false)
            {
                tbl_erreurPetitPrix.Text = "entrez un prix en chiffre";
                valide = false;
            }
            if (double.TryParse(tbx_Grandprix.Text, out nbrGrand) == false)
            {
                tbl_erreurGrandPrix.Text = "entez un prix en chiffre";
                valide = false;
            }
            if (nbrPetit > nbrGrand)
            {
                tbl_erreurGrand.Text = "le premier chiffre doit être < ou = au deuxieme";
                valide = false ;
            }
            if (nbrPetit<0 || nbrGrand <0)
            {
                tbl_erreurGrand.Text = "Entrez une valeur positive";
                valide = false;
            }

            if (valide == true) 
            Singleton.getInstance().recherchePrix(nbrPetit, nbrGrand);
        }
    }
}
