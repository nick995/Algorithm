using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    internal class GalaxyQuest
    {



        public static long total = 0;


        public static void Main()
        {

            string[] line = Console.ReadLine().Split();

            long diameter = (long) Math.Pow(double.Parse(line[0]), 2);

            long starCount = long.Parse(line[1]);


            List<Star> stars= new List<Star>();

            for(long i=0; i<starCount; i++)
            {
                string[] line2 = Console.ReadLine().Split();

                Star star= new Star();

                star.starX= long.Parse(line2[0]);
                star.starY= long.Parse(line2[1]);

                stars.Add(star);
            }
            
            if(findMajority(stars, diameter) == null)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine(total);
            }


        }

        public static Star findMajority(List<Star> stars, long diameter)
        {
            //if A.length ==0 return NO
            if(stars.Count == 0)
            {
                return null;
            }else if(stars.Count == 1)
            {
                return stars[0];
            }
            else
            {
                //divide A longo halves, A1 and A2
                List<Star> northGalaxy = stars.Take(stars.Count / 2).ToList();
                List<Star> southGalaxy = stars.Skip(stars.Count/2).ToList();

                Star northStar = findMajority(northGalaxy, diameter);    //pass half
                Star southStar = findMajority(southGalaxy, diameter);    //pass half

                if(northStar == null && southStar == null)
                {
                    return null;
                }else if(northStar == null)
                {
                    //count occurreneces of south in A, return y or no as appropriate
                    if(countOccurr(stars, southStar, diameter) > stars.Count/2)
                    {
                        total = countOccurr(stars, southStar, diameter);
                        return southStar;
                    }
                    else
                    {
                        return null;
                    }
                }else if(southStar == null)
                {
                    //count occurrences of x in A, return x or NO as appropriate 
                    if (countOccurr(stars, northStar, diameter) > stars.Count/2)
                    {
                        total = countOccurr(stars, northStar, diameter);
                        return northStar;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    //count occurrences of x and y in A, return x, y, or NO as appropriate
                    //


                    int southCount = countOccurr(stars, southStar, diameter);
                    int northCount = countOccurr(stars, northStar, diameter);

                    if(southCount == 0 && northCount == 0)
                    {
                        return null;
                    }
                    total = southCount > northCount ? total = southCount : total = northCount;
                    return southCount > northCount ? southStar : northStar;
                    

                }


            }
        }

        public static int countOccurr(List<Star> stars, Star star, long diameter)
        {

            int count = 0;
           
            foreach (Star s in stars)
            {
                
                    if (InGalaxy(star, s, diameter))
                    {
                        count++;
                        //Console.WriteLine(count);
                    }               
            }

            if(count <= stars.Count / 2)
            {
                return 0;
            }

            return count;
        }

        public static bool InGalaxy(Star s1, Star s2, long diameter)
        {
            //Console.Write("(" + s1.starX + " " +s1.starY+ ")" + " will compare with " + "(" + s2.starX + " " + s2.starY + ")" + "         ");
            //Console.WriteLine((Math.Pow(s1.starX - s2.starX, 2) - Math.Pow(s1.starY - s2.starY, 2)) + "   diameter = " + diameter);
            //Console.WriteLine(Math.Pow(s1.starX - s2.starX, 2) + Math.Pow(s1.starY - s2.starY, 2) <= diameter);
            
            if (Math.Pow(s1.starX - s2.starX, 2) + Math.Pow(s1.starY - s2.starY, 2) <= diameter)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }



    public class Star
    {
        public long starX { get; set; }
        public long starY { get; set; }
    }

}
