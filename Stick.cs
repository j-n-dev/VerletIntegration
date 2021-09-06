using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.System;

namespace VerletIntegration
{
    class Stick
    {
        public Point P0;
        public Point P1;
        // DO NOT TOUCH
        public float Length { get; }

        public Stick(Point P0, Point P1)
        {
            this.P0 = P0;
            this.P1 = P1;
            Length = Distance(P0, P1);
        }

        private static float Distance(Point p0, Point p1)
        {
            float dx = p1.X - p0.X;
            float dy = p1.Y - p0.Y;
            return MathF.Sqrt(dx * dx + dy * dy);
        }
    }
}
