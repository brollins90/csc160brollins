using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Thinker
    {
        private Random _Rand;

        public Thinker()
        {
            _Rand = new Random();
        }

        public void ThinkOfANewNumber(int maxValue)
        {            
            int randomNumber = _Rand.Next(0, maxValue) + 1;
        }
    }
}
