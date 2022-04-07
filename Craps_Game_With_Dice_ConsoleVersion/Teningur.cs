using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrapsConsoleDiceGame
{
    class Teningur
    {
        int sides = 7;
        static Random slembitala = new Random();
        public int Kasta()
        {
            return slembitala.Next(1, sides);

        }
    }
}
