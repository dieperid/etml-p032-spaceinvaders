/// ETML
/// Auteur : David Dieperink
/// Date : 27.08.2021
/// Description : Projet DEV -> Class GameBoard qui génére le jeu avec les paramètres reçu

using Space_Invaders.GameObjects;
using System;
using System.Collections.Generic;

namespace Space_Invaders
{
    /// <summary>
    /// Class GameBoard
    /// </summary>
    public class GameBoard
    {
        #region[Déclaration des variables]
        /// <summary>
        /// Variable pour la position x de l'écriture du score du joueur
        /// </summary>
        private const int _POS_X_WRITE_SCORE = 10;
        /// <summary>
        /// Variable pour la position x de l'écriture du nombre d'invader échappé
        /// </summary>
        private const int _POS_X_WRITE_ESCAPED_INVADERS = 70;
        /// <summary>
        /// Variable pour la position x de l'écriture du nombre de vie du HERO
        /// </summary>
        private const int _POS_X_WRITE_HERO_LIFE = 45;

        #endregion

        /// <summary>
        /// Méthode SetBoardSize pour définir la taille de la console
        /// </summary>
        /// <param name="width">largeur</param>
        /// <param name="height">hauteur</param>
        public void SetBoardSize(int width, int height)
        {
            #region[SetBoardSize code]
            // Set la taille de la console
            Console.SetWindowSize(width, height);
            #endregion
        }

        /// <summary>
        /// Méthode RenderHero pour l'emplacement du hero
        /// </summary>
        /// <param name="hero">Variable hero qui contient l'objet Hero</param>
        public void RenderHero(Hero hero)
        {
            #region[RenderHero code]
            // Couleur de l'écriture en vert
            Console.ForegroundColor = ConsoleColor.Blue;

            // Si la position du hero < 2
            if (hero.PositionX < 2)
            {
                hero.PositionX = 2;
            }
            // Si la posotion du hero + sa taille > la taille de la console - 2
            else if (hero.PositionX + hero.Symbol.Length > Program.WINDOW_WIDTH - 42)
            {
                hero.PositionX = Program.WINDOW_WIDTH - 42;
            }
            // Ecriture du hero à la position donnée
            Console.SetCursorPosition(hero.PositionX, hero.PositionY);
            Console.Write(hero.Symbol);
            // Reset la couleur d'écriture
            Console.ResetColor();
            #endregion
        }

        /// <summary>
        /// Méthode RenderInvaders qui check la position des invaders
        /// </summary>
        /// <param name="invaders">Variable invaders qui est une instance de la list d'invader</param>
        public void RenderInvaders(List<Invader> invaders)
        {
            #region[RenderInvaders code]
            // Couleur de l'écriture en rouge
            Console.ForegroundColor = ConsoleColor.Red;
            
            // Si l'invaders est différent de null
            if (invaders != null)
            {
                // Boucle foreach pour récupérer l'invader dans la list d'invaders
                foreach (var invader in invaders)
                {
                    // Si l'invader atteint la position 30 en Y
                    if (invader.PositionY == 30)
                    {
                        // Appel de la méthode RemoveOutOfBoundInvader qui retire l'invader
                        RemoveOutOfBoundInvader(invader);
                    }
                    // Sinon
                    else
                    {
                        // Ecriture de l'invader à la position donnée
                        Console.SetCursorPosition(invader.PositionX, invader.PositionY);
                        Console.Write(invader.Symbol);
                    }
                }
            }
            // Reset la couleur d'écriture
            Console.ResetColor();
            #endregion
        }

