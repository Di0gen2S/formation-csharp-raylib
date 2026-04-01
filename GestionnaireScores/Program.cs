List<int> scores = new List<int>();
string choix = "";

Console.WriteLine("=== Gestionnaire de Scores ===");

while (choix != "q")
{
    Console.WriteLine("");
    Console.WriteLine("1 - Ajouter un score");
    Console.WriteLine("2 - Afficher les scores");
    Console.WriteLine("3 - Afficher les statistiques");
    Console.WriteLine("q - Quitter");
    Console.Write("Ton choix : ");
    choix = Console.ReadLine();

    if (choix == "1")
        AjouterScore(scores);
    else if (choix == "2")
        AfficherScores(scores);
    else if (choix == "3")
        AfficherStatistiques(scores);
}

Console.WriteLine("À bientôt !");

// --- Méthodes ---

void AjouterScore(List<int> liste)
{
    Console.Write("Entre le score : ");
    int score = Convert.ToInt32(Console.ReadLine());
    liste.Add(score);
    Console.WriteLine("Score " + score + " ajouté !");
}

void AfficherScores(List<int> liste)
{
    if (liste.Count == 0)
    {
        Console.WriteLine("Aucun score enregistré.");
        return;
    }

    Console.WriteLine("--- Scores ---");
    for (int i = 0; i < liste.Count; i++)
    {
        Console.WriteLine((i + 1) + ". " + liste[i]);
    }
}

void AfficherStatistiques(List<int> liste)
{
    if (liste.Count == 0)
    {
        Console.WriteLine("Aucun score enregistré.");
        return;
    }

    Console.WriteLine("--- Statistiques ---");
    Console.WriteLine("Nombre de scores : " + liste.Count);
    Console.WriteLine("Meilleur score   : " + liste.Max());
    Console.WriteLine("Score moyen      : " + Math.Round(liste.Average(), 1));
}