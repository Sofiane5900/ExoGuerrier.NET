using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace ExoGuerrier.NET
{
  
    public class Creation
    {
        private List<Hero> listHeros;
        private Sauvegarde sauvegarde;
        private Utils utils;

        public Creation(List<Hero> listHeros, Sauvegarde sauvegarde)
        {
            this.listHeros = listHeros;
            this.sauvegarde = sauvegarde;
        }
        public void AjoutHero()
        {
            Console.Clear();
            AnsiConsole.Write(
                new FigletText("Creation de Hero").LeftJustified().Color(Color.Red)
            );


            var choixAjoutMenu = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("=== Sélectionnez une [green]option[/] pour créer un personnage : ===")
                    .AddChoices("Hero", "Nain", "Elfe", "Retour")
            );

            switch (choixAjoutMenu)
            {
                case "Retour":
                    Console.Clear();
                    return;

                case "Hero":
                    AjouterPersonnage("Hero");
                    break;

                case "Nain":
                    AjouterPersonnage("Nain");
                    break;

                case "Elfe":
                    AjouterPersonnage("Elfe");
                    break;

                default:
                    Utils.InterditSaisie();
                    break;
            }
        }

        public void AjouterPersonnage(string classePersonnage)
        {
            Console.Clear();
            AnsiConsole.Write(
                new FigletText($"Creation de {classePersonnage}").LeftJustified().Color(Color.Red)
            );

            // Nom
            string nom = AnsiConsole.Ask<string>($"Quel est le [green]nom[/] de votre {classePersonnage} ?");
            if (string.IsNullOrWhiteSpace(nom))
            {
                Utils.InterditSaisie();
                return;
            }
            // PV
            int pv = AnsiConsole.Prompt(
                new TextPrompt<int>($"Combien de [red]points de vie[/] pour le {classePersonnage} ?")
                    .DefaultValue(30)
                    // Condition de validation est que value > 0, sinons erreur (opération ternaire)
                    .Validate(value => value > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Les points de vie doivent être supérieurs à 0.[/]"))
            );

            // Nombre ATQ
            int nbATQ = AnsiConsole.Prompt(
                new TextPrompt<int>($"Nombre d'[green]attaques[/] pour le {classePersonnage} ?")
                    .DefaultValue(5)
                    .Validate(value => value > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]Le nombre d'attaques doit être supérieur à 0.[/]"))
            );

            // Armure Lourde?
            bool porteArmure = false;
            if (classePersonnage == "Nain")
            {
                porteArmure = AnsiConsole.Confirm("Le Nain porte-t-il une [yellow]armure lourde[/] ?");
            }

            // Ajout du personnage a ma liste listHeros
            switch (classePersonnage)
            {
                case "Hero":
                    listHeros.Add(new Hero(nom, pv, nbATQ, false));
                    break;

                case "Nain":
                    listHeros.Add(new Nain(nom, pv, nbATQ, porteArmure));
                    break;

                case "Elfe":
                    listHeros.Add(new Elfe(nom, pv, nbATQ, false));
                    break;
            }

            // Confirmation
            
            Console.Clear();
            sauvegarde.SauvegarderHeros(listHeros);
            Utils.AfficherListeHeros(listHeros, sauvegarde);
            AnsiConsole.MarkupLine($"[green]{classePersonnage} {nom} ajouté avec succès ![/]");
            
        }
    }
}
