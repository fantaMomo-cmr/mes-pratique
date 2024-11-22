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

namespace Partie1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pageAjouter : Page
    {
        Equipe equipe;
        public pageAjouter()
        {
            this.InitializeComponent();
            equipe = new Equipe();

        }

        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            tbl_erreurNom.Text = "";
            tbl_erreurVille.Text = "";
            tbl_erreurUrl.Text = "";

            if (tbx_nom.Text.Trim() != "")
            {
                tbl_erreurNom.Text = "";
            }
            else
            {
                tbl_erreurNom.Text = "entrez le nom de l'equipe";
                valide = false;
            }
            //-------------------------------------------
            if (tbx_ville.Text.Trim() != "")
            {
                tbl_erreurVille.Text = "";
            }
            else
            {
                tbl_erreurVille.Text = "entrez la ville de l'equipe";
                valide = false;
            }
            if (Uri.IsWellFormedUriString(tbx_logo.Text.Trim(), UriKind.Absolute) == false)
            {
                tbl_erreurUrl.Text = "vous devez entrer l'URL du logo de l'equipe";
                valide = false;
            }
            if(valide == true)
            {
                equipe.Nom = tbx_nom.Text;
                equipe.Ville = tbx_ville.Text;
                equipe.Logo = tbx_logo.Text;

                
                SingletonEquipeetJoueur.getInstance().ajouter(equipe);
                Frame.Navigate(typeof(pageAffichage));
            }

        }
    }
}
