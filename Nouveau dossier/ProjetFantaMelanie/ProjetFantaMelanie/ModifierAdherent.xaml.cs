using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Media.Imaging;
using System.Reflection;
using Google.Protobuf.WellKnownTypes;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFantaMelanie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ModifierAdherent : Page
    {
        
        Adherent unAdherent;
        public ModifierAdherent()
        {
            this.InitializeComponent();


        
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is not null)
            {
                base.OnNavigatedTo(e);
                //ServiceNavigation.getInstance().NavigationView.SelectedItem = null;
                unAdherent = (Adherent)e.Parameter;
                if (DateTime.TryParse(unAdherent.DateNaissance, out DateTime dateNaissance))
                {
                    tbxDateNaisDetail.Text = dateNaissance.ToString("yyyy-MM-dd");
                    tbxDateNaisDetail.IsEnabled = false;
                }
                tbxNomDetail.Text = unAdherent.Nom;
                tbxPrenomDetail.Text = unAdherent.Prenom;
                tbxAdresseDetail.Text = unAdherent.Adresse;

            }
        }

        private void resetErreurs()
        {
            tblErreurNom.Text = string.Empty;
            tblErreurPrenom.Text = string.Empty;
            tblErreurdateNais.Text = string.Empty;
            tblErreurAdresse.Text = string.Empty;
        }





        private async void btnModifier_Click(object sender, RoutedEventArgs e)
        {

            resetErreurs();
            bool valide = true; //on le met à vrai pour avant de commencer la validation

            if (Validations.isNomValide(tbxNomDetail.Text) == false)
            {
                tblErreurNom.Text = "Veuillez entrer le nom de l'adhérent";
                valide = false;
            }

            if (Validations.isPrenomValide(tbxPrenomDetail.Text) == false)
            {
                tblErreurPrenom.Text = "Veuillez entrer le prenom de l'adhérent";
                valide = false;
            }

            if (Validations.isDateNaisValide(tbxDateNaisDetail.Text) == false)
            {
                tblErreurdateNais.Text = "Entrer une date de naissance valide";
                valide = false;
            }

            if (Validations.isPrenomValide(tbxAdresseDetail.Text) == false)
            {
                tblErreurAdresse.Text = "Entrer une adresse valide";
                valide = false;
            }


            if (valide == true)
            {
                //Adherent unAdherent = new Adherent()
                //{
                unAdherent.Nom = tbxNomDetail.Text;
                unAdherent.Prenom = tbxPrenomDetail.Text;
                unAdherent.DateNaissance = tbxDateNaisDetail.Text;
                unAdherent.Adresse = tbxAdresseDetail.Text;
                //};

                SingletonListe2.getInstance().modifierAdherent(unAdherent);

                ContentDialog dialog = new ContentDialog();
                dialog.XamlRoot = mainGrid.XamlRoot;
                dialog.Title = "Modification d'un adhérent";
                dialog.PrimaryButtonText = "OK";
                dialog.DefaultButton = ContentDialogButton.Primary;
                dialog.Content = "L'adhérent a été modifié avec succès";

                ContentDialogResult resultat = await dialog.ShowAsync();

                this.Frame.Navigate(typeof(AfficherAdherent));
            }



        }
    }
}
