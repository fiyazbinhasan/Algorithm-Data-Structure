using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            //var adjacencyMatrix = new AdjacencyMatrix(4);
            //adjacencyMatrix.AddEdge(0, 1);
            //adjacencyMatrix.AddEdge(1, 2);
            //adjacencyMatrix.AddEdge(2, 0);
            //adjacencyMatrix.AddEdge(1, 3);

            ////    -------
            ////  /         \
            //// 0 --- 1 --- 2
            ////        \
            ////          -- 3

            //var iterator = new AdjacencyMatrixNeighborIterator(adjacencyMatrix, 3);

            //while (iterator.MoveNext())
            //{
            //    var currentItem = iterator.Current;
            //    Console.WriteLine(currentItem);
            //}

            // Directed Adjacency Graph

            AdjacencyList list = new AdjacencyList(4);
            list.AddEdge(0, 0);
            list.AddEdge(0, 1);
            list.AddEdge(1, 2);
            list.AddEdge(2, 0);
            list.AddEdge(2, 3);
            list.AddEdge(1, 3);
            list.AddEdge(3, 1);

            Console.WriteLine(list.Contains(1, 3));
            Console.WriteLine(list.Contains(3, 0));

            var iterator = new AdjacencyListNeighborIterator(list, 2);

            while (iterator.MoveNext())
            {
                var currentItem = iterator.Current;
                Console.WriteLine(currentItem);
            }

            Console.WriteLine(list.ToString());
            Console.ReadLine();
        }
    }
}