using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Add(4);
            binaryTree.Add(1);
            binaryTree.Add(5);

            Console.WriteLine("Pre order traversal");
            binaryTree.PreOrderTraversal((value) => Console.WriteLine(value));
            Console.WriteLine("In order traversal");
            binaryTree.InOrderTraversal((value) => Console.WriteLine(value));
            Console.WriteLine("Post order traversal");
            binaryTree.PostOrderTraversal((value) => Console.WriteLine(value));

            Console.WriteLine($"Contains 1? {binaryTree.Contains(1)}");
            Console.WriteLine($"Removed 1? {binaryTree.Remove(1)}");

            Console.WriteLine($"Enumerate using in order");
            foreach (var node in binaryTree)
            {
                Console.WriteLine(node);
            }

            Console.ReadLine();
        }
    }
}
