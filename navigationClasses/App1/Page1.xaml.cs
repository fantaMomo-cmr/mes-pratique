﻿using Microsoft.UI.Xaml;
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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        
        public Page1()
        {
            this.InitializeComponent();
            lv_liste.ItemsSource = SingletonListe.getInstance().Liste; // SingletonListe.getInstance() permet de retourner l'objet sur le quel on travaille
        }
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);
        //    if (e.Parameter is not null)
        //    {
        //        tbl_texte.Text = (string)e.Parameter;
        //        // e.Parameter as string
        //    }
        //    else
        //    {
        //        tbl_texte.Text = "AUCUNE DONNÉE";

        //    }

        //}
        private void btnPageFanta_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pagefanta));
        }
    }
}