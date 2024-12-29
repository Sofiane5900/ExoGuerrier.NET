using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExoGuerrier.NET;
using ExoGuerrier.NET.ModeHistoire.Histoire;
using Spectre.Console;

namespace ExoGuerrier.NET.Donjon
{
    internal class Ennemi
    {
        private string _nomEnnemi;
        private int _pointsDeVie;
        private int _nbDesAttaque;

        public string NomEnnemi
        {
            get => _nomEnnemi;
            set => _nomEnnemi = value;
        }
        public int PointsDeVie
        {
            get => _pointsDeVie;
            set => _pointsDeVie = value;
        }
        public int NbDesAttaque
        {
            get => _nbDesAttaque;
            set => _nbDesAttaque = value;
        }

        public Ennemi(string nomEnnemi, int pointsDeVie, int nbDesAttaque)
        {
            this.NomEnnemi = nomEnnemi;
            this.PointsDeVie = pointsDeVie;
            this.NbDesAttaque = nbDesAttaque;
        }

        public int Attaquer()
        {
            Random random = new Random();
            int degats = 0;
            for (int i = 0; i < NbDesAttaque; i++)
            {
                degats += random.Next(1, 7); // Dés de 1 à 6
            }
            return degats;
        }

        public void SubirDegats(int degats)
        {
            PointsDeVie -= degats;
            if (PointsDeVie < 0)
            {
                PointsDeVie = 0;
            }
            Console.WriteLine(
                $"{NomEnnemi} a subi {degats} dégâts, il lui reste {PointsDeVie} PV."
            );
            if (PointsDeVie == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{NomEnnemi} est mort.");
                Console.ResetColor();
            }
        }

        public void Combat(Hero hero, Ennemi ennemi)
        {
            PredictionCombat(ennemi, hero);
            Console.Clear();
            AnsiConsole.Write(new FigletText("Combat").LeftJustified().Color(Color.Red));
            AnsiConsole.WriteLine("=== Combat ===\n");
            AnsiConsole.WriteLine($"Vous êtes attaqué par un {NomEnnemi}!");
            AnsiConsole.WriteLine($"PV: {PointsDeVie}, ATQ: {NbDesAttaque}");
            while (hero.PointsDeVie > 0 && PointsDeVie > 0)
            {
                int degats = Attaquer();
                hero.SubirDegats(degats);
                if (hero.PointsDeVie > 0)
                {
                    degats = hero.Attaquer();
                    SubirDegats(degats);
                    if (PointsDeVie <= 0)
                    {
                        AnsiConsole.WriteLine($"[red][green]Vous avez vaincu le[/]{NomEnnemi}[/]");
                        hero.PointsDeVie += 5;
                        AnsiConsole.WriteLine(
                            $"Vous avez récupéré 5 points de vie. PV: {hero.PointsDeVie}"
                        );
                    }
                    else
                    {
                        AnsiConsole.WriteLine("[yellow]Le combat continue...[/]");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    AnsiConsole.WriteLine("[red]Vous avez été vaincu.[/]");
                    Thread.Sleep(1000);
                    MenuHistoire.GameOver();
                }
            }
        }

        public void PredictionCombat(Ennemi ennemi, Hero hero)
        {
            Console.Clear();
            AnsiConsole.Write(new FigletText("Prediction").LeftJustified().Color(Color.Yellow));
            AnsiConsole.MarkupLine("=== Prédiction de Combat ===\n");

            AnsiConsole.MarkupLine(
                $"[bold green]{hero.GetNom()}[/] contre [bold red]{ennemi.NomEnnemi}[/] !"
            );
            AnsiConsole.MarkupLine($"[green]Points de Vie du héros :[/] {hero.PointsDeVie}");
            AnsiConsole.MarkupLine($"[red]Points de Vie de l'ennemi :[/] {ennemi.PointsDeVie}\n");

            if (ennemi.PointsDeVie > hero.PointsDeVie)
            {
                AnsiConsole.MarkupLine(
                    $"[bold red]{ennemi.NomEnnemi} semble plus puissant que vous, votre entraînement et votre détermination pourraient bien faire la différence ![/]"
                );
            }
            else if (ennemi.PointsDeVie < hero.PointsDeVie)
            {
                AnsiConsole.MarkupLine(
                    $"[bold green]{hero.GetNom()} domine dans cette confrontation ! [/]"
                );
            }
            else
            {
                AnsiConsole.MarkupLine(
                    $"[bold yellow]Un combat équilibré s'annonce ! {hero.GetNom()} et {ennemi.NomEnnemi} semblent être de force égale. Tout dépendra de vos choix et de votre courage.[/]"
                );
            }

            AnsiConsole.MarkupLine(
                "\n[italic]Préparez-vous... Le combat ne dépend pas que des chiffres, mais aussi de votre stratégie et de votre bravoure ![/]"
            );

            string choixPrediction = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold green]Attaque[/]")
                    .AddChoices("Attaquer", "Fuir")
            );

            switch (choixPrediction)
            {
                case "Attaquer":
                    break;
                case "Fuir":
                    Console.Clear();
                    AnsiConsole.WriteLine("Vous avez fui le combat.");
                    Thread.Sleep(2000);
                    MenuHistoire.GameOver();
                    break;
                default:
                    break;
            }
        }
    }
}
