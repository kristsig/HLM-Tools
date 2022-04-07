using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrapsConsoleDiceGame
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to craps");
            Craps craps = new Craps();
            craps.DieThrower();
            Console.ReadLine();
        }

        
	}
}
