using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Graph
{
    internal class _01_Breadth_First_Search
    {
        public _01_Breadth_First_Search()
        {
        }

        public List<int> GetBfs(int Vertices,List<List<int>> adj)
        {
            Graph graph = new Graph(Vertices);

            for(int i=0;i<adj.Count;i++)
            {
                graph.AddEdge(i, adj[i]);
            }

            return graph.Bfs(0);
        }

    }

    class Graph
    {
        int Vertices { get; set; }
        List<int>[] Edges { get; set; }

        public Graph(int vertices)
        {
            Vertices = vertices;
            Edges = new List<int>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                Edges[i] = new List<int>();
            }
        }

        public void AddEdge(int vertex,List<int> nodes)
        {
            Edges[vertex].AddRange(nodes);
        }

        public List<int> Bfs(int vertex)
        {
            bool[] visited = new bool[Vertices];

            List<int> path = new List<int>();
            Queue<int> queue = new Queue<int>();

            visited[vertex] = true;
            queue.Enqueue(vertex);

            while(queue.Count > 0)
            {
                int node=queue.Peek();
                visited[node] = true;
                for(int i = 0; i < Edges[node].Count; i++)
                {
                    int child = Edges[node][i];
                    if (!visited[child])
                    {
                        visited[child] = true;
                        path.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }
            return path;
        }
    }
}
