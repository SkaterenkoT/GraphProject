using GraphLib;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryForGraph
{
    public partial class GraphFrameForm : Form
    {
        private Graph graph;
        private const int VertexRadius = 20;

        public GraphFrameForm(Graph graph, Edge[] removedEdges, Frame frameType)
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            this.graph = graph;
            string type = "";
            if (frameType == Frame.Max)
            { 
                type = "максимального";
                this.Text = "Максимальный каркас";
            }
            else
            { 
                type = "минимального";
                this.Text = "Минимальный каркас";
            }
            int removedEdgesCount = 0;
            for (int i = 0; i < removedEdges.Length; i++)
            {
                if (removedEdges[i] == null)
                    break;
                removedEdgesCount++;
            }

            descriptionLabel.Text = $"Во избежании циклов,\nа также для сохранения\n{type} значения путей\nв графе были удалены следующие\n ребра, а именно {removedEdgesCount} шт:";
            foreach (var edge in removedEdges)
            {
                if (edge != null)
                {
                    DataForRemoved.Rows.Add(edge.vert1.number, edge.vert2.number, edge.level);
                }
            }

            int edgesInMinGraph = 0;
            int edgeSum = 0;
            foreach (var edge in graph.edges)
            {
                if (edge == null)
                    break;
                edgesInMinGraph++;
                edgeSum += edge.level;
            }
            edgesRemainingLabel.Text = $"Ребер осталось: {edgesInMinGraph}";
            edgesLevelSumLab.Text = $"Общая сумма ребер: {edgeSum}";
            // Привязка обработчика Paint
            this.Paint += new PaintEventHandler(FrameResultForm_Paint);
        }

        private void FrameResultForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Рисуем все рёбра графа
            foreach (var edge in graph.edges)
            {
                Point start = edge.vert1.coords.ToPoint();
                Point end = edge.vert2.coords.ToPoint();

                // Рисуем линию ребра
                g.DrawLine(Pens.Black, start, end);

                // Рисуем уровень ребра на середине линии
                Point midPoint = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);
                g.DrawString(edge.level.ToString(), this.Font, Brushes.Red, midPoint);

                // Если ребро ориентированное, рисуем стрелку
                if (edge.directed)
                {
                    DrawArrow(g, start, end);
                }
            }

            // Рисуем все вершины графа
            foreach (var vertex in graph.vertices)
            {
                Point point = vertex.coords.ToPoint();
                Rectangle rect = new Rectangle(point.X - VertexRadius / 2, point.Y - VertexRadius / 2, VertexRadius, VertexRadius);

                g.FillEllipse(Brushes.LightBlue, rect);
                g.DrawEllipse(Pens.Black, rect);

                // Рисуем номер вершины
                string vertexNumber = vertex.number.ToString();
                SizeF textSize = g.MeasureString(vertexNumber, this.Font);
                PointF textPosition = new PointF(point.X - textSize.Width / 2, point.Y - textSize.Height / 2);
                g.DrawString(vertexNumber, this.Font, Brushes.Black, textPosition);
            }
        }


        // Метод для рисования стрелки для ориентированных рёбер
        private void DrawArrow(Graphics g, Point start, Point end)
        {
            const int arrowLength = 10;
            const double arrowAngle = Math.PI / 6; // 30 градусов

            double angle = Math.Atan2(end.Y - start.Y, end.X - start.X);

            Point arrowEnd = new Point(
                end.X - (int)(VertexRadius / 2 * Math.Cos(angle)),
                end.Y - (int)(VertexRadius / 2 * Math.Sin(angle))
            );

            Point leftWing = new Point(
                arrowEnd.X - (int)(arrowLength * Math.Cos(angle - arrowAngle)),
                arrowEnd.Y - (int)(arrowLength * Math.Sin(angle - arrowAngle))
            );

            Point rightWing = new Point(
                arrowEnd.X - (int)(arrowLength * Math.Cos(angle + arrowAngle)),
                arrowEnd.Y - (int)(arrowLength * Math.Sin(angle + arrowAngle))
            );

            g.DrawLine(Pens.Black, arrowEnd, leftWing);
            g.DrawLine(Pens.Black, arrowEnd, rightWing);
        }
    }
}
