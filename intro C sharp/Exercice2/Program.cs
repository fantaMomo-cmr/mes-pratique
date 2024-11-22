// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int somme = 0;
string phrase = "";

Console.WriteLine("entrez le premier nombre");
int nbr1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("entrez le deuxieme nombre");
int nbr2 = Convert.ToInt32(Console.ReadLine());

for (int i = nbr1; i<=nbr2;i++)
{
    somme += i;
    phrase += i; 
    phrase += i==nbr2 ? " = " : " + ";
}
Console.WriteLine("la somme est : " + phrase + somme);