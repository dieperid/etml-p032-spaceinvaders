/// ETML
/// Auteur : David Dieperink
/// Date : 27.08.2021
/// Description : Projet DEV -> Class GameObjects qui contient les positions

namespace Space_Invaders.GameObjects
{
    /// <summary>
    /// Class GameObjects
    /// </summary>
    public class GameObjects
    {
        #region[Déclaration des variables]
        /// <summary>
        /// Variable pour la position x avec un get, set
        /// </summary>
        public int PositionX { get; set; }
        /// <summary>
        /// Variable pour la position y avec un get, set
        /// </summary>
        public int PositionY { get; set; }

        #endregion

        /// <summary>
        /// Constructeur de la class GameObjects
        /// </summary>
        /// <param name="x">Position x de l'objet</param>
        /// <param name="y">Position y de l'objet</param>
        public GameObjects(int x, int y)
        {
            PositionX = x + 2;
            PositionY = y;
        }
    }
}
