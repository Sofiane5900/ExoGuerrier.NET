using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExoGuerrier.NET.Donjon;
using Spectre.Console;

namespace ExoGuerrier.NET.ModeHistoire.Histoire
{
    internal class Foret
    {
        public Foret() { }

        public void LancerForet(Hero hero)
        {
            if (hero == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erreur : le héros n'a pas été crée.");
                Console.ResetColor();
                return;
            }

            Console.Clear();
            AnsiConsole.Write(new FigletText("Foret").LeftJustified().Color(Color.Green));
            AnsiConsole.WriteLine("=== Chemin Forestier  ===\n");
            AnsiConsole.MarkupLine(
                "[white]Vous entrez dans une forêt dense, où l'air est frais mais lourd de mystère. Les arbres forment une voûte naturelle qui assombrit le chemin devant vous.[/]"
            );
            AnsiConsole.MarkupLine(
                "[grey]Des bruits légers de branches qui craquent et des chuchotements du vent brisent le silence. Vous sentez que vous n'êtes pas seul.[/]"
            );
            AnsiConsole.MarkupLine(
                "[italic silver]À chaque pas, vos bottes s'enfoncent légèrement dans le sol humide, et un frisson vous parcourt l'échine.[/]"
            );
            AnsiConsole.MarkupLine(
                "\nUn ancien panneau à moitié effacé vous avertit : [red bold]\"Danger : créatures hostiles.\"[/]"
            );
            AnsiConsole.MarkupLine(
                "[yellow]Le chemin devant vous semble s'étirer sans fin, et vous hésitez sur la direction à prendre...[/]"
            );
            // Choix du chemin
            var choixForet = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold green]Quel chemin choisissez-vous ?[/]")
                    .AddChoices(
                        "Chemin sûr mais plus long",
                        "Chemin rapide mais risqué",
                        "Explorer la forêt à l'aveugle"
                    )
            );

            switch (choixForet)
            {
                case "Chemin sûr mais plus long":
                    EvenementAleatoire(5, hero);
                    break;
                case "Chemin rapide mais risqué":
                    EvenementAleatoire(10, hero);
                    break;
                case "Explorer la forêt à l'aveugle":
                    EvenementAleatoire(19, hero);
                    break;
                default:
                    break;
            }
        }

        private void EvenementAleatoire(int chance, Hero hero)
        {
            Random random = new Random();
            int aleatoire = random.Next(1, 20);
            if (aleatoire <= chance)
            {
                CombatForet(hero);
            }
        }

        private void CombatForet(Hero hero)
        {
            Loup loup = new Loup("Loup", 10, 3);
            Console.Clear();
            AnsiConsole.Write(new FigletText("Foret").LeftJustified().Color(Color.Green));
            AnsiConsole.WriteLine("=== Combat ===\n");
            AnsiConsole.WriteLine($"Vous êtes attaqué par un {loup.NomEnnemi}!");
            AnsiConsole.WriteLine($"PV: {loup.PointsDeVie}, ATQ: {loup.NbDesAttaque}");
            loup.PredictionCombat(loup, hero);

            // Si GameOver est true, alors on arrête le combat.
            if (MenuHistoire.GameOver())
            {
                return;
            }

            AnsiConsole.WriteLine($"[red] Le {loup.NomEnnemi} vous attaque [/]");
            int degats = loup.Attaquer();
            hero.SubirDegats(degats);
            if (hero.PointsDeVie > 0)
            {
                AnsiConsole.WriteLine($"[green] Vous attaquez le {loup.NomEnnemi} [/]");
                degats = hero.Attaquer();
                loup.SubirDegats(degats);

                if (loup.PointsDeVie <= 0)
                {
                    AnsiConsole.WriteLine($"[red] Vous avez vaincu le {loup.NomEnnemi} [/]");
                    AnsiConsole.WriteLine("Vous avez gagné le combat.");
                    hero.PointsDeVie += 5;
                    AnsiConsole.WriteLine(
                        $"Vous avez récupéré 5 points de vie. PV: {hero.PointsDeVie}"
                    );
                }
                else
                {
                    AnsiConsole.WriteLine("[yellow]Le combat continue...[/]");
                    Thread.Sleep(1000);
                    CombatForet(hero);
                }
            }
            else
            {
                AnsiConsole.WriteLine("[red]Vous avez été vaincu. [/]");
                Thread.Sleep(1000);
                MenuHistoire.GameOver();
            }
        }
    }
}
