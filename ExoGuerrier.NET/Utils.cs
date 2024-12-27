namespace ExoGuerrier.NET
{
    public static class Utils
    {
        public static void InterditSaisie()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous n'êtes pas autorisé à effectuer cette action.");
            Console.ResetColor();
        }

        public static void AfficherListeHeros(List<Hero> listHeros)
        {
            Console.Clear();
            Console.WriteLine("=== Afficher tous les guerriers ===");
            foreach (Hero hero in listHeros)
            {
                Console.WriteLine(hero.GetNom());
            }
            Console.Write("Appuyez sur n'importe quelle touche pour retourner au menu : ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
