﻿using GraphLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryForGraph
{
    public static class Converter
    {
        public static Point ToPoint(this Coordinates coords)
        {
            return new Point(coords.x, coords.y);
        }
        public static Coordinates ToCoords(this Point point)
        {
            return new Coordinates(point.X, point.Y);
        }
    }
}