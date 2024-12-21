using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public class Vertex    //вершина
    {
        public Vertex(byte _number)
        {
            number = _number;
            edges = new List<Edge>();
        }
        public Vertex(byte _number, Coordinates coordinates)
        {
            number = _number;
            edges = new List<Edge>();
            coords = coordinates;
        }
        public byte number { get; }
        public List<Edge> edges;
        public Coordinates coords;
    }
}
