# Phase 1 — Bases du C#

Récapitulatif de toutes les commandes et tout le code utilisés durant la Phase 1,
avec l'explication du pourquoi de chaque élément.

---

## Session 1.1 — Variables & Types

### Commandes terminal

```bash
dotnet new console -n Calculatrice
```
**Pourquoi :** Crée un nouveau projet C# de type console nommé `Calculatrice`.
Génère `Calculatrice.csproj` (configuration du projet) et `Program.cs` (le code).

---

```bash
dotnet run
```
**Pourquoi :** Compile et exécute le projet en une seule commande.
C'est la commande qu'on utilise à chaque fois pour tester le code.

---

### Code — Calculatrice/Program.cs (version 1 — variables fixes)

```csharp
int a = 10;
int b = 3;
double resultat = 0;
```
**Pourquoi :** Déclaration de variables.
- `int` stocke un nombre entier (sans décimales).
- `double` stocke un nombre décimal.
- La variable `resultat` est en `double` pour pouvoir accueillir le résultat d'une division.

---

```csharp
Console.WriteLine("a = " + a);
```
**Pourquoi :** Affiche une ligne dans la console.
L'opérateur `+` entre une chaîne et une variable colle les deux ensemble (concaténation).

---

```csharp
resultat = a / (double)b;
```
**Pourquoi :** Le **cast** `(double)` convertit `b` de `int` en `double` avant la division.
Sans ça, C# ferait une division entière : `10 / 3 = 3` (résultat tronqué).
Avec le cast : `10 / 3.0 = 3.333...` (résultat exact).

---

### Code — Calculatrice/Program.cs (version 2 — interactive)

```csharp
Console.Write("Entre le premier nombre : ");
double a = Convert.ToDouble(Console.ReadLine());
```
**Pourquoi :**
- `Console.Write` affiche sans saut de ligne — l'utilisateur tape sur la même ligne.
- `Console.ReadLine()` lit ce que l'utilisateur tape. Retourne toujours un `string`.
- `Convert.ToDouble()` convertit ce `string` en nombre décimal utilisable pour les calculs.

---

```csharp
if (b == 0)
{
    Console.WriteLine("Division impossible (division par zéro !)");
}
else
{
    Console.WriteLine(a + " / " + b + " = " + (a / b));
}
```
**Pourquoi :** Protège contre la division par zéro qui ferait planter le programme.
Premier usage concret du `if/else` — si condition vraie, bloc 1 ; sinon, bloc 2.

---

## Session 1.2 — Conditions & Boucles

### Commandes terminal

```bash
dotnet new console -n NombreMystere
```
**Pourquoi :** Crée le projet pour le jeu du nombre mystère.

---

### Opérateurs de comparaison

```
==   égal à
!=   différent de
>    supérieur à
<    inférieur à
>=   supérieur ou égal
<=   inférieur ou égal
```
**Pourquoi :** Ces opérateurs retournent toujours `true` ou `false`.
On les utilise dans les conditions `if` et les boucles `while`.

---

### Code — NombreMystere/Program.cs (version 1)

```csharp
Random random = new Random();
int nombreSecret = random.Next(1, 101);
```
**Pourquoi :**
- `Random` est une classe intégrée à C# qui génère des nombres aléatoires.
- `Next(1, 101)` génère un entier entre 1 inclus et 101 **exclus** (donc entre 1 et 100).
- Le `+1` sur la borne haute est un détail classique à retenir.

---

```csharp
while (proposition != nombreSecret)
{
    ...
    tentative++;
}
```
**Pourquoi :** La boucle `while` tourne tant que la condition est vraie.
Ici : tant que la proposition est différente du nombre secret.
`tentative++` est un raccourci pour `tentative = tentative + 1`.

---

### Code — NombreMystere/Program.cs (version 2 — avec rejouer)

```csharp
do
{
    // code du jeu
} while (rejouer == "o");
```
**Pourquoi :** Le `do/while` exécute le bloc **au moins une fois** avant de vérifier la condition.
Parfait pour un jeu : on joue d'abord, puis on demande si on veut rejouer.
Différence clé avec `while` : `while` vérifie avant d'entrer, `do/while` vérifie après.

---

```csharp
if (tentative <= 5)
    Console.WriteLine("Excellent !");
else if (tentative <= 8)
    Console.WriteLine("Bien joué !");
else
    Console.WriteLine("Peut mieux faire...");
```
**Pourquoi :** Chaîne de conditions `if/else if/else` — seul le premier bloc vrai s'exécute.
Permet d'adapter le message selon la performance du joueur.

---

## Session 1.3 — Méthodes & Fonctions

### Anatomie d'une méthode

```
type de retour   nom        paramètres
      ↓           ↓              ↓
    int      Additionner  (int a, int b)
    void     DireBonjour  ()
```

- `void` → la méthode ne retourne rien.
- `int`, `double`, `bool`, `string` → la méthode retourne une valeur de ce type.
- `return valeur;` → envoie la valeur au code appelant et sort de la méthode.

---

### Code — NombreMystere/Program.cs (version refactorisée)

```csharp
void LancerPartie()
{
    int nombreSecret = GenererNombreSecret();
    ...
}
```
**Pourquoi :** Chaque méthode a **une seule responsabilité**.
Le programme principal se lit comme une phrase :
"Lance une partie, tant que le joueur veut rejouer."

