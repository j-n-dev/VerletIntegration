using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerletIntegration
{
    class World
    {
        private Point[] points;
        private Stick[] sticks;

        private float width;
        private float height;
        private float bounce;
        private float gravity;
        private float friction;
        private int iterPerFrame;

        private ShapeDrawer drawer;
        
        public World(ShapeDrawer drawer, float width, float height, float bounce, float gravity, float friction, int iterPerFrame)
        {
            this.width = width;
            this.height = height;
            this.bounce = bounce;
            this.gravity = gravity;
            this.friction = friction;
            this.iterPerFrame = iterPerFrame;

            points = new Point[4];
            points[0] = new(100, 100, 95, 95);
            points[1] = new(200, 100, 200, 100);
            points[2] = new(200, 200, 200, 200);
            points[3] = new(100, 200, 100, 200);

            sticks = new Stick[4];
            sticks[0] = new(points[0], points[1]);
            sticks[1] = new(points[1], points[2]);
            sticks[2] = new(points[2], points[3]);
            sticks[3] = new(points[3], points[0]);

            this.drawer = drawer;
        }

        public void Update()
        {
            UpdatePoints();
            for (int i = 0; i < iterPerFrame; i++)
            {
                UpdateSticks();
                ConstrainPoints();
            }
        }

        public void Render()
        {
            RenderPoints();
            RenderSticks();
        }

        private void UpdatePoints()
        {
            for (int i = 0; i < points.Length; i++)
            {
                Point p = points[i];
                float vx = (p.X - p.OldX) * friction;
                float vy = (p.Y - p.OldY) * friction;

                p.OldX = p.X;
                p.OldY = p.Y;
                p.X += vx;
                p.Y += vy;
                p.Y += gravity;

                if (p.X > width)
                {
                    p.X = width;
                    p.OldX = p.X + vx * bounce;
                }
                if (p.X < 0)
                {
                    p.X = 0;
                    p.OldX = p.X + vx * bounce;
                }
                if (p.Y > height)
                {
                    p.Y = height;
                    p.OldY = p.Y + vy * bounce;
                }
                if (p.Y < 0)
                {
                    p.Y = 0;
                    p.OldY = p.Y + vy * bounce;
                }
            }
        }

        private void ConstrainPoints()
        {
            for (int i = 0; i < points.Length; i++)
            {
                Point p = points[i];
                float vx = (p.X - p.OldX) * friction;
                float vy = (p.Y - p.OldY) * friction;

                if (p.X > width)
                {
                    p.X = width;
                    p.OldX = p.X + vx * bounce;
                }
                if (p.X < 0)
                {
                    p.X = 0;
                    p.OldX = p.X + vx * bounce;
                }
                if (p.Y > height)
                {
                    p.Y = height;
                    p.OldY = p.Y + vy * bounce;
                }
                if (p.Y < 0)
                {
                    p.Y = 0;
                    p.OldY = p.Y + vy * bounce;
                }
            }
        }

        private void UpdateSticks()
        {
            for (int i = 0; i < sticks.Length; i++)
            {
                Stick s = sticks[i];
                float dx = s.P1.X - s.P0.X;
                float dy = s.P1.Y - s.P0.Y;
                float distance = MathF.Sqrt(dx * dx + dy + dy);
                float difference = s.Length - distance;
                float percent = difference / distance / 2.0f;
                float offsetX = dx * percent;
                float offsetY = dy * percent;

                s.P0.X -= offsetX;
                s.P0.Y -= offsetY;
                s.P1.X += offsetX;
                s.P1.Y += offsetY;
            }
        }

        private void RenderPoints()
        {
            foreach (Point p in points)
            {
                drawer.DrawCircle(5.0f, new(p.X, p.Y), new(0, 0, 0));
            }
        }

        private void RenderSticks()
        {
            foreach (Stick s in sticks)
            {
                drawer.DrawLine(new(s.P0.X, s.P0.Y), new(s.P1.X, s.P1.Y), new(0, 0, 0));
            }
        }
    }
}
