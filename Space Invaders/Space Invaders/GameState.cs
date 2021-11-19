/// ETML
/// Auteur : David Dieperink
/// Date : 27.08.2021
/// Description : Projet DEV -> Class GameState qui s'occupe du refresh de la page

using Space_Invaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Media;

namespace Space_Invaders
{
    /// <summary>
    /// Class GameState
    /// </summary>
    public class GameState
    {
        #region[Déclaration des variables]
        /// <summary>
        /// Variable Hero qui contient l'objet Hero
        /// </summary>
        public Hero Hero { get; set; }
        /// <summary>
        /// List d'invader qui contient l'objet Invader
        /// </summary>
        public List<Invader> Invaders { get; set; }
        /// <summary>
        /// List de bullet qui contient l'objet Bullet
        /// </summary>
        public List<Bullet> Bullets { get; set; }
        /// <summary>
        /// List de bullet qui contient l'objet Bullet
        /// </summary>
        public List<Bullet> BulletsInvader { get; set; }
        /// <summary>
        /// List de Wall qui contient l'objet Wall
        /// </summary>
        public List<Wall> Walls { get; set; }
        /// <summary>
        /// Variable GameScore qui récupère le score du jouer
        /// </summary>
        public int GameScore { get; set; }
        /// <summary>
        /// Variable escapedInvadersCount qui compte le nombre d'invader qui se sont échappés
        /// </summary>
        public int EscapedInvaderCount { get; set; }
        /// <summary>
        /// Variable pour la position de départ en Y des invaders
        /// </summary>
        private static int _posStartInvadersY = 0;
        /// <summary>
        /// Booléan pour connaître la direction horizontal des invaders
        /// </summary>
        private static bool _mooveLeft = false;
        /// <summary>
        /// Booléan pour l'incrémentation de Y depuis la droite
        /// </summary>
        private static bool _invaderFromRightAddY = true;
        /// <summary>
        /// Booléan pour l'incrémentation de Y depuis la gauche
        /// </summary>
        private static bool _invaderFromLeftAddY = false;
        /// <summary>
        /// Variable pour le temps de tir
        /// </summary>
        private static int _napTimeToShoot = 0;
        /// <summary>
        /// Variable qui contient le nombre de vie du Hero
        /// </summary>
        public int HeroLife = 3;
        /// <summary>
        /// Variable qui contient le nombre d'invader par ligne
        /// </summary>
        private const byte _INVADER_PER_LINE = 7;
        /// <summary>
        /// Variable qui contient le nombre de ligne d'invaders si la difficulté est en EASY
        /// </summary>
        private const byte _NUMBER_OF_LINE_DIFFICULT_EASY = 2;
        /// <summary>
        /// Variable qui contient le nombre de ligne d'invaders si la difficulté est en HARD
        /// </summary>
        private const byte _NUMBER_OF_LINE_DIFFICULT_HARD = 4;
        /// <summary>
        /// Son pour la mort d'un invader
        /// </summary>
        public SoundPlayer _deathSoundInvader = new SoundPlayer("F:\\CFC\\2ème année\\Projets\\P-032_Dev\\Son\\minecraftOw.wav");
        /// <summary>
        /// Son pour la mort du Hero
        /// </summary>
        public SoundPlayer _deathSoundHero = new SoundPlayer("F:\\CFC\\2ème année\\Projets\\P-032_Dev\\Son\\aieeeee.wav");
        /// <summary>
        /// Son pour l'écran Game Over
        /// </summary>
        public SoundPlayer _gameOverSound = new SoundPlayer("F:\\CFC\\2ème année\\Projets\\P-032_Dev\\Son\\gameOver.wav");
        /// <summary>
        /// Son pour les tirs du Hero
        /// </summary>
        public SoundPlayer _shootSound = new SoundPlayer("F:\\CFC\\2ème année\\Projets\\P-032_Dev\\Son\\laserSound.wav");

        #endregion

        /// <summary>
        /// Constructeur de la class GameState
        /// </summary>
        public GameState()
        {
            #region[GameState code]
            Hero = new Hero((Program.WINDOW_WIDTH - 47) / 2, 30, 3);
            Bullets = new List<Bullet>();
            Invaders = new List<Invader>();
            Walls = new List<Wall>();
            #endregion
        }

