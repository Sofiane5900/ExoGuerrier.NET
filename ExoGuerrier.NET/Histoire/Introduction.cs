using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace ExoGuerrier.NET.Histoire
{
    internal class Introduction
    {
        private string nomHero;
        public string NomHero { get => nomHero; set => nomHero = value; }
        public Introduction() {
            this.nomHero = string.Empty;
        }


        public void ChoisirNomHero()
        {
            Console.Clear();
            while (true) {
                AnsiConsole.Write(
                        new FigletText("Prologue").LeftJustified().Color(Color.Red)
                    );
            AnsiConsole.WriteLine("=== Création du personnage ===\n");
            AnsiConsole.Write("Quel est votre nom, aventurier ? : ");
            string nomHero = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nomHero))
            {
                    AnsiConsole.WriteLine("Vous devez entrer un nom pour continuer.");
                   
            }
            else
            {
                    AnsiConsole.WriteLine($"Bienvenue, {nomHero} !");
                    NomHero = nomHero;
                    Thread.Sleep(2000);
                    break;
                }
            
        }
        }

        public void LancerPrologue()
        {
            Console.Clear();
            AnsiConsole.Write(
                    new FigletText("Prologue").LeftJustified().Color(Color.Red)
                );
            AnsiConsole.WriteLine("=== Prologue - Le début de l'aventure ===\n");
            // Description du village
            AnsiConsole.MarkupLine("[yellow]Vous vous tenez dans le petit village de Valombre.[/] Les maisons en pierre sont anciennes, et l'air frais du matin vous donne une sensation de calme.");
            AnsiConsole.MarkupLine("[yellow]La place du village est animée par quelques marchands et villageois,[/] mais quelque chose ne va pas. Les murmures se propagent parmi les habitants.");
            AnsiConsole.MarkupLine("\nUne rumeur court : [red]des créatures mystérieuses ont été aperçues[/] près de la forêt voisine, et un mal ancien semble renaître...");

            // Appel du maire
            AnsiConsole.MarkupLine("\n[white]Le chef du village, un vieil homme appelé [blue]Le Maire[/],[/] vous appelle.");
            AnsiConsole.MarkupLine($"[blue]Le Maire :[/] \"{NomHero}, nous avons besoin de vous. Notre village est en danger. Les créatures des ténèbres se rassemblent à la Crypte Obscure, à l'est. Seul un courageux aventurier comme vous peut espérer stopper cette menace.\"");
        }
    }
}
