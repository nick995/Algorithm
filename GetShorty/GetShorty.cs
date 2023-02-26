using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetShorty
{
    class GetShorty
    {

        public static void Main(string[] args)
        {



            string[] input = Console.ReadLine().Split(" ");
            //number of vertex
            int n = int.Parse(input[0]);
            //number of line.
            int m = int.Parse(input[1]);

            while (m != 0 && n != 0)
            {
                //Dictionary<int, LinkedList<Tuple<int, double>>> graph = new Dictionary<int, LinkedList<Tuple<int, double>>>();
                List<LinkedList<Tuple<int, double>>> graph = new List<LinkedList<Tuple<int, double>>>(10000);

                for(int i= 0; i < n; i++)
                {
                    graph.Add(new LinkedList<Tuple<int, double>>());
                }

                //do until below the m
                for (int i = 0; i < m; i++)
                {
                    input = Console.ReadLine().Split(" ");

                    int firstV = int.Parse(input[0]);
                    int secondV = int.Parse(input[1]);
                    double weight = double.Parse(input[2]);
                    //if (!graph.ContainsKey(firstV))
                    //{
                    //    graph.Add(firstV, new LinkedList<Tuple<int, double>>());
                    //}
                    //if (!graph.ContainsKey(secondV))
                    //{
                    //    graph.Add(secondV, new LinkedList<Tuple<int, double>>());
                    //}

                    if (graph[firstV].Count == 0)
                    {
                        graph[firstV] = new LinkedList<Tuple<int, double>>();
                    }

                    if (graph[secondV].Count == 0)
                    {
                        graph[secondV] = new LinkedList<Tuple<int, double>>();
                    }

                    graph[firstV].AddFirst(new Tuple<int, double>(secondV, weight));
                    graph[secondV].AddLast(new Tuple<int, double>(firstV, weight));

                }

                    dijkstra(graph);

                    input = Console.ReadLine().Split(" ");

                    n = int.Parse(input[0]);
                    m = int.Parse(input[1]);
                
            }
        }

        public static void dijkstra(List<LinkedList<Tuple<int, double>>> g)
        {
            double[] distance = new double[g.Count()];

            for (int i = 0; i < g.Count(); i++)
            {
                distance[i] = -1;
            }

            distance[0] = 1;

            //PriorityQueue<int, double> pq = new PriorityQueue<int, double>();

            PQ prq = new PQ();

            prq.Enqueue(1, 0);


            //pq.Enqueue(0, 1);

            while (prq.heap.Count() != 0)
            {
                int temp = prq.Dequeue().Value;

                foreach (Tuple<int, double> t in g[temp])
                {
                    if (distance[t.Item1] < distance[temp] * t.Item2)
                    {
                        distance[t.Item1] = t.Item2 * distance[temp];
                        prq.Enqueue(distance[temp], t.Item1);
                    }
                }
            }
            string result = string.Format("{0:0.###0}", distance[g.Count() - 1]);


            Console.WriteLine(result);

        }



    }

    class Item
    {
        //value
        public int Value { get; set; }
        //Priority that should be dpeneded on ordering
        public double Priority { get; set; }
    }

    class PQ
    {
        public List<Item> heap = new List<Item>();

        public void Enqueue(double priority, int value)
        {
            heap.Add(new Item() { Priority = priority, Value = value });

            int current = heap.Count - 1;

            while (current > 0)
            {
                int next = (current - 1) / 2;

                if (heap[current].Priority < heap[next].Priority)
                    break;

                Item temp = heap[current];
                heap[current] = heap[next];
                heap[next] = temp;
                current = next;
            }
        }

        public Item Dequeue()
        {
            Item ret = heap[0];
            int lastIdx = heap.Count - 1;

            heap[0] = heap[lastIdx];
            heap.RemoveAt(lastIdx);
            lastIdx--;

            int current = 0;
            while (true)
            {
                int left = 2 * current + 1;
                int right = 2 * current + 2;

                int next = current;

                if (left <= lastIdx && heap[next].Priority < heap[left].Priority)
                    next = left;
                if (right <= lastIdx && heap[next].Priority < heap[right].Priority)
                    next = right;

                if (current == next)
                    break;

                Item temp = heap[current];
                heap[current] = heap[next];
                heap[next] = temp;
                current = next;
            }

            return ret;
        }
    }
}