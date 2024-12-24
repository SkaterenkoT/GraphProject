using System;
using System.Linq;
using System.Net.Http.Headers;

namespace GraphLib
{
    public class Graph
    {
        public const int MaxVertices = 100; // Максимальное количество вершин
        public const int MaxEdges = MaxVertices * (MaxVertices - 1); // Максимальное количество рёбер для ненаправленного графа

        public Vertex[] vertices = new Vertex[MaxVertices];
        public Edge[] edges = new Edge[MaxEdges];

        private int vertexCount = 0;
        private int edgeCount = 0;

        private const int INF = int.MaxValue / 2;

        // Конструктор для инициализации с переданными вершинами и рёбрами
        public Graph(Vertex[] vert, Edge[] edg)
        {
            if (vert == null || edg == null)
            {
                throw new ArgumentNullException("Вершины и рёбра не могут быть null");
            }

            vertices = vert;
            edges = edg;
        }

        // Конструктор по умолчанию
        public Graph()
        {
            vertices = new Vertex[0];
            edges = new Edge[0];
        }

        // Конструктор с количеством вершин
        public Graph(int vertQuantity)
        {
            if (vertQuantity <= 0)
            {
                throw new ArgumentException("Количество вершин должно быть больше нуля");
            }

            vertices = new Vertex[vertQuantity];
            for (int i = 0; i < vertQuantity; i++)
            {
                vertices[i] = new Vertex((byte)i, new Coordinates(0, 0), i);
            }

            // Максимальное количество рёбер для ненаправленного графа
            edges = new Edge[vertQuantity * (vertQuantity - 1) / 2];
        }

        public Graph(int vertexCount, int maxEdgesPerVertex, int minEdgeWeight, int maxEdgeWeight, bool allowDirected)
        {
            if (vertexCount <= 0 || vertexCount > MaxVertices)
            {
                throw new ArgumentException($"Количество вершин должно быть больше нуля и не превышать {MaxVertices}");
            }

            this.vertexCount = vertexCount;
            Random random = new Random();

            // Создаём вершины
            for (byte i = 0; i < vertexCount; i++)
            {
                // Случайные координаты для примера
                vertices[i] = new Vertex(i, vertexCount);
            }

            // Создаём рёбра
            for (int i = 0; i < vertexCount; i++)
            {
                int edgesForVertex = random.Next(1, maxEdgesPerVertex + 1);
                for (int j = 0; j < edgesForVertex; j++)
                {
                    if (edgeCount >= MaxEdges) break;

                    Vertex start = vertices[i];
                    Vertex end = vertices[random.Next(0, vertexCount)];

                    if (start == end) continue; // Исключаем петли

                    // Проверяем, существует ли уже ребро между этими вершинами
                    if (EdgeExists(start, end)) continue;

                    int weight = random.Next(minEdgeWeight, maxEdgeWeight + 1);
                    bool isDirected = allowDirected && random.Next(0, 2) == 1;
                    edges[edgeCount++] = new Edge((byte)edgeCount, start, end, weight, isDirected);
                }
            }
        }
        private bool EdgeExists(Vertex start, Vertex end)
        {
            for (int i = 0; i < edgeCount; i++)
            {
                Edge e = edges[i];
                // Проверяем существование ребра между start и end
                if ((e.vert1 == start && e.vert2 == end) ||
                    (e.vert1 == end && e.vert2 == start && !e.directed))
                {
                    return true;
                }
            }
            return false;
        }
        // Метод для добавления вершины в граф
        public void AddVertex(Vertex newVertex)
        {
            if (vertexCount >= MaxVertices)
            {
                throw new InvalidOperationException("Достигнуто максимальное количество вершин.");
            }

            vertices[vertexCount++] = newVertex;
        }

        public void AddEdge(Edge newEdge)
        {
            if (edgeCount >= MaxEdges)
            {
                throw new InvalidOperationException("Достигнуто максимальное количество рёбер.");
            }

            edges[edgeCount++] = newEdge;
        }

