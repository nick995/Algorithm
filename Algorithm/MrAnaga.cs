using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    internal class MrAnagaTime
    {
        public const int REPTS = 1000;

        public const int DURATION = 10000;

        public const int Bound = 1000;

        //Number of words.
        public const int N = 1000;

        public const int MAXIMUMN = 10000;

        public const int MAXIMUMK = 1000;

        //Length of word
        public const int K = 5;



        public static void Main()
        {
            //TimeAnagmaN(10000);

            TimeAnagmaK(1);


        }

        public static void TimeAnagmaN(int maximum)
        {


            String sortedWord = "";

            for (int probSize = 1000; probSize <= maximum; probSize += 1000)
            {

                Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
                Dictionary<string, bool> solutions = new Dictionary<string, bool>();
                Dictionary<string, bool> rejected = new Dictionary<string, bool>();

                string temp = "";


                for (int i = 0; i < probSize; i++)
                {
                    //constructor dictionary.

                    temp = WordFinder(K);

                    if (dictionary.ContainsKey(temp))
                    {   
                        while (dictionary.ContainsKey(temp))
                        {
                            temp = WordFinder(K);
                        }
                        dictionary.Add(temp, false);
                    }
                    else
                    {
                        dictionary.Add(temp, false);
                    }
                }

                Stopwatch sw = new Stopwatch();


                for (int k = 0; k < REPTS; k++)
                {
                    sw.Start();
                    foreach (string word in dictionary.Keys)
                    {

                        sortedWord = string.Concat(word.OrderBy(c => c));

                        if (solutions.ContainsKey(sortedWord))
                        {
                            solutions.Remove(sortedWord);
                            rejected.Add(sortedWord, false);
                        }
                        else if (!rejected.ContainsKey(sortedWord))
                        {
                            solutions.Add(sortedWord, false);
                        }
                    }
                    sw.Stop();

                    solutions.Clear();
                    rejected.Clear();
                }

                Console.WriteLine(sw.ElapsedTicks);

                Console.WriteLine("CASE 1 : problem size : " + probSize + " average : " + msecs(sw) / REPTS);

                //Console.WriteLine("CASE 2 : problem size : " + probSize + " average : " + time / REPTS);
                Console.WriteLine();



            }


            //// Construct a sorted array
            //for (int i = 0; i < size; i++)
            //{
            //    data[i] = i;
            //}

            //// Create a stopwatch
            //Stopwatch sw = new Stopwatch();

            //// Time REPTS operations
            //for (int i = 0; i < REPTS; i++)
            //{
            //    sw.Start();
            //    BinarySearch(data, size - 1);
            //    sw.Stop();
            //}

            // Return the average number of milliseconds that elapsed
            //return msecs(sw) / REPTS;

        }

        public static void TimeAnagmaK(int t)
        {
            String sortedWord = "";

            for (int probSize = 100; probSize <= 1000; probSize += 100)
            {

                Dictionary<string, bool> dictionary = new Dictionary<string, bool>();

                Dictionary<string, bool> solutions = new Dictionary<string, bool>();
                Dictionary<string, bool> rejected = new Dictionary<string, bool>();

                string temp = "";

                for (int i = 0; i < 2000; i++)
                {
                    //constructor dictionary.

                    temp = WordFinder(probSize);

                    if (dictionary.ContainsKey(temp))
                    {
                        while (dictionary.ContainsKey(temp))
                        {
                            temp = WordFinder(probSize);
                        }
                        dictionary.Add(temp, false);
                    }
                    else
                    {
                        dictionary.Add(temp, false);
                    }
                }
                Stopwatch sw = new Stopwatch();


                for (int k = 0; k < REPTS; k++)
                {
                    sw.Start();
                    foreach (string word in dictionary.Keys)
                    {
                        sortedWord = string.Concat(word.OrderBy(c => c));

                        if (solutions.ContainsKey(sortedWord))
                        {
                            solutions.Remove(sortedWord);
                            rejected.Add(sortedWord, false);
                        }
                        else if (!rejected.ContainsKey(sortedWord))
                        {
                            solutions.Add(sortedWord, false);
                        }
                    }
                    sw.Stop();

                    solutions.Clear();
                    rejected.Clear();
                }

                Console.WriteLine("problem size : " + probSize + " average : " + msecs(sw) / REPTS);

                dictionary.Clear();
            }
        }

        /// <summary>
        /// create random word
        /// </summary>
        /// <param name="requestedLength"></param>
        /// <returns></returns>
        public static string WordFinder(int requestedLength)
        {
            Random rnd = new Random();
            string[] wordList = { "a", "e", "i", "o", "u", "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };


            StringBuilder word = new StringBuilder();

            if (requestedLength == 1)
            {
                word.Append(GetRandomLetter(rnd, wordList));
            }
            else
            {
                for (int i = 0; i < requestedLength; i++)
                {
                    word.Append(GetRandomLetter(rnd, wordList));
                }
            }

            return word.ToString();
        }

        private static string GetRandomLetter(Random rnd, string[] letters)
        {
            return letters[rnd.Next(0, letters.Length - 1)];
        }

        public static double msecs(Stopwatch sw)
        {
            return (((double)sw.ElapsedTicks) / Stopwatch.Frequency) * 1000;
        }
    }
}