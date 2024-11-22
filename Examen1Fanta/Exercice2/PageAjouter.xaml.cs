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

namespace Exercice2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAjouter : Page
    {
        public PageAjouter()
        {
            this.InitializeComponent();
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            tbl_erreurNom.Text = "";
            tbl_erreurPhoto.Text = "";

            if (tbx_nomCegep.Text.Trim() == "")
            {
                tbl_erreurNom.Text = "Vous devez entrer le nom du cegep";
                valide = false;
            }
            if (Uri.IsWellFormedUriString(tbx_photo.Text.Trim(), UriKind.Absolute) == false)
            {
                tbl_erreurPhoto.Text = "vous devez entrer l'URL du cegep";
                valide = false;
            }

            if (valide == true)
            {
                string nom = tbx_nomCegep.Text;
                string photo = tbx_photo.Text;

                SingletonCegep.getInstance().ajouter(new Cegep(nom, photo));
                Frame.Navigate(typeof(PageAffichage));
            }
        }
    }
}
