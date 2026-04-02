string prenom = "Fred";
int age = 46;
double taille = 1.78;
Console.WriteLine("------------");
Console.WriteLine(prenom);
Console.WriteLine(age);
Console.WriteLine(taille);

DateTime maintenant = DateTime.Today;
int annee = maintenant.Year;
int anneeNaissance = annee - age;
int ageDansDixAns = age + 10;
Console.WriteLine("------------");
Console.WriteLine("Année de naissance : " + anneeNaissance + ".");
Console.WriteLine("Dans 10 ans, j'aurai " + ageDansDixAns + " ans.");

int nombre = 0;
Console.WriteLine("------------");
Console.Write("Entre un nombre : ");
nombre = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Tu as rentré : " + nombre);

int nb1 = 0;
int nb2 = 0;
Console.WriteLine("------------");
Console.Write("Entre un premier nombre :");
nb1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Entre un deuxième nombre :");
nb2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("nb1 + nb2 = " + (nb1+nb2));
Console.WriteLine("nb1 - nb2 = " + (nb1-nb2));
Console.WriteLine("nb1 x nb2 = " + (nb1*nb2));
if (nb2 != 0)
    Console.WriteLine("nb1 / nb2 = " + (nb1/(double)nb2));
else 
    Console.WriteLine("Division impossible");