/// ETML
/// Auteur : David Dieperink
/// Date : 27.08.2021
/// Description : Projet DEV -> Classe pour clear les différents menus

using System;
using System.Threading;

namespace Space_Invaders
{
    /// <summary>
    /// Class ClearMenu
    /// </summary>
    class ClearPages
    {
        #region[Déclaration des variables]
        /// <summary>
        /// Position X pour le départ du clear
        /// </summary>
        private const int _CLEAR_X = 0;
        /// <summary>
        /// Nombre de ligne à clear
        /// </summary>
        private const int _NB_LINE_TO_CLEAR = 35;

        #endregion

        /// <summary>
        /// Méthode pour le clear de toutes les pages 
        /// </summary>
        public static void ClearScreen()
        {
            #region[ClearScreen code]
            int compteurClear = 0;      // Compteur pour la position Y du clear

            // Boucle for pour clear la page
            for (int i = 0; i < _NB_LINE_TO_CLEAR - 5; i++)
            {
                Console.SetCursorPosition(_CLEAR_X, compteurClear++);
                Console.Write(new string(' ', Console.WindowWidth));
                Thread.Sleep(5);
            }
            #endregion
        }

        /// <summary>
        /// Méthode pour le clear de l'écran de jeu
        /// </summary>
        public static void ClearScreenGame()
        {
            #region[ClearScreenGame code]
            int compteurClear = 0;      // Compteur pour la position Y du clear

            // Boucle for pour clear la page de jeu
            for (int i = 0; i < _NB_LINE_TO_CLEAR; i++)
            {
                Console.SetCursorPosition(_CLEAR_X, compteurClear++);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            #endregion
        }

        /// <summary>
        /// Méthode pour le clear de l'écran game over
        /// </summary>
        public static void ClearScreenGameOver()
        {
            #region[ClearScreenGameOver code]
            int compteurClear = 0;      // Compteur pour la position Y du clear

            // Boucle for pour clear la page de jeu
            for (int i = 0; i < _NB_LINE_TO_CLEAR; i++)
            {
                Console.SetCursorPosition(_CLEAR_X, compteurClear++);
                Console.Write(new string(' ', Console.WindowWidth));
                Thread.Sleep(5);
            }
            #endregion
        }
    }
}
