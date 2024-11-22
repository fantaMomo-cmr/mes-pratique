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

namespace LesFichiersTexteetCSV
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



        //             -------------------------              pour ecrire dans un fichier text      -------------------------------------


        //private async void myButton_Click(object sender, RoutedEventArgs e)
        //{
        //    /* 
        //                                            pour sauvegarder les elts ecris dans un texBox dans un fichier texte 
        //     */

        //    // le bouton sauvegerder
        //    //var picker = new Windows.Storage.Pickers.FileSavePicker();// declaration de l'objet

        //    //var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);//la fenetre ou on var apparaitre. this fonctionne car c'est dans windows dans page c'est pas pariel 
        //    //WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

        //    //picker.SuggestedFileName = "test"; // pour suggerer un titre a notre fichier. on propose car on utilise le picker, si non on peut l'imposer avec autre chose
        //    //picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".txt" });// on met l'extention du fichier 

        //    ////crée le fichier
        //    //Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync(); // avec await il faut automatiquement  mentre async

        //    ////écrit dans le fichier
        //    ///* pour que ca ne plante pas. si le fichier est different de null ecrire si non n'ecrit pas */
        //    //if(monFichier != null)
        //    //await Windows.Storage.FileIO.WriteTextAsync(monFichier, tbx_texte.Text);


        //    /* 
        //                           pour l'ecriture ligne par ligne
        //     */

        //    var picker = new Windows.Storage.Pickers.FileSavePicker();// declaration de l'objet

        //    var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);//la fenetre ou on var apparaitre. this fonctionne car c'est dans windows dans page c'est pas pariel 
        //    WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

        //    picker.SuggestedFileName = "test"; // pour suggerer un titre a notre fichier. on propose car on utilise le picker, si non on peut l'imposer avec autre chose
        //    picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".txt" });// on met l'extention du fichier 

        //    //crée le fichier
        //    Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync(); // avec await il faut automatiquement  mentre async


        //    List<Client> liste = new List<Client>();
        //    liste.Add(new Client { Nom = "Laroche", Prenom = "Marie" });
        //    liste.Add(new Client { Nom = "Demers", Prenom = "René" });
        //    liste.Add(new Client { Nom = "Lavoie", Prenom = "Denis" });
        //    liste.Add(new Client { Nom = "Rivard", Prenom = "Louise" });

        //    //écrit dans le fichier chacune des lignes du tableau
        //    //une boucle sera faite sur la collection et prendra chacun des objets de celle-ci
        //    /*  await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.ToString())); avec le toString */ // 2 aprametre et pour cahque elts de ma liste 
        //    await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.StringTXT));                                                                                        /* 
        //                                                                                                   retourne se 
        //                                                                                                   */


        //}

        //                            /* 
        //                                                 pour lire
        //                             */
        //private async void btn_ouvrir_Click(object sender, RoutedEventArgs e)
        //{
        //    /*
        //                                                            pour la lecture d'un fichier texte
        //    */

        //    //var picker = new Windows.Storage.Pickers.FileOpenPicker(); // ouvre la fenetre pour choisir un fichier
        //    //picker.FileTypeFilter.Add(".txt");

        //    //var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
        //    //WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

        //    ////sélectionne le fichier à lire
        //    //Windows.Storage.StorageFile monFichier = await picker.PickSingleFileAsync(); //

        //    ////ouvre le fichier et lit le contenu
        //    //if (monFichier != null) // pour ne pas que mon fichier plante si on fais annuler
        //    //tbl_texte.Text = await Windows.Storage.FileIO.ReadTextAsync(monFichier);// pour lire le fichier



        //    /* 
        //                                                 pour lire ligne par ligne
        //     */


        //    var picker = new Windows.Storage.Pickers.FileOpenPicker(); // ouvre la fenetre pour choisir un fichier
        //    picker.FileTypeFilter.Add(".txt");

        //    var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
        //    WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

        //    //sélectionne le fichier à lire
        //    Windows.Storage.StorageFile monFichier = await picker.PickSingleFileAsync(); //

        //    //ouvre le fichier et lit le contenu
        //    //if (monFichier != null) // pour ne pas que mon fichier plante si on fais annuler
        //       var lignes= await Windows.Storage.FileIO.ReadLinesAsync(monFichier);// pour lire le fichier

        //    lv_liste.ItemsSource = lignes;
        //}


        /*
                                    Pour les fichier CSV
         */


        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            /*
                                 Pour ecrire une ligne les fichier CSV
            */
            var picker = new Windows.Storage.Pickers.FileSavePicker();

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            picker.SuggestedFileName = "test2";
            picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });

            //crée le fichier
            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

            string texteAEcrire = "nom;prenom;age";

            //écrit dans le fichier chacune des lignes du tableau
            await Windows.Storage.FileIO.WriteTextAsync(monFichier, texteAEcrire, Windows.Storage.Streams.UnicodeEncoding.Utf8);

        }

        private async void btn_ouvrir_Click(object sender, RoutedEventArgs e)
        {

            /* pour lire les ligne*/

            //var picker = new Windows.Storage.Pickers.FileSavePicker();

            //var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            //WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            //picker.SuggestedFileName = "test2";
            ////picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".txt" });
            //picker.FileTypeChoices.Add("Fichier CSV", new List<string>() { ".csv" });

            ////crée le fichier
            //Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();

            //List<Client> liste = new List<Client>();
            //liste.Add(new Client { Nom = "Laroche", Prenom = "Marie" });
            //liste.Add(new Client { Nom = "Demers", Prenom = "René" });
            //liste.Add(new Client { Nom = "Lavoie", Prenom = "Denis" });

            //// La fonction ToString de la classe Client retourne: nom + ";" + prenom

            //await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.StringCSV), Windows.Storage.Streams.UnicodeEncoding.Utf8);



            //                           pour lire ligne a ligne

            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.FileTypeFilter.Add(".csv");

            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            //sélectionne le fichier à lire
            Windows.Storage.StorageFile monFichier = await picker.PickSingleFileAsync();

            //ouvre le fichier et lit le contenu
            var lignes = await Windows.Storage.FileIO.ReadLinesAsync(monFichier);

            List<Client> liste = new List<Client>();

            /*boucle permettant de lire chacune des lignes du fichier
            * et de remplir une liste d'objets de type CLient
            */
            foreach (var ligne in lignes)
            {
                var v = ligne.Split(";");
                liste.Add(new Client { Nom = v[0], Prenom = v[1] });
            }

            //on peut mettre la liste de Clients comme source d'une listView
            lv_liste.ItemsSource = liste;


        }
    }
}
