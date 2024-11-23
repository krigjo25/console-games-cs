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

            Model.ConsoleTypeEffect("Type in an Integer to select one of the following Games.");
            Model.ConsoleTypeEffect("2 - Guess the number");
            Model.ConsoleTypeEffect("1 - Crocks game");
            Model.ConsoleTypeEffect("0 - exit");
            Model.ConsoleTypeEffect("s - Current Stats ( while in a game)");
            Model.ConsoleTypeEffect("q - Quit the game");
            //  Ensure that input is an integer
            if (!Int32.TryParse(Console.ReadLine(), out int option))
            {
                Model.ConsoleTypeEffect("Provide only integers !");
                Model.ConsoleTypeEffect("System exit Not an INT !");
                Thread.Sleep(5000);
            }

            switch (Convert.ToInt32(option))
            {
                case 2:
                    config.Gname = array[option];
                    GuessTheNumber @gtn = new GuessTheNumber();
                    Console.Clear();
                    @gtn.Start();
                    break;

                case 1:
                    config.Gname = array[option];
                    Crocks @crocks = new Crocks();
                    Console.Clear();
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