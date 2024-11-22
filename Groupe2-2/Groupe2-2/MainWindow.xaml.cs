using Microsoft.UI;
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

namespace Groupe2_2
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
            // verifie qu'il ai quelque chose a selectionner pour supprimer
            if(lv_liste.SelectedIndex >= 0)
            {
                // supprime toute la liste
                lv_liste.Items.Clear();
                // supprime l'elt selectionne
                lv_liste.Items.RemoveAt(lv_liste.SelectedIndex);
            }
            //string texte = tbx_nom.Text;
            //lv_liste.Items.Add(texte);

            // elt selectionnné et index c'est la position
            //int index = lv_liste.SelectedIndex;
            //string s = lv_liste.SelectedItem as string;
            //tbl_texte.Text = s;

            //Uri uri = new Uri("https://i.pinimg.com/originals/03/ec/a7/03eca729730411fd43dccbaff1bed8a0.jpg");
            //img.Source = new BitmapImage(uri);

            //    tbl_texte.Text = "Bonjour"; ici on l'affecte une string predefinit
            //     pour recuperer le contenu de mon textbox pour le mettre dans mon textblock
            //    String nom = tbx_nom.Text;
            //    tbl_texte.Text = nom; // ici on l'affecte une variable

            //    pour preremolir: leur donner des valeurs par defaut
            //    tbx_nom.Text = "john doe";


            //    ^pour verifier si on clique ou pas
            //    if (cb.IsChecked == true)
            //    {
            //        tbl_texte.Text = "Case cochée";
            //    }
            //    else
            //    {
            //        tbl_texte.Text = "Case décochée";
            //    }


        }
        private void lv_liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lv_liste.SelectedIndex;
            string s = lv_liste.SelectedItem as string;
            tbl_texte.Text = s;
        }
        private void couleurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // pour la couleur des bouttons
            //int index = couleurs.SelectedIndex;
            //if (index == 0)
            //    stkpnl.Background = new SolidColorBrush(Colors.Aqua);
            //if (index == 1)
            //    stkpnl.Background = new SolidColorBrush(Colors.Pink);
            //if(index == 2)
            //    stkpnl.Background= new SolidColorBrush(Colors.Azure);
        }
        //private void cb_Checked(object sender, RoutedEventArgs e)
        //{
        //    //tbl_texte.Text = "Case cochée";
        //}
        //private void cb_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    //tbl_texte.Text = "Case décochée";
        //}

        //private void cb_Tapped(object sender, RoutedEventArgs e)
        //{
        //    if (cb.IsChecked == true)
        //    {
        //        tbl_texte.Text = "Case cochée";
        //    }
        //    else
        //    {
        //        tbl_texte.Text = "Case décochée";
        //    }
        //}



        //Exercice 1


    }
}
