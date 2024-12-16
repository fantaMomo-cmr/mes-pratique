using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFantaMelanie
{
    public sealed partial class MonDialogueConnexion : ContentDialog
    {
        Adherent adherent;
        Administrateur administrateur;
        bool valide = true;
        public MonDialogueConnexion()
        {
            this.InitializeComponent();
         
        }

        private void cbxRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbl_erreurIDAdherent.Text = "";
            tbl_erreurIdAdmin.Text = "";
            tbl_erreurRole.Text = "";
            tbl_erreurMotDePasse.Text = "";

            if (cbxRole.SelectedItem is ComboBoxItem selectedItem)
            {
                string role = selectedItem.Content.ToString();

                if (role == "Administrateur")
                {
                    adminPanel.Visibility = Visibility.Visible;
                    adherentPanel.Visibility = Visibility.Collapsed;
                }
                else if (role == "Adhérent")
                {
                    adminPanel.Visibility = Visibility.Collapsed;
                    adherentPanel.Visibility = Visibility.Visible;
                }
            }

        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

            valide = true;
            tbl_erreurIDAdherent.Text = "";
            tbl_erreurIdAdmin.Text = "";
            tbl_erreurRole.Text = "";
            tbl_erreurMotDePasse.Text = "";

            if (cbxRole.SelectedItem == null)
            {
                tbl_erreurRole.Text = "Selectionner votre role";
                valide = false;
            }
            else
            {
                if(cbxRole.SelectedIndex == 0)
                {
                    if (tbx_AdminId.Text.Trim() == "")
                    {
                        tbl_erreurIdAdmin.Text = "Entrez votre identifiant";
                        valide = false;
                    }
                    if (tbx_AdminPassword.Password.Trim() == "")
                    {
                        tbl_erreurMotDePasse.Text = "entre votre de passe";
                        valide = false;
                    }
                }

                if (cbxRole.SelectedIndex == 1)
                {
                    if (tbx_AdherentNumber.Text.Trim() == "")
                    {
                        tbl_erreurIDAdherent.Text = "Entrez votre identifiant";
                        valide = false;
                    }
                }
            }

           
            

            if (valide == true)
            {
                if (cbxRole.SelectedIndex == 0)
                {
                    string idAmin = tbx_AdminId.Text;
                    string motDePasse = tbx_AdminPassword.Password;
                    bool result =  Singleton.getInstance().AuthAdmin(idAmin, motDePasse);
                    //Debug.WriteLine(result);
                    if (result == true) 
                    {
                        Singleton.getInstance().Role = "admin";
                        ServiceNavigation.getInstance().changerUser();

                        ServiceNavigation.getInstance().affichageVisiteur();
                        //Singleton.getInstance().Frame.Navigate(typeof(PageAffichageActivite));
                    }
                    else
                    {
                        tbl_erreurIdAdmin.Text = "l'identifiant ou mot de passe incorrect";
                    }
                }
                else
                {
                    string idAderent = tbx_AdherentNumber.Text;
                    Singleton.getInstance().SelectionnerUnAdherent(idAderent);
                    Singleton.getInstance().Role = "Adherent";
                    ServiceNavigation.getInstance().changerUser();
                    ServiceNavigation.getInstance().affichageVisiteur();
                    if (Singleton.getInstance().AdherentConnecte == null)
                    {
                        tbl_erreurIDAdherent.Text = "L'identifiant n'est pas valide";
                        valide = false;
                    }
                    

                }
            }
        }

          

   
        // Ferme la boite de dialogue
        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            if (args.Result == ContentDialogResult.Primary)
            {
                if (valide == false)
                    args.Cancel = true;
            }
            else
                args.Cancel = false;

        }
    }
}