        public void DelConnectedEdges(Vertex vert)
        {
            // Удаляем рёбра, связанные с удаляемой вершиной
            for (int i = 0; i < edgeCount; i++)
            {
                if (edges[i] != null && (edges[i].vert1 == vert || edges[i].vert2 == vert))
                {
                    edges[i].vert1.edges = RemoveEdgeFromVertex(edges[i].vert1.edges, edges[i]);
                    edges[i].vert2.edges = RemoveEdgeFromVertex(edges[i].vert2.edges, edges[i]);
                    edges[i] = null;
                }
            }

            // Сжимаем массив рёбер
            edges = edges.Where(e => e != null).ToArray();
            edgeCount = edges.Length;

            // Удаляем вершину из массива вершин
            int indexToRemove = Array.IndexOf(vertices, vert);
            if (indexToRemove >= 0)
            {
                for (int i = indexToRemove; i < vertexCount - 1; i++)
                {
                    vertices[i] = vertices[i + 1];
                }
                vertices[--vertexCount] = null;
            }

            // Перенумерация вершин
            for (int i = 0; i < vertexCount; i++)
            {
                vertices[i] = new Vertex((byte)i, vertices[i].coords, vertexCount - 1);
            }
        }

        private Edge[] RemoveEdgeFromVertex(Edge[] edgesArray, Edge edgeToRemove)
        {
            return edgesArray.Where(e => e != edgeToRemove).ToArray();
        }


        // Получение рёбер по вершинам
        public Edge GetEdge(Vertex startVertex, Vertex endVertex)
        {
            foreach (var edge in edges)
            {
                if ((edge.vert1 == startVertex && edge.vert2 == endVertex) ||
                    (!edge.directed && edge.vert1 == endVertex && edge.vert2 == startVertex))
                {
                    return edge;
                }
            }
            return null;
        }

        // Получение матрицы смежности
        public int[,] GetAdjacencyMatrix()
        {
            int size = vertices.Length;
            int[,] adjMatrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    adjMatrix[i, j] = (i == j) ? 0 : INF;
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

        // Поиск рёбер по номерам вершин
        public Edge[] FindEdges(byte[] verts)
        {
            Edge[] connectedEdges = new Edge[edges.Length];
            int count = 0;

            foreach (var edge in edges)
            {
                if (verts.Contains(edge.vert1.number) && verts.Contains(edge.vert2.number))
                {
                    connectedEdges[count++] = edge;
                }
            }

            // Обрезаем массив до актуального количества найденных рёбер
            Array.Resize(ref connectedEdges, count);
            return connectedEdges;
        }

        // Поиск вершины по координатам
        public Vertex FindVertByCoords(Coordinates point, int tolerance = 10)
        {
            foreach (var vertex in vertices)
            {
                if (Math.Abs(vertex.coords.x - point.x) <= tolerance &&
                    Math.Abs(vertex.coords.y - point.y) <= tolerance)
                {
                    return vertex;
                }
            }
            return null;
        }

        // Метод для поиска минимального каркаса для смешанного графа
        public Edge[] FindMinimumSpanningTree()
        {
            // Считаем количество рёбер (пропуская null)
            int edgeCount = 0;
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i] != null)
                {
                    edgeCount++;
                }
            }

