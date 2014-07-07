using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class UserGuesser : Guesser
    {
        private int _PreviousGuess;
        private ArrayList _Guesses;

        public UserGuesser() : base()
        {
            _PreviousGuess = -1;
            _Guesses = new ArrayList();
        }

        public override int MakeGuess(int maxValue)
        {
            Console.WriteLine("I'm thinking of a number between 1 and 100.  What is it?");

            _PreviousGuess = GetGuess();
            return _PreviousGuess;
        }
        public override void SayTooHigh()
        {
            Console.WriteLine("Too high");
        }
        public override void SayTooLow()
        {
            Console.WriteLine("Too low");
        }
        public override void SayYouWin()
        {
            Console.WriteLine("You win");
            _Guesses.Clear();
        }

        private int GetGuess() {
            int guess = -1;
            bool guessIsValid = false;
            do
            {
                try 
                {
                    guess = int.Parse(Console.ReadLine());
                    if (guess < 1 || _Guesses.Contains(guess)) {
                        Console.WriteLine("Invalid choice.  Try again.");
                    } else {
                        guessIsValid = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid choice.  Try again.");
                }
            } while (!guessIsValid);
            return guess;
        }
    }
}