        /// <summary>
        /// Méthode GetKeyPressed qui récupère les touches préssée par l'utilisateur
        /// </summary>
        public void GetKeyPressed()
        {
            #region[GetKeyPressed code]
            
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Switch qui donne une instruction en fonction de la touche préssée
                switch (key.Key)
                {
                    // Touche flèche de gauche
                    case ConsoleKey.LeftArrow:
                        Hero.PositionX -= 1;
                        break;

                    // Touche flèche de droite
                    case ConsoleKey.RightArrow:
                        Hero.PositionX += 1;
                        break;

                    // Touche Espace
                    case ConsoleKey.Spacebar:
                        if (MenuOptions.sound == true)
                        {
                            _shootSound.Play();
                        }
                        Bullets.Add(new Bullet(Hero.PositionX, Hero.PositionY));
                        break;
                }
            }
            #endregion
        }

        /// <summary>
        /// Méthode GenerateInvader qui génére les invaders
        /// </summary>
        public void GenerateInvader()
        {
            #region[GenerateInvader code]
            
            int comptIdInvader = 0;         // ID de l'invader
            int posStartX = 2;              // Position X de départ
            int nbInvaders;                 // Variable pour le nombre d'invaders à générer
            _posStartInvadersY = 0;         // Position Y de départ
            _mooveLeft = false;             // Remise à false du déplacement à gauche
            _invaderFromLeftAddY = false;   // Remise à false d'ajout de 1 à la pos Y depuis la gauche
            _invaderFromRightAddY = true;   // Remise à true d'ajout de 1 à la pos Y depuis la droite

            // Si l'option de difficulté est EASY
            if (MenuOptions.difficulty == false)
            {
                nbInvaders = _INVADER_PER_LINE * _NUMBER_OF_LINE_DIFFICULT_EASY;
            }
            // Si l'option de difficulté est HARD
            else
            {
                nbInvaders = _INVADER_PER_LINE * _NUMBER_OF_LINE_DIFFICULT_HARD;
            }

            // Boucle for pour la génération des invaders
            for (int w = 0; w < nbInvaders; w++)
            {
                // Si w % 5 vaut 0 et que w est supérieur à 0
                if(w % _INVADER_PER_LINE == 0 && w > 0)
                {
                    // Réinitialisation de la valeur de x à 2
                    posStartX = 2;
                    // Incrémentation de 2 sur la position de départ Y
                    _posStartInvadersY += 2;
                }

                // Création d'un nouvel invader et ajout de celui-ci dans la list d'invaders
                Invader invader = new Invader(posStartX - 2, _posStartInvadersY, comptIdInvader);
                Invaders.Add(invader);

                // Incrémentation de 7 à la position x
                posStartX += 7;
                comptIdInvader++;
            }
            #endregion
        }

        /// <summary>
        /// Méthode GenerateWall qui génère les murs
        /// </summary>
        public void GenerateWall()
        {
            #region[GenerateWall code]

            const byte COLUMN_OF_WALL = 5;          // Nombre de colonne de mur
            const byte WALL_PER_COLUMN = 10;        // Nombre de mur par colonne
            const byte SPACE_BETWEEN_WALL = 5;      // Nombre d'espace entre deux mur
            const byte NUMBER_OF_SPACE = 4;         // Nombre d'espace total
            const byte POSITION_Y = 25;             // Position Y de départ pour les murs
            const byte POSITION_START_X = (Program.WINDOW_WIDTH - 55) - ((COLUMN_OF_WALL * WALL_PER_COLUMN) + (SPACE_BETWEEN_WALL * NUMBER_OF_SPACE));  // Position X de départ pour les murs
            int posX = POSITION_START_X;            // Compteur

            // Boucle for -> tant que x est plus petit que le nombre de colonne de mur
            for(int x = 0; x < COLUMN_OF_WALL; x++)
            {
                // Boucle for -> tant que y est plus petit que le nombre de mur par colonne
                for (int y = 0; y < WALL_PER_COLUMN; y++)
                {
                    // Création d'un nouveau mur et ajout de celui-ci dans la list
                    Wall wall = new Wall(posX - 2, POSITION_Y, 3);
                    Walls.Add(wall);
                    // Incrémentation de la position x
                    posX++;
                }
                posX += SPACE_BETWEEN_WALL;
            }
            #endregion
        }

