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

        public override int MakeGuess(int maxValue, int numGuesses)
        {
            Console.WriteLine("I'm thinking of a number between 1 and " + maxValue + ".  You have " + numGuesses + " Guesses.  What is it?");

            _PreviousGuess = GetGuess(maxValue);
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
        public override void SayYouWin(int numGuesses)
        {
            Console.WriteLine("You win.  You used " + numGuesses + " guesses.");
            _Guesses.Clear();
        }
        public override void SayYouLose(int secretNumber)
        {
            Console.WriteLine("Sorry, you lose.  The number was " + secretNumber);
            _Guesses.Clear();
        }

        private int GetGuess(int maxValue)
        {
            int guess = -1;
            bool guessIsValid = false;
            do
            {
                try 
                {
                    guess = int.Parse(Console.ReadLine());
                    if (guess < 1 || guess > maxValue) {                        
                        Console.WriteLine("Guess is not in the valid range.  Try again.");
                    } else if (_Guesses.Contains(guess)) {
                        Console.WriteLine("You have already tried " + guess + " and it was wrong.  Try again.");
                    } else {
                        _Guesses.Add(guess);
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
