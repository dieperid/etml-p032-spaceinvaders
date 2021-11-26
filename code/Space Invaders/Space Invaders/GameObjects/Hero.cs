/// ETML
/// Auteur : David Dieperink
/// Date : 27.08.2021
/// Description : Projet DEV -> Class Hero qui contient l'objet Hero

namespace Space_Invaders.GameObjects
{
    /// <summary>
    /// Class Hero liée à la class GameObjects
    /// </summary>
    public class Hero : GameObjects
    {
        #region[Déclaration des variables]
        /// <summary>
        /// Variable Symbol avec un get, set
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Variable LifeHero avec un get, set
        /// </summary>
        public int LifeHero { get; set; }

        #endregion

        /// <summary>
        /// Constructeur de la class Hero
        /// </summary>
        /// <param name="x">Position x du Hero</param>
        /// <param name="y">Position y du Hero</param>
        public Hero(int x, int y, int life) : base(x, y)
        {
            // Caractère du Hero
            Symbol = "╔█═█╗";
            LifeHero = life;
        }
    }
}
