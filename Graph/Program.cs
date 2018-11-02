using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var adjacencyMatrix = new AdjacencyMatrix(4);
            adjacencyMatrix.AddEdge(0, 1);
            adjacencyMatrix.AddEdge(1, 2);
            adjacencyMatrix.AddEdge(2, 0);
            adjacencyMatrix.AddEdge(1, 3);

            //    -------
            //  /         \
            // 0 --- 1 --- 2
            //        \
            //          -- 3

            var graph = new Graph(adjacencyMatrix, 3);
            var iterator = graph.GetIterator();

            while (iterator.MoveNext())
            {
                var currentItem = iterator.Current;
                Console.WriteLine(currentItem);
            }

            Console.WriteLine(adjacencyMatrix.ToString());
            Console.ReadLine();
        }
    }
}