using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ExoGuerrier.NET
{
    public class Sauvegarde
    {
        string path;
        string filePath;

        public Sauvegarde()
        {
            // Je précise ce qu'est mon dossier
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // Je précise ou mon fichier derva étre ecrit
            filePath = Path.Combine(path, "saveGuerriers.txt");
        }

        // Méthode qui prend en paramétre ma liste de guerriers
        public void SauvegarderGuerriers(List<Guerrier> listGuerriers)
        {
            // Je Serialize ma listGuerriers en format .json
            string jsonString = JsonSerializer.Serialize(listGuerriers);
            // Je crée un noueau fichier, qui écrit tout ce qu'il y a dans ma listGuerriers
            File.WriteAllText(filePath, jsonString);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Liste des guerriers sauvegardée avec succès !");
            Console.ResetColor();
        }

        public void ChargerGuerriers(out List<Guerrier> listGuerriers)
        {
            if (File.Exists(filePath))
            {
                // Je lis tout ce qu'il y a dans mon fichier
                string jsonString = File.ReadAllText(filePath);
                // Ma liste des guerriers est deserialize pour étre passé en tant qu'objet et non .json
                listGuerriers = JsonSerializer.Deserialize<List<Guerrier>>(jsonString);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Liste des guerriers chargée avec succès !");
                Console.ResetColor();
            }
            else
            {
                // Si il n'y a pas de guerriers, alors je crée une nouvelle liste de guerrier (pour que le programme puisse fonctionner)
                listGuerriers = new List<Guerrier>();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aucune sauvegarde trouvée.");
                Console.ResetColor();
            }
        }
    }
}
