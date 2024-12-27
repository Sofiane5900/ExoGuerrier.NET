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
        private List<Hero> listHeros;

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
        public List<Hero> ListHeros { get => listHeros; set => listHeros = value; }

        public Sauvegarde(List<Hero> listHeros)
        {
            // Je précise ce qu'est mon dossier
            Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // Je précise ou mon fichier derva étre ecrit
            FilePath = System.IO.Path.Combine(Path, "saveHeros.txt");
            this.ListHeros = listHeros;
        }

        // Méthode qui prend en paramétre ma liste de heros
        public void SauvegarderHeros(List<Hero> listHeros)
        {
            // Je Serialize ma listGuerriers en format .json
            string jsonString = JsonSerializer.Serialize(listHeros);
            // Je crée un noueau fichier, qui écrit tout ce qu'il y a dans ma listHeros
            File.WriteAllText(FilePath, jsonString);
        }

        public void ChargerHeros(out List<Hero> listHeros)
        {
            // Si le fichier existe
            try
            {
                // Je lis tout ce qu'il y a dans mon fichier
                string jsonString = File.ReadAllText(FilePath);
                // Ma liste des guerriers est deserialize pour étre passé en tant qu'objet et non .json
                listHeros = JsonSerializer.Deserialize<List<Hero>>(jsonString);
            }
            catch (Exception ex)
            {
                // Si il n'y a pas de guerriers, alors je crée une nouvelle liste de guerrier (pour que le programme puisse fonctionner)
                listHeros = new List<Hero>();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erreur lors de la sauvegarde : {ex.Message}");
                Console.ResetColor();

            }
        }
    }
}
