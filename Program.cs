using System;

using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace VerletIntegration
{
    class Program
    {
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void Main()
        {
            RenderWindow app = new(new VideoMode(1280, 720), "i am dead inside");
            app.SetFramerateLimit(30);
            app.Closed += new EventHandler(OnClose);

            ShapeDrawer drawer = new(app);

            World world = new(drawer, app.Size.X, app.Size.Y, 0.9f, 0.5f, 0.999f, 3);

            Color windowCol = new(255, 255, 255);

            while (app.IsOpen)
            {
                app.DispatchEvents();

                #region Update stuff here
                world.Update();
                #endregion

                app.Clear(windowCol);

                #region Render stuff here
                world.Render();
                #endregion

                app.Display();
            }
        }
    }
}
