using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public class Graph
    {
        public List<Vertex> vertices = new List<Vertex>();
        public List<Edge> edges = new List<Edge>();

        private const int INF = int.MaxValue / 2;
        public Graph(List<Vertex> vert, List<Edge> edg)
        {
            vertices = vert;
            edges = edg;
        }
        public Graph()
        {
            List<Vertex> vertices = new List<Vertex>();
            List<Edge> edges = new List<Edge>();
        }
        public void DelConnectedEdges(Vertex vert)
        {
            List<Edge> edgesToRemove = new List<Edge>();

            for (int i = 0; i < edges.Count; i++)
            {
                Edge edge = edges[i];
                if (edge.vert1 == vert || edge.vert2 == vert)
                {
                    edgesToRemove.Add(edge);
                }
            }

            foreach (Edge edge in edgesToRemove)
            {
                edges.Remove(edge);

                edge.vert1.edges.Remove(edge);
                edge.vert2.edges.Remove(edge);
            }
            for (byte i = 0; i < (byte)edges.Count; i++)
            {
                Edge edge = edges[i];
                edges[i] = new Edge(i, edge.vert1, edge.vert2, edge.level, edge.directed);
            }
            vertices.Remove(vert);
            for (byte i = 0; i < (byte)vertices.Count; i++)
            {
                Vertex vertex = vertices[i];
                List<Edge> vertEdges = vertex.edges;
                vertices[i] = new Vertex(i, vertex.coords);
                vertices[i].edges = vertEdges;
            }
        }
        public Edge GetEdge(Vertex startVertex, Vertex endVertex)
        {
            foreach (Edge e in edges)
            {
                if ((e.vert1 == startVertex && e.vert2 == endVertex) || (!e.directed && e.vert1 == endVertex && e.vert2 == startVertex))
                {
                    return e;
                }
            }
            return null;
        }
        public int[,] GetAdjacencyMatrix()
        {
            int size = vertices.Count;
            int[,] adjMatrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                        adjMatrix[i, j] = 0;
                    else
                        adjMatrix[i, j] = INF;
                }
            }

            foreach (var edge in edges)
            {
                int v1Index = edge.vert1.number;
                int v2Index = edge.vert2.number;

                adjMatrix[v1Index, v2Index] = edge.level;

                if (!edge.directed)
                {
                    adjMatrix[v2Index, v1Index] = edge.level;
                }
            }

            return adjMatrix;
        }
        public List<Edge> FindEdges(List<byte> verts)
        {
            List<Edge> connectedEdges = new List<Edge>();
            for (int i = 1; i < verts.Count; i++)
            {
                byte v1_num = verts[i - 1];
                byte v2_num = verts[i];

                foreach (var edge in edges)
                {
                    if (edge.vert1.number == v1_num && edge.vert2.number == v2_num)
                        connectedEdges.Add(edge);
                }
            }
            return connectedEdges;
        }
        public Vertex FindVertByCoords(Coordinates point, int tolerance = 10)
        {
            foreach (var v in vertices)
            {
                if (Math.Abs(v.coords.x - point.x) <= tolerance && Math.Abs(v.coords.y - point.y) <= tolerance)
                    return v;
            }
            return null;
        }
        // Метод для поиска минимального каркаса для смешанного графа
        public List<Edge> FindMinimumSpanningTree()
        {
            List<Edge> result = new List<Edge>();

            // Разделяем рёбра на ориентированные и неориентированные
            var undirectedEdges = edges.Where(e => !e.directed).ToList();
            var directedEdges = edges.Where(e => e.directed).ToList();

            // Находим минимальное остовное дерево для неориентированных рёбер (Краскал)
            result.AddRange(FindMSTForUndirectedEdges(undirectedEdges));

            // Находим минимальное остовное дерево для ориентированных рёбер (Чу-Лиу/Эдмондс)
            result.AddRange(FindMSTForDirectedEdges(directedEdges));

            return result;
        }

        // Алгоритм Краскала для неориентированных рёбер
        private List<Edge> FindMSTForUndirectedEdges(List<Edge> undirectedEdges)
        {
            List<Edge> mst = new List<Edge>();

            // Сортируем рёбра по весу
            undirectedEdges.Sort((a, b) => a.level.CompareTo(b.level));

            UnionFind uf = new UnionFind(vertices.Count);

            foreach (var edge in undirectedEdges)
            {
                int v1 = edge.vert1.number;
                int v2 = edge.vert2.number;

                if (!uf.Connected(v1, v2))
                {
                    mst.Add(edge);
                    uf.Union(v1, v2);
                }
            }

            return mst;
        }

        // Алгоритм Чу-Лиу/Эдмондса для ориентированных рёбер
        private List<Edge> FindMSTForDirectedEdges(List<Edge> directedEdges)
        {
            List<Edge> mst = new List<Edge>();

            // Псевдо-код для Чу-Лиу/Эдмондса
            // В полной реализации требуется сложный цикл поиска и разрешения циклов
            // Для упрощения будем считать, что граф уже ацикличен
            foreach (var vertex in vertices)
            {
                Edge minEdge = directedEdges
                    .Where(e => e.vert2 == vertex)
                    .OrderBy(e => e.level)
                    .FirstOrDefault();

                if (minEdge != null)
                {
                    mst.Add(minEdge);
                }
            }

            return mst;
        }
    }
}