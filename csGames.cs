using System;
using System.Net.Quic;

namespace games
{
    internal class Base
    {
        /*
            This is the entry point of the program
            Includes base functionality for the games
         */
        protected private int lives;
        protected private int points = 0;
        protected private bool quit = false;

        protected private static void Main(string[] arg)
        {
            //  Initializing classes
            Base @base = new Base();

            Console.Write(@"Type in an Integer to select one of the following Games
    1 - Crocks game
    q - exit
    s - Current Stats");

            var option = Console.ReadLine();

            //  Ensure that the input is a valid integer
            switch (Convert.ToInt32(option))
            {
                case 1:
                    Crocks crocks = new Crocks();
                    Console.WriteLine("Starting Crocks game");
                    crocks.Start();
                    break;

                case 0:
                    Console.WriteLine("Exiting the game with status 0");
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
            
            @base.Stop();

            return;
        }
        protected private dynamic Stop()
        {

            //  End the game
            if (lives == 0)
            {
                Console.WriteLine("Game Over");
            }
            else if (quit == true)
            {
                Console.WriteLine("The Game is Over");
            }
            return 0;
        }
    }

    internal class Crocks : Base
    {
        Random r = new Random();

        public void Start()
        {
            //  Game Configrutations

            //  Assigning the number of lives
            lives = 3;

            //  Randomizing the numbers
            Random r = new Random();

            //  Array of strings
            string[] array = { ">", "=", "<" };



            //  Welcome the user to the game, give a brief description about the game
            //  and the rules of the game
            Console.WriteLine(@" Welcome to the crocodile game
This game is more like basic understanding of greater than and less than or equal to
The game will generate random integers then as a user you guessing if the numbers are greater than or less than....
Initializing the game");


            while (quit != true)
            {
                int num = r.Next(1, 100000);
                int num1 = r.Next(1, 100000);

                Console.WriteLine($" Is {num} Greater than, equal to or less than ? {num1}");

                var prompt = Console.ReadLine();

                if (num == num1 && Convert.ToString(prompt) == array[1])
                {
                    Console.WriteLine("Congratulation you recieve +1 points");
                    points++;
                }
                else if (num > num1 && Convert.ToString(prompt) == array[0])
                {
                    Console.WriteLine("Congratulation you recieve +1 points");
                    points++;
                }
                else if (num < num1 && Convert.ToString(prompt) == array[2])
                {
                    Console.WriteLine("Congratulation you recieve +1 points");
                    points++;
                }
                else if(prompt == "s")
                {
                    Console.WriteLine($"|-------------------------------|\n| You have {lives} lives left |\n| Points achived : {points} |");
                }
                else if (prompt == "q")
                {
                    quit = true;
                    Console.WriteLine("Closing the game");
                    break;
                }
                else
                {
                    Console.WriteLine("You have lost a life");
                    lives--;
                }

                //  Check if the user has lost all the lives
                Stop();

            }
            return;
        }
    }
}