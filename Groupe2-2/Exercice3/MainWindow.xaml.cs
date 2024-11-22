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

namespace Exercice3
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
            myButton.Content = "Clicked";
            double prixDeBase = Convert.ToDouble(tbx_prix.Text);
            double frais = 0;
            double profit = 0;
            double prixAvantTaxe = 0;
            double TVQ =0;
            double TPS = 0;
            double prixDeVente = 0;



            frais = prixDeBase * 0.02;
            profit = prixDeBase * 0.12;
            prixAvantTaxe = prixDeBase + frais + profit;
            TPS = prixAvantTaxe * 0.05;
            TVQ = prixAvantTaxe * 0.09975;

            prixDeVente = prixAvantTaxe + TVQ + TPS;

            tbl_affichage.Text = "le prix de vente de la voiture est de : " + prixDeVente;
        }
    }
}