        /// <summary>
        /// Méthode UpdateInvaderLocation pour update leur position dans la console
        /// </summary>
        public void UpdateInvaderLocation()
        {
            #region[UpdateInvaderLocation code]
            int compteur = 0;                           // Compteur pour la vérif des déplacement horizontaux
            var activeInvaders = new List<Invader>();   // Variable activeInvaders qui est une instance de la list d'invaders

            // Si la list d'invaders est différente de null
            if (Invaders != null)
            {
                // Boucle foreach pour check si des invaders sont au limite de la console
                foreach (var invaderCheckLimit in Invaders)
                {
                    // Si la position X de l'invader est > à la taille de la console - 2 et que le bool _invaderFromRightAddY est vrai
                    if ((invaderCheckLimit.PositionX + invaderCheckLimit.Symbol.Length > Console.WindowWidth - 2) && (_invaderFromRightAddY == true))
                    {
                        compteur += 1;                  // Incrémentation du compteur pour la vérif
                        _mooveLeft = true;              // Le bool _mooveLeft est vrai donc les prochain déplacement vont vers la gauche
                        _invaderFromLeftAddY = true;    // Le bool _invaderFromLeftAddY est mit à vrai vu qu'on vient de descendre du côté droit
                        _invaderFromRightAddY = false;  // Le bool _invaderFromRightAddY est mit à faux vu qu'on vient de descendre du côté droit

                        // Boucle foreach pour ajouter 1 à toutes les position Y des invaders
                        foreach (var invaderAddY in Invaders)
                        {
                            invaderAddY.PositionY += 1;
                            // Ajout des invaders dans la list
                            activeInvaders.Add(invaderAddY);
                        }
                    }
                    // Si la position X de l'invader est < à - 2 et que le bool _invaderFromLeftAddY est vrai
                    if ((invaderCheckLimit.PositionX < 2) && (_invaderFromLeftAddY == true))
                    {
                        compteur += 1;                  // Incrémentation du compteur pour la vérif
                        _mooveLeft = false;             // Le bool _mooveLeft est faux donc les prochain déplacement vont vers la droite
                        _invaderFromRightAddY = true;   // Le bool _invaderFromRightAddY est mit à vrai vu qu'on vient de descendre du côté gauche
                        _invaderFromLeftAddY = false;   // Le bool _invaderFromLeftAddY est mit à faux vu qu'on vient de descendre du côté gauche

                        // Boucle foreach pour ajouter 1 à toutes les position Y des invaders
                        foreach (var invaderAddY in Invaders)
                        {
                            invaderAddY.PositionY += 1;
                            // Ajout des invaders dans la list
                            activeInvaders.Add(invaderAddY);
                        }
                    }
                    // Si la position Y est égal à 30
                    if(invaderCheckLimit.PositionY == 30)
                    {
                        // Remove de l'invader dans la list
                        activeInvaders.Remove(invaderCheckLimit);
                        // Incrémentation du compteur du nombre d'invader sorti
                        EscapedInvaderCount++;
                    }
                }
                // Si le bool _mooveLeft est faux et que le compteur est à 0 donc aucun ajout de Y
                if (_mooveLeft == false && compteur == 0)
                {
                    // Boucle foreach pour ajouter 1 à toutes les position X des invaders
                    foreach (var invaderAddX in Invaders)
                    {
                        invaderAddX.PositionX += 1;
                        // Ajout des invaders dans la list
                        activeInvaders.Add(invaderAddX);
                    }
                }
                // Si le bool _mooveLeft est vrai et que le compteur est à 0 donc aucun ajout de Y
                else if (_mooveLeft == true && compteur == 0)
                {
                    // Boucle foreach pour retirer 1 à toutes les position X des invaders
                    foreach (var invaderRemoveX in Invaders)
                    {
                        invaderRemoveX.PositionX -= 1;
                        // Ajout des invaders dans la list
                        activeInvaders.Add(invaderRemoveX);
                    }
                }
            }
            // La list d'invader récupère la valeur de la variable activeInvaders
            Invaders = activeInvaders;
            #endregion
        }

