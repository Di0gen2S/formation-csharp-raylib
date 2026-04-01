// --- Programme principal ---
do
{
    LancerPartie();
    Console.WriteLine("");
} while (DemanderRejouer());

Console.WriteLine("À bientôt !");

// --- Méthodes ---

void LancerPartie()
{
    int nombreSecret = GenererNombreSecret();
    int tentatives = 0;
    int proposition = 0;

    Console.WriteLine("=== Jeu du Nombre Mystère ===");
    Console.WriteLine("Je pense à un nombre entre 1 et 100.");
    Console.WriteLine("");

    while (proposition != nombreSecret)
    {
        proposition = DemanderProposition();
        tentatives++;
        AfficherIndice(proposition, nombreSecret);
    }

    AfficherScore(tentatives);
}

int GenererNombreSecret()
{
    Random random = new Random();
    return random.Next(1, 101);
}

int DemanderProposition()
{
    Console.Write("Ta proposition : ");
    return Convert.ToInt32(Console.ReadLine());
}

void AfficherIndice(int proposition, int nombreSecret)
{
    if (proposition < nombreSecret)
        Console.WriteLine("Trop bas !");
    else if (proposition > nombreSecret)
        Console.WriteLine("Trop haut !");
}

void AfficherScore(int tentatives)
{
    Console.WriteLine("");
    Console.WriteLine("Bravo ! Trouvé en " + tentatives + " tentative(s) !");

    if (tentatives <= 5)
        Console.WriteLine("Excellent ! Tu es une machine.");
    else if (tentatives <= 8)
        Console.WriteLine("Bien joué !");
    else
        Console.WriteLine("Peut mieux faire... Essaie la stratégie 50/25/75 !");
}

bool DemanderRejouer()
{
    Console.Write("Rejouer ? (o/n) : ");
    return Console.ReadLine() == "o";
}