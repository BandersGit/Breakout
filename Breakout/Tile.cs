using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Breakout
{
    public class Tile
    {
        public Sprite sprite;
        public Vector2f size;
        public List<Vector2f> positions;

        public Tile()
        {
            sprite = new Sprite();
            sprite.Texture = new Texture("assets/tileBlue.png");

            Vector2f tileTextureSize = (Vector2f) sprite.Texture.Size;
            sprite.Origin = 0.5f * tileTextureSize;
            sprite.Scale = new Vector2f((tileTextureSize.Y / tileTextureSize.X), (tileTextureSize.Y / tileTextureSize.X));
            size = new Vector2f(sprite.GetGlobalBounds().Width,sprite.GetGlobalBounds().Height);
            
            positions = new List<Vector2f>();
            for (int i = -2; i <= 2; i++)
            {
                for (int j = -2; j <= 2; j++)
                {
                    var pos = new Vector2f(Program.ScreenW * 0.5f + i * 96.0f, Program.ScreenH * 0.3f + j * 48.0f);
                    positions.Add(pos);
                }
            }
        }

        public void Update(Ball ball, float deltaTime)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                var pos = positions[i];
                if (Collision.CircleRectangle(ball.sprite.Position, Ball.Radius, pos, size, out Vector2f hit))
                {
                    ball.sprite.Position += hit;
                    ball.tilesHit ++;
                    ball.Reflect(hit.Normalized());
                    positions.RemoveAt(i);
                    ball.score += 100 * ball.tilesHit;
                    i = 0;
                }
            }
        }

        public void Draw(RenderTarget target)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                sprite.Position = positions[i];
                target.Draw(sprite);
            }
        }
    }
}