        /// <summary>
        /// Méthode UpdateBulletHeroLocation pour update leur position dans la console pour le Hero
        /// </summary>
        public void UpdateBulletHeroLocation()
        {
            #region[UpdateBulletHeroLocation code]
            var activeBullets = new List<Bullet>();     // Variable activeBullets qui est une instance de la list de Bullet

            // Si la list de bullets est différente de null
            if (Bullets != null)
            {
                // Boucle foreach pour récupérer le numéro de la bullet dans la list
                foreach (var bullet in Bullets)
                {
                    // Appel de la méthode CheckKill en lui passant le numéro de la bullet
                    if (!CheckKillInvader(bullet) && !CheckShootWall(bullet))
                    {
                        // Si la position Y de la bullet est différente de 0
                        if (bullet.PositionY != 0)
                        {
                            // On lui retire 1 en position Y et on ajoute la bullet dans la list de bullets
                            bullet.PositionY -= 1;
                            activeBullets.Add(bullet);
                        }
                    }
                }
            }
            // La list Bullets récupère la valeur de la variable activeBullets
            Bullets = activeBullets;
            #endregion
        }

        /// <summary>
        /// Méthode UpdateBulletInvaderLocation pour update leur position dans la console pour les Invaders
        /// </summary>
        public void UpdateBulletInvaderLocation()
        {
            #region[UpdateBulletInvaderLocation code]
            Random rndShootInvader = new Random();                              // Initialisation d'un Random                                        
            int idInvaderCanShoot, idInvaderCanShoot2, idInvaderCanShoot3;      // Récupération des ID des invaders
            var activeBullets = new List<Bullet>();                             // Variable activeBullets qui est une instance de la list de Bullet
            int whichInvader = rndShootInvader.Next(0, Invaders.Count);         // Quel invader peut tirer
            int compt = 0;                                                      // Compteur

            // Fréquence de tir
            if (_napTimeToShoot % 4 == 0)
            {
                // Boucle foreach pour récupérer l'invader qui tire
                foreach (var invaderBullets in Invaders)
                {
                    // Si le compteur est égal à l'invader qui doit tirer
                    if (compt == whichInvader)
                    {
                        idInvaderCanShoot = invaderBullets.IdInvader + _INVADER_PER_LINE;
                        // Si la difficulté est en HARD
                        if(MenuOptions.difficulty == true)
                        {
                            idInvaderCanShoot2 = invaderBullets.IdInvader + (_INVADER_PER_LINE * 2);
                            idInvaderCanShoot3 = invaderBullets.IdInvader + (_INVADER_PER_LINE * 3);

                            // Check si les id d'invaders trouvés existent dans la list
                            if (!Invaders.Exists(x => x.IdInvader == idInvaderCanShoot || x.IdInvader == idInvaderCanShoot2 || x.IdInvader == idInvaderCanShoot3))
                            {
                                BulletsInvader.Add(new Bullet(invaderBullets.PositionX, invaderBullets.PositionY));
                            }
                        }
                        // Sinon
                        else
                        {
                            // Check si l'id d'invader trouvé existe dans la list
                            if (!Invaders.Exists(x => x.IdInvader == idInvaderCanShoot))
                            {
                                BulletsInvader.Add(new Bullet(invaderBullets.PositionX, invaderBullets.PositionY));
                            }
                        }  
                    }
                    // Incrémentation du compteur
                    compt++;
                }
            }

            // Si la list de bullets est différente de null
            if (BulletsInvader != null)
            {
                // Boucle foreach pour récupérer le numéro de la bullet dans la list
                foreach (var bullet in BulletsInvader)
                {
                    // Appel de la méthode CheckKill en lui passant le numéro de la bullet
                    if (!CheckKillHero(bullet) && !CheckShootWall(bullet))
                    {
                        // Si la position Y de la bullet est différente de 0
                        if (bullet.PositionY != 30)
                        {
                            // On lui retire 1 en position Y et on ajoute la bullet dans la list de bullets
                            bullet.PositionY += 1;
                            activeBullets.Add(bullet);
                        }
                    }
                }
            }
            // La list Bullets récupère la valeur de la variable activeBullets
            BulletsInvader = activeBullets;
            _napTimeToShoot++;
            #endregion
        }

