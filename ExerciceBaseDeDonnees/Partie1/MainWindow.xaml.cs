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

namespace Partie1
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            mainFrame.Navigate(typeof(pageAffichage));
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "iajouter":
                    mainFrame.Navigate(typeof(pageAjouter));
                    break;
                case "ilisteEquipe":
                    mainFrame.Navigate(typeof(pageAffichage));
                    break;
                case "irecherche":
                    mainFrame.Navigate(typeof(pageRecherher));
                    break;
                case "ilisteJoueur":
                    mainFrame.Navigate(typeof(pageAffichageJoueur));
                    break;
                case "iajouterJoueur":
                    mainFrame.Navigate(typeof(pageAjoutJoueur));
                    break;
            }
        }
    }
}
