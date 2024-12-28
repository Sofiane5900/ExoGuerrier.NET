using Spectre.Console;

namespace ExoGuerrier.NET
{
    internal class Utils
    {
        private Sauvegarde sauvegarde;

        public Sauvegarde Sauvegarde { get => sauvegarde; set => sauvegarde = value; }

        

        public Utils(Sauvegarde sauvegarde)
        {
            this.sauvegarde = sauvegarde;

        }
        public static void InterditSaisie()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous n'êtes pas autorisé à effectuer cette action.");
            Console.ResetColor();
        }

        public static void AfficherListeHeros(List<Hero> listHeros, Sauvegarde sauvegarde)
        {
            Console.Clear();
            AnsiConsole.Write(
                new FigletText("Mes heros").LeftJustified().Color(Color.Red)
            );
            Console.WriteLine("=== Menu Heros ===");
            // Pour chaque hero dans ma liste de heros, j'affiche le nom
            foreach (Hero hero in listHeros)
            {
                Console.WriteLine(hero.GetNom());
            }
            
            Console.Write("Voulez-vous supprimer un hero ? (o/n) : ");
            string choixTournoi = Console.ReadLine().ToLower();
            if (choixTournoi == "o")
            {
                SupprimerHero(listHeros, sauvegarde);
            }
            else
            {
                Console.Clear();
            }
        }

        public static void SupprimerHero(List<Hero> listHeros, Sauvegarde sauvegarde)
        {
            Console.Clear();
            var choixSupprimer = AnsiConsole.Prompt(
                new SelectionPrompt<String>()
                .Title("Selectionnez les heros a [red]supprimer[/]")
                .PageSize(10)
                .MoreChoicesText("[blue](Utilisez les fléches pour voir plus de hero)[/]")
                .AddChoices(listHeros.Select(hero => hero.GetNom()).ToArray())
            );

            foreach (char hero in choixSupprimer)
            {
                var heroToRemove = listHeros.FirstOrDefault(h => h.GetNom() == choixSupprimer);
                if (heroToRemove != null)
                {
                    listHeros.Remove(heroToRemove);
                    AnsiConsole.MarkupLine($"[green]{choixSupprimer} a été supprimé.[/]");
                }
            }

            
            sauvegarde.SauvegarderHeros(listHeros);
        }
    }
}
