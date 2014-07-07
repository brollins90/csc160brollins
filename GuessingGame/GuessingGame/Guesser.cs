using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    public abstract class Guesser
    {
        protected Random _Random;

        public Guesser()
        {
            _Random = new Random();
        }

        public abstract int MakeGuess(int maxValue, int numGuesses);
        public abstract void SayTooHigh();
        public abstract void SayTooLow();
        public abstract void SayYouWin(int numGuesses);
        public abstract void SayYouLose(int secretNumber);

    }
}