        /// <summary>
        /// Méthode CheckKillInvader qui vérifie si la balle a touché un invader
        /// </summary>
        /// <param name="bullet">Bullet envoyée à la méthode</param>
        /// <returns></returns>
        private bool CheckKillInvader(Bullet bullet)
        {
            #region[CheckKillInvader code]
            Invader invader = new Invader(0, 0, 0);    // Création d'une instance de Invader
            int size = invader.Symbol.Length;          // Variable size pour la hitbox des invaders

            // Si la bullet est différente de null
            if (bullet != null)
            {
                // Boucle for pour check la hitbox des invaders
                for (int compt = 0; compt < size; compt++)
                {
                    // Variable killedInvaders qui vérifie si la position X et Y de la bullet est la même que celle de l'invader
                    var killedInvader = Invaders.Find(x => x.PositionX + compt == bullet.PositionX && x.PositionY == bullet.PositionY);

                    // Si killedInvader est différent de null
                    if (killedInvader != null)
                    {
                        if (MenuOptions.sound == true)
                        {
                            _deathSoundInvader.Play();
                        }
                        // Remove l'invader tué dans la list d'invader
                        Invaders.Remove(killedInvader);
                        // Incrémentation du score du joueur
                        GameScore += 10;
                        // Return true si un invader est tué
                        return true;
                    }
                }
                // Return false si aucun invader est tué
                return false;
            }
            // Return false si aucun invader est tué
            return false;
            #endregion
        }

        /// <summary>
        /// Méthode CheckKillHero qui vérifie si la balle a touché le Hero
        /// </summary>
        /// <param name="bullet">Bullet envoyée à la méthode</param>
        /// <returns></returns>
        private bool CheckKillHero(Bullet bullet)
        {
            #region[CheckKill code]
            int size = Hero.Symbol.Length;      // Variable size pour la hitbox du Hero

            // Si la bullet est différente de null
            if (bullet != null)
            {
                // Boucle for pour check la hitbox de l'Hero
                for (int compt = 0; compt < size; compt++)
                {                  
                    if(Hero.PositionX + compt == bullet.PositionX && Hero.PositionY == bullet.PositionY)
                    {
                        if (MenuOptions.sound == true)
                        {
                            _deathSoundHero.Play();
                        }
                        // Decrémentation de la vie du Hero
                        HeroLife--;
                        // Création d'un nouveau Hero
                        Hero = new Hero((Program.WINDOW_WIDTH - 47) / 2, 30, HeroLife);
                        // Return true si un invader est tué
                        return true;
                    }
                }
                // Return false si le Hero n'est pas tué
                return false;
            }
            // Return false si le Hero n'est pas tué
            return false;
            #endregion
        }

        /// <summary>
        /// Méthode CheckShootWall qui vérifie si la balle a touché un mur
        /// </summary>
        /// <param name="bullet"></param>
        /// <returns></returns>
        private bool CheckShootWall(Bullet bullet)
        {
            #region[CheckShootWall code]
            // Si la bullet est différente de null
            if (bullet != null)
            {
                // Variable qui récupère le mur touchés
                var wallTouched = Walls.Find(x => x.PositionX == bullet.PositionX && x.PositionY == bullet.PositionY);

                // Si wallTouched est différent de null
                if(wallTouched != null)
                {
                    // Retire une vie au mur
                    wallTouched.LifeWall--;

                    // Si le mur a 0 vie
                    if (wallTouched.LifeWall == 0)
                    {
                        // Retire le mur de la list
                        Walls.Remove(wallTouched);
                    }
                    // Return true si un mur est touché
                    return true;
                }
                // Return false si un mur n'est pas touché
                return false;
            }
            // Return false si un mur n'est pas touché
            return false;
            #endregion
        }

        /// <summary>
        /// Méthode CheckGameOver qui check si la partie est finie
        /// </summary>
        /// <returns></returns>
        public bool CheckGameOver()
        {
            #region[CheckGameOver code]

            if (HeroLife == 0 || Invaders.Count == 0)
            {
                if (MenuOptions.sound == true)
                {
                    _gameOverSound.Play();
                }
                return true;
            }
            else
            {
                return false;
            }

            #endregion
        }
    }
}

