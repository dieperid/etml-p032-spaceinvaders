/// ETML
/// Auteur : David Dieperink
/// Date : 27.08.2021
/// Description : Projet DEV -> Class Game qui contient tout le fonctionnement du jeu

using System;
using System.Threading;

namespace Space_Invaders
{
    /// <summary>
    /// Class Game
    /// </summary>
    class Game
    {
        #region[Déclaration des variables]
        /// <summary>
        /// Booléan pour mettre à jour la taille de la console
        /// </summary>
        private static bool _setWindowSize = true;
        /// <summary>
        /// Booléan pour générer les invaders
        /// </summary>
        private static bool _boolGenerate = true;
        /// <summary>
        /// Variable qui prend une valeur sur la touche Escape est pressée
        /// </summary>
        public static bool IfEscapePressed = false;

        #endregion

        /// <summary>
        /// Méthode GameStart pour démarrer le jeu
        /// </summary>
        public static void GameStart()
        {
            #region[GameStart code]

            var gameState = new GameState();    // Création d'un instance de la class GameState
            _setWindowSize = true;

            while (true)
            {
                // Variable qui récupère le temp actuel
                var initialTimeStamp = DateTime.Now;

                // Variable qui récupère toute les updates faites lors de l'exécution du jeu
                var state = HandleFrame(gameState);

                // Check si la game est over
                if (state.CheckGameOver())
                {
                    _boolGenerate = true;
                    gameState.Invaders.Clear();
                    // Appel de la méthode RenderGameOverScreen pour afficher le text de fin de partie
                    RenderGameOverScreen(state);
                    // ReadKey pour lire la touche préssée
                    var key = Console.ReadKey(true).Key;

                    // Tant que c'est vrai
                    while (true)
                    {
                        // Si la touche Q ou Enter est préssée on break
                        if (key == ConsoleKey.Q || key == ConsoleKey.Enter)
                            break;
                        // Sinon
                        else
                            key = Console.ReadKey(true).Key;
                    }

                    // Si la touche préssée est Q
                    if (key == ConsoleKey.Q)
                    {
                        state._gameOverSound.Stop();
                        ClearPages.ClearScreenGameOver();
                        Program.Main();
                    }
                    // Si la touche préssée est Enter
                    else if (key == ConsoleKey.Enter)
                    {
                        state._gameOverSound.Stop();
                        // On réinitialise tous les compteur à 0, la position du Hero, les list de bullet et d'invader
                        _boolGenerate = true;
                        gameState.Invaders.Clear();
                        GameStart();
                    }

                }

                // Appel de la méthode Render avec le paramètre state
                Render(state);

                // La variable gameState prend la valeur de la variable state
                gameState = state;

                // Variable napTime pour la vitesse d'exécution du jeu
                int napTime = GetNapTime(initialTimeStamp);
                Thread.Sleep(napTime);
            }
            #endregion
        }

        /// <summary>
        /// Méthode HandleFrame de la class GameState qui récupère toutes les updates
        /// </summary>
        /// <param name="state">Variable state qui sert à envoyé les valeur à la class GameState</param>
        /// <returns>Retourne la variable state</returns>
        static GameState HandleFrame(GameState state)
        {
            #region[HandleFrame code]
            // Récupération des updates (touche préssée, position des bullet, position des invader)
            state.GetKeyPressed();
            state.UpdateBulletHeroLocation();
            state.UpdateInvaderLocation();
            state.UpdateBulletInvaderLocation();
            // Si le booléan _boolGenerateInvader est true
            if (_boolGenerate == true)
            {
                // Changement de sa valeur à false
                _boolGenerate = false;
                // Appel de la méthode GenerateInvader
                state.GenerateInvader();
                // Appel de la méthode GenerateWall
                state.GenerateWall();
            }
            // Retourne la variable state
            return state;
            #endregion
        }

        /// <summary>
        /// Méthode Render qui affiche les nouvelles valeurs en console
        /// </summary>
        /// <param name="state">Variable state qui sert à envoyé les valeur à la class GameState</param>
        static void Render(GameState state)
        {
            #region[Render code]
            // Variable board crée une instance de la class GameBoard
            var board = new GameBoard();

            // Si le booléan _setWindowSize est true
            if (_setWindowSize == true)
            {
                // Changement à false
                _setWindowSize = false;
                // Set la taille de la console
                board.SetBoardSize(Program.WINDOW_WIDTH - 40, 35);
            }
            // Appel de la méthode ClearScreenGame de la class ClearMenu pour clear l'écran de jeu
            ClearPages.ClearScreenGame();

            // Envoi au GameBoard les nouvelles valeurs des différentes méthodes
            board.RenderHero(state.Hero);
            board.RenderInvaders(state.Invaders);
            Console.ForegroundColor = ConsoleColor.Blue;
            board.RenderBullets(state.Bullets);
            Console.ForegroundColor = ConsoleColor.Red;
            board.RenderBullets(state.BulletsInvader);
            Console.ResetColor();
            board.RenderWalls(state.Walls);
            board.DisplayGameScore(state.GameScore);
            board.DisplayEscapedInvaderCount(state.EscapedInvaderCount);
            board.DisplayHeroLife(state.HeroLife);
            board.HideCursor();
            #endregion
        }

        /// <summary>
        /// Méthode GetNapTime qui sert à définir la vitesse du jeu
        /// </summary>
        /// <param name="initialTime">Variable initialTime qui récupère le temp actuel</param>
        /// <returns>Retourne la valeur de napTime</returns>
        static int GetNapTime(DateTime initialTime)
        {
            #region[GetNapTime code]
            var finalTimeStamp = DateTime.Now;                                      // Variable qui récupère le temp actuel
            var timeDifference = (finalTimeStamp - initialTime).TotalMilliseconds;  // Variable qui fait la différence de temp entre le temp actuel et le temp reçu
            int napTime = 0;                                                        // Variable qui défini le temp de différence

            // Si le temp de différence est en dessous de 33.3 secondes
            if (timeDifference < 33.3)
            {
                // napTime prend la valeur de 33.3 second - la valeur de timeDifference
                napTime = (int)(33.3 - timeDifference);
            }
            // Retourn la valeur de naptime
            return napTime > 0 ? napTime : 0;
            #endregion
        }

        /// <summary>
        /// Méthode RenderGameOverScreen qui sert à afficher l'écran de fin de partie
        /// </summary>
        /// <param name="state">Variable state qui sert à envoyé les valeur à la class GameState</param>
        static void RenderGameOverScreen(GameState state)
        {
            #region[RenderGameOverScreen code]

            // Clear de la console
            Console.Clear();

            // Ecriture du texte Game Over à la position donnée
            Console.SetCursorPosition(10, 4);
            Title.WriteGameOverTitle();
            // Ecriture du score du joueur à la position donnée
            Console.SetCursorPosition(15, 14);
            Console.Write(String.Format("Votre Score : {0}", state.GameScore));

            // Demande à l'utilisateur de rentrer son pseudo
            Console.SetCursorPosition(15, 16);
            Console.Write("Entrez votre pseudo : ");
            string pseudo = Convert.ToString(Console.ReadLine());
            MenuHighscore.Pseudo = pseudo.Trim();

            MenuHighscore.WriteFile(state);

            Thread.Sleep(500);
            // Demande à l'utiliseur si il veut rejouer
            Console.SetCursorPosition(15, 18);
            Console.Write("Appuyez sur la touche [Enter] si vous voulez rejouer.");
            Console.SetCursorPosition(15, 19);
            Console.Write("Appuyez sur la touche [Q] si vous voulez quitter le jeu.");

            #endregion
        }
    }
}