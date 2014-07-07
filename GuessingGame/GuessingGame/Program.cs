using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    /// <summary>
    /// Play a guessing game
    /// 
    /// Blake Rollins
    /// First lab in the .Net class 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            GuessingGame g = new GuessingGame();
            g.play();
        }
    }
}
