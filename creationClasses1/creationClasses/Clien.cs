using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creationClasses
{
    internal partial class Clien : INotifyPropertyChanged
    {   /*
        string nom;
        int age;

        public Clien(string nom, int age)
        {
            this.nom = nom;
            this.age = age;
        }

        //public void setNom(string nom)
        //{
        //    this.nom=nom;
        //}
        //public string getNom()
        //{
        //    return this.nom;
        //}

        //public void setAge(int age)
        //{
        //    this.age=age;
        //}

        //public int getAge()
        //{
        //    return this.age;
        //}

        // on va le remplace par le propriete ci dessous
        public string Nom
        {
            get 
            { 
                return nom; 
            }

            set
            {
                nom = value;
            }
        }

        public int Age
        {
            get { return age; }
            set { 
                if(value < 0)
                    age = 2;
                else
                age = value; 
            }
        }

        // toujour mettre le override si veut le retour de notre methode 
        public override string ToString()
        {
            return $"{nom} - {age}";
           // return "Mon nom est : " + nom + " et J'ai " + age;
        }*/

        /*
        // deuxieme methode
        public string Nom { get; set; }
        public int Age { get; set; }

        // proprierte calculer qui est juste en lecture
        public string Infos => $"{Nom} - {Age}";

        public int Agedouble => Age * 2;

        public string AgeString  => Age.ToString();*/
        string nom;
        int age;
        string photo;

        public Clien(string nom, int age, string photo)
        {
            this.nom = nom;
            this.age = age;
            this.photo = photo;
        }

        public string Nom
        {
            get { return nom; }
            set { 
                nom = value;
                this.OnPropertyChanged(nameof(Nom));
                 }
        }

        public int Age
        {
            get => age;
            set
            {
                 age = value;
                 this.OnPropertyChanged(nameof(Age));
                    this.OnPropertyChanged(nameof(Couleur));
                this.OnPropertyChanged(nameof(Visible));
            }
        }
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }


        // retourne couleur en fonction de l'age
        public string Couleur => Age >= 18 ? "Green" : "Red";

        public Visibility Visible => Age >= 18 ? Visibility.Visible : Visibility.Collapsed ;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"{Nom} - {Age} - {photo}";
        }
    }
}
