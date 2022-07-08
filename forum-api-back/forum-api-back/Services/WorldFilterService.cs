using forum_api_back.Interfaces;

namespace forum_api_back.Services
{
    public class WorldFilterService : IWorldFilterService
    {
        public string[] banWords;

        public WorldFilterService()
        {         
            var contenuInsults = File.ReadLines(@"../../../../insults.txt");
            banWords = contenuInsults.ToArray();
        }

        public string ChangeInsultToStar(string text)
        {
            // Tester si "text" n'est pas null et pas vide ?
            if(text != null && text != "")
            {
                // Parcourir les mots du tableau banWord 
                foreach(var mot in banWords)
                {
                    // Si dans le text il contient un mot du tableau insulte
                    if (text.Contains(mot))
                    {
                        // Nouveau mot avec la première lettre du mot banni
                        var nouveauMot = "" + mot[0];
                        // À partir de la deuxième lettre jusqu'à l'avant dernière je remplace par une étoile
                        for(int i = 1; i < mot.Length - 1; i++)
                        {
                            nouveauMot += "*";
                        }
                        // Ajoute la dernière lettre du mot banni
                        nouveauMot += mot[mot.Length - 1];
                        // Je remplace le mot du text par le nouveau avec les étoiles
                        text = text.Replace(mot, nouveauMot);
                    }
                }
            }
            return text;
        }


    }
}
