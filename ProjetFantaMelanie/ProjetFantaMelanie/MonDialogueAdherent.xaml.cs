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
using Google.Protobuf.WellKnownTypes;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFantaMelanie
{
    public sealed partial class MonDialogueAdherent : ContentDialog
    {
        bool valide; // permet de savoir si le formulaire est valide
        public MonDialogueAdherent()
        {
            this.InitializeComponent();
        }

        private void resetErreurs()
        {
            tblErreurNom.Text = string.Empty;
            tblErreurPrenom.Text = string.Empty;
            tblErreurdateNais.Text = string.Empty;
            tblErreurAdresse.Text = string.Empty;

        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            resetErreurs();
            valide = true; //on le met à vrai pour avant de commencer la validation

            if (Validations.isNomValide(tbxNomAjout.Text) == false)
            {
                tblErreurNom.Text = "Veuillez entrer le nom de l'adhérent";
                valide = false;
            }

            if (Validations.isPrenomValide(tbxPrenomAjout.Text) == false)
            {
                tblErreurPrenom.Text = "Veuillez entrer le prenom de l'adhérent";
                valide = false;
            }

            if (Validations.isDateNaisValide(tbxDateNaisAjout.Text) == false)
            {
                tblErreurdateNais.Text = "Entrer une date de naissance valide";
                valide = false;
            }

            if (Validations.isPrenomValide(tbxAdresseAjout.Text) == false)
            {
                tblErreurAdresse.Text = "Entrer une adresse valide";
                valide = false;
            }


            if (valide == true)
            {
                Adherent unAdherent = new Adherent()
                {
                    Nom = tbxNomAjout.Text,
                    Prenom = tbxPrenomAjout.Text,
                    DateNaissance = tbxDateNaisAjout.Text,
                    Adresse = tbxAdresseAjout.Text
                };

                SingletonListe2.getInstance().ajouterAdherent(unAdherent);


            }

        }

        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            //si on a cliquer sur le bouton primaire, on vérifie si la validation est OK
            //si ce n'est pas le cas, on ne ferme pas la boite de dialogue
            if (args.Result == ContentDialogResult.Primary)
            {
                if (valide == false)
                    args.Cancel = true;
            }
        }
    }
}
