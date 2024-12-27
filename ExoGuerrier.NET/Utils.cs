namespace ExoGuerrier.NET
{
    public static class Utils
    {
        public static void InterditSaisie()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous n'�tes pas autoris� � effectuer cette action.");
            Console.ResetColor();
        }

        public static void AfficherListeGuerriers(List<Guerrier> listGuerriers)
        {
            Console.Clear();
            Console.WriteLine("=== Afficher tous les guerriers ===");
            foreach (Guerrier guerrier in listGuerriers)
            {
                Console.WriteLine(guerrier.GetNom());
            }
            Console.Write("Appuyez sur n'importe quelle touche pour retourner au menu : ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}