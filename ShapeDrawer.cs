using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace VerletIntegration
{
    class ShapeDrawer
    {
        private readonly RenderWindow targetWindow;

        public ShapeDrawer(RenderWindow target)
        {
            targetWindow = target;
        }

        public void DrawCircle(float radius, Vector2f position, Color color)
        {
            CircleShape circle = new(radius);
            circle.Position = position;
            circle.FillColor = color;
            circle.Origin = new(circle.Radius, circle.Radius);
            targetWindow.Draw(circle);
        }

        public void DrawLine(Vector2f p1, Vector2f p2, Color color)
        {
            VertexArray line = new(PrimitiveType.Lines, 2);
            line[0] = new(p1, color);
            line[1] = new(p2, color);
            targetWindow.Draw(line);
        }
    }
}
