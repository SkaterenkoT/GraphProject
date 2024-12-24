using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public class Vertex    // Вершина
    {
        public byte number { get; }
        public Edge[] edges;
        public Coordinates coords;
        private int nextEl = 0;

        // Конструктор с количеством рёбер
        public Vertex(byte _number, int edgeQuantity)
        {
            number = _number;
            edges = new Edge[edgeQuantity]; // Инициализируем массив рёбер с заданным количеством
        }

        // Конструктор с координатами и количеством рёбер
        public Vertex(byte _number, Coordinates coordinates, int edgeQuantity)
        {
            number = _number;
            coords = coordinates;
            edges = new Edge[edgeQuantity];
        }

        public void AddEdge(Edge edge)
        {
            if (nextEl < edges.Length)
            {
                edges[nextEl++] = edge;
            }
            else
            {
                // Если места нет, увеличиваем размер массива и добавляем новое ребро
                Array.Resize(ref edges, edges.Length * 2); // Увеличиваем размер массива в 2 раза
                edges[nextEl++] = edge; // Добавляем ребро в новый массив
            }
        }

        // Метод для удаления всех рёбер из вершины
        public void RemoveAllEdges()
        {
            edges = new Edge[edges.Length]; // Создаем новый массив с тем же размером
        }

        // Метод для удаления конкретного ребра
        public void RemoveEdge(Edge edge)
        {
            int indexToRemove = -1;
            // Ищем индекс ребра в массиве
            for (int i = 0; i < nextEl; i++)
            {
                if (edges[i] == edge)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove != -1)
            {
                // Сдвигаем элементы массива после удаленного ребра
                for (int i = indexToRemove; i < nextEl - 1; i++)
                {
                    edges[i] = edges[i + 1];
                }
                edges[nextEl - 1] = null; // Обнуляем последний элемент
                nextEl--; // Уменьшаем количество рёбер
            }
        }
    }
}
