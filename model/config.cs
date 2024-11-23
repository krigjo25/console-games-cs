using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace console_games_cs
{
    internal class Config
    {
        /* // Virtuell og abstract
            This is the entry point of the program
            Includes @config functionality for the games
         */

        // Class members  / Fields
        private int __lives__;
        private int __level__;
        private int __points__;
        private bool __quit__;
        private string __botName__ = "";
        private string __gName__ = "";
        private int __compareScore__;


        //  Properties @rules
        protected string BotName
        {
            get => __botName__;
            set
            {
                //  Ensure that the bot name is a string
                string match = "[a-zA-Z$]";
                var regex = new Regex(match);

                if (regex.IsMatch(value))
                {
                    __botName__ = value;
                }
            }
        }

        protected int Lives
        {
            get => __lives__;
            set
            {
                if (value > -1)
                {
                    __lives__ = value;
                }
            }
        }

        internal int Level
        {
            get => __level__;
            set
            {
                if (value > 0)
                {
                    __level__ = value;
                }
            }
        }

        internal int Points
        {
            get => __points__;
            set
            {
                if (value >= 0)
                {
                    __points__ = value;
                }
            }

        }

        public int compareScore
        {
            get => __compareScore__;
            set
            {
                if (Points == __compareScore__ + 3)
                {
                    __compareScore__ = value;
                }
            }
        }

        internal string Gname
        {
            get => __gName__;
            set
            {
                //  Ensure that the game name is a string
                string match = "[a - zA - Z$]";
                var regex = new Regex(match);

                if (regex.IsMatch(match))
                {
                    __gName__ = value;
                }
            }
        }

        internal bool Quit
        {
            get => __quit__;
            set
            {
                //  Ensure when the game should end
                Console.WriteLine(Lives);
                if (__lives__ == 0)
                {
                    __quit__ = value;
                }
            }
        }

        protected dynamic GenerateName()
        {

            BotName = RandomizedName();
            return 0;
        }

        private static string RandomizedName()
        {
            string[] array = new string[]
            {
                "Martin", "Terje", "Marie",
                "Ellie Marie", "Therese", "Rebecka",
                "Eskil", "Erlend", "Linda"
            };

            Model @model = new Model();

            return array[@model.RandomNumber(array.Length - 1)];
        }

        protected dynamic SetLives(int lives)
        {
            Lives = lives;
            return Lives;
        }

        protected dynamic DecreaseLives()
        {
            Lives--;

            return 0;
        }


        protected dynamic IncreaseLevel()
        {
            const int n = 100;
            // Up to date -> level = n * Math.Sqrt(Points)
            //  Ensure the user has achived the required score to level up
            if (Points == (compareScore * Level) + 3)
            {
                Level++;
                Lives++;
                compareScore += 4;

                //  Level up message
                Console.WriteLine($"Congratulation ! You just level'ed up !");
                Console.WriteLine($"Score : {Points}, Level : {Level}, Lives : {Lives}, Compare : {compareScore * Level}");

                return 0;
            }

            Points++;
            return 0;
        }


        internal virtual void GameConfig(int lives, string gname)
        {
            // Initializing new objects
            Config config = new Config();

            //  Game Configurations
            Level = 1;
            Points = 0;
            SetLives(lives);
            GenerateName();
            Gname = gname;
        }

        internal dynamic Stop(int points, int level)
        {
            //  End the game
            if (Lives == 0)
            {
                Console.WriteLine($"\n[ @ ] The Game has ended Points achived : {points}, Level Achived : {level} [ @ ]\n");
                Quit = true;
                return true;
            }
            return false;
        }
        
        internal dynamic FindN()
        {
            int n = Level * Points;
            Model @model = new Model();

            // Up to date
            // Algorithm to determine the difficulty level based on the current level
            if (Level < 10)
            {
                return n + 10; // Easy
            }
            else
            {
                return n;
            }
        }
    }

    internal class Model
    {
        public dynamic RandomNumber(int arg)
        {
            Random r = new Random();
            return r.Next(0, arg);
        }


    }

}
