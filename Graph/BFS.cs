using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class BreadthFirstSearch
    {
        private readonly bool[] _visited;
        private Queue<int> _queue;
        private readonly AdjacencyList _graph;

        public BreadthFirstSearch(AdjacencyList graph)
        {
            _graph = graph;
            _visited = new bool[graph.Vertices];
            _queue = new Queue<int>();
        }

        public IEnumerable<int> Traverse(int startingVertex)
        {
            _visited[startingVertex] = true;
            _queue.Enqueue(startingVertex);

            while (_queue.Count != 0)
            {
                startingVertex = _queue.Dequeue();
                var iterator = new AdjacencyListNeighborIterator(_graph, startingVertex);

                while (iterator.MoveNext())
                {
                    var neighbor =  (((int, int)) iterator.Current).Item2;

                    if (!_visited[neighbor])
                    {
                        _visited[neighbor] = true;
                        _queue.Enqueue(neighbor);
                    }
                }

                yield return startingVertex;
            }
        }
    }
}
