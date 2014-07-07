using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Thinker
    {
        private Random _Random;
        private int _SecretNumber;

        public Thinker()
        {
            _Random = new Random();
        }

        internal int SecretNumber
        {
            get { return _SecretNumber; }
        }

        public void ThinkOfANewNumber(int maxValue)
        {
            _SecretNumber = _Random.Next(0, maxValue) + 1;
        }

        public bool IsGuessCorrect(int guess)
        {
            return guess == _SecretNumber;
        }

        public bool IsGuessTooHigh(int guess)
        {
            return guess > _SecretNumber;
        }

        public bool IsGuessTooLow(int guess)
        {
            return guess < _SecretNumber;
        }
    }
}
