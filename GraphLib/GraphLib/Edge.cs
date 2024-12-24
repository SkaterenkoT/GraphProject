using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public class Edge    //ребро
    {
        public Edge(byte _number, Vertex v1, Vertex v2, int _level, bool _directed)
        {
            number = _number;
            vert1 = v1;
            vert2 = v2;
            level = _level;
            directed = _directed;
        }
        public byte number { get; }
        public Vertex vert1 { get; }
        public Vertex vert2 { get; }
        public int level { get; }
        public bool directed { get; }
    }
}
