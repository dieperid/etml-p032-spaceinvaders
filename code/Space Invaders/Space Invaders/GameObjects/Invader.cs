/// ETML
/// Auteur : David Dieperink
/// Date : 27.08.2021
/// Description : Projet DEV -> Class Invader qui contient l'objet Invader

namespace Space_Invaders.GameObjects
{
    /// <summary>
    /// Class Invader liée à la class GameObjects
    /// </summary>
    public class Invader : GameObjects
    {
        #region[Déclaration des variables]
        /// <summary>
        /// Variable Symbol avec un get, set
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// Variable IdInvader avec un get, set
        /// </summary>
        public int IdInvader { get; set; }

        #endregion

        /// <summary>
        /// Constructeur de la class Invader
        /// </summary>
        /// <param name="x">Position x de l'invader</param>
        /// <param name="y">Position y de l'invader</param>
        /// <param name="idInvader">Id de l'invader</param>
        public Invader(int x, int y, int idInvader) : base(x, y)
        {
            // Caractère de l'invader
            Symbol = "╔█═█╗";
            IdInvader = idInvader;
        }
    }
}
