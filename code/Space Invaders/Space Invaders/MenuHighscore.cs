/// ETML
/// Auteur : David Dieperink
/// Date : 19.11.2021
/// Description : Projet DEV -> Classe pour la page Highscore

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Space_Invaders
{
    /// <summary>
    /// Classe pour la page Highscore
    /// </summary>
    class MenuHighscore
    {
        #region[Déclaration des variables]
        /// <summary>
        /// Variable _key pour la touche pressée
        /// </summary>
        private static ConsoleKey _key;
        /// <summary>
        /// Booléan si une touche est pressée
        /// </summary>
        private static bool _valid;
        /// <summary>
        /// variable _pathUser pour le chemin de l'utilisateur
        /// </summary>
        private static string _pathUser = @"%USERPROFILE%\Desktop\Score.txt";
        /// <summary>
        /// Variable _pathFile pour le chemin du fichier
        /// </summary>
        private static string _pathFile = Environment.ExpandEnvironmentVariables(_pathUser);
        /// <summary>
        /// Variable _pseudo pour le pseudo du joueur
        /// </summary>
        private static string _pseudo;
        /// <summary>
        /// Getter setter sur le pseudo du joueur
        /// </summary>
        public static string Pseudo
        {
            get { return _pseudo; }
            set { _pseudo = value; }
        }

        #endregion

        /// <summary>
        /// Méthode pour écrire le contenu de la page Highscore
        /// </summary>
        public static void HighscoreText()
        {
            #region[HighscoreText code]

            // Appel de la méthode ClearScreen pour clear toute la page
            ClearPages.ClearScreen();

            // Ecriture du titre de la page + son contenu
            Title.WriteHighscoreTitle();
            Console.ForegroundColor = ConsoleColor.Green;
            ReadFile();
            Console.ResetColor();

            // Read_key pour récupérer la touche pressée
            _key = Console.ReadKey(true).Key;

            do
            {
                // Switch pour les différentes touches appuyées
                switch (_key)
                {
                    // Touche Escape
                    case ConsoleKey.Escape:
                        ClearPages.ClearScreen();
                        _valid = true;
                        Program.Main();
                        break;
                }
                // Tant que le booléan "valid" est false
            } while (!_valid);

            #endregion
        }

        /// <summary>
        /// Méthode ReadFile qui lit le contenu du fichier et l'écrit en console
        /// </summary>
        public static void ReadFile()
        {
            #region[ReadFile code]

            int positionY = 15;     // Position y de départ pour l'affichage des scores

            // Si le fichier n'existe pas on le crée
            if (!File.Exists(_pathFile))
            {
                StreamWriter sw = File.CreateText(_pathFile);
                sw.Close();
            }
            else
            {
                // Leture du fichier texte
                using (StreamReader sr = new StreamReader(_pathFile))
                {
                    string line;    // Récupère la ligne lue

                    // Tant que la ligne contient une valeur
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Set la position du curseur et on écrit le contenu
                        Console.SetCursorPosition(15, positionY);
                        Console.WriteLine(line);

                        // Incrémentation de la position X
                        positionY++;
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// Méthode WriteFile qui écrit dans le fichier texte
        /// </summary>
        /// <param name="state">Paramètre reçu</param>
        public static void WriteFile(GameState state)
        {
            #region[WriteFile code]

            string textInFile = "";         // Contenu du fichier texte
            string[] arrayContent;          // Tableau qui récupère le contenu et le split
            string fileResult = "";         // Variable qui récupère le pseudo du joueur
            string lastScore = "";          // Variable qui récupère le dernier score du joueur
            string newFileContent = "";     // Variable qui récupère les nouvelles données à écrire
            string fileContent = "";        // Variable qui récupère les anciennes données

            // Si le fichier n'existe pas on le crée
            if (!File.Exists(_pathFile))
            {
                StreamWriter sw = File.CreateText(_pathFile);
                sw.Close();
            }
            // Boucle foreach pour lire tout le contenu du fichier texte et trouver un texte qui contient le pseudo du joueur
            foreach (var match in File.ReadLines(_pathFile).Select((text, index) => new { text, lineNumber = index + 1 }).Where(x => x.text.Contains(Pseudo)))
            {
                // Split des info récupérée dans le tableau
                arrayContent = match.text.Split(' ');

                // Si la case 0 du tableau correspond à un pseudo
                if (arrayContent[0] == Pseudo)
                {
                    fileResult = match.text;
                }
            }

            // Si la variable fileResult n'est pas vide
            if (fileResult != "")
            {
                // Recherche seuelement des nombre dans le contenu récupéré
                MatchCollection matches = Regex.Matches(fileResult, "[0-9]");
                foreach (Match match in matches)
                {
                    lastScore += match.Value;
                }

                // On converti l'ancien score
                fileContent = File.ReadAllText(_pathFile);

                // Si le score qu'il vient de faire est supérieur à l'ancien
                if (state.GameScore > Convert.ToInt32(lastScore))
                {
                    // On remplace son score dans la variable qui contient le contenu du fichier texte
                    newFileContent = fileContent.Replace(Pseudo + " \t:   " + lastScore, Pseudo + " \t:   " + state.GameScore);
                }

                // On écrit dans le fichier texte les nouvelles données
                using (FileStream fs = File.Create(_pathFile))
                {
                    Byte[] textToWrite = new UTF8Encoding(true).GetBytes(newFileContent);
                    fs.Write(textToWrite, 0, textToWrite.Length);
                }
            }
            // Sinon
            else
            {
                // On lit simplement le contenu
                textInFile = File.ReadAllText(_pathFile);

                // On écrit le contenu total
                using (FileStream fs = File.Create(_pathFile))
                {
                    Byte[] textToWrite = new UTF8Encoding(true).GetBytes(textInFile + "\n" + Pseudo + " \t:   " + state.GameScore);
                    fs.Write(textToWrite, 0, textToWrite.Length);
                }
            }

            #endregion
        }
    }
}