            // Копируем только инициализированные рёбра
            Edge[] allEdges = new Edge[edgeCount];
            int index = 0;
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i] != null)
                {
                    allEdges[index++] = edges[i];
                }
            }

            // Сортируем рёбра по весу (простая сортировка вставками)
            for (int i = 1; i < allEdges.Length; i++)
            {
                Edge key = allEdges[i];
                int j = i - 1;
                while (j >= 0 && allEdges[j].level > key.level)
                {
                    allEdges[j + 1] = allEdges[j];
                    j--;
                }
                allEdges[j + 1] = key;
            }

            UnionFind uf = new UnionFind(vertices.Length);
            Edge[] mstEdges = new Edge[vertices.Length - 1];
            int mstCount = 0;

            for (int i = 0; i < allEdges.Length; i++)
            {
                Edge edge = allEdges[i];
                int v1 = edge.vert1.number;
                int v2 = edge.vert2.number;

                // Проверяем наличие цикла
                if (!uf.Connected(v1, v2))
                {
                    mstEdges[mstCount++] = edge;
                    uf.Union(v1, v2);

                    // Если найдено достаточно рёбер для остова, завершаем
                    if (mstCount == vertices.Length - 1)
                    {
                        break;
                    }
                }
            }

            // Обрезаем массив до фактического размера
            Edge[] finalMstEdges = new Edge[mstCount];
            for (int i = 0; i < mstCount; i++)
            {
                finalMstEdges[i] = mstEdges[i];
            }

            return finalMstEdges;
        }

        public void RemoveEdgeAt(int index)
        {
            if (index < 0 || index >= edges.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            // Сохраняем удаляемое ребро
            var edgeToRemove = edges[index];
            if (edgeToRemove == null)
            {
                throw new InvalidOperationException("The edge to remove is null.");
            }

            // Создаём новый массив без удаляемого ребра
            Edge[] newEdges = new Edge[edges.Length - 1];
            for (int i = 0, j = 0; i < edges.Length; i++)
            {
                if (i != index)
                {
                    newEdges[j++] = edges[i];
                }
            }
            edges = newEdges;

            // Удаляем ребро из списков рёбер связанных вершин
            if (edgeToRemove.vert1 != null && edgeToRemove.vert1.edges != null)
            {
                edgeToRemove.vert1.edges = RemoveEdgeFromList(edgeToRemove.vert1.edges, edgeToRemove);
            }
            if (edgeToRemove.vert2 != null && edgeToRemove.vert2.edges != null)
            {
                edgeToRemove.vert2.edges = RemoveEdgeFromList(edgeToRemove.vert2.edges, edgeToRemove);
            }

            // Перенумерация рёбер
            for (int i = 0; i < edges.Length; i++)
            {
                Edge oldEdge = edges[i];
                if (oldEdge == null)
                    break;
                edges[i] = new Edge((byte)i, oldEdge.vert1, oldEdge.vert2, oldEdge.level, oldEdge.directed);
            }
            edgeCount--;
        }

        private Edge[] RemoveEdgeFromList(Edge[] edgeList, Edge edgeToRemove)
        {
            int count = 0;
            for (int i = 0; i < edgeList.Length; i++)
            {
                if (edgeList[i] != edgeToRemove)
                {
                    count++;
                }
            }

            Edge[] newList = new Edge[count];
            int index = 0;
            for (int i = 0; i < edgeList.Length; i++)
            {
                if (edgeList[i] != edgeToRemove)
                {
                    newList[index++] = edgeList[i];
                }
            }

            return newList;
        }

        // Метод для нахождения максимального каркаса для смешанного графа
        public Edge[] FindMaximumSpanningTree()
        {
            // Считаем количество рёбер (пропуская null)
            int edgeCount = 0;
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i] != null)
                {
                    edgeCount++;
                }
            }

            // Копируем только инициализированные рёбра
            Edge[] allEdges = new Edge[edgeCount];
            int index = 0;
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i] != null)
                {
                    allEdges[index++] = edges[i];
                }
            }

            // Сортируем рёбра по убыванию веса для максимального остовного дерева
            for (int i = 1; i < allEdges.Length; i++)
            {
                Edge key = allEdges[i];
                int j = i - 1;
                while (j >= 0 && allEdges[j].level < key.level)  // Меняем знак для сортировки по убыванию
                {
                    allEdges[j + 1] = allEdges[j];
                    j--;
                }
                allEdges[j + 1] = key;
            }

            UnionFind uf = new UnionFind(vertices.Length);
            Edge[] mstEdges = new Edge[vertices.Length - 1];
            int mstCount = 0;

            for (int i = 0; i < allEdges.Length; i++)
            {
                Edge edge = allEdges[i];
                int v1 = edge.vert1.number;
                int v2 = edge.vert2.number;

                // Проверяем наличие цикла
                if (!uf.Connected(v1, v2))
                {
                    mstEdges[mstCount++] = edge;
                    uf.Union(v1, v2);

                    // Если найдено достаточно рёбер для остова, завершаем
                    if (mstCount == vertices.Length - 1)
                    {
                        break;
                    }
                }
            }

            // Обрезаем массив до фактического размера
            Edge[] finalMstEdges = new Edge[mstCount];
            for (int i = 0; i < mstCount; i++)
            {
                finalMstEdges[i] = mstEdges[i];
            }

            return finalMstEdges;
        }
        public bool OnlyInit()
        {
            if (vertices.Length != 0)
            {
                if (vertices[0] != null)
                {
                    return false;
                }
                return true;
            }
            return true;
        }
    }
}
