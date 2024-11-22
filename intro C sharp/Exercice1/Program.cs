// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine("entrez votre salaire: ");
double salaire = Convert.ToDouble(Console.ReadLine());
double salairenet;
double commission;
double TauxCom1 = 0.05;
double TauxCom2 = 0.1;
double TauxCom3 = 0.12;
double TauxCom4 = 0.14;
double TauxCom5 = 0.16;


if (salaire < 10000)
{
    commission = salaire * TauxCom1;
    salairenet = commission + salaire;
} else if (salaire >= 10000 && salaire <= 149999)
{
    commission = salaire * TauxCom2;
    salairenet = commission + salaire;
} else if (salaire >= 15000 && salaire <= 17999)
{
    commission = salaire * TauxCom3;
    salairenet = commission + salaire;
} else if (salaire >= 18000 && salaire <= 21999)
{
    commission = salaire * TauxCom4;
    salairenet = commission + salaire;
} else {
    commission = salaire * TauxCom5;
    salairenet = commission + salaire;
}
Console.WriteLine("votre salaire de base est de : " + salaire + "\n la commission est de : " + commission + "\n votre salaire net est de : " + salairenet);
