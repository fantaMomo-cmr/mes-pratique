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
    public sealed partial class PageSeanceActivite : Page
    {
        Activite activite;
        Seance seance;
        public PageSeanceActivite()
        {
            this.InitializeComponent();
            lv_listeSeance.ItemsSource = Singleton.getInstance().ListeSeances;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is not null)
            {
                activite = (Activite)e.Parameter;
                Singleton.getInstance().afficherSeance(activite.IdActivite);
                
            }
        }

        private void inscription_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            Seance seance = button.DataContext as Seance;

            lv_listeSeance.SelectedItem = seance;
            Frame.Navigate(typeof(PageParticipant),seance);
        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PageDetailActivite),activite);
        }
    }
}
