using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.Graph
{
    internal class _02_Depth_First_Search
    {
        public _02_Depth_First_Search()
        {
        }
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

        for (int i = 0; i < Vertices; i++)
        {
            Edges[i] = new List<int>();
        }
    }

    public void AddEdge(int vertex,List<int> nodes)
    {
        Edges[vertex].AddRange(nodes);
    }

    public List<int> GetDfs(int vertex)
    {
        bool[] visited=new bool[Vertices];
        List<int> path = new List<int>();
        Dfs(vertex,visited,path);

        return path;
    }

    void Dfs(int vertex, bool[] visited,List<int> path)
    {
        visited[vertex] = true;
        path.Add(vertex);
        foreach(var node in Edges[vertex])
        {
            if (!visited[node])
            {
                Dfs(node,visited,path);
            }
        }
    }

    public List<int> GetDfsIterative(int s)
    {
        bool[] visited = new bool[Vertices];
        List<int> path = new List<int>();
        Stack<int> stack=new Stack<int>();
        path.Add(s);
        stack.Push(s);

        while(stack.Count > 0)
        {
            int node = stack.Peek();
            stack.Pop();

            if (!visited[node])
            {
                path.Add(node);
                visited[node]=true;
            }

            foreach(var child in Edges[node])
            {
                if (!visited[child])
                {
                    stack.Push(child);
                }
            }

        }

        return path;
    }
}

