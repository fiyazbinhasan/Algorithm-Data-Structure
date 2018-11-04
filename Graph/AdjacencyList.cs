using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class AdjacencyList
    {
        public int Vertices { get; }
        public int Edges { get; set; }
        public LinkedList<int>[] List { get; set; }

        public AdjacencyList(int vertices)
        {
            Vertices = vertices;
            Edges = 0;
            List = new LinkedList<int>[vertices];

            for (int i = 0; i < vertices; i++)
                List[i] = new LinkedList<int>();
        }
        public AdjacencyList(int vertices, int edges) : this(vertices)
        {
            if (edges > (long)vertices * (vertices - 1) / 2 + vertices) throw new ArgumentException("Too many edges");
            if (edges < 0) throw new ArgumentException("Too few edges");


            while (Edges != edges)
            {
                int u = new Random().Next(vertices);
                int v = new Random().Next(vertices);
                AddEdge(u, v);
            }
        }

        public void AddEdge(int u, int v)
        {
            List[u].AddLast(v);
            List[v].AddLast(u);
            Edges++;
        }

        public bool Contains(int u, int v)
        {
            return List[u].Contains(v);
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append($"Vertices : {Vertices} \t Edges: {Edges} \n");

            for (int v = 0; v < Vertices; v++)
            {
                s.Append(v + ": ");

                foreach (var u in List[v])
                {
                    s.Append(u + " ");
                }
                s.Append("\n");
            }
            return s.ToString();
        }
    }
    public class AdjacencyListNeighborIterator : IIterator
    {
        private readonly int _vertex;
        private int _index = -1;
        private readonly AdjacencyList _list;

        public AdjacencyListNeighborIterator(AdjacencyList list, int vertex)
        {
            _list = list;
            _vertex = vertex;
        }

        public bool MoveNext()
        {
            _index++;
            while (_index < _list.Vertices)
            {
                if (_list.List[_index].Contains(_vertex)) return true;
                _index++;
            }
            return false;
        }

        public object Current => (_vertex, _index);
        public void Reset()
        {
            _index = -1;
        }
    }
}
