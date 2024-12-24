using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using GraphLib;
using System.Drawing.Drawing2D;

namespace TryForGraph
{
    public partial class initGraph : Form
    {
        private Graph mainGraph;
        private Coordinates tempLineStart = null;
        private const int VertexRadius = 20;
        private const int INF = int.MaxValue / 2;
        private Mode mode = Mode.Move;
        private int actualEdgeCount = 0;

        private bool isDragging = false;
        private Vertex draggedVert = null;

        public initGraph(Graph graph, bool filled)
        {
            InitializeComponent();
            if (graph != null)
                mainGraph = graph;
            else
                mainGraph = new Graph();

            int actualVertCount = 0;
            for (int i = 0; i < mainGraph.vertices.Length; i++)
            {
                if (mainGraph.vertices[i] != null)
                    actualVertCount++;
                else
                    break;
            }
            VertMaxCountLabel.Text = $"Число вершин: {actualVertCount}";

            for (int i = 0;i < mainGraph.edges.Length;i++)
            {
                if (mainGraph.edges[i] != null)
                    actualEdgeCount++;
                else
                    break;
            }
            EdgesCountLabel.Text = $"Число ребер: {actualEdgeCount}";
            this.DoubleBuffered = true;
            this.KeyPreview = true;

            ToolTip forMove = new ToolTip();
            forMove.IsBalloon = true;
            forMove.ToolTipTitle = "Кнопка move";
            forMove.InitialDelay = 500;
            forMove.SetToolTip(moveVertbtn, "Режим для перемещения вершин.\nДля перетаскивания нажмите левой кнопкой мыши по вершине и удерживайте.");

            ToolTip createEdge = new ToolTip();
            createEdge.IsBalloon = true;
            createEdge.ToolTipTitle = "Кнопка v→v";
            createEdge.InitialDelay = 500;
            createEdge.SetToolTip(createEdgebtn, "Режим для создания ребер.\nДля создания выберите левой кнопкой мыши две вершины, а затем во всплывающем окне заполните информацию о ребре.");

            ToolTip deleteItems = new ToolTip();
            deleteItems.IsBalloon = true;
            deleteItems.ToolTipTitle = "Кнопка del";
            deleteItems.InitialDelay = 500;
            deleteItems.SetToolTip(deleteItemsbtn, "Режим для удаления ребер.\nДля удаления кликните левой кнопкой мыши по ребру");

        }

        // Обрабатываем правый клик мыши для создания рёбер
        private void initGraph_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mode == Mode.Merge && mainGraph.vertices != null)
            {
                foreach (var v in mainGraph.vertices)
                {
                    if (v == null)
                        break;
                    if (IsPointInsideCircle(e.Location, v.coords.ToPoint(), VertexRadius))
                    {
                        if (tempLineStart == null)
                        {
                            // Начинаем создание ребра
                            tempLineStart = v.coords;
                            break;
                        }
                        else
                        {
                            // Завершаем создание ребра и запрашиваем информацию
                            Vertex startVert = mainGraph.FindVertByCoords(tempLineStart);
                            Vertex endVert = v;
                            if (startVert == endVert)
                            {
                                tempLineStart = null;
                                break;
                            }

                            if (startVert != null && endVert != null && startVert != endVert)
                            {
                                using (var form = new EdgeInfoForm())
                                {
                                    if (form.ShowDialog() == DialogResult.OK)
                                    {
                                        Edge edge = new Edge(
                                            (byte)mainGraph.edges.Length,
                                            startVert,
                                            endVert,
                                            form.EdgeLevel,
                                            form.IsDirected
                                        );
                                        mainGraph.AddEdge(edge);
                                    }
                                }
                            }

                            tempLineStart = null; // Сбрасываем временную линию
                            EdgesCountLabel.Text = $"Число ребер: {++actualEdgeCount}";
                            Invalidate(); // Перерисовываем форму
                            break;
                        }
                    }
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (mode == Mode.Move)
                {
                    // Перемещение вершины
                    // Ищем вершину, по которой кликнули
                    foreach (var v in mainGraph.vertices)
                    {
                        if (v == null)
                            break;
                        if (IsPointInsideCircle(e.Location, v.coords.ToPoint(), VertexRadius))
                        {
                            // Начинаем перетаскивание вершины
                            isDragging = true;
                            draggedVert = v;
                            break;
                        }
                    }
                }
                else if (mode == Mode.Del)
                {
                    // Проверяем, был ли клик по ребру для его удаления
                    for (int i = 0; i < mainGraph.edges.Length; i++)
                    {
                        if (mainGraph.edges[i] == null)
                            break;
                        if (IsPointNearLine(e.Location, mainGraph.edges[i].vert1.coords.ToPoint(), mainGraph.edges[i].vert2.coords.ToPoint()))
                        {
                            // Удаляем ребро
                            mainGraph.RemoveEdgeAt(i);
                            EdgesCountLabel.Text = $"Число ребер: {--actualEdgeCount}";
                            Invalidate(); // Перерисовываем форму после удаления
                            break;
                        }
                    }
                }
            }
        }



