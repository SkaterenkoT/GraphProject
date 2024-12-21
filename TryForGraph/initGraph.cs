using System;
using System.Collections.Generic;
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

namespace TryForGraph
{
    public partial class initGraph : Form
    {
        private Graph mainGraph = new Graph();
        private Coordinates tempLineStart = null;
        private const int VertexRadius = 20;
        private const int INF = int.MaxValue / 2;

        private bool isDragging = false;
        private Vertex draggedVert = null;

        public initGraph()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.KeyPreview = true;
        }

        private void initGraph_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Добавляем вершину по двойному щелчку левой кнопкой мыши
                Point newCoords = new Point(e.X, e.Y);
                mainGraph.vertices.Add(new Vertex((byte)mainGraph.vertices.Count, newCoords.ToCoords()));
                tempLineStart = null; // Сбрасываем временную линию
                Invalidate(); // Перерисовываем форму
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Удаляем вершину по двойному щелчку правой кнопкой мыши
                for (int i = 0; i < mainGraph.vertices.Count; i++)
                {
                    if (IsPointInsideCircle(e.Location, mainGraph.vertices[i].coords.ToPoint(), VertexRadius))
                    {
                        mainGraph.DelConnectedEdges(mainGraph.vertices[i]);
                        Invalidate(); // Перерисовываем форму после удаления
                        return;
                    }
                }

                // Удаляем ребро, если клик произошёл по ребру
                for (int i = 0; i < mainGraph.edges.Count; i++)
                {
                    if (IsPointNearLine(e.Location, mainGraph.edges[i].vert1.coords.ToPoint(), mainGraph.edges[i].vert2.coords.ToPoint()))
                    {
                        mainGraph.edges.RemoveAt(i);
                        Invalidate(); // Перерисовываем форму после удаления
                        return;
                    }
                }
            }
        }


        // Обрабатываем правый клик мыши для создания рёбер
        private void initGraph_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                foreach (var v in mainGraph.vertices)
                {
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

                            if (startVert != null && endVert != null && startVert != endVert)
                            {
                                using (var form = new EdgeInfoForm())
                                {
                                    if (form.ShowDialog() == DialogResult.OK)
                                    {
                                        Edge edge = new Edge(
                                            (byte)mainGraph.edges.Count,
                                            startVert,
                                            endVert,
                                            form.EdgeLevel,
                                            form.IsDirected
                                        );
                                        mainGraph.edges.Add(edge);
                                    }
                                }
                            }

                            tempLineStart = null; // Сбрасываем временную линию
                            Invalidate(); // Перерисовываем форму
                            break;
                        }
                    }
                }
            }
        }



        // Начало перетаскивания вершины
        private void initGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mainGraph.vertices != null)
            {
                foreach (var v in mainGraph.vertices) //(int i = 0; i < vertices.Count; i++)
                {
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
            if (isDragging && draggedVert != null)
            {
                draggedVert.coords = e.Location.ToCoords();
                Invalidate(); // Перерисовываем форму, чтобы обновить вершины и рёбра
            }
        }

        // Завершение перетаскивания вершины
        private void initGraph_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isDragging)
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
                if (mainGraph.edges != null)
                {
                    foreach (var edge in mainGraph.edges)
                    {
  
                        Point start = edge.vert1.coords.ToPoint();
                        Point end = edge.vert2.coords.ToPoint();
                        g.DrawLine(Pens.Black, start, end);

                        Point midPoint = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);
                        g.DrawString(edge.level.ToString(), this.Font, Brushes.Red, midPoint);

                        if (edge.directed)
                        {
                            DrawArrow(g, start, end);
                        }
                    }
                }

                if (mainGraph.vertices != null)
                {
                    foreach (var v in mainGraph.vertices)
                    {
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
            if (mainGraph.vertices.Count == 0)
            {
                MessageBox.Show("Граф пустой. Добавьте вершины и рёбра перед поиском минимального каркаса.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Находим минимальный каркас
            List<Edge> mstEdges = mainGraph.FindMinimumSpanningTree();

            if (mstEdges == null || mstEdges.Count == 0)
            {
                MessageBox.Show("Минимальный каркас не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Собираем уникальные вершины из рёбер минимального каркаса
            List<Vertex> vertices = new List<Vertex>();
            foreach (var edge in mstEdges)
            {
                if (!vertices.Contains(edge.vert1))
                {
                    vertices.Add(edge.vert1);
                }
                if (!vertices.Contains(edge.vert2))
                {
                    vertices.Add(edge.vert2);
                }
            }

            // Создаём новый граф с минимальным каркасом
            Graph mstGraph = new Graph(vertices, mstEdges);

            // Открываем новую форму для отображения минимального каркаса
            GraphFrameForm graphFrameForm = new GraphFrameForm(mstGraph);
            graphFrameForm.Show();
        }
    }
}
