using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    internal class CeilingFunction
    {
        public static void Main()
        {

            string[] line = Console.ReadLine().Split();

            int n = int.Parse(line[0]);

            int k = int.Parse(line[1]);

            long uniqueNumber = 0;

            double total = Math.Pow(2, k)-1;

            HashSet<long> shapeNumber = new HashSet<long>();

            List<double> shape = new List<double>((int) total);


            for(int i=0 ; i<n; i++)
            {
                string[] value = Console.ReadLine().Split();

                for(int j=0; i<k; j++)
                {
                    
                }

            }

        }

        public static int searchIndex(List<double> shapeList, int key)
        {
            int index = 0;

            while (shapeList[index] != null)
            {
                if (shapeList[index].Equals(null))
                {
                    return index;
                }else if (shapeList[index] > key)
                {
                    index = index * 2 + 1;
                }else if (shapeList[index] < key)
                {
                    index = index * 2 + 2;
                }

            }


            return 0;
        }

       

    }
}
