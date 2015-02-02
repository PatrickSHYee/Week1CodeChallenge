/*
 *   Programmer:    Patrick S. Yee
 *   Date:          Feb. 1, 2015
 *   Description: see function summaries for the following:
 *      FizzBuzz, Yodaizer, TextStats, IsPrime, and DashInsert
 *    The main function has calls to these functions.
 */
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
            // looping from 0 to 20 to get a fizz, buzz, or fizzbuzz
            int start = 0;
            int end = 20;

            for (int i = start; i <= end; i++)
            {
                Console.WriteLine("{0} - {1}", i, FizzBuzz(i));
            }
            Console.WriteLine();  // a space break so it doesn't look choppy

            // looping from 92 to 79
            start = 92;
            end = 79;
            for (int i = start; i >= end; i--)
            {
                Console.WriteLine("{0} - {1}", i, FizzBuzz(i));
            }

            // printing out the stats for these 3 sentences.
            TextStats("Hi, how are you? Doing good. How about you?");

            // printing the prime numbers of odd numbers from 1 - 25
            start = 1;
            end = 25;
            for (int i = start; i < end; i+=2)
            {
                if (IsPrime(i))
                    Console.WriteLine("{0} is  a prime number", i);

                else
                    Console.WriteLine(i.ToString());

            }

            // Inserting dashes between two odd numbers.
            start = 454793;
            end = 8675309;
            Console.WriteLine("{0} looks like this now {1}", start, DashInsert(start));
            Console.WriteLine("{0} reads like this now {1}", end, DashInsert(end));
        }

        /// <summary>
        /// Print a Fizz when the number is divisible by 5, a Buzz when the number is divisible by 3, and if the number is divisible by 3 and 5 print out
        /// FizzBuzz.  If the number is not divisible by either 3 or 5, the number just prints out.
        /// </summary>
        /// <param name="number">The number to test</param>
        /// <returns>Fizz, Buzz, or FizzBuzz</returns>
        public static string FizzBuzz(int number)
        {
            // setting a null string to be return to the main
            string BuzzOrNot = null;

            // do the checks for the number
            if (number % 5 == 0)
            {
                BuzzOrNot += "Fizz";
            }
            if (number % 3 == 0)
            {
                BuzzOrNot += "Buzz";
            }
            // if the number does not pass the checks the number is in the string
            if (BuzzOrNot == null)
            {
                BuzzOrNot += number.ToString();
            }
            return BuzzOrNot;
        }

        /// <summary>
        /// Taking a sentence and reverse the order.  Special test when there is only 3 words, where
        /// the last word gets a comma and the last word is first and the other words follow.
        /// </summary>
        /// <param name="text">regular sentence</param>
        /// <returns>reverse sentence</returns>
        public static string Yodaizer(string text)
        {
            string returnText = "";
            List<string> listWords = text.Split(' ').ToList<string>();

            if (listWords.Count == 3)
            {
                listWords[2] += ",";
                returnText += listWords[2] + " " + listWords[0] + " " + listWords[1];
            }
            else
            {
                for (int i = listWords.Count - 1; i >= 0; i--)
                {
                    returnText += listWords[i];
                    if (i != 0)
                    {
                        returnText += " ";
                    }
                }
            }
            return returnText.Trim();
        }

        /// <summary>
        /// Taking a sentence and the stats of it.  Special case of the 2 longest words and the shortest word.
        /// </summary>
        /// <param name="text">a string of a sentence</param>
        static void TextStats(string text)
        {
            List<string> listWords = text.Split(' ').ToList<string>();  // split the text with a more useable manner

            int num_Chars = text.Length;  // a given b/c text is an array of characters reguardless for special characters
            int num_Words = listWords.Count;  // when the words are seperated by a delimiter, space. The count in this list is count for the words
            // set the counters
            int num_Vowels = 0;
            int num_Const = 0;
            int num_SpChar = 0;

            // set an array, it's much easier to check these with loops.
            char[] specialChars = { ' ', '.', '?', '.' };
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            // declaring 2 longest words and the shortest
            // setting one longest and the shortest to the first of sentence.
            string longestWord1 = listWords[0];
            string longestWord2 = null;
            string shortestWord = listWords[0];

            // looking for vowels and special characters
            for (int i = 0; i < text.Length; i++)
            {
                // count the special characters against my specialChars array.
                for (int sp = 0; sp < specialChars.Length; sp++)
                {
                    if (specialChars[sp] == text[i])
                    {
                        num_SpChar++;
                    }
                }
                
                // check for vowels against the vowels array
                for (int vi = 0; vi < vowels.Length; vi++)
                {
                    if (text[i] == vowels[vi])
                    {
                        num_Vowels++;
                    }
                }
            }

            num_Const = num_Chars - num_SpChar - num_Vowels;  // do the math, if you take out the characters and vowels and what you have left.

            // print stats
            Console.WriteLine(text);  // I wanted to make it clean
            Console.WriteLine("Number of characters: {0}\nNumber of words: {1}\nNumber of vowels: {2}\nNumber of consonants: {3}\nNumber of special characters: {4}",
                num_Chars, num_Words, num_Vowels, num_Const, num_SpChar);

            // looping through the List for the longest words and the shortest word
            for (int i = 0; i < listWords.Count; i++)
            {
                if (listWords[i].Length > longestWord1.Length)
                {
                    string tempString = longestWord1;
                    longestWord1 = listWords[i];
                    longestWord2 = tempString;
                }
                if (listWords[i].Length < shortestWord.Length)
                {
                    shortestWord = listWords[i];

                }
            }

            // print the results
            Console.WriteLine("Longest word: {0}\n2nd longest word: {1}\nShortest word: {2}", longestWord1, longestWord2, shortestWord);
        }

        /// <summary>
        /// Finds the prime number and returns true. If the number is not prime returns false.
        /// </summary>
        /// <param name="number">a number to test if is prime number</param>
        /// <returns>the number is prime or not by a boolean value</returns>
        public static bool IsPrime(int number)
        {
            bool thatPrime = true;
            if (number < 3)
            {
                thatPrime = true;
            }
            for (int i = 2; i < Math.Sqrt(number); i++ )
            {
                if (number % i == 0) thatPrime = false;
            }
            return thatPrime;
        }

        /// <summary>
        /// Insert a dash between odd numbers.
        /// </summary>
        /// <param name="number">an large integer</param>
        /// <returns>a string of numbers with dashes between odd numbers</returns>
        public static string DashInsert(int number)
        {
            // sorry I didn't want to do the math for this, so I turned the number into a manageable array of characters, which are numbers
            string numbers = number.ToString();
            string retString = string.Empty;

            int start = 0;

            while (start < numbers.Length)
            {
                // concates the number to the string
                retString += numbers[start];
                // Found the odd numbers by finding the even numbers
                // I want to make sure that the next value is checked to, but does not exceed the bounds of the string
                if (Convert.ToInt32(numbers[start]) % 2 != 0 && start + 1 < numbers.Length)
                {
                    // looks at the next number and sees if is an odd number
                    if (Convert.ToInt32(numbers[start + 1]) % 2 != 0)
                    {
                        retString += '-';
                    }
                }
                start++;
            }
            return retString;
        }
    }
}
