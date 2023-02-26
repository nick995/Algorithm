using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class AutoSink
    {

        public static Dictionary<City, List<City>> cityList = new Dictionary<City, List<City>>();


        public static Dictionary<string, City> tempList = new Dictionary<string, City>();

        public static int MaxPrice;

        public static void Main(string[] args)
        {



            int cityCount = int.Parse(Console.ReadLine());

            MaxPrice = cityCount*10000;
            //initalize the citylist
            for (int i = 0; i < cityCount; i++)
            {
                string[] cityInfo = Console.ReadLine().Split(" ");

                //create the new city 
                City city = new City(cityInfo[0], int.Parse(cityInfo[1]));

                //Temporary holing the city.
                tempList.Add(cityInfo[0], city);

                //adding to citylist
                if (!cityList.ContainsKey(city))
                {
                    cityList.Add(city, new List<City>());
                }
            }

            //reading the number of the connection.
            int connectionCount = int.Parse(Console.ReadLine());

            //adding edge
            for (int j = 0; j < connectionCount; j++)
            {
                string[] connectCity = Console.ReadLine().Split(" ");

                cityList[tempList[connectCity[0]]].Add(tempList[connectCity[1]]);
            }

            int calNumber = int.Parse(Console.ReadLine());

            //sorting 

            Stack<City> topolResult = TopologicalSort();

            for(int k=0; k<calNumber; k++)
            {
                string[] startToDest = Console.ReadLine().Split(" ");

                int answer = CalMimum(tempList[startToDest[0]], tempList[startToDest[1]], topolResult);

                if(answer == -1)
                {
                    Console.WriteLine("NO");
                }
                else
                {
                    Console.WriteLine(answer);
                }
            }
        }

        public static int CalMimum(City start, City dest, Stack<City> topolResult)
        {

            Dictionary<City, int> totalPrice = new Dictionary<City, int>();

            totalPrice.Add(start, 0);

            foreach (City topolCity in topolResult)
            {

                if (!totalPrice.ContainsKey(topolCity) && !start.Equals(topolCity))
                {
                    totalPrice.Add(topolCity, MaxPrice);
                }

                foreach(City city in cityList[topolCity])
                {
                    if (!totalPrice.ContainsKey(city))
                    {
                        totalPrice.Add(city, MaxPrice);
                    }

                    if (totalPrice[topolCity] + city.price < totalPrice[city])
                    {
                        totalPrice[city] = totalPrice[topolCity] + city.price;
                    }
                }
            }

            return totalPrice[dest] != MaxPrice ? totalPrice[dest] : -1;

        }


        public static Stack<City> TopologicalSort()
        {


            Stack<City> stack = new Stack<City>();

            foreach (City city in cityList.Keys)
            {
                if (city.visited == false)
                {

                    TopologicalRecursive(stack, city);

                }
            }

            return stack;
        }

        public static void TopologicalRecursive(Stack<City> stack, City city)
        {
            city.visited = true;

            foreach (City recurCity in cityList[city])
            {
                //when visit the next city, add the price.
                if (recurCity.visited == false)
                {
                    TopologicalRecursive(stack, recurCity);
                }
            }

            stack.Push(city);
        }
    }





    public class City
    {
        public City(string cityName, int price)
        {
            this.cityName = cityName;
            this.price = price;
            visited = false;
        }

        public bool visited { get; set; }
        public string cityName { get; set; }
        public int price { get; set; }
    }



}