        /// <summary>
        /// Méthode RenderBullets qui check la position des bullets
        /// </summary>
        /// <param name="bullets">Variable bullets qui est une instance de la list de Bullet</param>
        public void RenderBullets(List<Bullet> bullets)
        {
            #region[RenderBullets code]
            // Si la bullet est différente de null
            if (bullets != null)
            {
                // Boucle foreach pour récupérer la bullet dans la list de bullets
                foreach (var bullet in bullets)
                {
                    // Si la bullet atteint la position 0 en Y
                    if (bullet.PositionY == 0)
                    {
                        // Appel de la méthode RemoveOutOfBoundBullet qui retire la bullet
                        RemoveOutOfBoundBullet(bullet);
                    }
                    // Sinon
                    else
                    {
                        // Ecriture de la bullet à la position donnée
                        Console.SetCursorPosition(bullet.PositionX, bullet.PositionY);
                        Console.Write(bullet.Symbol);

                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Méthode RenderWalls qui affiche des walls en console
        /// </summary>
        /// <param name="walls">Variables walls qui est une instance de la list de Wall</param>
        public void RenderWalls(List<Wall> walls)
        {
            #region[RenderWalls code]
            // Boucle foreach qui récupère chaque mur dans la list de walls
            foreach (var wall in walls)
            {
                // Si le mur a 3 vie
                if(wall.LifeWall == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                // Si le mur a 2 vie
                if (wall.LifeWall == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                // Si le mur a 1 vie
                if (wall.LifeWall == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }

                // Ecriture du mur dans la console
                Console.SetCursorPosition(wall.PositionX, wall.PositionY);
                Console.Write(wall.Symbol);
                Console.ResetColor();
            }
            #endregion
        }

        /// <summary>
        /// Méthode RemoveOutOfBoundBullet qui retire la bullet
        /// </summary>
        /// <param name="bullet">Variable bullet qui est une instance de la class Bullet</param>
        private void RemoveOutOfBoundBullet(Bullet bullet)
        {
            #region[RemoveOutOfBoundBullet code]
            // Si la bullet est différente de null
            if (bullet != null)
            {
                // Ecriture d'un espace à la position de la bullet
                Console.SetCursorPosition(bullet.PositionX, bullet.PositionY);
                Console.Write(' ');
            }
            #endregion
        }

        /// <summary>
        /// Méthode RemoveOutOfBoundInvader qui retire l'invader
        /// </summary>
        /// <param name="invader">Variable invader qui est une instance de la class Invader</param>
        private void RemoveOutOfBoundInvader(Invader invader)
        {
            #region[RemoveOutOfBoundInvader code]
            // Si l'invader est différent de null
            if (invader != null)
            {
                // Ecriture d'un espace à la position de l'invader
                Console.SetCursorPosition(invader.PositionX, invader.PositionY);
                Console.Write(' ');
            }
            #endregion
        }

        /// <summary>
        /// Méthode DisplayGameScore qui affiche le score du joueur
        /// </summary>
        /// <param name="gameScore">Variable qui contient le score</param>
        public void DisplayGameScore(int gameScore)
        {
            #region[DisplayGameScore code]
            Console.SetCursorPosition(_POS_X_WRITE_SCORE, 32);
            Console.Write("Game Score : ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(gameScore);
            Console.ResetColor();
            #endregion
        }

        /// <summary>
        /// Méthode DisplayEscapedInvaderCount qui affiche le nombre d'invader échappé
        /// </summary>
        /// <param name="escapedInvadersCount">Variable qui contient le nombre d'invaders échappé</param>
        public void DisplayEscapedInvaderCount(int escapedInvadersCount)
        {
            #region[DisplayEscapedInvaderCount code]
            Console.SetCursorPosition(_POS_X_WRITE_ESCAPED_INVADERS, 32);
            Console.Write(String.Format("Escaped Invaders : {0}", escapedInvadersCount));
            #endregion
        }

        /// <summary>
        /// Méthode DisplayHeroLife qui affiche le nombre de vie du Hero
        /// </summary>
        /// <param name="heroLife">Variable qui contient le nombre de vie</param>
        public void DisplayHeroLife(int heroLife)
        {
            #region[DisplayHeroLife code]
            Console.SetCursorPosition(_POS_X_WRITE_HERO_LIFE, 32);
            Console.Write("Hero Life : ");
            Console.ForegroundColor = ConsoleColor.Red;
            for(byte x = 0; x < heroLife; x++)
            {
                Console.Write("♥");
            }
            Console.ResetColor();
            #endregion
        }

        /// <summary>
        /// Méthode HideCursor qui cache le curseur
        /// </summary>
        public void HideCursor()
        {
            #region[HideCursor code]
            Console.CursorVisible = false;
            #endregion
        }
    }
}