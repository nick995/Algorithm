using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    internal class MrAnaga
    {
        public static void Main()
        {

            string[] line = Console.ReadLine().Split();

            int number = int.Parse(line[0]);

            Dictionary<string, bool> dictionary = new Dictionary<string, bool>();

            for (int i = 0; i < number; i++)
            {
                dictionary.Add(Console.ReadLine().ToString(), false);
            }


            Dictionary<string, bool> solutions = new Dictionary<string, bool>();
            Dictionary<string, bool> rejected = new Dictionary<string, bool>();

            String sortedWord = "";

            foreach (string word in dictionary.Keys)
            {
                sortedWord = String.Concat(word.OrderBy(c => c));

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
            Console.WriteLine(solutions.Count);
        }
    }
}