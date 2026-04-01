// --- Données du quiz ---
List<string> questions = new List<string>();
List<string> reponses = new List<string>();

ChargerQuestions(questions, reponses);

// --- Programme principal ---
Console.WriteLine("=== Mini-Quiz C# ===");
Console.WriteLine("Réponds aux questions suivantes.");
Console.WriteLine("");

int score = LancerQuiz(questions, reponses);
AfficherResultat(score, questions.Count);

Console.WriteLine("");
Console.Write("Appuie sur Entrée pour quitter...");
Console.ReadLine();

// --- Méthodes ---

void ChargerQuestions(List<string> q, List<string> r)
{
    q.Add("Quel type stocke un nombre entier en C# ?");
    r.Add("int");

    q.Add("Quel mot-clé déclare une méthode sans retour ?");
    r.Add("void");

    q.Add("Quelle boucle s'exécute au moins une fois ?");
    r.Add("do while");

    q.Add("Comment ajoute-t-on un élément à une List ?");
    r.Add("add");

    q.Add("Quel mot-clé sort immédiatement d'une méthode ?");
    r.Add("return");
}

int LancerQuiz(List<string> q, List<string> r)
{
    int score = 0;

    for (int i = 0; i < q.Count; i++)
    {
        Console.WriteLine("Question " + (i + 1) + "/" + q.Count + " : " + q[i]);
        Console.Write("Ta réponse : ");
        string reponse = Console.ReadLine().ToLower().Trim();

        if (reponse == r[i].ToLower())
        {
            Console.WriteLine("Correct !");
            score++;
        }
        else
        {
            Console.WriteLine("Incorrect. La réponse était : " + r[i]);
        }

        Console.WriteLine("");
    }

    return score;
}

void AfficherResultat(int score, int total)
{
    Console.WriteLine("=== Résultat ===");
    Console.WriteLine("Score : " + score + "/" + total);

    if (score == total)
        Console.WriteLine("Parfait ! Tu maîtrises les bases du C#.");
    else if (score >= total / 2)
        Console.WriteLine("Bien joué ! Quelques points à revoir.");
    else
        Console.WriteLine("Continue à pratiquer, tu y es presque !");
}