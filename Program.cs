using System;
using System.Net.Quic;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace games
{
    internal class Base
    {
        /*
            This is the entry point of the program
            Includes base functionality for the games
         */
        // Class members  / Fields
        protected private int __lives__;
        protected private int __level__;
        protected private int __points__;
        protected private bool __quit__;
        protected private string __botName__ = "";
        protected private string __gName__ = "";
        protected private int __compareScore__;


        //  Properties @rules
        protected private string BotName
        {
            get { return __botName__; }
            set
            {
                string match = "^[a-z][A-Z]$";

                var regex = new Regex(match);

                if (regex.IsMatch(value))
                {
                    __botName__ = value;
                }
            }
        }
        protected private int Lives
        {
            get { return __lives__; } 
            set 
            { 
                if (value > -1 )
                {
                    __lives__ = value;
                }
            }
        }
        protected private int Level
        {
            get { return __level__; }
            set
            {
                if (value > 0)
                {
                    __level__ = value;
                }
            }
        }

        protected private int Points
        { 
            get { return __points__; }
            set
            {
                if (value >= 0 && value < 2)
                {
                    __points__ = value;
                }
            }
        
        }

        protected private int compareScore
        {
            get { return __compareScore__; }
            set
            {
                int compare = Points + 3;
                if (Points == compare)
                {
                    __compareScore__ = Points;
                }
            }
        }
        protected private string Gname
        {
            get { return __gName__; }
            set { __gName__ = value; }
        }
        protected private bool Quit
        {
            get { return __quit__; }
            set { 
                    //  Ensure that the game should end
                    if (__lives__ == 0 || value == true)
                    { 
                        __quit__ = value; 
                    }
                }
        }

        protected private static void Main(string[] arg)
        {
            // Initializing a new class
            Base @base = new Base();

            //  Game Configurations
            @base.SetLives(3);
            @base.GenerateName();

            Console.Write(@"Type in an Integer to select one of the following Games
    1 - Crocks game
    q - exit
    s - Current Stats ( while in a game)");

            var option = Console.ReadLine();

            //  Ensure that the input is a valid integer
            switch (Convert.ToInt32(option))
            {
                case 2:

                    @base.Gname = "Guess the number";
                    GuessTheNumber @gtn = new GuessTheNumber;
                    @gtn.Start();
                    break;

                case 1:
                    @base.Gname = "Crockodile";
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
        
        protected private dynamic GenerateName()
        {
            Base @base = new Base();
            @base.BotName = RandomizedName();
            return 0;
        }
        
        protected private static string RandomizedName()
        {
            string[] array = new string[]
            {
                "Martin", "Terje", "Marie",
                "Ellie Marie", "Therese", "Rebecka",
                "Eskil", "Erlend", "Linda"
            };

            Random @r = new Random();

            return array[r.Next(0, array.Length)];
        }
        
        protected private dynamic SetLives(dynamic lives)
        {
            __lives__ = lives;
            return Lives;
        }
        
        protected private dynamic DecreaseLives()
        {
            __lives__--;

            return 0;
        }

        protected private dynamic IncreaseLevel()
        {
            Base @base = new Base();
            // Compare Score with Compare + 3
            if (@base.Points == @base.compareScore)
            {
                __lives__ ++;
                __level__++;
                return __level__;
            }
        }

        protected private dynamic IncreaseScore()
        {
            __points__ ++;
            return 0;
        }

        protected private dynamic Stop()
        {

            //  End the game
            if (Lives == 0)
            {
                __quit__ = true;
                Console.WriteLine($"\n[ @ ] The Game has ended Points achived : {Points}, Level Achived : {Level} [ @ ]\n");
            }

            return 0;
        }
    }

    internal class Crocks : Base
    {
        Random r = new Random();


        internal dynamic Start()
        {
            //  Game Configrutations
            SetLives(3);
            //  Assigning the number of __lives__
            Console.WriteLine(__lives__);
            //  Randomizing the numbers
            Random r = new Random();

            //  Array of strings
            char[] array = new char[3]
            { 
                '>', '=', '<' 
            };

            //  Welcome the user to the game, give a brief description about the game
            //  and the rules of the game
            Console.WriteLine(@" Welcome to the crocodile game
This game is more like basic understanding of greater than and less than or equal to
The game will generate random integers then as a user you guessing if the numbers are greater than or less than....
Initializing the game");


            while (Quit != true)
            {
                int[] ran_num = new int[]
                {
                    r.Next(1, 100000), r.Next(1, 100000)
                };


                Console.WriteLine($"\n[ @ ] Is {ran_num[0]} Greater than, equal to or less than {ran_num[1]}?\n");
                var prompt = Convert.ToChar(value: Console.ReadLine());

                if (ran_num[0] == ran_num[1] && prompt.CompareTo(array[1]) == array[1] )
                {
                    Console.WriteLine("\n[ @ ] Congratulation you recieve +1 points\n");
                    IncreaseScore();
                }
                else if (ran_num[0] > ran_num[1] && prompt.CompareTo(array[0]) == array[0])
                {
                    Console.WriteLine("\n[ @ ] Congratulation you recieve +1 points\n");
                    IncreaseScore();
                }
                else if (ran_num[0] < ran_num[1] && prompt.CompareTo(array[2]) == array[2])
                {
                    Console.WriteLine("\n[ @ ] Congratulation you recieve +1 points [ @ ]\n");
                    IncreaseScore();
                }
                else if(prompt == 's')
                {
                    Console.WriteLine($"\n[ @ ] Stats :\nCurrent points : {Points}, Level Achived : {Level} [ @ ]\n");
                }
                else if (prompt == 'q')
                {
                    
                    SetLives(0);
                    Stop();
                    break;
                }
                else
                {
                    Console.WriteLine("\n[ @ ] You have lost a life [ @ ]\n");
                    DecreaseLives();
                    Stop();
                }

            }
            return 0;
        }
    }

    internal class GuessTheNumber : Base
    {
        internal dynamic Start()
        {

            // Increase level
            //  Every three points Increase level
            // Points == 0
            //  if points == points+3
            // Increase level
            Console.WriteLine($"Greetings my name is {BotName}, and I'm an bot for this {gName}game.\nIf you guess the correct number 3-5 times I'll make it difficultier.\nFor now I would like you to guess a number between 1-10");
            //  Guess the number
            while (Quit != true)
            {
            }
            // End

            return 0;
        }
    }
}