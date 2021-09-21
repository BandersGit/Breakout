using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Breakout
{
    class Program
    {
        public const int ScreenW = 500;
        public const int ScreenH = 700;

        static void Main(string[] args)
        {
            using (var window = new RenderWindow(new VideoMode(ScreenW, ScreenH), "Breakout"))
            {
                window.Closed += (o,e) => window.Close();

                Clock clock = new Clock();
                Ball ball = new Ball();
                Paddle paddle = new Paddle();
                Tile tile = new Tile();

                while (window.IsOpen)
                {
                    if (ball.health <= 0 || tile.positions.Count == 0)
                    {
                        clock = new Clock();
                        ball = new Ball();
                        paddle = new Paddle();
                        tile.positions.Clear();
                        tile = new Tile();
                    }

                    float deltaTime = clock.Restart().AsSeconds();
                    window.DispatchEvents();

                    ball.Update(deltaTime);
                    paddle.Update(ball, deltaTime);
                    tile.Update(ball, deltaTime);

                    window.Clear(new Color(131, 197, 235));

                    ball.Draw(window);
                    paddle.Draw(window);
                    tile.Draw(window);
                    window.Display();
                }
            }
        }
    }
}
