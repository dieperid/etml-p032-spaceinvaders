/// ETML
/// Auteur : David Dieperink
/// Date : 26.11.2021
/// Description : Projet DEV -> Class GameStateTests pour les tests unitaire de la class GameState

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Space_Invaders.GameObjects;
using System.Collections.Generic;

namespace Space_Invaders.Tests
{
    [TestClass()]
    public class GameStateTests
    {
        [TestMethod()]
        public void CheckGameOverHeroTest()
        {
            // Check si la game est over avec la vie du Hero à 0

            // Arrange
            GameState gamestate = new GameState();

            // Act
            for (byte i = 0; gamestate.HeroLife != 0; i++)
            {
                Bullet bullet = new Bullet(gamestate.Hero.PositionX, gamestate.Hero.PositionY);
                gamestate.CheckKillHero(bullet);
            }

            // Assert
            Assert.AreEqual(0, gamestate.HeroLife, "Le résultat doit être 0");
        }

        [TestMethod()]
        public void CheckGameOverInvadersTest()
        {
            // Check si la game est over avec la list d'invaders si sont .Count = 0

            // Arrange
            GameState gamestate = new GameState();

            // Act
            gamestate.GenerateInvader();

            for (int i = gamestate.Invaders.Count - 1; gamestate.Invaders.Count != 0; i--)
            {
                Bullet bullet = new Bullet(gamestate.Invaders[i].PositionX, gamestate.Invaders[i].PositionY);
                gamestate.CheckKillInvader(bullet);
            }

            // Assert
            Assert.AreEqual(0, gamestate.Invaders.Count, "Le résultat doit être 0");
        }

        [TestMethod()]
        public void CheckHeroLifeAtStartTest()
        {
            // Check si au lancement du jeu la vie de Hero est à 3

            // Arrange
            GameState gamestate = new GameState();

            // Act
            int heroLife = gamestate.Hero.LifeHero;

            // Assert
            Assert.AreEqual(3, heroLife, "Le résultat doit être 3");
        }

        [TestMethod()]
        public void CheckGenerateInvaderDifficultyEasyTest()
        {
            // Check si au lancement de la game la génération avec le bool pour la diffculté est Easy fonctionne

            // Arrange
            GameState gamestate = new GameState();
            MenuOptions.difficulty = false;

            // Act
            gamestate.GenerateInvader();

            // Assert
            Assert.AreEqual(14, gamestate.Invaders.Count, "Le résultat doit être 14");
        }

        [TestMethod()]
        public void CheckGenerateInvaderDifficultyHardTest()
        {
            // Check si au lancement de la game la génération avec le bool pour la diffculté est Hard fonctionne

            // Arrange
            GameState gamestate = new GameState();
            MenuOptions.difficulty = true;

            // Act
            gamestate.GenerateInvader();

            // Assert
            Assert.AreEqual(28, gamestate.Invaders.Count, "Le résultat doit être 28");
        }

        [TestMethod()]
        public void CheckGenerateWallTest()
        {
            // Check si au lancement de la game la génération des walls se fait correctement

            // Arrange
            GameState gamestate = new GameState();

            // Act
            gamestate.GenerateWall();

            // Assert
            Assert.AreEqual(50, gamestate.Walls.Count, "Le résultat doit être 50");
        }

        [TestMethod()]
        public void CheckLifeWallTest()
        {
            // Check si un wall perd de la vie 

            // Arrange
            GameState gamestate = new GameState();

            // Act
            gamestate.GenerateWall();
            int numberLifeAfterShoot = gamestate.Walls[0].LifeWall - 1;

            while (gamestate.Walls[0].LifeWall != numberLifeAfterShoot)
            {
                Bullet bullet = new Bullet(gamestate.Walls[0].PositionX - 2, gamestate.Walls[0].PositionY);
                gamestate.CheckShootWall(bullet);
            }

            // Assert
            Assert.AreEqual(2, numberLifeAfterShoot, "Le résultat doit être 2");
        }

        [TestMethod()]
        public void CheckRemoveWallTest()
        {
            // Check si un wall est supprimé de la list une fois qu'il n'a plus de vie

            // Arrange
            GameState gamestate = new GameState();

            // Act
            gamestate.GenerateWall();
            int numberWalls = gamestate.Walls.Count - 1;

            while(gamestate.Walls.Count != numberWalls)
            {
                Bullet bullet = new Bullet(gamestate.Walls[0].PositionX - 2, gamestate.Walls[0].PositionY);
                gamestate.CheckShootWall(bullet);
            }

            // Assert
            Assert.AreEqual(49, numberWalls, "Le résultat doit être 49");
        }

        [TestMethod()]
        public void UpdateInvaderLocationTest()
        {
            // Check de l'update des Invaders avec leurs anciennes positions et les actuelles

            // Arrange
            GameState gamestate = new GameState();
            MenuOptions.difficulty = false;
            gamestate.GenerateInvader();
            List<int> expectedPosition = new List<int>();
            List<int> actualPosition = new List<int>();
            bool verifVal = false;

            // Act

            for (int i = 0; i < gamestate.Invaders.Count; i++)
            {
                expectedPosition.Add(gamestate.Invaders[i].PositionX + 1);
            }
            
            gamestate.UpdateInvaderLocation();

            for (int i = 0; i < gamestate.Invaders.Count; i++)
            {
                actualPosition.Add(gamestate.Invaders[i].PositionX);
            }

            for(int i = 0; i < gamestate.Invaders.Count; i++)
            {
                if(expectedPosition[i] != actualPosition[i])
                {
                    verifVal = false;
                    break;
                }
                else
                {
                    verifVal = true;
                }
            }

            // Assert
            Assert.AreEqual(true, verifVal, "Les données doivent être les mêmes");
        }
    }
}