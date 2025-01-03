﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExoGuerrier.NET.Donjon;
using Spectre.Console;

namespace ExoGuerrier.NET.ModeHistoire
{
    internal class CombatHistoire
    {
        public CombatHistoire() { }

        public void Combat(Hero hero, Ennemi ennemi)
        {
            // Affichage de la prédiction avant le combat
            PredictionCombat(ennemi, hero);
            if (!MenuHistoire.isGameOver)
            {
                Console.Clear();
                AnsiConsole.Write(new FigletText("Combat").LeftJustified().Color(Color.Red));
                AnsiConsole.MarkupLine("=== Combat ===\n");
                AnsiConsole.MarkupLine(
                    $"Vous êtes attaqué par un [bold red]{ennemi.NomEnnemi}[/]!"
                );
                while (hero.PointsDeVie > 0 && ennemi.PointsDeVie > 0)
                {
                    AnsiConsole.MarkupLine(
                        $"[green]PV du héros :[/] {hero.PointsDeVie} | [red]PV de l'ennemi :[/] {ennemi.PointsDeVie}"
                    );
                    AnsiConsole.MarkupLine($"[navy]ATQ de l'ennemi :[/] {ennemi.NbDesAttaque}");

                    string choixCombat = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[bold green]Que voulez-vous faire ?[/]")
                            .AddChoices("Attaquer", "Utiliser une potion", "Fuir", "Défendre")
                    );

                    switch (choixCombat)
                    {
                        case "Attaquer":
                            int degats = hero.Attaquer(); // degats = la méthode Attaquer du héros
                            ennemi.SubirDegats(degats);
                            AnsiConsole.MarkupLine(
                                $"[bold green]Vous attaquez[/] {ennemi.NomEnnemi} et lui infligez [bold red]{degats}[/] points de dégâts."
                            );
                            break;

                        case "Utiliser une potion":
                            if (hero.Potions > 0)
                            {
                                hero.UtiliserPotions(); // Potion = +10 PV
                                AnsiConsole.MarkupLine(
                                    $"[bold plum2]Vous utilisez une potion et récupérez 10 points de vie (PV:{hero.PointsDeVie}), (Il vous reste {hero.Potions} potions)[/]"
                                );
                            }
                            else
                            {
                                AnsiConsole.MarkupLine(
                                    "[bold red]Vous n'avez plus de potions ![/]"
                                );
                            }
                            break;

                        case "Fuir":
                            AnsiConsole.MarkupLine(
                                "[bold yellow]Vous avez décidé de fuir le combat ![/]"
                            );
                            Thread.Sleep(1000);
                            MenuHistoire.GameOver(); // Appel à GameOver si on fuit
                            return;

                        case "Défendre":
                            AnsiConsole.MarkupLine(
                                "[bold blue]Vous vous préparez à défendre contre les attaques ennemies.[/]"
                            );
                            break;
                    }

                    int degatsEnnemi = ennemi.Attaquer(); // degatsEnnemi = la méthode Attaquer de l'ennemi
                    if (choixCombat == "Défendre")
                    {
                        degatsEnnemi = hero.Defendre(degatsEnnemi); // Defendre = (degatsEnnemi / 2)
                        AnsiConsole.MarkupLine(
                            $"[bold blue]Vous avez réduit les dégâts à [bold red]{degatsEnnemi}[/] grâce à votre défense.[/]"
                        );
                    }

                    hero.SubirDegats(degatsEnnemi);

                    //  Si l'ennemi et l'héro sont mort
                    if (hero.PointsDeVie <= 0 && ennemi.PointsDeVie <= 0)
                    {
                        MenuHistoire.GameOver();
                    }
                    else if (ennemi.PointsDeVie <= 0)
                    {
                        AnsiConsole.MarkupLine(
                            $"[bold green][underline]Vous avez vaincu le {ennemi.NomEnnemi} ![/][/]"
                        );
                        hero.PointsDeVie += 5;
                        AnsiConsole.MarkupLine(
                            $"[plum2]Vous avez récupéré 5 points de vie. PV du héros : {hero.PointsDeVie}[/]"
                        );
                    }
                    // Si le héros meurt
                    else if (hero.PointsDeVie <= 0)
                    {
                        AnsiConsole.MarkupLine("[bold red]Vous avez été vaincu.[/]");
                        Thread.Sleep(1000);
                        MenuHistoire.GameOver();
                    }

                    Thread.Sleep(2000); // Petite pause avant de continuer
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
                "[italic]Préparez-vous... Le combat ne dépend pas que des chiffres, mais aussi de votre stratégie et de votre bravoure ![/]\n"
            );

            string choixPrediction = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold green]Que choisisez vous ?[/]\n")
                    .AddChoices("Combattre", "Fuir")
            );

            switch (choixPrediction)
            {
                case "Combattre":
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

        public void EvenementAleatoire(int chance, Hero hero, Ennemi ennemi)
        {
            Random random = new Random();
            int resultat = random.Next(1, 21); // Dés de 1 à 20
            if (resultat <= chance)
            {
                Combat(hero, ennemi);
            }
        }
    }
}
