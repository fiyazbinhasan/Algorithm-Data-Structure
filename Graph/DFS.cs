using System;
using System.Collections.Generic;

namespace Graph
{
    public class DepthFirstSearch
    {
        readonly AdjacencyList _graph;
        readonly bool[] _visited;

        public DepthFirstSearch(AdjacencyList graph)
        {
            _graph = graph;
            _visited = new bool[graph.Vertices];
        }

        public void Traverse(int v, Action<int> action)
        {
            DfsVisit(v, _visited, action);
        }

        private void DfsVisit(int v, bool[] visited, Action<int> action)
        {
            visited[v] = true;
            action(v);

            var iterator = new AdjacencyListNeighborIterator(_graph, v);
            while (iterator.MoveNext())
            {
                var neighbor = (((int, int))iterator.Current).Item2;
                if (!visited[neighbor])
                    DfsVisit(neighbor, visited, action);
            }
        }
    }
}
