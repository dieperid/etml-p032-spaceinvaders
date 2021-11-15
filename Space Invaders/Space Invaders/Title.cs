/// ETML
/// Auteur : David Dieperink
/// Date : 27.08.2021
/// Description : Projet DEV -> Classe qui contient tout les titres des pages

using System;

namespace Space_Invaders
{
    /// <summary>
    /// Classe pour les titres des pages
    /// </summary>
    class Title
    {
        /// <summary>
        /// Méthode pour écrire le titre principal
        /// </summary>
        public static void WriteHomeTitle()
        {
            // Constante qui contient le titre de la page
            const string TITLE_HOME = @"

              ██████  ██▓███   ▄▄▄       ▄████▄  ▓█████     ██▓ ███▄    █  ██▒   █▓ ▄▄▄      ▓█████▄ ▓█████  ██▀███    ██████ 
            ▒██    ▒ ▓██░  ██▒▒████▄    ▒██▀ ▀█  ▓█   ▀    ▓██▒ ██ ▀█   █ ▓██░   █▒▒████▄    ▒██▀ ██▌▓█   ▀ ▓██ ▒ ██▒▒██    ▒ 
            ░ ▓██▄   ▓██░ ██▓▒▒██  ▀█▄  ▒▓█    ▄ ▒███      ▒██▒▓██  ▀█ ██▒ ▓██  █▒░▒██  ▀█▄  ░██   █▌▒███   ▓██ ░▄█ ▒░ ▓██▄   
              ▒   ██▒▒██▄█▓▒ ▒░██▄▄▄▄██ ▒▓▓▄ ▄██▒▒▓█  ▄    ░██░▓██▒  ▐▌██▒  ▒██ █░░░██▄▄▄▄██ ░▓█▄   ▌▒▓█  ▄ ▒██▀▀█▄    ▒   ██▒
            ▒██████▒▒▒██▒ ░  ░ ▓█   ▓██▒▒ ▓███▀ ░░▒████▒   ░██░▒██░   ▓██░   ▒▀█░   ▓█   ▓██▒░▒████▓ ░▒████▒░██▓ ▒██▒▒██████▒▒
            ▒ ▒▓▒ ▒ ░▒▓▒░ ░  ░ ▒▒   ▓▒█░░ ░▒ ▒  ░░░ ▒░ ░   ░▓  ░ ▒░   ▒ ▒    ░ ▐░   ▒▒   ▓▒█░ ▒▒▓  ▒ ░░ ▒░ ░░ ▒▓ ░▒▓░▒ ▒▓▒ ▒ ░
            ░ ░▒  ░ ░░▒ ░       ▒   ▒▒ ░  ░  ▒    ░ ░  ░    ▒ ░░ ░░   ░ ▒░   ░ ░░    ▒   ▒▒ ░ ░ ▒  ▒  ░ ░  ░  ░▒ ░ ▒░░ ░▒  ░ ░
            ░  ░  ░  ░░         ░   ▒   ░           ░       ▒ ░   ░   ░ ░      ░░    ░   ▒    ░ ░  ░    ░     ░░   ░ ░  ░  ░  
                  ░                 ░  ░░ ░         ░  ░    ░           ░       ░        ░  ░   ░       ░  ░   ░           ░  
                                        ░                                      ░              ░                               
            ";
            // Ecriture du titre en vert + position x et y à 0
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(TITLE_HOME);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Méthode pour écrire le titre de la page options
        /// </summary>
        public static void WriteOptionsTitle()
        {
            // Constante qui contient le titre de la page
            const string TITLE_OPTIONS = @"
                     ________      ________    _________    ___      ________      ________       ________      
                    |\   __  \    |\   __  \  |\___   ___\ |\  \    |\   __  \    |\   ___  \    |\   ____\     
                    \ \  \|\  \   \ \  \|\  \ \|___ \  \_| \ \  \   \ \  \|\  \   \ \  \\ \  \   \ \  \___|_    
                     \ \  \\\  \   \ \   ____\     \ \  \   \ \  \   \ \  \\\  \   \ \  \\ \  \   \ \_____  \   
                      \ \  \\\  \   \ \  \___|      \ \  \   \ \  \   \ \  \\\  \   \ \  \\ \  \   \|____|\  \  
                       \ \_______\   \ \__\          \ \__\   \ \__\   \ \_______\   \ \__\\ \__\    ____\_\  \ 
                        \|_______|    \|__|           \|__|    \|__|    \|_______|    \|__| \|__|   |\_________\
                                                                                                    \|_________|                                                                             
            ";
            // Ecriture du titre en vert + position x et y à 0
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(TITLE_OPTIONS);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Méthode pour écrire le titre de la page A Propos
        /// </summary>
        public static void WriteAboutTitle()
        {
            // Constante qui contient le titre de la page
            const string TITLE_ABOUT = @"
                     ________          ________    ________      ________      ________    ________      ________      
                    |\   __  \        |\   __  \  |\   __  \    |\   __  \    |\   __  \  |\   __  \    |\   ____\     
                    \ \  \|\  \       \ \  \|\  \ \ \  \|\  \   \ \  \|\  \   \ \  \|\  \ \ \  \|\  \   \ \  \___|_    
                     \ \   __  \       \ \   ____\ \ \   _  _\   \ \  \\\  \   \ \   ____\ \ \  \\\  \   \ \_____  \   
                      \ \  \ \  \       \ \  \___|  \ \  \\  \|   \ \  \\\  \   \ \  \___|  \ \  \\\  \   \|____|\  \  
                       \ \__\ \__\       \ \__\      \ \__\\ _\    \ \_______\   \ \__\      \ \_______\    ____\_\  \ 
                        \|__|\|__|        \|__|       \|__|\|__|    \|_______|    \|__|       \|_______|   |\_________\
                                                                                                           \|_________|                                                                                    
            ";
            // Ecriture du titre en vert + position x et y à 0
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(TITLE_ABOUT);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteGameOverTitle()
        {
            // Constante qui contient le titre de la page
            const string TITLE_GAMEOVER = @"
             ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ 
            ██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗
            ██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝
            ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗
            ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║
             ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝
            ";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(TITLE_GAMEOVER);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
