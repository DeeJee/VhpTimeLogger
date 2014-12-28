using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VhpTimeLogger
{
    public static class Extensionmethods
    {
        public static Point Add(this Point point, Point pointToAdd)
        {
            return new Point(point.X + pointToAdd.X, point.Y + pointToAdd.Y);
        }
    }
}
