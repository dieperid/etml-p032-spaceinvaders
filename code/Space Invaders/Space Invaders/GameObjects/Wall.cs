/// Auteur : David Dieperink
/// Date : 12.11.2021
/// Description : Projet DEV -> Class Wall pour les mur de protection

namespace Space_Invaders.GameObjects
{
    /// <summary>
    /// Class Wall liée à la class GameObjects
    /// </summary>
    public class Wall : GameObjects
    {
        #region[Déclaration des variables]
        /// <summary>
        /// Getter setter, sur le symbol du wall
        /// </summary>
        public char Symbol { get; set; }
        /// <summary>
        /// Variable LifeWall avec un get, set
        /// </summary>
        public int LifeWall { get; set; }

        #endregion

        /// <summary>
        /// Constructeur de la class Wall
        /// </summary>
        /// <param name="x">position x</param>
        /// <param name="y">position y</param>
        /// <param name="life">nombre de vie</param>
        public Wall(int x, int y, int life) : base(x, y)
        {
            Symbol = '█';
            LifeWall = life;
        }
    }
}
