using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("{0} - {1}", i, FizzBuzz(i));
            }

            for (int i = 92; i > 78; i--)
            {
                Console.WriteLine("{0} - {1}", i, FizzBuzz(i));
            }

            string temp = "I like code";
            Console.WriteLine(Yodaizer(temp));
        }
        public static string FizzBuzz(int number)
        {
            string BuzzOrNot = "";

            if (number % 5 == 0)
            {
                BuzzOrNot += "Buzz";
                if (number % 3 == 0)
                {
                    BuzzOrNot += "Fizz";
                }
            }
            else if (number % 3 == 0)
            {
                BuzzOrNot = "Fizz";
            }
            else
            {
                BuzzOrNot = number.ToString();
            }
            return BuzzOrNot;
        }

        public static string Yodaizer(string text)
        {
            string returnText = "";
            List<string> listWords = text.Split(' ').ToList<string>();

            if (listWords.Count == 3)
            {
                returnText += listWords[2] + ", " + returnText[0] + " " + returnText[1];
            }
            else
            {
                for (int i = listWords.Count; i >= 0; i--)
                {
                    returnText += listWords[i];
                    returnText += " ";
                }
            }
            return returnText.Trim();
        }
        public static bool IsPrime(int number)
        {
            return true;
        }
        public static string DashInsert(int number)
        {
            return string.Empty;
        }
    }
}
