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

namespace ExercicePosition22
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



        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            string nom = tbx_nomProduit.Text;

            if (nom != "")
            {
                if (listeDeCategories.SelectedIndex == 0)
                {
                    if (lv_informatique.Items.Count < 5)
                        lv_informatique.Items.Add(nom);

                }

                if (listeDeCategories.SelectedIndex == 1)
                {
                    if (lv_meubles.Items.Count < 5)
                        lv_meubles.Items.Add(nom);
                }

                if (listeDeCategories.SelectedIndex == 2)
                {
                    if (lv_Electromenagers.Items.Count < 5)
                        lv_Electromenagers.Items.Add(nom);
                }
                if (listeDeCategories.SelectedIndex == -1)
                {
                    tbl_informatique.Text = "Choisissez une catégorie";
                }
            }
        }
    }
}
