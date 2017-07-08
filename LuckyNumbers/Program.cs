using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string cont;
            do
            {
                Console.Clear();
                Lottery();
                
                Console.WriteLine("Would you like to play again? Yes/No");
                cont = Console.ReadLine().ToLower();

                if (cont == "no")
                {
                    Console.WriteLine("Thanks for playing!");
                    Environment.Exit(0);
                }
            }
            while (cont == "yes");
            
        }
        static void Lottery()
        {
            //Aligning text, formatting and displaying title and instruction 
            double jackpot = 1000000d;
            Console.SetCursorPosition((Console.WindowWidth / 3), 0);
            Console.WriteLine("The Lucky Numbers Game");
            Console.SetCursorPosition((Console.WindowWidth / 3), 1);
            Console.WriteLine("______________________");
            Console.SetCursorPosition((Console.WindowWidth / 3), 2);
            Console.WriteLine((jackpot.ToString("C2")) + " JACKPOT!!");
            Console.Write("--------------------------------------------------------------------------------");
            Console.WriteLine("Instructions:\nYou will enter a set of numbers to determine the range the game will use." +
                "\nYou will then be asked to select 6 numbers. For every number you match to \nthe LUCKY NUMBERS, you earn 1/6th of the Jackpot.");
            Console.WriteLine("--------------------------------------------------------------------------------");

            //Asking user to set a number range to begin the game
            Console.SetCursorPosition((Console.WindowWidth / 3), 10);
            Console.Write("Lowest:");
            int min = int.Parse(Console.ReadLine());
            Console.SetCursorPosition((Console.WindowWidth / 2), 10);
            Console.Write("Highest:");
            int max = int.Parse(Console.ReadLine());

            int[] numberUserRange = new int[6];
            for (int i = 0; i < numberUserRange.Length; i++)
            {
                Console.Write("\nPick " + (i + 1) + ": ");
                numberUserRange[i] = int.Parse(Console.ReadLine());
                while (numberUserRange[i] < min || numberUserRange[i] > max)
                {
                    Console.WriteLine("Number is out of range.\n");
                    Console.Write("Pick " + (i + 1) + ": ");
                    numberUserRange[i] = int.Parse(Console.ReadLine());
                }
            }

            //Using a for loop to randomly add elements into the luckyNumbers array.
            Console.WriteLine();
            Random lucky = new Random();
            int[] luckyNumbers = new int[6];
            for (int i = 0; i < luckyNumbers.Length; i++)
            {
                luckyNumbers[i] = lucky.Next(min, max);
            }

            //Printing each element in the luckyNumbers array using a foreach loop.
            foreach (int num in luckyNumbers)
            {
                Console.Write("Lucky Number: " + num);
            }

            //Checking the users numbers against the lucky numbers to see how many they matched.
            int match = 0;
            foreach (int num in numberUserRange)
            {
                if (num == luckyNumbers[0] || num == luckyNumbers[1] || num == luckyNumbers[2] || num == luckyNumbers[3] || num == luckyNumbers[4] || num == luckyNumbers[5])
                {
                    match++;
                }
            }
            Console.WriteLine("You matched {0} lucky number(s) correctly!", match);
            double winnings = ((jackpot / 6) * match);
            Console.WriteLine("You won " + winnings.ToString("C2")+"!");
        }
    }
}
