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
        // Class members  / Fields
        protected private int _lives_;
        protected private int _level_;
        protected private int _points_;
        protected private bool _quit_;


        //  Properties @rules
        protected private int Lives
        {
            get { return _lives_; } 
            set 
            { 
                if (value > -1 )
                {
                    _lives_ = value;
                }
            }
        }
        protected private int Level
        {
            get { return _level_; }
            set
            {
                if (value > -1)
                {
                    _level_ = value;
                }
            }
        }

        protected private int Points
        { 
            get { return _points_; }
            set
            {
                if (value >= 0 && value < 2)
                {
                    _points_ = value;
                }
            }
        
        }

        protected private bool Quit
        {
            get { return _quit_; }
            set { 
                    //  Ensure that the game should end
                    if (_lives_ == 0 || value == true)
                    { 
                        _quit_ = value; 
                    }
                }
        }

        protected private static void Main(string[] arg)
        {
            //  Initializing classes
            Base @base = new Base();

            Console.Write(@"Type in an Integer to select one of the following Games
    1 - Crocks game
    q - exit
    s - Current Stats ( while in a game)");

            var option = Console.ReadLine();

            //  Ensure that the input is a valid integer
            switch (Convert.ToInt32(option))
            {
                case 1:
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
        
        protected private dynamic SetLives(dynamic lives)
        {
            _lives_ = lives;
            return Lives;
        }
        protected private dynamic DecreaseLives()
        {
            _lives_--;

            return 0;
        }

        protected private dynamic IncreaseLevel()
        {
            _level_ ++;
            return _level_;
        }

        protected private dynamic IncreaseScore()
        {
            _points_ ++;
            return 0;
        }

        
        protected private dynamic Stop()
        {

            //  End the game
            if (Lives == 0)
            {
                _quit_ = true;
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
            //  Assigning the number of _lives_
            Console.WriteLine(_lives_);
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
                int num = r.Next(1, 100000);
                int num1 = r.Next(1, 100000);

                Console.WriteLine($"\n[ @ ] Is {num} Greater than, equal to or less than {num1}?\n");
                var prompt = Convert.ToChar(value:Console.ReadLine());

                if (num == num1 && prompt.CompareTo(array[1]) == array[1] )
                {
                    Console.WriteLine("\n[ @ ] Congratulation you recieve +1 points\n");
                    IncreaseScore();
                }
                else if (num > num1 && prompt.CompareTo(array[0]) == array[0])
                {
                    Console.WriteLine("\n[ @ ] Congratulation you recieve +1 points\n");
                    IncreaseScore();
                }
                else if (num < num1 && prompt.CompareTo(array[2]) == array[2])
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

            return 0;
        }
    }
}