using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerletIntegration
{
    class Point
    {
        public float X;
        public float Y;
        public float OldX;
        public float OldY;

        public Point(float X, float Y, float OldX, float OldY)
        {
            this.X = X;
            this.Y = Y;
            this.OldX = OldX;
            this.OldY = OldY;
        }
    }
}
