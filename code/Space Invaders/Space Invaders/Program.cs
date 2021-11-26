/// ETML
/// Auteur : David Dieperink
/// Date : 27.08.2021
/// Description : Projet DEV -> Faire un space invaders

using System;

namespace Space_Invaders
{
    /// <summary>
    /// Classe Program
    /// </summary>
    public class Program
    {
        #region[Déclaration des variables]
        /// <summary>
        /// Constante pour la largeur de la console
        /// </summary>
        public const int WINDOW_WIDTH = 140;
        /// <summary>
        /// Constante pour le hauteur de la console
        /// </summary>
        public const int WINDOW_HEIGHT = 30;

        #endregion

        /// <summary>
        /// Main du programme
        /// </summary>
        public static void Main()
        {
            #region[Main code]
            // Taille de la console
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);

            // Ecriture du titre à la position 0 et 0
            Console.SetCursorPosition(0, 0);
            Title.WriteHomeTitle();

            // Appel de la méthode MultipleChoice dans la classe MenuHome pour afficher le menu de départ
            int selectedClass = MenuHome.Menu("Jouer", "Options", "Highscore", "A propos", "Quitter");

            // En fonction de la position du curseur si la touche Enter est pressée on appel des choses différentes
            switch(selectedClass)
            {
                case 0:
                    Console.Clear();
                    Game.GameStart();
                    break;
                case 1:
                    MenuOptions.Menu("Son", "Difficulté", "Retour");
                    break;
                case 2:
                    MenuHighscore.HighscoreText();
                    break;
                case 3:
                    About.AboutText();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
            #endregion
        }
    }
}
