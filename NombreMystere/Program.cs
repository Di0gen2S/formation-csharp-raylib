Random random = new Random();
string rejouer = "o";

do
{
    int nombreSecret = random.Next(1, 101);
    int tentative = 0;
    int proposition = 0;

    Console.WriteLine("=== Jeu du Nombre Mystère ===");
    Console.WriteLine("Je pense à un nombre entre 1 et 100.");
    Console.WriteLine("");

    while (proposition != nombreSecret)
    {
        Console.Write("Ta proposition : ");
        proposition = Convert.ToInt32(Console.ReadLine());
        tentative++;

        if (proposition < nombreSecret)
            Console.WriteLine("Trop bas !");
        else if (proposition > nombreSecret)
            Console.WriteLine("Trop haut !");
        else
        {
            Console.WriteLine("");
            Console.WriteLine("Bravo ! Trouvé en " + tentative + " tentative(s) !");

            if (tentative <= 5)
                Console.WriteLine("Excellent ! Tu es une machine.");
            else if (tentative <= 8)
                Console.WriteLine("Bien joué !");
            else
                Console.WriteLine("Peut mieux faire... Essaie la stratégie 50/25/75 !");
        }
    }

    Console.WriteLine("");
    Console.Write("Rejouer ? (o/n) : ");
    rejouer = Console.ReadLine();
    Console.WriteLine("");

} while (rejouer == "o");

Console.WriteLine("À bientôt !");