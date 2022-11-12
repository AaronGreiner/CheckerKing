using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    internal class Piece
    {
        public bool is_light;

        public Piece(bool is_light)
        {
            this.is_light = is_light;
        }
    }
}
