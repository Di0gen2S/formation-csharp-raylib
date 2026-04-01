Console.WriteLine("=== Calculatrice ===");

// Saisie du premier nombre
Console.Write("Entre le premier nombre : ");
double a = Convert.ToDouble(Console.ReadLine());

// Saisie du deuxième nombre
Console.Write("Entre le deuxième nombre : ");
double b = Convert.ToDouble(Console.ReadLine());

// Calculs et affichage
Console.WriteLine("--- Résultats ---");
Console.WriteLine(a + " + " + b + " = " + (a + b));
Console.WriteLine(a + " - " + b + " = " + (a - b));
Console.WriteLine(a + " * " + b + " = " + (a * b));

// Cas spécial : division par zéro
if (b == 0)
{
    Console.WriteLine("Division impossible (division par zéro !)");
}
else
{
    Console.WriteLine(a + " / " + b + " = " + (a / b));
}