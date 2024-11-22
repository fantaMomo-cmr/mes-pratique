using ABI.Windows.UI;
using Microsoft.UI;
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
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace validationDeDonnees
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            // ma propre boite
            MonDialogue dialog = new MonDialogue();
            dialog.XamlRoot = myButton.XamlRoot;
            dialog.Title = "Mon titre";
           // dialog.Content = "Contenu de la boite de dialogue";
            dialog.CloseButtonText = "Annuler";
            dialog.PrimaryButtonText = "Se connecter";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync(); 

            /*
            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = myButton.XamlRoot;
            dialog.Title = "Mon titre";
            dialog.Content = "Contenu de la boite de dialogue";
            dialog.CloseButtonText = "Annuler";
            dialog.PrimaryButtonText = "Oui";
            dialog.SecondaryButtonText = "Non";
            dialog.DefaultButton = ContentDialogButton.Close;


            //var resultat  = await dialog.ShowAsync();

            // pour savoir sur quoi on a clique on utilise le ' ContentDialogResult' a la place du 'var

            ContentDialogResult resultat = await dialog.ShowAsync();*/

            //if (resultat == ContentDialogResult.Primary)
            //    Debug.WriteLine("bouton primaire sélectionné");
            //else if (resultat == ContentDialogResult.Secondary)
            //    Debug.WriteLine("bouton secondaire sélectionné");
            //else
            //    Debug.WriteLine("bouton par défaut sélectionné");

            /*
             * utilisation des regex
             */
            //string expression = "^[a-zA-Z0-9]+$";
            //if (Regex.IsMatch(tbx_texte.Text, expression) == false)
            //{
            //    tbl_erreur.Text = "entrer non valide";
            //    tbl_erreur.Foreground = new SolidColorBrush(Colors.Red);
            //}
            //else
            //{
            //    tbl_erreur.Text = "valeur valide";
            //    tbl_erreur.Foreground = new SolidColorBrush(Colors.Green);
            //}

            //----------------------------------------------------------------------

            // pour convertir mes text block en nombre
            //double nombre;
            //if (Double.TryParse(tbx_texte.Text, out nombre) == false)
            //{ 
            //    tbl_erreur.Text = "entrer une valeur";
            //    tbl_erreur.Foreground = new SolidColorBrush(Colors.Red);
            //}
            //else
            //{
            //    tbl_erreur.Text = "texte valide";
            //    tbl_erreur.Foreground = new SolidColorBrush(Colors.Green);
            //}


            /*
          --------------------------------------------------------------------------------------------------------
            if (string.IsNullOrWhiteSpace(tbx_texte.Text))
            {
                
                // * Debug.WriteLine("Exécution du code");
              //   * quand on veut utiliser le debogeur
                 
                tbl_erreur.Text = "entrer une valeur";
                tbl_erreur.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                tbl_erreur.Text = "texte valide";
                tbl_erreur.Foreground = new SolidColorBrush(Colors.Green);
            }
            */

        }
    }
}
