/// ETML
/// Auteur : David Dieperink
/// Date : 27.08.2021
/// Description : Projet DEV -> Classe pour la page About

using System;

namespace Space_Invaders
{
    /// <summary>
    /// Classe pour la page About
    /// </summary>
    class About
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

        #endregion

        /// <summary>
        /// Méthode pour écrire le contenu de la page About
        /// </summary>
        public static void AboutText()
        {
            #region[AboutText code]
            // Appel de la méthode ClearMenuAll pour clear toute la page
            ClearPages.ClearScreen();

            // Ecriture du titre de la page + son contenu
            Title.WriteAboutTitle();
            WritePageAbout();

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
        /// Méthode pour écrire le contenu de la page A Propos
        /// </summary>
        public static void WritePageAbout()
        {
            #region[WritePageAbout code]
            // Constante qui contient le texte à afficher
            const string ABOUT = @"
                                    ╔═════════════════════════════════════════════════════════════════╗
                                    ║Nom :        Dieperink                                           ║
                                    ║Prénom :     David                                               ║
                                    ║Classe :     CID2a                                               ║
                                    ║Age :        18 ans                                              ║
                                    ║Formation :  CFC Informatique - 2021 / 2024                      ║
                                    ║Lieu :       ETML - Ecole Technique des Métiers de Lausanne      ║
                                    ║Date :       13.09.2021                                          ║
                                    ╠═════════════════════════════════════════════════════════════════╣
                                    ║Projet :     Le projet consiste à crée un Space Invaders à       ║
                                    ║             partir de rien. Le Space Invaders est un jeu        ║
                                    ║             d'arcade de l'époque, le but ici est de le          ║
                                    ║             recrée en C# en mode console.                       ║
                                    ╚═════════════════════════════════════════════════════════════════╝
            ";
            // Ecriture du texte en vert
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(ABOUT);
            Console.ForegroundColor = ConsoleColor.White;
            #endregion
        }
    }
}
