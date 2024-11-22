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

namespace Laboratoir2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pageStatistique : Page
    {
        //Produit produit;
        public pageStatistique()
        {
            this.InitializeComponent();

            tbl_Total.Text = Singleton.getInstance().totalProduits().ToString();
            lv_produitCategorie.ItemsSource = Singleton.getInstance().NombreCategories();
            lvPluschere.ItemsSource = Singleton.getInstance().produitPlusChere();

            //if (tbl_Total.Text == "" && lv_produitCategorie.ItemsSource == null && lvPluschere.ItemsSource == null)
            //{
            //    tbl_pageVide.Text = " Aucun produit n'est disponible";
            //}
           



    }
        }
}