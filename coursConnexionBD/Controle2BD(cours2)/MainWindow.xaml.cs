using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Controle2BD_cours2_
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            this.InitializeComponent();
            //datepicker.SelectedDate = DateTime.Now;// selection a partir de la date d'aujourdhui
            //datepicker.MinYear= DateTimeOffset.Now;
            //datepicker.MaxYear= DateTimeOffset.Now.AddYears(3);

            // max de mon calendier
            //calendardatepiker.MaxDate = new DateTimeOffset(new DateTime(2024, 12, 31));
            //calendardatepiker.MinDate = DateTimeOffset.Now;// la valeur la plus petite est la date d'aujourdhui
           
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            //tbl_texte.Text = datepicker.Date.ToString("d"); // pour choisire le format de la date
            // tbl_texte.Text = timepicker.Time.ToString();
           // tbl_texte.Text = calendardatepiker.Date.ToString() ;
        }

        private void tbx_texte_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbl_texte.Text = tbx_texte.Text;

        }

        //private void calendardatepiker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        //{
        //    tbl_texte.Text = calendardatepiker.Date.Value.ToString("d");
        //}

        //private void datepicker_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        //{
        //   // tbl_texte.Text = datepicker.Date.ToString();
        //}

        //private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        //{
        //   //tbl_texte.Text = slider.Value.ToString();// pour que mon textBloc prend la valeur choisit du slider
        //   tbl_texte.FontSize=slider.Value;
        //}

        //private void toggleSwitch_Toggled(object sender, RoutedEventArgs e)
        //{
        //    if (toggleSwitch.IsOn) // si on l'active genre un chiffre aleatoir et met le dabs le textBloc
        //        tbl_texte.Text = new Random().Next(10,100).ToString(); // next sans les valeur genere beaucoup de chiffre . avec un parametre ca mets s
        //                                                            // sans depasser la valeur mis exple Next(100)
        //                                                            // avce deux paramettre (plus petit et plus grand)

        //}
    }
}