        // Начало перетаскивания вершины
        private void initGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mainGraph.vertices != null && mode == Mode.Move)
            {
                foreach (var v in mainGraph.vertices)
                {
                    if (v == null)
                        break;
                    if (IsPointInsideCircle(e.Location, v.coords.ToPoint(), VertexRadius))
                    {
                        isDragging = true;
                        draggedVert = v;
                        break;
                    }
                }
            }
        }

        // Перемещение вершины
        private void initGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedVert != null && mode == Mode.Move)
            {
                if (e.Location.X >= 0 && e.Location.Y >= 40)
                {
                    draggedVert.coords = e.Location.ToCoords();
                    Invalidate(); // Перерисовываем форму, чтобы обновить вершины и рёбра
                }
            }
        }

        // Завершение перетаскивания вершины
        private void initGraph_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDragging && mode == Mode.Move)
            {
                isDragging = false;
                draggedVert = null;
            }
        }

        // Метод для рисования вершин и рёбер
        private void initGraph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Рисуем все рёбра
            if (mainGraph.edges != null)
            {
                foreach (var edge in mainGraph.edges)
                {
                    if (edge == null || edge.vert1 == null || edge.vert2 == null ||
                        edge.vert1.coords == null || edge.vert2.coords == null)
                    {
                        continue; // Пропускаем некорректные или неинициализированные рёбра
                    }

                    // Получаем начальную и конечную точки ребра
                    Point start = edge.vert1.coords.ToPoint();
                    Point end = edge.vert2.coords.ToPoint();
                    g.DrawLine(Pens.Black, start, end);

                    // Рисуем уровень ребра
                    Point midPoint = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);
                    g.DrawString(edge.level.ToString(), this.Font, Brushes.Red, midPoint);

                    // Если граф ориентированный, рисуем стрелку
                    if (edge.directed)
                    {
                        DrawArrow(g, start, end);
                    }
                }


                if (!mainGraph.OnlyInit())
                {
                    foreach (var v in mainGraph.vertices)
                    {
                        if (v == null) continue;
                        Coordinates vertex = v.coords;
                        Rectangle rect = new Rectangle(vertex.x - VertexRadius / 2, vertex.y - VertexRadius / 2, VertexRadius, VertexRadius);

                        g.FillEllipse(Brushes.LightBlue, rect);
                        g.DrawEllipse(Pens.Black, rect);

                        string vertexNumber = v.number.ToString();
                        SizeF textSize = g.MeasureString(vertexNumber, this.Font);
                        PointF textPosition = new PointF(vertex.x - textSize.Width / 2, vertex.y - textSize.Height / 2);
                        g.DrawString(vertexNumber, this.Font, Brushes.Black, textPosition);
                    }
                }

            }
        }

        // Проверка, находится ли точка внутри круга
        private bool IsPointInsideCircle(Point point, Point center, int radius)
        {
            int dx = point.X - center.X;
            int dy = point.Y - center.Y;
            return dx * dx + dy * dy <= radius * radius;
        }

        // Метод для рисования стрелки
        private void DrawArrow(Graphics g, Point start, Point end)
        {
            // Длина стрелки и угол "крыльев"
            const int arrowLength = 10;
            const double arrowAngle = Math.PI / 6; // 30 градусов

            // Вычисляем направление от start к end
            double angle = Math.Atan2(end.Y - start.Y, end.X - start.X);

            // Координаты конца стрелки (непосредственно перед вершиной)
            Point arrowEnd = new Point(
                end.X - (int)(VertexRadius / 2 * Math.Cos(angle)),
                end.Y - (int)(VertexRadius / 2 * Math.Sin(angle))
            );

            // Координаты "крыльев" стрелки
            Point leftWing = new Point(
                arrowEnd.X - (int)(arrowLength * Math.Cos(angle - arrowAngle)),
                arrowEnd.Y - (int)(arrowLength * Math.Sin(angle - arrowAngle))
            );

            Point rightWing = new Point(
                arrowEnd.X - (int)(arrowLength * Math.Cos(angle + arrowAngle)),
                arrowEnd.Y - (int)(arrowLength * Math.Sin(angle + arrowAngle))
            );

            // Рисуем основную линию ребра
            g.DrawLine(Pens.Black, start, end);

            // Рисуем стрелку (две линии от конца стрелки к "крыльям")
            g.DrawLine(Pens.Black, arrowEnd, leftWing);
            g.DrawLine(Pens.Black, arrowEnd, rightWing);
        }

        // Метод для проверки, находится ли точка рядом с линией (ребром)
        private bool IsPointNearLine(Point point, Point start, Point end, int threshold = 10)
        {
            // Вычисляем расстояние от точки до линии (ребра)
            float distance = DistanceFromPointToLine(point, start, end);
            return distance <= threshold;
        }

        // Метод для вычисления расстояния от точки до линии
        private float DistanceFromPointToLine(Point point, Point lineStart, Point lineEnd)
        {
            float A = point.X - lineStart.X;
            float B = point.Y - lineStart.Y;
            float C = lineEnd.X - lineStart.X;
            float D = lineEnd.Y - lineStart.Y;

            float dot = A * C + B * D;
            float lengthSquared = C * C + D * D;
            float param = lengthSquared != 0 ? dot / lengthSquared : -1;

            float xx, yy;

            if (param < 0)
            {
                xx = lineStart.X;
                yy = lineStart.Y;
            }
            else if (param > 1)
            {
                xx = lineEnd.X;
                yy = lineEnd.Y;
            }
            else
            {
                xx = lineStart.X + param * C;
                yy = lineStart.Y + param * D;
            }

            float dx = point.X - xx;
            float dy = point.Y - yy;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        private void frameAlgbtn_Click(object sender, EventArgs e)
        {
            if (mainGraph.vertices.Length == 0)
            {
                MessageBox.Show("Граф пустой. Добавьте вершины и рёбра перед поиском минимального каркаса.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Находим минимальный каркас
            Edge[] mstEdges = mainGraph.FindMinimumSpanningTree();

            if (mstEdges == null || mstEdges.Length == 0)
            {
                MessageBox.Show("Минимальный каркас не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Сравниваем рёбра старого графа и рёбра минимального каркаса
            Edge[] removedEdges = new Edge[mainGraph.edges.Length]; // Максимально возможное количество удалённых рёбер
            int removedCount = 0;

            foreach (var edge in mainGraph.edges)
            {
                if (edge == null) continue;

                // Если ребро не входит в MST, добавляем его в массив
                if (!mstEdges.Contains(edge))
                {
                    removedEdges[removedCount++] = edge;
                }
            }

            // Обрезаем массив удалённых рёбер до фактического размера
            Array.Resize(ref removedEdges, removedCount);

            // Определяем уникальные вершины в MST
            Vertex[] vertices = new Vertex[mstEdges.Length * 2]; // Максимально возможное количество уникальных вершин
            int vertexCount = 0;

            foreach (var edge in mstEdges)
            {
                bool containsVert1 = false;
                bool containsVert2 = false;

                // Проверяем, есть ли вершины в массиве
                for (int i = 0; i < vertexCount; i++)
                {
                    if (vertices[i] == edge.vert1)
                    {
                        containsVert1 = true;
                    }
                    if (vertices[i] == edge.vert2)
                    {
                        containsVert2 = true;
                    }
                }

                // Добавляем уникальные вершины
                if (!containsVert1)
                {
                    vertices[vertexCount++] = edge.vert1;
                }
                if (!containsVert2)
                {
                    vertices[vertexCount++] = edge.vert2;
                }
            }

            // Урезаем массив до фактического количества уникальных вершин
            Array.Resize(ref vertices, vertexCount);

            // Создаём новый граф с вершинами и рёбрами MST
            Graph mstGraph = new Graph(vertices, mstEdges);

            // Открываем форму для отображения минимального каркаса
            GraphFrameForm graphFrameForm = new GraphFrameForm(mstGraph, removedEdges, Frame.Min);
            graphFrameForm.Show();
        }


        private void clearBtn_Click(object sender, EventArgs e)
        {
            GraphSettings graphSettings = new GraphSettings();
            graphSettings.Show();
            this.Close();
        }

        private void moveVertbtn_Click(object sender, EventArgs e)
        {
            mode = Mode.Move;
        }

        private void createEdgebtn_Click(object sender, EventArgs e)
        {
            mode = Mode.Merge;
        }

        private void deleteItemsbtn_Click(object sender, EventArgs e)
        {
            mode = Mode.Del;
        }

        private void maxFrameBtn_Click(object sender, EventArgs e)
        {
            if (mainGraph.vertices.Length == 0)
            {
                MessageBox.Show("Граф пустой. Добавьте вершины и рёбра перед поиском максимального каркаса.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Находим максимальный каркас
            Edge[] maxSTEdges = mainGraph.FindMaximumSpanningTree();

            if (maxSTEdges == null || maxSTEdges.Length == 0)
            {
                MessageBox.Show("Максимальный каркас не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Определяем уникальные вершины в MST
            Vertex[] vertices = new Vertex[maxSTEdges.Length * 2]; // Максимально возможное количество уникальных вершин
            int vertexCount = 0;

            foreach (var edge in maxSTEdges)
            {
                bool containsVert1 = false;
                bool containsVert2 = false;

                // Проверяем, есть ли вершины в массиве
                for (int i = 0; i < vertexCount; i++)
                {
                    if (vertices[i] == edge.vert1)
                    {
                        containsVert1 = true;
                    }
                    if (vertices[i] == edge.vert2)
                    {
                        containsVert2 = true;
                    }
                }

                // Добавляем уникальные вершины
                if (!containsVert1)
                {
                    vertices[vertexCount++] = edge.vert1;
                }
                if (!containsVert2)
                {
                    vertices[vertexCount++] = edge.vert2;
                }
            }

            // Урезаем массив до фактического количества уникальных вершин
            Array.Resize(ref vertices, vertexCount);

            // Создаём новый граф с вершинами и рёбрами MST
            Graph maxSTGraph = new Graph(vertices, maxSTEdges);

            // Поиск удалённых рёбер
            int removedEdgesCount = 0;
            Edge[] removedEdges = new Edge[mainGraph.edges.Length]; // Массив для хранения удалённых рёбер

            foreach (var edge in mainGraph.edges)
            {
                bool isEdgeInMST = false;
                foreach (var mstEdge in maxSTEdges)
                {
                    // Проверяем, присутствует ли ребро в MST
                    if (edge == mstEdge)
                    {
                        isEdgeInMST = true;
                        break;
                    }
                }

                // Если ребро не в MST, то оно удалено
                if (!isEdgeInMST)
                {
                    removedEdges[removedEdgesCount++] = edge;
                }
            }

            // Урезаем массив до фактического количества удалённых рёбер
            Array.Resize(ref removedEdges, removedEdgesCount);

            // Открываем форму для отображения максимального каркаса и передаем удалённые рёбра
            GraphFrameForm graphFrameForm = new GraphFrameForm(maxSTGraph, removedEdges, Frame.Max);
            graphFrameForm.Show();
        }

    }
}
