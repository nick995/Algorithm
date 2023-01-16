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

            List<string> input = new List<string>();

            for (int i=0; i<number; i++)
            {
                input.Add(Console.ReadLine());
            }

            //bool for if it's checked of not.
            Dictionary<string, bool> tempDic = new Dictionary<string, bool>();

            //count for how many words are NOT anaga.
            int count = input.Count;
            String sortWord = "";

            for (int i = 0; i < input.Count; i++)
            {
                //sort word 
                sortWord = String.Concat(input[i].OrderBy(c => c));
                //if it's first insert just add it.
                if (i == 0)
                {
                    tempDic.Add(sortWord.ToString(), false);
                }
                else
                {
                    // if it's cotained at dictionary.
                    if (tempDic.ContainsKey(sortWord))
                    {
                        // if stored sortword is not removed yet.
                        if (!tempDic[sortWord])
                        {
                            count -= 2;
                            tempDic[sortWord] = true;
                        }
                        else
                        {
                            count--;
                        }
                    }
                    else
                    {
                        tempDic.Add(sortWord, false);
                    }
                }
            }
            Console.WriteLine(count);

        }
    }
}
