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
using System.Diagnostics;
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
    public sealed partial class PageModifieSeance : Page
    {
        Seance seance;
        public PageModifieSeance()
        {
            this.InitializeComponent();
            datePiker.MaxYear = new DateTimeOffset(new DateTime(2027, 12, 31));
            datePiker.MinYear = new DateTimeOffset(new DateTime(2024, 12, 20));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is not null)
            {
              
                seance = (Seance)e.Parameter;
                combo_IDActivite.ItemsSource = Singleton.getInstance().selectionnerIDActiviteDansSeance();
                combo_IDActivite.SelectedItem = seance.Id_activite;
                datePiker.SelectedDate = Convert.ToDateTime(seance.DateSeance);
                heurePiker.SelectedTime = TimeSpan.Parse(seance.Heure);
                num_nbrPlace.Text = Convert.ToString(seance.Nbr_place);
            }
        }

        private void btn_modifier_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;
            tbl_erreurIDactivite.Text = "";
            tbl_erreurDate.Text = "";
            tbl_erreurHeure.Text = "";
            tbl_erreurNbrPlace.Text = "";
            int nbrPlace = 0;

            if (combo_IDActivite.SelectedIndex == null)
            {
                tbl_erreurIDactivite.Text = "selectionner l'id de l'activite pour la seance";
                valide = false;
            }
            if(datePiker.SelectedDate == null)
            {
                tbl_erreurDate.Text = "vous devez selectionner une date";
                valide = false;
            }
            if (heurePiker.SelectedTime == null) 
            {
                tbl_erreurHeure.Text = "vouz devez selectionner l'heure de la seance";
                valide = false;
            }
            if(int.TryParse(num_nbrPlace.Text,out nbrPlace) == false)
            {
                tbl_erreurNbrPlace.Text = "vous devez entrer le nombre de place";
                valide = false;
            }
            if (nbrPlace < 0)
            {
                tbl_erreurNbrPlace.Text = "le nombre de place ne peut pas inferieur à 0";
                valide = false;
            }
            if(valide == true)
            {
                seance.Id_activite = combo_IDActivite.SelectedItem.ToString();
                seance.DateSeance = datePiker.SelectedDate.ToString();
                seance.Heure = heurePiker.SelectedTime.ToString();
                seance.Nbr_place = nbrPlace;
                Singleton.getInstance().updateSeance(seance);
                Frame.Navigate(typeof(PageSeance));
            }
        }
    }
}
