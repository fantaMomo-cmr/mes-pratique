using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ExerciceCollection
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window, INotifyPropertyChanged
    {
        int index = -1;

        ObservableCollection<Employes> liste = new ObservableCollection<Employes>();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            this.InitializeComponent();
            lv_listeEmployes.ItemsSource = liste;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        // propiete pour faire un bind avec avec le textbloc pour l'affichage des details
        public Employes EmployesSelection => lv_listeEmployes.SelectedItem as Employes;

        public Visibility AfficherZone => liste.Count >0 ? Visibility.Visible : Visibility.Collapsed;
        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            //bool valide = true;
            tbl_ErreurMatricul.Text = "";
            tbl_ErreurNom.Text = "";
            tbl_ErreurPrenom.Text = "";
            tbl_ErreurDepartement.Text = "";


            

            if (liste.Count < 10)
            {
                if(validation() == true)
                    liste.Add(new Employes(tbx_Matricule.Text, tbx_Nom.Text, tbx_Prenom.Text, list_departement.SelectedItem.ToString()));
            }
           
            
        }

        private void lv_listeEmployes_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Employes employes = lv_listeEmployes.SelectedItem as Employes;
            if (employes != null)
            {
                tlb_matriculDetails.Text = employes.Matricule;
                tbl_nomDetails.Text = employes.Nom;
                tbl_prenomDetail.Text = employes.Prenom;
                tbl_departementDetail.Text = employes.Departement;

                index = lv_listeEmployes.SelectedIndex;
            }
            //this.OnPropertyChanged(nameof(EmployesSelection));
            //this.OnPropertyChanged(nameof(AfficherZone));
        }

        private void precedant_Click(object sender, RoutedEventArgs e)
        {
            suivant.IsEnabled = true;
            lv_listeEmployes.SelectedIndex = --index;

            if (lv_listeEmployes.SelectedIndex == 0)
            {
                precedant.IsEnabled = false;
            }
                
        }

        private void suivant_Click(object sender, RoutedEventArgs e)
        {
            precedant.IsEnabled = true;

            if (lv_listeEmployes.SelectedIndex < liste.Count-1 )
            {
                lv_listeEmployes.SelectedIndex = ++index;
                if (lv_listeEmployes.SelectedIndex == liste.Count - 1)
                {
                    suivant.IsEnabled = false;
                }
            }
                
        }


        private bool validation()
        {
            bool valide = true;

            if (tbx_Matricule.Text.Trim() != "")
            {
                tbl_ErreurMatricul.Text = "";
            }
            else
            {
                tbl_ErreurMatricul.Text = "vous devez entrer votre matricule";
                valide = false;
            }
            //-------------------------------------------
            if (tbx_Nom.Text.Trim() != "")
            {
                tbl_ErreurNom.Text = "";
            }
            else
            {
                tbl_ErreurNom.Text = "vous devez entrer votre nom";
                valide = false;
            }

            //-------------------------------------------
            if (tbx_Prenom.Text.Trim() != "")
            {
                tbl_ErreurPrenom.Text = "";
            }
            else
            {
                tbl_ErreurPrenom.Text = "vous devez entrer votre prenom";
                valide = false;
            }

            //-------------------------------------------
            if (list_departement.SelectedItem != null)
            {
                tbl_ErreurDepartement.Text = "";
            }
            else
            {
                tbl_ErreurDepartement.Text = "vous devez choisir votre departement";
                valide = false;
            }

            return valide;
        }
    }
}
