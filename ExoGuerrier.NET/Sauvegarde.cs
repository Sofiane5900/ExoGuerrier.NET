using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ExoGuerrier.NET
{
    public class Sauvegarde
    {
        private string _path;
        private string _filePath;

        public string Path
        {
            get => _path;
            set => _path = value;
        }
        public string FilePath
        {
            get => _filePath;
            set => _filePath = value;
        }

        public Sauvegarde()
        {
            // Je précise ce qu'est mon dossier
            Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // Je précise ou mon fichier derva étre ecrit
            FilePath = System.IO.Path.Combine(Path, "saveGuerriers.txt");
        }

        // Méthode qui prend en paramétre ma liste de guerriers
        public void SauvegarderGuerriers(List<Guerrier> listGuerriers)
        {
            // Je Serialize ma listGuerriers en format .json
            string jsonString = JsonSerializer.Serialize(listGuerriers);
            // Je crée un noueau fichier, qui écrit tout ce qu'il y a dans ma listGuerriers
            File.WriteAllText(FilePath, jsonString);
        }

        public void ChargerGuerriers(out List<Guerrier> listGuerriers)
        {
            // Si le fichier existe
            if (File.Exists(FilePath))
            {
                // Je lis tout ce qu'il y a dans mon fichier
                string jsonString = File.ReadAllText(FilePath);
                // Ma liste des guerriers est deserialize pour étre passé en tant qu'objet et non .json
                listGuerriers = JsonSerializer.Deserialize<List<Guerrier>>(jsonString);
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
