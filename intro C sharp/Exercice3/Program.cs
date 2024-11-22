// See https://aka.ms/new-console-template for more information

Console.WriteLine("entrez la taille de votre tableau");
int taille = Convert.ToInt32(Console.ReadLine());
int[] nombres = new int[taille];

int somme=0;
double moyenne = 0;


// entre les valeurs dans le tableau
for(int i = 0; i < nombres.Length; i++)
{
    Console.WriteLine("entrez vos nombres ");
    int nbr = Convert.ToInt32(Console.ReadLine());
    nombres[i] = nbr;
}
// 
int max = nombres[0];
int min = nombres[0];
// affiche les valeurs de mon tableau
Console.WriteLine("les nombre entre sont les suivants: ");
for (int i = 0; i < nombres.Length; i++)
{
    if (nombres[i] < min)
    {
        min = nombres[i];
    }
    
    if(nombres[i] > max) 
    {
        max = nombres[i]; 
    }

    Console.WriteLine(nombres[i]);

    // la somme des nombres
    somme += nombres[i];
}

// la moyenne
moyenne = somme / taille; // /nombres.length

Console.WriteLine("la somme des nombres est : "+somme + "\nLa moyenne de vos chiffre est de : " + moyenne +
    "\n le nombre le plus petit est : "+ min + "\n le plus grand est :"+max);






