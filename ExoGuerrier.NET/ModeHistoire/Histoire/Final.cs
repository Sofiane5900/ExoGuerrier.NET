using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExoGuerrier.NET.Donjon;
using Spectre.Console;

namespace ExoGuerrier.NET.ModeHistoire.Histoire
{
    internal class Final
    {
        public void LancerFinal(Hero hero)
        {
            if (hero == null)
            {
                Console.Clear();
                AnsiConsole.MarkupLine("[red]Erreur : le héros n'a pas été crée.[/]");
                return;
            }

            Console.Clear();
            AnsiConsole.Write(new FigletText("Victoire").LeftJustified().Color(Color.Green));
            AnsiConsole.MarkupLine("=== Épilogue - La Fin de l'Aventure ===\n");
            Thread.Sleep(2000);

            AnsiConsole.MarkupLine(
                "[darkviolet]Le Seigneur Liche s'écroule dans un fracas retentissant,[/] son aura ténébreuse se dissipant comme un souffle de vent."
            );
            AnsiConsole.MarkupLine(
                "[yellow]L'obscurité de la crypte semble s'atténuer, remplacée par une lumière douce et apaisante.[/]"
            );
            Thread.Sleep(3000);

            AnsiConsole.MarkupLine(
                "[green]Vous ramassez un mystérieux artefact brillant[/], laissé derrière par le Seigneur Liche. Ce symbole de victoire vous accompagnera désormais."
            );
            AnsiConsole.MarkupLine(
                "[yellow]Vous quittez la crypte, épuisé mais triomphant, et retournez au village de Valombre.[/]"
            );

            AnsiConsole.MarkupLine(
                "[blue]Le Maire et les villageois vous accueillent en héros ![/]"
            );
            AnsiConsole.MarkupLine(
                $"[blue]Le Maire:[/] [italic]\"{hero.GetNom()}, vous avez sauvé Valombre ! Votre courage et votre détermination resteront gravés dans l'histoire.\"[/]"
            );
            AnsiConsole.MarkupLine(
                "[yellow]Une fête grandiose est organisée en votre honneur. Les villageois célèbrent la fin de la menace qui pesait sur eux.[/]"
            );

            AnsiConsole.MarkupLine(
                "[italic][green]Vous savez que cette victoire est une étape dans votre destinée.[/] Un monde plus vaste vous attend, rempli d'autres défis et d'aventures. Mais pour l'instant, vous savourez ce moment de paix et de reconnaissance.[/]"
            );

            AnsiConsole.MarkupLine(
                "[bold yellow]Félicitations, aventurier ! Vous avez triomphé du mal et restauré la paix à Valombre ![/]"
            );
            Thread.Sleep(5000);
        }
    }
}
