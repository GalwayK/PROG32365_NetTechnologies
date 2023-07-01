using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekTwoLessonTwo
{
    internal class CoinFlip
    {
        private CoinFlip() { }

        public static void FlipCoin()
        {
            Random random = new Random();
            Console.WriteLine("Flipping coin...");
            bool isHead = Convert.ToBoolean(random.Next(0, 1));
            string strCoin = isHead ? "Heads" : "Tails";
            Console.Write($"The coin landed on {strCoin!}\nPlay again (y/n): ");
            char chaRepeat = Char.ToLower(Console.ReadKey().KeyChar);     
            if (chaRepeat == 'y')
            {
                Console.WriteLine();
                FlipCoin();
            }
        }

    }
}
