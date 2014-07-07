using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Game
    {

        public void play()
        {
            Thinker thinker = new Thinker();
            bool stillPlaying = true;

            do
            {
                Console.WriteLine("What difficulty?\n1: Easy (1-10, 3 guesses)\n2: Medium (1-50, 10 guesses)\n3: Hard (1-100, 10 guesses)");
                int difficulty = 0;
                do
                {
                    try
                    {
                        difficulty = int.Parse(Console.ReadLine());
                        if (difficulty < 1 || difficulty > 3)
                        {
                            Console.WriteLine("Invalid choice.  Try again.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid choice.  Try again.");
                    }
                } while (difficulty < 1 || difficulty > 3);
                Console.WriteLine("You chose: " + difficulty);
                
                int maxValue;
                int numGuesses;
                switch (difficulty)
                {
                    case 1:
                        maxValue = 10;
                        numGuesses = 3;
                        break;
                    case 2:
                        maxValue = 50;
                        numGuesses = 10;
                        break;
                    case 3:
                        maxValue = 100;
                        numGuesses = 10;
                        break;
                }

                thinker.ThinkOfANewNumber(maxValue);

                Guesser guesser = new UserGuesser();

                int guessCount = 0;
                int guess = -1;
                do
                {
                    guess = guesser.makeGuess(maxValue);
                    guessCount++;

                    if (thinker.isGuessTooHigh(guess))
                    {
                        guesser.sayTooHigh();
                    }
                    else if (thinker.isGuessTooLow(guess))
                    {
                        guesser.sayTooLow();
                    }
                } while (!thinker.isCorrectGuess(guess));

                Console.WriteLine("You win.  It took " + guessCount + " guesses");

            } while (stillPlaying);

        }
    }
}
