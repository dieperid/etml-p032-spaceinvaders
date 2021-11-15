/// ETML
/// Auteur : David Dieperink
/// Date : 27.08.2021
/// Description : Projet DEV -> Menu d'affichage au lancement du programme

using System;

namespace Space_Invaders
{
    /// <summary>
    /// Classe pour le menu principal
    /// </summary>
    class MenuHome
    {
        #region[Déclaration des variables]
        /// <summary>
        /// Variable _key pour la touche pressée
        /// </summary>
        private static ConsoleKey _key;
        /// <summary>
        /// Variable _currentSelection pour le choix séléctionné
        /// </summary>
        private static int _currentSelection = 0;

        #endregion

        /// <summary>
        /// Méthode pour les paramètres du menu
        /// </summary>
        /// <param name="options">Options dans le tableau</param>
        /// <returns>On retourne la valeur séléctionnée</returns>
        public static int Menu(params string[] options)
        {
            #region[Menu code]
            int positionX = 0;                  // Position X du Menu
            int positionY = 0;                  // Position Y du Menu
            const int START_X = 35;             // Position X de départ
            const int START_Y = 15;             // Position Y de départ
            const int OPTIONS_PER_LINE = 5;     // Nombre d'options par lignes
            const int SPACING_PER_LINE = 14;    // Nombre d'espace entre chaque options

            // Curseur invisible
            Console.CursorVisible = false;

            do
            {
                // Boucle for pour l'écriture du Menu
                for (int i = 0; i < options.Length; i++)
                {
                    // On récupère la position X et Y des mots à écrire pour le menu
                    positionX = START_X + (i % OPTIONS_PER_LINE) * SPACING_PER_LINE;
                    positionY = START_Y + i / OPTIONS_PER_LINE;
                    Console.SetCursorPosition(positionX, positionY);

                    // Si i est égal à l'option qu'on séléctionne on met l'écriture en rouge
                    if (i == _currentSelection)
                        Console.ForegroundColor = ConsoleColor.Red;

                    // On écrit l'options et on reset la couleur
                    Console.Write(options[i]);
                    Console.ResetColor();
                }

                // ReadKey pour récupérer la touche pressée
                _key = Console.ReadKey(true).Key;

                // Switch pour les différentes touches appuyées
                switch (_key)
                {
                    // Flèche gauche
                    case ConsoleKey.LeftArrow:
                        {
                            if (_currentSelection % OPTIONS_PER_LINE > 0)
                                _currentSelection--;
                            break;
                        }
                    // Flèche droite
                    case ConsoleKey.RightArrow:
                        {
                            if (_currentSelection % OPTIONS_PER_LINE < OPTIONS_PER_LINE - 1)
                                _currentSelection++;
                            break;
                        }
                    // Touche Escape
                    case ConsoleKey.Escape:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            // Tant que la touche pressée n'est pas Enter
            } while (_key != ConsoleKey.Enter);

            // On retourne l'élément séléctionné
            return _currentSelection;
            #endregion
        }
    }
}
