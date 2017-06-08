using System;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create tree
            BST<int> tree = new BST<int>();

            int size = 10000;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                tree.Add(rand.Next(size * 3));//Adding numbers randomly in tree
            }
            Console.WriteLine(tree.GetLevels());//Print the amount of leaves

            for (int i = 0; i < size*3; i++)
            {
                tree.Remove(rand.Next(size*3));//Remove numbers randomly from tree
            }

            Console.WriteLine(tree.GetLevels());//Print the amount of leaves

        }
    }
}
