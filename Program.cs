using System;
using System.Net.Quic;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using console_games_cs;

namespace console_games_cs
{
    internal class App
    {
        public static void Main(string[] arg)
        {
            // Initializing a new object
            Config config = new Config();

            //  Initializing a string
            string[] array = new string[]
            {
                "exit","Crocks Game", "Guess the number",
            };

            Console.WriteLine(@$"Type in an Integer to select one of the following Games
    2 - Guess the number
    1 - Crocks game
    0 - exit
    s - Current Stats ( while in a game)");
        
            //  Ensure that input is an integer
            if (!Int32.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Provide only integers !");
                Console.WriteLine("System exit Not an INT !");
                Thread.Sleep(5000);
            }

            switch (Convert.ToInt32(option))
            {
                case 2:
                    config.Gname = array[option];
                    GuessTheNumber @gtn = new GuessTheNumber();
                    @gtn.Start();
                    break;

                case 1:
                    config.Gname = array[option];
                    Crocks @crocks = new Crocks();
                    Console.WriteLine("Starting Crocks game");
                    @crocks.Start();
                    break;

                case 0:
                    Console.WriteLine("Exiting the game with status 0");
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

            return;
        }

    }
}