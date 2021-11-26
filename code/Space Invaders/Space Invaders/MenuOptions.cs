/// ETML
/// Auteur : David Dieperink
/// Date : 27.08.2021
/// Description : Projet DEV -> Menu Options du programme

using System;

namespace Space_Invaders
{
    /// <summary>
    /// Classe pour le menu des options
    /// </summary>
    class MenuOptions
    {
        #region[Déclaration des variables]
        /// <summary>
        /// Booléan pour le son
        /// </summary>
        public static bool sound;
        /// <summary>
        /// Booléan pour la difficulté
        /// </summary>
        public static bool difficulty;
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
        /// Méthode pour les paramètres du menu options
        /// </summary>
        /// <param name="options">Options dans le tableau</param>
        /// <returns>On retourne la valeur séléctionnée</returns>
        public static int Menu(params string[] options)
        {
            #region[MultipleChoice code]
            bool showMenu = false;              // Booléan pour l'affichage du menu
            int positionX = 0;                  // Position X du Menu
            int positionY = 0;                  // Position Y du Menu
            const int START_X = 40;             // Position X de départ
            const int START_Y = 15;             // Position Y de départ
            const int OPTIONS_PER_LINE = 3;     // Nombre d'options par lignes
            const int SPACING_PER_LINE = 20;    // Nombre d'espace entre chaque options
            const string ON = "[ON] ";          // String pour le son ON
            const string OFF = "[OFF]";         // String pour le son OFF
            const string EASY = "[EASY]";       // String pour la difficulté EASY
            const string HARD = "[HARD]";       // String pour la difficulté EASY

            // Curseur invisible
            Console.CursorVisible = false;

            // Clear du Menu + Ecriture du Menu Options
            ClearPages.ClearScreen();
            Title.WriteOptionsTitle();

            do
            {
                // Condition pour le son
                if (sound == false)
                    options[0] = "Son" + OFF;
                else if(sound == true)
                    options[0] = "Son" + ON;
                // Condition pour la difficulté
                if (difficulty == false)
                    options[1] = "Difficulté" + EASY;
                else if (difficulty == true)
                    options[1] = "Difficulté" + HARD;

                // Boucle for pour l'écriture du Menu
                for (int i = 0; i < options.Length; i++)
                {
                    // On récupère la position X et Y des mots à écrire pour le menu
                    positionX = START_X + (i % OPTIONS_PER_LINE) * SPACING_PER_LINE;
                    positionY = START_Y + i / OPTIONS_PER_LINE;

                    // Si l'options a écrire est la 1 on réduit la position X de 4
                    if (i == 1)
                    {
                        Console.SetCursorPosition(positionX - 4, positionY);
                    }
                    else
                    {
                        Console.SetCursorPosition(positionX, positionY);
                    }

                    // Si i est égal à l'option qu'on séléctionne on met l'écriture en rouge
                    if (i == _currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    // On écrit l'options et on reset la couleur
                    Console.Write(options[i]);
                    Console.ResetColor();
                }

                // Read_key pour récupérer la touche pressée
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
                    // Touche Enter
                    case ConsoleKey.Enter:
                        {
                            // Si l'options choisie son index est 0 alors 
                            if (_currentSelection == 0)
                            {
                                if (sound == false)
                                {
                                    sound = true;
                                }
                                else
                                {
                                    sound = false;
                                }
                            }
                            // Si l'options choisie son index est 1 alors 
                            else if (_currentSelection == 1)
                            {
                                if (difficulty == false)
                                {
                                    difficulty = true;
                                }
                                else
                                {
                                    difficulty = false;
                                }
                            }
                            // Si l'options choisie son index est 2 alors 
                            else if (_currentSelection == 2)
                            {
                                ClearPages.ClearScreen();
                                showMenu = true;
                                Program.Main();
                            }
                            break;
                        }
                    // Touche Escape
                    case ConsoleKey.Escape:
                        {
                            ClearPages.ClearScreen();
                            showMenu = true;
                            Program.Main();
                            break;
                        }
                }
            // Tant que le booléan "_valid" est false
            } while (!showMenu);

            // On retourne l'élément séléctionné
            return _currentSelection;
            #endregion
        }
    }
}