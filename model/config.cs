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
        private int __totalScore__;
        private string __botName__ = "";
        private string __gName__ = "";
        private int __compareScore__ = (int) Math.Round(0.0f * (float)Math.Sqrt(0) + 3);


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

        private int totalScore
        {
            get => __totalScore__;
            set
            {
                if (value >= 0)
                {
                    __totalScore__ = value;
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
                if (value > 0 )
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
            
            
            // Up to date -> level = n * Math.Sqrt(Points)
            //  Ensure the user has achived the required score to level up
            if (Points >= compareScore)
            {
                float n = 7.0f;

                Level++;
                Lives++;

               //https://gamedev.stackexchange.com/questions/13638/algorithm-for-dynamically-calculating-a-level-based-on-experience-points
               compareScore = (int)Math.Round(n *(float)Math.Sqrt(totalScore));

                //  Level up message
                Model.ConsoleTypeEffect($"Congratulation ! You just level'ed up !");
                Model.ConsoleTypeEffect($"Score : {Points}, Level : {Level}, Lives : {Lives}, Points untill next lvl  : {compareScore}");

                return 0;
            }
            totalScore++;
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
                Console.WriteLine($"\n[ @ ] The Game has ended total Scores achived : {totalScore}, Level Achived : {level} [ @ ]\n");
                Quit = true;
                return true;
            }
            return false;
        }
        
        protected virtual void GreetUser()
        {

        }
        internal dynamic FindN()
        {
            int n = Level * Points;

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
        public static void ConsoleTypeEffect(string text)
        {
            //  Console type effect
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(75);
            }
            Console.WriteLine("");

        }
        public dynamic RandomNumber(int arg)
        {
            Random r = new Random();
            return r.Next(0, arg);
        }


    }

}
