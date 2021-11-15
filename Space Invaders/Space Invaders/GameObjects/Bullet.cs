/// ETML
/// Auteur : David Dieperink
/// Date : 27.08.2021
/// Description : Projet DEV -> Class Bullet qui contient l'objet Bullet

namespace Space_Invaders.GameObjects
{
    /// <summary>
    /// Class Bullet liée à la class GameObjects
    /// </summary>
    public class Bullet : GameObjects
    {
        #region[Déclaration des variables]
        /// <summary>
        /// Variable Symbol avec un get, set
        /// </summary>
        public char Symbol { get; set; }

        #endregion

        /// <summary>
        /// Constructeur de la class Bullet
        /// </summary>
        /// <param name="x">Position x de la bullet</param>
        /// <param name="y">Position y de la bullet</param>
        public Bullet(int x, int y) : base(x, y)
        {
            // Caractère de la bullet
            Symbol = '°';
        }
    }
}
