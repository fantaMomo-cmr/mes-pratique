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

namespace App1
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            // le frame qu'on a declarer pour la navigation 
            // permet de sevoir quel page on a a l'entree
          //  mainFrame.Navigate(typeof(Page1));
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "iClients":
                    mainFrame.Navigate(typeof(Page1));
                    break;
                case "iAgenda":
                    mainFrame.Navigate(typeof(Page2));
                    break;
                case "iCommandes":
                    mainFrame.Navigate(typeof(Pagefanta));
                    break;
                default:
                    break;
            }

        }
        /*
private void btPage1_Click(object sender, RoutedEventArgs e)
{
   mainFrame.Navigate(typeof(Page1));
}

private void btPage2_Click(object sender, RoutedEventArgs e)
{
   mainFrame.Navigate(typeof(Page2));
}

//private void myButton_Click(object sender, RoutedEventArgs e)
//{
//    myButton.Content = "Clicked";
//}*/
    }
}
