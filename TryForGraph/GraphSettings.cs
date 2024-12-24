using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphLib;

namespace TryForGraph
{
    public partial class GraphSettings : Form
    {
        public GraphSettings()
        {
            InitializeComponent();
        }

        private void CompleteBtn_Click(object sender, EventArgs e)
        {
            int vertQuantity = 0;

            if (vertCount.Value > 0 && vertCount.Value < 100)
            {
                vertQuantity = (int)vertCount.Value;
            }

            Graph graph;

            // Создание графа в зависимости от состояния авто-заполнения
            if (autoFillCheck.Checked)
                graph = new Graph(vertQuantity, vertQuantity - 1, 1, 100, directedCheck.Checked);
            else
                graph = new Graph(vertQuantity);

            FillVertexCoordinates(graph);

            initGraph initGraph = new initGraph(graph, autoFillCheck.Checked);
            this.Hide();
            initGraph.Show();
        }

        private void FillVertexCoordinates(Graph graph)
        {
            Random rand = new Random();

            int minX = 100, maxX = 500;
            int minY = 100, maxY = 500;

            for (int i = 0; i < graph.vertices.Length; i++)
            {
                if (graph.vertices[i] == null)
                    break;
                int x = rand.Next(minX, maxX);
                int y = rand.Next(minY, maxY);

                graph.vertices[i].coords = new Coordinates(x, y);
            }
        }

    }
}
