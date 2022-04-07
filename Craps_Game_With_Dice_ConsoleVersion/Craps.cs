using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrapsConsoleDiceGame
{
    class Craps
    {
        //Ég skrifaði kóðann til að geta bæði virkað í Microsoft Visual C# Express og í Mono Developer
        int t1 = 0, t2 = 0, summa = 0, bank = 0, gO = 0, counter = 0, wc=0,lc=0, games;
        bool gameOver,winner,newGame,loser;
        string checkme,tmp;
        public void DieThrower()
        {
            Console.WriteLine("Simple rules");
            Console.WriteLine("if you get 7 or 11 on a new game you win right away");
            Console.WriteLine("if you get 2,3 or 12 on a new game you lose");
            Console.WriteLine("if you get 7 on a reroll you lose");
            Console.WriteLine("you reroll until you get either same number again and win or a 7 and lose");
            Console.WriteLine();
            Console.WriteLine("How many games will you play?");
            checkme = Console.ReadLine();
            Console.WriteLine("Error Detection...");
            tmp = "";
            Console.WriteLine(checkme + "...");
            for (int i = 0; i < checkme.Length; i++)
                try
                {
                    if ((Convert.ToChar(checkme.Substring(i, 1)) < '0') || (Convert.ToChar(checkme.Substring(i, 1)) > '9'))
                        tmp += checkme.Substring(i, 1);
                }
                catch
                { }
            if (tmp != "")
            {
                Console.WriteLine("Extracting... " + tmp);
                tmp = "";
            }
            for (int i = 0; i < checkme.Length; i++)
                try
                {
                    if (Convert.ToInt32(checkme.Substring(i, 1)) >= 0 || Convert.ToInt32(checkme.Substring(i, 1)) <= 9)
                        tmp += checkme.Substring(i, 1);
                }
                catch
                { }
            if (tmp != "")
            {
                Console.WriteLine("Gives: " + tmp);
                games = Convert.ToInt16(tmp);
            }
            if (tmp == "")
            {
                tmp = "0";
            }
            Console.WriteLine();
            games = Convert.ToInt16(tmp);
            Console.WriteLine();
            Console.WriteLine("---"+games+" Games---");
            Teningur ten1 = new Teningur();
            Teningur ten2 = new Teningur();
            while (counter < games)
            {
                gO = 0;
                gameOver = false;
                newGame = true;
                winner = false;
                loser = false;
                counter = counter + 1;
                Console.WriteLine("--- New Game Nr. "+counter+" --- ");
                while (gO == 0)
                {
                    t1 = ten1.Kasta();
                    t2 = ten2.Kasta();
                    summa = t1 + t2;
                    if (newGame == true)
                    {
                        Console.WriteLine("Player Rolled " + t1 + " + " + t2 + " = " + summa);
                    }
                    if (newGame == false)
                    {
                        Console.WriteLine("Player Rerolled " + t1 + " + " + t2 + " = " + summa);
                    }
                    crapsPlay();
                }
                newGame = true;
            }
            Console.WriteLine("--You Won " + wc + ".  games and lost" + lc + ". games");
            Console.ReadLine();
        }
        public void crapsPlay()
        {
            if (newGame == true)
            {
                if (summa == 2 || summa == 3 || summa == 12)
                {
                    gameOver = true;
                    loser = true;
                }
                if (summa == 7 || summa == 11)
                {
                    winner = true;
                    gameOver = true;
                }
                else
                {
                    bank = summa;
                }
            }
            if (newGame == false)
            {

                if (summa == bank)
                {
                    winner = true;
                    gameOver = true;
                }
                else
                {
                    if (summa == 7)
                    {
                        gameOver = true;
                        winner = false;
                        loser = true;
                    }
                }
            }
            if (winner == true)
            {
                Console.WriteLine("You Win");
                wc = wc + 1;
            }
            if (loser == true)
            {
                Console.WriteLine("You lose");
                lc = lc + 1;
            }
            if (gameOver == true)
            {
                gO = 1;
            }
            newGame = false;
        }
    }
}
