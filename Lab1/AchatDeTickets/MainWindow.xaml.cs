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

namespace AchatDeTickets
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

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            // declaration des variables
            int nbrTicket = Convert.ToInt32(tbx_nbrTickets.Text);

            double PrixDonQuichotte = 75;
            double PrixBossuNotreDame = 60;
            double PrixFantomeOpera = 50;
            double rabaisPersonneAge = 0.1;
            double rabaisEnfant = 0.5;

            double prixAdulte = 0;
            double prixAge = 0;
            double prixEnfant = 0;

            
                // pour le filme donQuichotte
                if (listeSpectacles.SelectedIndex == 0)
                {
                    if (listeCategorie.SelectedIndex == 0)
                    {
                        prixAdulte = PrixDonQuichotte * nbrTicket;
                        lv_choix.Items.Add(prixAdulte);

                    }
                    if (listeCategorie.SelectedIndex == 1)
                    {
                        prixAge = PrixDonQuichotte * rabaisPersonneAge * nbrTicket;
                        lv_choix.Items.Add(prixAge);
                    }
                    if (listeCategorie.SelectedIndex == 2)
                    {
                        prixEnfant = PrixDonQuichotte * rabaisEnfant * nbrTicket;
                        lv_choix.Items.Add(prixEnfant);
                    }
                }

                // •	Le bossu de Notre-Dame 
                if (listeSpectacles.SelectedIndex == 1)
                {
                    if (listeCategorie.SelectedIndex == 0)
                    {
                        prixAdulte = PrixBossuNotreDame * nbrTicket;
                        lv_choix.Items.Add(prixAdulte);

                    }
                    if (listeCategorie.SelectedIndex == 1)
                    {
                        prixAge = PrixBossuNotreDame * rabaisPersonneAge * nbrTicket;
                        lv_choix.Items.Add(prixAge);
                    }
                    if (listeCategorie.SelectedIndex == 2)
                    {
                        prixEnfant = PrixBossuNotreDame * rabaisEnfant * nbrTicket;
                        lv_choix.Items.Add(prixEnfant);
                    }
                }

                // •	Le fantôme de l’opéra
                if (listeSpectacles.SelectedIndex == 2)
                {
                    if (listeCategorie.SelectedIndex == 0)
                    {
                        prixAdulte = PrixFantomeOpera * nbrTicket;
                        lv_choix.Items.Add(prixAdulte);
                    }
                    if (listeCategorie.SelectedIndex == 1)
                    {
                        prixAge = PrixFantomeOpera * rabaisPersonneAge * nbrTicket;
                        lv_choix.Items.Add(prixAge);
                    }
                    if (listeCategorie.SelectedIndex == 2)
                    {
                        prixEnfant = PrixFantomeOpera * rabaisEnfant * nbrTicket;
                        lv_choix.Items.Add(prixEnfant);
                    }
                }
            
            
        }

        private void Terminer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
