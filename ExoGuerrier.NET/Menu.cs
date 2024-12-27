using System.Text.Json;
using Spectre.Console;

namespace ExoGuerrier.NET
{
    public class Menu
    {
        private List<Hero> listHeros;
        private Sauvegarde sauvegarde;
        private Creation creation;

        public Menu(List<Hero> listHeros, Sauvegarde sauvegarde, Creation creation)
        {
            this.listHeros = listHeros;
            this.sauvegarde = sauvegarde;
            this.creation = creation;
        }

        public void AfficherMenu()
        {
            
            while (true)
            {
                sauvegarde.ChargerHeros(out listHeros);
                AnsiConsole.Write(
                    new FigletText("Donjon & Heros").LeftJustified().Color(Color.Red)
                );
                var affichageMenu = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("=== Menu ===")
                        .PageSize(5)
                        .AddChoices(
                            new[]
                            {
                                "Ajouter un hero",
                                "Afficher tous les heros",
                                "Lancer un tournoi",
                                "Entrez dans le mode donjon",
                                "Quitter",
                            }
                        )
                );

                int choixMenu = affichageMenu switch
                {
                    "Ajouter un hero" => 1,
                    "Afficher tous les heros" => 2,
                    "Lancer un tournoi" => 3,
                    "Entrez dans le mode donjon" => 4,
                    "Quitter" => 0,
                    _ => -1,
                };

                switch (choixMenu)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        creation.AjoutHero();
                        sauvegarde.SauvegarderHeros(listHeros);
                        break;
                    case 2:
                        Utils.AfficherListeHeros(listHeros, sauvegarde);
                        break;
                    case 3:
                        Console.Clear();
                        LancerTournoi();
                        break;
                    case 4:
                        //Hero heroDonjon = ExoGuerrier.NET.Donjon.Creation.CreerHero();
                        break;
                    default:
                        Utils.InterditSaisie();
                        break;
                }
            }
        }
     
        private void LancerTournoi()
        {
            Console.Clear();
            Console.WriteLine("=== Lancer un tournoi ===");

            if (listHeros.Count < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Il faut au moins deux heros pour lancer un tournoi.");
                Console.ResetColor();
                Console.Write("Appuyez sur n'importe quelle touche pour retourner au menu : ");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            // Création d'une liste de participants en clonant les heros originaux
            List<Hero> participants = new List<Hero>();
            foreach (Hero hero in listHeros)
            {
                participants.Add((Hero)hero.Clone());
            }

            Random randomHero = new Random();

            while (participants.Count > 1)
            {
                int index1 = randomHero.Next(participants.Count);
                Hero hero1 = participants[index1];
                participants.RemoveAt(index1);

                int index2 = randomHero.Next(participants.Count);
                Hero hero2 = participants[index2];
                participants.RemoveAt(index2);

                Console.WriteLine($"Combat entre {hero1.GetNom()} et {hero2.GetNom()}");

                Thread.Sleep(1000);

                Hero gagnant = Hero.Duel(hero1, hero2);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Le gagnant du duel est {gagnant.GetNom()}\n");
                Console.ResetColor();

                participants.Add(gagnant);
            }

            Hero champion = participants[0];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Le champion du tournoi est {champion.GetNom()} !");
            Console.ResetColor();

            Console.Write("Voulez-vous lancer un autre tournoi ? (o/n) : ");
            string choixTournoi = Console.ReadLine().ToLower();
            if (choixTournoi == "o")
            {
                LancerTournoi();
            }
            else
            {
                Console.Clear();
            }
        }
    }
}
