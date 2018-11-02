using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace GraphAndPath
{
    public class AdjacencyMatrix
    {
        public AdjacencyMatrix(int vertices)
        {
            if (vertices < 0)
                throw new ArgumentException("Graph should have at least one vertex");

            Vertices = vertices;
            Edges = 0;

            Matrix = new bool[vertices, vertices];
        }

        public int Vertices { get; }

        public int Edges { get; set; }

        public bool[,] Matrix { get; set; }

        // if edges are less than squared of vertices then go for adjacency list

        // 2, 1 => 1 > 2 * (2 - 1) / 2  = 1 + 2 = 3 false
        // 2, 4 => 2 > 4 * 3 / 2 = 6 + 2 = 8 false
        // 4, 2 = > 4 > 2 * 1 / 4 = 0.5 = 0 true => to many edges
        public AdjacencyMatrix(int vertices, int edges) : this(vertices)
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
            if (Matrix[u, v]) return;
            Matrix[u, v] = true;
            Matrix[v, u] = true;
            Edges++;
        }

        public bool Contains(int u, int v)
        {
            return Matrix[u , v];
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append($"{Vertices} {Edges} \n");
            for (int v = 0; v < Vertices; v++)
            {
                s.Append(v + ": ");
                var iterator = new Graph(this, v).GetIterator();

                while (iterator.MoveNext())
                {
                    s.Append(iterator.Current + " ");
                }
                s.Append("\n");
            }
            return s.ToString();
        }
    }
    public interface IGraphIterable
    {
        GraphIterator GetIterator();
    }
    public class Graph : IGraphIterable
    {
        readonly AdjacencyMatrix _matrix;
        private readonly int _vertex;

        public Graph(AdjacencyMatrix matrix, int vertex)
        {
            _matrix = matrix;
            _vertex = vertex;
        }

        public GraphIterator GetIterator()
        {
            return new GraphIterator(_matrix, _vertex);
        }
    }

    public class GraphIterator : IIterator
    {
        private readonly int _vertex;
        private int _index = -1;
        private readonly AdjacencyMatrix _matrix;
        
        public GraphIterator(AdjacencyMatrix matrix, int vertex)
        {
            _matrix = matrix;
            _vertex = vertex;
        }

        public bool MoveNext()
        {
            _index++;
            while (_index < _matrix.Vertices)
            {
                if (_matrix.Matrix[_vertex, _index]) return true;
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

    public interface IIterator
    {
        bool MoveNext();
        Object Current { get; }
        void Reset();
    }
}
