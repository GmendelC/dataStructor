using System;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            // test of FindClosestAmount
            //Create tree
            BST<int> tree = new BST<int>();

            int size = 10000;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                tree.Add(rand.Next(size * 10));//Adding numbers randomly in tree
            }
            tree.Add(0);
            int a;
            bool res = tree.FindClosestAmount(0,out a);

        }
    }
}
