using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFantaMelanie
{
    class ServiceNavigation
    {

        NavigationView navigationView;

        static ServiceNavigation instance;

        public static ServiceNavigation getInstance()
        {
            if (instance == null)
                instance = new ServiceNavigation();

            return instance;
        }

        public NavigationView NavigationView
        {
            get { return navigationView; }
            set { navigationView = value; }
        }

        public void affichageVisiteur()
        {
            foreach (var item in navigationView.MenuItems)
            {
                if (item is NavigationViewItem)
                {
                    var i = item as NavigationViewItem;
                    if (i.Name == "ilisteActivite")
                    {
                        i.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                    }

                    if (i.Name == "iListeAdherent")
                    {
                        // Affichage dans la fenêtre Sortie pour le débogage
                        Debug.WriteLine(Singleton.getInstance().userConnecte);
                        Debug.WriteLine(Singleton.getInstance().PersonneConnecte?.Role);

                        // Vérifiez si un utilisateur est connecté et si son rôle est "Administrateur"
                        if (Singleton.getInstance().userConnecte && Singleton.getInstance().PersonneConnecte?.Role == "Administrateur")
                        {
                            i.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                        }
                        else
                        {
                            i.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                        }
                    }
                    if (i.Name == "iListeSeance")
                    {
                        i.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                    }
                    if (i.Name == "iStatistique")
                    {
                        i.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                    }
                }

            }
        }


        public void connexionAderent()
        {
            //navigationView.Header = "";

            //foreach (var item in navigationView.PaneCustomContent)
            //{
            //    if (item is NavigationViewItem)
            //    {
            //        var i = item as NavigationViewItem;
            //        if (i.Name == "ilisteActivite")
            //        {
            //            i.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
            //        }

            //        if (i.Name == "iListeAdherent")
            //        {
            //            i.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
            //        }
            //    }

            //}
        }

        public void changerUser()
        {
            StackPanel? stackPanel = navigationView.PaneCustomContent as StackPanel;
            if (stackPanel != null)
            {
                foreach (var item in stackPanel.Children)
                {
                    if (item is TextBlock)
                    {
                        TextBlock textBlock = (TextBlock)item;
                        if(Singleton.getInstance().userConnecte)
                            textBlock.Text = Singleton.getInstance().PersonneConnecte.Nom + " " + Singleton.getInstance().PersonneConnecte.Prenom;
                        break;
                    }
                }
            }
        }

        public void cleanUserOnLogout()
        {
            StackPanel? stackPanel = navigationView.PaneCustomContent as StackPanel;
            if (stackPanel != null)
            {
                foreach (var item in stackPanel.Children)
                {
                    if (item is TextBlock)
                    {
                        TextBlock textBlock = (TextBlock)item;
                        if (!Singleton.getInstance().userConnecte)
                            textBlock.Text = "Allo";
                        break;
                    }
                }
            }
        }


    }
}
