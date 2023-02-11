using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Class1
    {
        public static void main(string[] args)
        {
            int f(int[] A, int k)
            {
                int sum = 0;
                //partition A using v as the pivot and returns the index where v ends up.
                int stop = partition(A, select(A, k));
                for (int i = 0; i < stop; i++)
                {
                    sum += A[i];
                }
                return sum;
            }
        }
    }
}
