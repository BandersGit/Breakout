using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Breakout
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var window = new RenderWindow(new VideoMode(500,700), "Breakout"))
            {
                window.Closed += (o,e) => window.Close();

                Clock clock = new Clock();
                while (window.IsOpen)
                {
                    float deltatime = clock.Restart().AsSeconds();

                    window.DispatchEvents();

                    window.Clear(new Color(131, 197, 235));

                    window.Display();
                }
            }
        }
    }
}
