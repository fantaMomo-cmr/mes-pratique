using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Protection.PlayReady;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace creationClasses
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        // pour l'utiliser dans tout le programme
        Clien client;

        //List<Clien> list = new List<Clien>() si on veut ajouter a chaque fois on utilise le ObservableCollection
        ObservableCollection<Clien> list = new ObservableCollection<Clien>()
            {
                    new Clien("Jean",25,"https://randomuser.me/api/portraits/men/86.jpg"),
                    new Clien("Michelle",23,"https://randomuser.me/api/portraits/women/94.jpg"),
                    new Clien("Sheere",26,"https://randomuser.me/api/portraits/women/33.jpg"),
                    new Clien("Pierre",30, "https://randomuser.me/api/portraits/men/44.jpg"),
                    new Clien("Franck",48, "https://randomuser.me/api/portraits/men/25.jpg"),

            };
    public MainWindow()
        {
            this.InitializeComponent();

            lv_liste.ItemsSource = list;
            // si on veut juste l'utiliser dans le mainWindows
            //Clien clien = new Clien("julie", 25);
            // tbl_texte.Text = client.ToString();
            // pour afficher ma propriete
            /*client.Nom = "fanta";
            //tbl_texte.Text = client.Nom;

            client.Age = 15;
            tbl_texte.Text = client.Age.ToString() + client.Nom;*/

            // autre methode 
            //client = new Clien 
            //{
            //    Nom = "julie",
            //    Age = 25
            //};
            /*
            // son resultat
            client.Age = 23;
            //tbl_texte.Text = client.Agedouble.ToString();
            tbl_texte.Text = client.AgeString;

            //*/
            //client = new Clien("julie", 25);

            //ArrayList liste = new ArrayList();
            //liste.Add(5);
            //liste.Add("un mot");
            //liste.Add(true);
            //liste.Add(new Clien("Jean", 25));

           

           

        }

        //public event PropertyChangedEventHandler PropertyChanged;

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //int age = Convert.ToInt32(tbx.Text);
            //client.Age = age;

            // si on veut pouvoir cliquer pour ajouter des images pour ca on utilise observableCollection
           // list.Add(new Clien("Jean", 25, "https://randomuser.me/api/portraits/men/86.jpg"));

            // pour la suppression
           // list.RemoveAt(0);

            // modification 
            //Clien nouveau = new Clien("Franck", 48, "https://randomuser.me/api/portraits/men/25.jpg");
            //list[0] = nouveau;
            // on veut juste changer le nom
           // list[0].Nom ="nouveau nom";


        }

        private void lv_liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            //< !--pour afficher le nom de la personne a cahue clique-- >
            Clien client = lv_liste.SelectedItem as Clien;
            tbl_text.Text = client.Nom; */
            // NB toujours verifier qu'il y a un elt selectionner
            // lv_liste.SelectedItem != null c'est pareil que (lv_liste.SelectedIndex >=0)
            if (lv_liste.SelectedItem != null)
            {
                
                int index = lv_liste.SelectedIndex;
                /*pour affercter une nouvelle valeur
                 * 
                list[index].Nom = "Nouveau nom";
                */
                /*pour supprimer a chaque clique

                list.RemoveAt(index);
                */



                
               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // celui qui emet l'evenement
            Button btn = sender as Button;

            Clien client = btn.DataContext as Clien;

            //permet de s'assurer que nous avons un élément sélectionné si non il peut planter
            lv_liste.SelectedItem = client;

            // pour trouver la position et le supprimer
            int index = list.IndexOf(client);

            list.RemoveAt(index);


        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            Clien client = btn.DataContext as Clien;
            //lv_liste.SelectedItem = client;
            ////tbl_text.Text = client.Nom;
            int index = list.IndexOf(client);
            //client.Nom = tbx_text.Text;

            list[index].Nom = tbx_text.Text;

        }
    }
}
