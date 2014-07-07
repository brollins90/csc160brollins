using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class GuessingGame
    {
        /// <summary>
        /// Plays the Guess A Number game
        /// </summary>
        public void play()
        {
            Thinker thinker = new Thinker();
            bool stillPlaying = true;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------------");
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
                int guessesLeft;
                switch (difficulty)
                {
                    case 1:
                    default:
                        maxValue = 10;
                        guessesLeft = 3;
                        break;
                    case 2:
                        maxValue = 50;
                        guessesLeft = 10;
                        break;
                    case 3:
                        maxValue = 100;
                        guessesLeft = 10;
                        break;
                }

                thinker.ThinkOfANewNumber(maxValue);

                Guesser guesser = new UserGuesser();

                int guessCount = 0;
                int guess = -1;
                do
                {
                    guess = guesser.MakeGuess(maxValue, guessesLeft--);
                    guessCount++;

                    if (thinker.IsGuessTooHigh(guess))
                    {
                        guesser.SayTooHigh();
                    }
                    else if (thinker.IsGuessTooLow(guess))
                    {
                        guesser.SayTooLow();
                    }
                    else if (thinker.IsGuessCorrect(guess))
                    {
                        guesser.SayYouWin(guessCount);
                        guessesLeft = -1;
                    }

                    if (guessesLeft == 0)
                    {
                        guesser.SayYouLose(thinker.SecretNumber);
                    }
                } while (guessesLeft > 0);

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Would you like to play again?");
                String playAgain = Console.ReadLine();
                stillPlaying = (playAgain.ToLower().ToCharArray()[0] == 'y');

            } while (stillPlaying);

        }
    }
}
