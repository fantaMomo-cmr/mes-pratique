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
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFantaMelanie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageModifieActivite : Page
    {
        Activite activite;
        public PageModifieActivite()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is not null)
            {
                activite = (Activite)e.Parameter;
                Uri uri = new Uri(activite.Logo);
                imgActiviteMo.Source = new BitmapImage(uri);
                tbx_nomMo.Text = activite.Nom;
                tbx_typeMo.Text = activite.Type;
                tbx_coutOrganisationMo.Text = Convert.ToString(activite.CoutOrganisation);
                tbx_prixventeMo.Text = Convert.ToString(activite.PrixVente);
                tbx_logoMo.Text = activite.Logo;
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            tblErreurNomMo.Text = "";
            tblErreurTypeMo.Text = "";
            tblErreurcoutMo.Text = "";
            tblErreurPrixMo.Text = "";
            tblErreurlogoMo.Text = "";
            double coutOrganisaationMo = 0;
            double prixVenteMo = 0;

            if (tbx_nomMo.Text.Trim() == "")
            {
                tblErreurNomMo.Text = "Vous devez entrer le nom de l'activité";
                valide = false;
            }
            if (tbx_typeMo.Text.Trim() == "")
            {
                tblErreurTypeMo.Text = "Vous devez entrer la type de l'activité";
                valide = false;
            }
            if (double.TryParse(tbx_coutOrganisationMo.Text, out coutOrganisaationMo) == false)
            {
                tblErreurcoutMo.Text = "Entrez le montant d'organisation en chiffre";
                valide = false;
            }
            if (double.TryParse(tbx_prixventeMo.Text, out prixVenteMo) == false)
            {
                tblErreurPrixMo.Text = " Enterz le prix de vente de l'activité en chiffre";
                valide = false;
            }
            if (Uri.IsWellFormedUriString(tbx_logoMo.Text.Trim(), UriKind.Absolute) == false)
            {
                tblErreurlogoMo.Text = "Entrez l'url de l'image de l'activé";
                valide = false;
            }
            if (valide == true)
            {
                //   Activite activite = new Activite()
                //  {

                activite.Nom = tbx_nomMo.Text;
                activite.Type = tbx_typeMo.Text;
                activite.CoutOrganisation = coutOrganisaationMo;
                activite.PrixVente = prixVenteMo;
                activite.Logo = tbx_logoMo.Text;
             //   };
                Singleton.getInstance().updateActivite(activite);
                Frame.Navigate(typeof(PageAffichageActivite));

            }

        }
    }
}
