using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    internal class Square
    {
        public Point pos;
        public bool is_light;
        public Piece piece;

        public Square(Point pos, bool is_light)
        {
            this.pos = pos;
            this.is_light = is_light;
        }
    }
}
