using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace console_games_cs
{
    internal class Crocks : Config
    {
        protected override void GreetUser()
        {
            char[] array = new char[5]
            {
                '=', '>', '<', 's', 'q'
            };



            int ms = 500;

            Model.ConsoleTypeEffect($@"Greetings my name is {BotName}, and I'm an bot for {Gname}.
If you guess the correct char n times I'll make it difficultier.");
            Thread.Sleep(ms);

            Model.ConsoleTypeEffect($"For now I would like you to Guess a key between {array[0]}, {array[1]} & {array[2]}");
            Thread.Sleep(ms);

            Model.ConsoleTypeEffect($"More about the game :\nFirstly I will generate random integers and you will guess if the first number is greater than, equal to or less than the second number...");
            Thread.Sleep(ms);

            Model.ConsoleTypeEffect("If you guess correctly you will recieve a point, if you do not guess correct a life will be lost.");
            Thread.Sleep(ms);

            Model.ConsoleTypeEffect(@"I'll only allow numeric values otherwise you'll loose a life.
If you guess incorrectly you will loose a life.");
            Thread.Sleep(ms);

            Model.ConsoleTypeEffect("as a user you'll start with {Lives} lives start at level {Level} and {Points} points.");
            Thread.Sleep(ms);

            Model.ConsoleTypeEffect("The game rules...");
            Thread.Sleep(ms);

            Model.ConsoleTypeEffect("I'll allow only three characters..");
            Thread.Sleep(ms);

            Model.ConsoleTypeEffect($"'{array[0]}', '{array[1]}', '{array[2]}', '{array[3]}' & '{array[4]}' to Quit the game...");
            Thread.Sleep(ms);
            
            Model.ConsoleTypeEffect("Initalizing the game...");
            Thread.Sleep(ms);
        }
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
            GreetUser();
            Thread.Sleep(ms);

            while (true)
            {
                int n = FindN();
                int[] ran_num = new int[2]
                {
                    model.RandomNumber(n), model.RandomNumber(n)
                };


                Model.ConsoleTypeEffect($"[ @ ] Is {ran_num[0]} Greater than, equal to or less than {ran_num[1]}?[ @ ]");

                // User input
                var key = Console.ReadKey();

                //  Ensure that the user input is correct
                if (ran_num[0] == ran_num[1] && key.KeyChar == array[0])
                {
                    Console.Clear();
                    Model.ConsoleTypeEffect("[ @ ] Congratulation you recieve 1 point [ @ ]");
                    IncreaseLevel();
                    Thread.Sleep(ms);
                }
                else if (ran_num[0] > ran_num[1] && key.KeyChar == array[1])
                {
                    Console.Clear();
                    Model.ConsoleTypeEffect("[ @ ] Congratulation you recieve 1 point [ @ ]");
                    IncreaseLevel();
                    Thread.Sleep(ms);
                }
                else if (ran_num[0] < ran_num[1] && key.KeyChar == array[2])
                {
                    Console.Clear();
                    Model.ConsoleTypeEffect("[ @ ] Congratulation you recieve 1 point [ @ ]");
                    IncreaseLevel();
                    Thread.Sleep(ms);
                }
                else if (key.Key ==ConsoleKey.S)
                {
                    Console.Clear();
                    Model.ConsoleTypeEffect($"[ @ ] Stats :\nCurrent points : {Points}/{compareScore}, Level Achived : {Level} Lives left : {Lives} [ @ ]");
                    Thread.Sleep(ms);
                }
                else if (key.Key == ConsoleKey.Q || key.Key == ConsoleKey.Escape)
                {
                    SetLives(0);
                }
                else
                {
                    Console.Clear();
                    Model.ConsoleTypeEffect("[ @ ] You lost a health point [ @ ]");
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
        protected override void GreetUser()
        {
            int ms = 500;

            Model.ConsoleTypeEffect($@"Greetings my name is {BotName}, and I'm an bot for {Gname}.
If you guess the correct int 3-5 times I'll make it difficultier.");
            Thread.Sleep(ms);

            Model.ConsoleTypeEffect("I will generate random numbers and you will guess what number I' have generated...");
            Thread.Sleep(ms);

            Model.ConsoleTypeEffect($@"If you guess correctly you will recieve a point, if you do not guess correct a life will be lost.
as a user you'll start with {Lives} lives, at level {Level} and {Points} points.");
            Thread.Sleep(ms);

            Model.ConsoleTypeEffect(@"The game rules..");
            Thread.Sleep(ms);

            Model.ConsoleTypeEffect(@"I'll only allow numeric values otherwise you'll loose a life.
If you guess incorrectly you will loose a life.");
            Thread.Sleep(ms);

            Model.ConsoleTypeEffect("Initalizing the game...");
        }
        internal dynamic Start()
        {
            GameConfig(3, "Guess The Number Game");

            // Initializing new objects
            Random r = new Random();
            Model model = new Model();
            Config config = new Config();

            //  Initializing a milisecond variable
            int Ikey;
            int ms = 500;
            int n = (int)Math.Floor(7.5f * Math.Sqrt(Level));
            int num = model.RandomNumber(n);

            //  Welcome the user to the game, give a brief description about the game
            GreetUser();
            

            while (true)
            {
                n = (int)Math.Floor(7.5f * Math.Sqrt(Level));

                Model.ConsoleTypeEffect(@"[ @ ] A number has been generated It's a number between 0 and {n}, can you guess the number ? {num} [ @ ]\n");
                
                if (!Int32.TryParse(Console.ReadLine(), out int key))
                {
                    Console.Clear();
                    Model.ConsoleTypeEffect("Provide only integers !");
                    Model.ConsoleTypeEffect("System exit Not an INT !");
                    return "Exit status : 1";
                }
                else
                {
                    Ikey = key;
                }

                Thread.Sleep(ms);

                if (num == Ikey)
                {
                    Console.Clear();
                    // Increase a Point
                    IncreaseLevel();

                    // generate a new number
                    num = model.RandomNumber(n);
                    Model.ConsoleTypeEffect("Congratulation a new integer will be randomized !");
                }
                else 
                {
                    Console.Clear();
                    // Decrease life
                    DecreaseLives();

                    if (num > Ikey)
                    {
                        Model.ConsoleTypeEffect($"[ @ ]    I regret to inform you. Your assumption was not correct this time.\nI'll give you a hint thought !\nThe number I'm thinking about is greater than {Ikey} [ @ ]\n");
                    }
                    else
                    {
                        Model.ConsoleTypeEffect($"[ @ ]    I regret to inform you. Your assumption was not correct this time.\nI'll give you a hint thought !\nThe number I'm thinking about is greater than {Ikey} [ @ ]\n");
                    }
                }
                Thread.Sleep(ms);

                //  Ensure that Quit is true
                if (Stop(Points, Level)) { break; } else { continue; }

                
            }

            return "Thanks for Playing !";
        }
    }
}