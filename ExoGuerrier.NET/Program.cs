using ExoGuerrier.NET;

Guerrier galahad = new Guerrier("Galahad", 30, 4);
Guerrier lancelot = new Guerrier("Lancelot", 35, 3);

galahad.Attaquer();
lancelot.SubirDegats();
lancelot.AfficherInfos();
Console.WriteLine(" ");
galahad.AfficherInfos();
