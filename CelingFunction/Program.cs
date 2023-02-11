using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    internal class BinaryShape
    {
        public Node root;

        public static int matched = 0;
        
        //constructor
        public BinaryShape()
        {
            root = null;
        }

        public void InsertNode(int value)
        {
            Node newNode = new Node();
            newNode.Data = value;

            if(root == null)
            {
                root = newNode;
            }
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if(value< current.Data)
                    {
                        current = current.LeftNode;

                        if(current == null)
                        {
                            parent.LeftNode = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.RightNode;
                        if (current == null)
                        {
                            parent.RightNode = newNode;
                            break;
                        }
                    }
                }
            }

        }



        public static void Main()
        {

            string[] line = Console.ReadLine().Split();

            //number of bst
            int n = int.Parse(line[0]);
            // number of values
            int k = int.Parse(line[1]);

            int answer = n;
                        
            List<BinaryShape> list = new List<BinaryShape>();

            Dictionary<bool, BinaryShape> listDic = new Dictionary<bool, BinaryShape>();

            //construct binaryTree and insert to List
            for(int i=0; i<n; i++)
            {
                BinaryShape binaryShape = new BinaryShape();

                string[] values = Console.ReadLine().Split();

                for (int j=0; j<k; j++)
                {
                    binaryShape.InsertNode(int.Parse(values[j]));                    
                }

                list.Add(binaryShape);




            } 
            
            for(int i=0; i<list.Count; i++)
            {
                for(int j= i+1; j<list.Count; j++)
                {

                    matched = 0;

                    PreOrderTraver(list[i].root, list[j].root);

                    if(matched == k)
                    {
                        answer--;
                        break;
                    }
                }
            }

            Console.WriteLine(answer);

        }

        public static void PreOrderTraver(Node node, Node node2)
        {

            if (node == null || node2 == null)
            {
                return;
            }
            else
            {
                if ((node != null && node2 != null))
                {
                    matched++;
                }

                PreOrderTraver(node.LeftNode, node2.LeftNode);

                PreOrderTraver(node.RightNode, node2.RightNode);
            }
        }

        

    }

    public class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Data { get; set; }
    }
}
