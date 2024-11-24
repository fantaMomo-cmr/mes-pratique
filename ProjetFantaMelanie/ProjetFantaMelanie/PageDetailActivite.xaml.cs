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
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFantaMelanie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageDetailActivite : Page
    {
        Activite activite;
        public PageDetailActivite()
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
                imgActivite.Source = new BitmapImage(uri);
                tbl_nomActivite.Text = activite.Nom;
                tbl_typeActivite.Text = activite.Type;
                tbl_prixActivite.Text =Convert.ToString(activite.PrixVente);
            }
        }

        private void inscription_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PageSeanceActivite),activite);
        }

        private void revenirAffichage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PageAffichageActivite));
        }
    }
}
