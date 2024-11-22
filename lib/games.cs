using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace console_games_cs
{
    internal class Crocks : Config
    {
        internal dynamic Start()
        {
            GameConfig(3, "Crocks Game");
            // Initializing new objects
            Random r = new Random();
            Model model = new Model();
            Config config = new Config();

            //  Array of strings
            char[] array = new char[5]
            {
                '=', '>', '<', 's', 'q'
            };

            int ms = 1000;

            //  Welcome the user to the game, give a brief description about the game
            Console.WriteLine($@"Greetings my name is {BotName}, and I'm an bot for {Gname}.
If you guess the correct char 3-5 times I'll make it difficultier.
For now I would like you to Guess a key between {array[0]}, {array[1]} & {array[2]}.
I will generate random numbers and you will guess if the first number is greater than, equal to or less than the second number...
If you guess correctly you will recieve a point, if you do not guess correct a life will be lost.
You will start with {Lives} lives as a user you'll start at level {Level} and {Points} points.
The game rules..
I'll allow only three characters..
'{array[0]}', '{array[1]}', '{array[2]}', '{array[3]}' & '{array[4]}' to Quit the game...
Initalizing the game...");

            while (true)
            {
                int[] ran_num = new int[2]
                {
                    model.RandomNumber(Level), model.RandomNumber(Level)
                };


                Console.WriteLine($"\n[ @ ] Is {ran_num[0]} Greater than, equal to or less than {ran_num[1]}?\n");

                // User input
                var key = Console.ReadKey().KeyChar;

                //  Ensure that the user input is correct
                if (ran_num[0] == ran_num[1] && key == array[0] )
                {
                    Console.WriteLine("\n[ @ ] Congratulation you recieve +1 points\n");
                    IncreaseLevel();
                    Thread.Sleep(ms);
                }
                else if (ran_num[0] > ran_num[1] && key == array[1])
                {
                    Console.WriteLine("\n[ @ ] Congratulation you recieve +1 points\n");
                    IncreaseLevel();
                    Thread.Sleep(ms);
                }
                else if (ran_num[0] < ran_num[1] && key == array[2])
                {
                    Console.WriteLine("\n[ @ ] Congratulation you recieve +1 points [ @ ]\n");
                    IncreaseLevel();
                    Thread.Sleep(ms);
                }
                else if (key == array[3])
                {
                    Console.WriteLine($"\n[ @ ] Stats :\nCurrent points : {Points}, Level Achived : {Level} Lives left : {Lives} [ @ ]\n");
                    Thread.Sleep(ms);
                }
                else if (key == array[4])
                {
                    SetLives(0);
                }
                else
                {
                    Console.WriteLine("\n[ @ ] You have lost a life [ @ ]\n");
                    DecreaseLives();
                    Thread.Sleep(ms);
                }

                //  Ensure that Quit is true
                if (Stop(Points, Level)) { break; } else { continue; }
            }
            return "Thanks for Playing !";
        }
    }

    internal class GuessTheNumber : Config
    {
        internal dynamic Start()
        {
            GameConfig(3, "Guess The Number Game");

            // Initializing new objects
            Random r = new Random();
            Model model = new Model();
            Config config = new Config();

            //  Initializing a milisecond variable
            int ms = 1000;

            //  Welcome the user to the game, give a brief description about the game


            while (true)
            {
                //  Generate a random number
                int ran_num = model.RandomNumber(Level);
                Console.WriteLine($"\n[ @ ] {BotName} have generated a random number between 0 and {Level * 10}, can you guess the number ? [ @ ]\n");

                //  Ensure that Quit is true
                if (Stop(Points, Level)) { break; } else { continue; }
            }
            return "Thanks for Playing !";
        }
    }
