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

namespace ExercicieMultipage
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAffichage : Page
    {
        public PageAffichage()
        {
            this.InitializeComponent();
            gv_listeArticles.ItemsSource = SingletonArticle.getInstance().ListeArticles;

        }
        private void gv_listeArticles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // pour faire le navigation vers la page de detaille
            Articles articles = (Articles)gv_listeArticles.SelectedItem;
            if(articles != null)
            {
                Frame.Navigate(typeof(PageDetailleArticle),articles);// pour envoyer les elt vers l'autre page de detaille
            }
            

        }
    }
}
