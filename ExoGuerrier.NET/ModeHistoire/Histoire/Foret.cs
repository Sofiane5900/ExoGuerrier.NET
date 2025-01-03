﻿using System;
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
        private Ennemi ennemi;
        private CombatHistoire combat;

        public Foret()
        {
            ennemi = new Ennemi("Loup", 10, 2);
            combat = new CombatHistoire();
        }

        public void LancerForet(Hero hero)
        {
            //TODO: Crée une methode pour verifier si le hero est null pour économiser des lignes de code
            if (hero == null)
            {
                Console.Clear();
                AnsiConsole.MarkupLine("[red]Erreur : le héros n'a pas été crée.[/]");
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
                    combat.EvenementAleatoire(5, hero, ennemi);
                    break;
                case "Chemin rapide mais risqué":
                    combat.EvenementAleatoire(10, hero, ennemi);
                    break;
                case "Explorer la forêt à l'aveugle":
                    combat.EvenementAleatoire(20, hero, ennemi);
                    break;
                default:
                    break;
            }

            // ** Il ce passe surement un combat vers ici dans le code en fonction de l'evenement aleatoire ** //

            // Donc avant d'afficher le message suivant, on vérifie si le jeu est GameOver
            if (!MenuHistoire.isGameOver)
            {
                Console.Clear();
                AnsiConsole.MarkupLine(
                    "[italic darkcyan]Vous continuez votre chemin à travers la forêt...[/]"
                );
                Thread.Sleep(2000);
            }
        }
    }
}
