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

namespace ProjetFantaMelanie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AfficherStatistiques : Page
    {
        public AfficherStatistiques()
        {
            this.InitializeComponent();

            // Total des adhérents par activité

            List<Adherent> listeTotaux = SingletonListe2.getInstance().nbrTotalAdherentActivite();

            if (listeTotaux != null && listeTotaux.Count > 0)
            {
                lv_totauxCategories.ItemsSource = listeTotaux;
            }
            else
            {
                lv_totauxCategories.ItemsSource = new List<Adherent>
            {
                    new Adherent { NomActivite = "Aucune catégorie disponible", NbrTotalAdherent = 0 }
                };

            }

            // Total des Adhérents
            int totalAdherents = SingletonListe2.getInstance().GetTotalAdherents();
            tbl_art_total.Text = totalAdherents.ToString();

            // total des activités
            int totalActivites = SingletonListe2.getInstance().GetTotalActivites();
            tbl_art_total_activite.Text = totalActivites.ToString();

            // Moyenne des notes par activité
            List<Adherent> notes = SingletonListe2.getInstance().getMoyenneNoteActivite();
            if (notes != null && notes.Count > 0)
            {
                lv_moy_notes.ItemsSource = notes;
            }
            else
            {
                lv_moy_notes.ItemsSource = new List<Adherent>
            {
                    new Adherent { NomActivite = "Aucune note n'est disponible", MoyenneNotesParAct = 0 }
                };

            }

            // Liste des adherents ayant participé au moins a une séance d'activité: 
            List<Adherent> listAdherent = SingletonListe2.getInstance().GetlisteParticipantsSeance();
            if (listAdherent != null && listAdherent.Count > 0)
            {
                lv_adherent_seance.ItemsSource = listAdherent;
            }
            else
            {
                lv_adherent_seance.ItemsSource = new List<Adherent>
            {
                    new Adherent 
                    { 
                        NomActivite = "Aucun adhérent pour le le moment", 
                        NomComplet="",
                        DateNaissance="",
                        Adresse="" 
                    }
                };

            }

            // Moyenne globale des seances d'activite
            double moyGlobale = SingletonListe2.getInstance().getMoyenneGlobale();
            tbl_moy_globale_activite.Text = moyGlobale.ToString();


            //`l'activité ayant le plus grand nombre de seance organisée
            Activite plusGrdNbrSeance = SingletonListe2.getInstance().activitePlusGrandNbrSeance();
            if (plusGrdNbrSeance != null)
            {
                tbl_nom.Text = plusGrdNbrSeance.Nom;
                tbl_prix_vente.Text = Convert.ToString(plusGrdNbrSeance.PrixVente);
                tbl_type.Text = plusGrdNbrSeance.Type;
                tbl_cout_organisation.Text= Convert.ToString(plusGrdNbrSeance.CoutOrganisation);
                tbl_total_seance.Text= Convert.ToString(plusGrdNbrSeance.TotalSeance);
            }

            // Moyenne des seances par activite
            double moyParAct = SingletonListe2.getInstance().nbrMoyenSeanceParActivite();
            tbl_moy_seance.Text = moyParAct.ToString();


        }





    }
}