---

```csharp
int GenererNombreSecret()
{
    Random random = new Random();
    return random.Next(1, 101);
}
```
**Pourquoi :** Isole la génération du nombre secret. Si on veut changer la plage (1-50 par exemple),
on sait exactement où modifier — une seule ligne, un seul endroit.

---

```csharp
bool DemanderRejouer()
{
    Console.Write("Rejouer ? (o/n) : ");
    return Console.ReadLine() == "o";
}
```
**Pourquoi :** Retourne directement le résultat de la comparaison (`true` ou `false`).
Plus concis qu'un `if/else` avec une variable intermédiaire.

---

```csharp
void AfficherIndice(int proposition, int nombreSecret)
{
    if (proposition < nombreSecret)
        Console.WriteLine("Trop bas !");
    else if (proposition > nombreSecret)
        Console.WriteLine("Trop haut !");
}
```
**Pourquoi :** Pas de `else` final — si la proposition est juste, on n'affiche rien.
La boucle `while` s'arrêtera d'elle-même quand `proposition == nombreSecret`.

---

## Session 1.4 — Tableaux & Listes

### Commandes terminal

```bash
dotnet new console -n GestionnaireScores
```
**Pourquoi :** Crée le projet pour le gestionnaire de scores.

---

### Tableau vs Liste

```csharp
// Tableau — taille fixe, définie à la création
int[] scores = new int[5];
scores[0] = 42;

// Liste — taille variable, on ajoute au fur et à mesure
List<int> scores = new List<int>();
scores.Add(42);
scores.Add(87);
```
**Pourquoi :** On préfère les listes en pratique — plus flexibles.
Le tableau est utile quand on connaît à l'avance le nombre exact d'éléments.

---

### Méthodes et propriétés utiles de List

```csharp
scores.Add(42)       // ajoute un élément
scores.Count         // nombre d'éléments (propriété, pas de parenthèses)
scores.Max()         // valeur maximale
scores.Average()     // moyenne
scores[i]            // accès à l'élément à la position i
```
**Pourquoi :** Ces outils sont intégrés dans C# — pas besoin de les coder soi-même.
`Count` est une propriété (pas de `()`), les autres sont des méthodes (avec `()`).

---

### Code — GestionnaireScores/Program.cs

```csharp
foreach (int score in scores)
{
    Console.WriteLine("- " + score);
}
```
**Pourquoi :** `foreach` parcourt chaque élément d'une liste automatiquement.
Plus lisible qu'un `for` classique quand on n'a pas besoin de l'index.

---

```csharp
for (int i = 0; i < liste.Count; i++)
{
    Console.WriteLine((i + 1) + ". " + liste[i]);
}
```
**Pourquoi :** On utilise `for` ici car on a besoin de `i` pour afficher le numéro de ligne.
`liste[i]` accède à l'élément à la position `i` (commence à 0).

---

```csharp
if (liste.Count == 0)
{
    Console.WriteLine("Aucun score enregistré.");
    return;
}
```
**Pourquoi :** `return` dans une méthode `void` sort immédiatement de la méthode.
Indispensable ici : appeler `Max()` ou `Average()` sur une liste vide planterait le programme.

---

```csharp
Console.WriteLine("Score moyen : " + Math.Round(liste.Average(), 1));
```
**Pourquoi :** `Math.Round(valeur, décimales)` arrondit à N décimales.
`liste.Average()` retourne un `double` avec beaucoup de décimales — on l'arrondit à 1.

---

## Session 1.5 — Mini-Quiz (Révision)

### Commandes terminal

```bash
dotnet new console -n MiniQuiz
```
**Pourquoi :** Crée le projet pour le mini-quiz de révision.

---

### Code — MiniQuiz/Program.cs

```csharp
List<string> questions = new List<string>();
List<string> reponses  = new List<string>();
```
**Pourquoi :** Deux listes parallèles — `questions[i]` correspond à `reponses[i]`.
Technique simple pour associer deux données sans encore connaître les classes (Phase 2).

---

```csharp
string reponse = Console.ReadLine().ToLower().Trim();
```
**Pourquoi :**
- `.ToLower()` convertit en minuscules — "INT" et "int" seront traités pareil.
- `.Trim()` supprime les espaces avant et après — " int " devient "int".
Ces deux appels évitent les erreurs dues à la casse ou aux espaces involontaires.

---

```csharp
if (reponse == r[i].ToLower())
```
**Pourquoi :** On compare également en minuscules côté réponse attendue,
pour que la comparaison soit symétrique et fiable.

---

## Schéma récapitulatif — Les fondamentaux C#

```
VARIABLES          CONDITIONS          BOUCLES
──────────         ──────────          ───────
int    = entier    if (cond) {}        while (cond) {}
double = décimal   else if  {}         do {} while (cond)
string = texte     else     {}         for (int i=0; ...) {}
bool   = vrai/faux                     foreach (x in liste) {}

MÉTHODES                    LISTES
────────                    ──────
void   Nom() {}             List<int> l = new List<int>();
int    Nom() { return x; }  l.Add(42);
void   Nom(int a) {}        l.Count / l.Max() / l.Average()
                            l[i]  →  accès par index
```

---

*Phase 1 terminée — Phase 2 : POO en C# →*
