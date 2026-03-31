# Phase 0 — Setup & Outillage

Récapitulatif de toutes les commandes et tout le code utilisés durant la Phase 0,
avec l'explication du pourquoi de chaque élément.

---

## Session 0.1 — L'atelier du développeur

### Commandes terminal

```bash
git --version
```
**Pourquoi :** Vérifie que Git est bien installé sur la machine et affiche sa version.
Sans Git, impossible de versionner son code et de pousser sur GitHub.

---

```bash
git config --global user.name "Prénom Nom"
git config --global user.email "ton@email.com"
```
**Pourquoi :** Configure l'identité associée à chaque commit.
Git a besoin de savoir qui fait les modifications pour pouvoir les signer.
`--global` signifie que cette configuration s'applique à tous les projets Git de la machine.

---

```bash
git config --global --list
```
**Pourquoi :** Affiche toutes les configurations Git globales enregistrées.
Permet de vérifier que le nom et l'email ont bien été pris en compte.

---

```bash
cd "d:/App/C#_Raylib"
git clone https://github.com/Di0gen2S/formation-csharp-raylib.git
cd formation-csharp-raylib
```
**Pourquoi :**
- `cd` (change directory) : se déplace dans le dossier de travail.
- `git clone` : télécharge une copie complète du dépôt GitHub en local.
  Le dépôt distant (sur GitHub) devient automatiquement lié au dépôt local.
- On entre ensuite dans le dossier cloné pour travailler dedans.

---

```bash
git add README.md
```
**Pourquoi :** Ajoute le fichier `README.md` à la zone de staging (préparation).
Git ne committe que ce qui est dans le staging — c'est une étape de sélection volontaire.

---

```bash
git commit -m "docs: initialisation du README de formation"
```
**Pourquoi :** Crée un snapshot (instantané) du projet avec un message descriptif.
Le préfixe `docs:` indique le type de changement (documentation).
Convention de nommage utilisée dans la formation :
- `feat:` → nouvelle fonctionnalité
- `docs:` → documentation
- `refactor:` → restructuration du code sans changer son comportement
- `fix:` → correction de bug

---

```bash
git push origin main
```
**Pourquoi :** Envoie les commits locaux vers le dépôt distant sur GitHub.
- `origin` : le nom donné par défaut au dépôt distant (GitHub).
- `main` : le nom de la branche principale.

---

### Code — README.md

```markdown
# Formation C# + Raylib

Apprentissage du C# et de la bibliothèque Raylib avec pour objectif
la création d'un jeu Breakout complet.

## Progression

- [ ] Phase 0 — Setup & outillage
- [ ] Phase 1 — Bases du C#
- [ ] Phase 2 — POO en C#
- [ ] Phase 3 — Découverte Raylib
- [ ] Phase 4 — Breakout complet

## Stack technique

- Langage : C#
- Bibliothèque : Raylib-cs
- Éditeur : Visual Studio Code
- Versionnage : Git + GitHub
```
**Pourquoi :** Le README est la carte d'identité du projet sur GitHub.
Il s'affiche automatiquement sur la page du dépôt.
Les `- [ ]` sont des cases à cocher en Markdown — on les cochera au fil de l'avancement.

---

## Session 0.2 — Hello Raylib !

### Commandes terminal

```bash
dotnet new console -n HelloRaylib
```
**Pourquoi :** Crée un nouveau projet C# de type console.
- `dotnet new console` : utilise le template "application console" du SDK .NET.
- `-n HelloRaylib` : donne le nom `HelloRaylib` au projet.
Génère automatiquement `HelloRaylib.csproj` (fichier de configuration du projet)
et `Program.cs` (le fichier de code principal).

---

```bash
dotnet add package Raylib-cs
```
**Pourquoi :** Installe la bibliothèque Raylib-cs dans le projet via NuGet (le gestionnaire de paquets .NET).
Raylib est une bibliothèque externe — sans cette commande, impossible d'utiliser ses fonctions.
NuGet télécharge automatiquement la bonne version et la référence dans le `.csproj`.

---

```bash
dotnet run
```
**Pourquoi :** Compile le projet C# et l'exécute immédiatement.
C'est la commande qu'on utilisera à chaque fois pour tester le code.

---

### Code — Program.cs

```csharp
using Raylib_cs;
```
**Pourquoi :** Importe l'espace de noms (namespace) de Raylib.
Sans cette ligne, C# ne saurait pas où trouver les classes `Raylib`, `Color`, etc.

---

```csharp
Raylib.InitWindow(800, 600, "Hello, Raylib!");
```
**Pourquoi :** Crée et ouvre la fenêtre graphique.
- `800` : largeur en pixels.
- `600` : hauteur en pixels.
- `"Hello, Raylib!"` : titre affiché dans la barre de la fenêtre.
Cette fonction doit être appelée avant toute autre fonction Raylib.

---

```csharp
Raylib.SetTargetFPS(60);
```
**Pourquoi :** Limite la cadence d'affichage à 60 images par seconde (FPS).
Sans cette limite, le jeu tournerait à vitesse maximale (500+ FPS),
consommant inutilement le processeur.

---

```csharp
while (!Raylib.WindowShouldClose())
{
    ...
}
```
**Pourquoi :** C'est la **game loop** — le cœur de tout jeu vidéo.
La boucle tourne en continu tant que la fenêtre est ouverte.
`WindowShouldClose()` retourne `true` quand l'utilisateur clique sur la croix ou appuie sur `Escape`.

---

```csharp
Raylib.BeginDrawing();
Raylib.ClearBackground(Color.RayWhite);
```
**Pourquoi :**
- `BeginDrawing()` : signale à Raylib le début d'une nouvelle frame (image).
- `ClearBackground()` : efface l'écran avec la couleur choisie avant de tout redessiner.
  Sans ça, les images précédentes resteraient visibles et se superposeraient.
`Color.RayWhite` est un blanc légèrement cassé — la couleur de fond par défaut de Raylib.

---

```csharp
Raylib.DrawText("Hello, Raylib!", 240, 270, 48, Color.DarkBlue);
```
**Pourquoi :** Affiche du texte à l'écran.
- `"Hello, Raylib!"` : le texte à afficher.
- `240, 270` : position X, Y en pixels depuis le coin supérieur gauche.
- `48` : taille de la police en pixels.
- `Color.DarkBlue` : couleur du texte.

---

```csharp
Raylib.EndDrawing();
```
**Pourquoi :** Signale la fin du rendu de la frame et l'affiche à l'écran.
Fonctionne toujours en binôme avec `BeginDrawing()`.

---

```csharp
Raylib.CloseWindow();
```
**Pourquoi :** Libère proprement toutes les ressources utilisées par Raylib
et ferme la fenêtre. Bonne pratique systématique en fin de programme.

---

## Schéma de la game loop

```
┌─────────────────────────────────┐
│         GAME LOOP               │
│                                 │
│  ┌──────────────────────────┐   │
│  │  BeginDrawing()          │   │
│  │  ClearBackground()       │   │
│  │  DrawText(...)           │   │  ← se répète 60x/seconde
│  │  EndDrawing()            │   │
│  └──────────────────────────┘   │
│           ↑                     │
│           └── tant que fenêtre  │
│               ouverte           │
└─────────────────────────────────┘
```

---

*Phase 0 terminée — Phase 1 : Bases du C# →*
