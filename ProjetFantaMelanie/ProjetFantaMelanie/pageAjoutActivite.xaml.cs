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
    public sealed partial class pageAjoutActivite : Page
    {
        Activite activite;
        public pageAjoutActivite()
        {
            this.InitializeComponent();
        }

        private void btn_ajoutActivite_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            tblErreurNom.Text = "";
            tblErreurType.Text = "";
            tblErreurcout.Text = "";
            tblErreurPrix.Text = "";
            tblErreurlogo.Text = "";
            double coutOrganisaation = 0;
            double prixVente = 0;

            if (tbx_nom.Text.Trim() == "")
            {
                tblErreurNom.Text = "Vous devez entrer le nom de l'activité"; 
                valide = false;
            }
            if (tbx_type.Text.Trim()== "")
            {
                tblErreurType.Text = "Vous devez entrer la type de l'activité";
                valide = false;
            }
            if (double.TryParse(tbx_coutOrganisation.Text, out coutOrganisaation) == false) 
            {
                tblErreurcout.Text = "Entrez le montant d'organisation en chiffre";
                valide = false;
            }
            if( double.TryParse(tbx_prixvente.Text, out prixVente) == false)
            {
                tblErreurPrix.Text = " Enterz le prix de vente de l'activité en chiffre";
                valide = false;
            }
            if(Uri.IsWellFormedUriString(tbx_logo.Text.Trim(),UriKind.Absolute) == false)
            {
                tblErreurlogo.Text = "Entrez l'url de l'image de l'activé";
                valide = false;
            }
            if (valide == true)
            {
                Activite activite = new Activite()
                {
                    Nom = tbx_nom.Text,
                    Type = tbx_type.Text,
                    CoutOrganisation = coutOrganisaation,
                    PrixVente = prixVente,
                    Logo = tbx_logo.Text

                };
                Singleton.getInstance().ajouterActivite(activite);
                Frame.Navigate(typeof(PageAffichageActivite));
                 
            }


        }
    }
}
