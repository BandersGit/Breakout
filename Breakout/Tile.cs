using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Breakout
{
    public class Tile
    {
        public Sprite sprite;

        public Tile()
        {
            sprite = new Sprite();
            sprite.Texture = new Texture("assets/tileBlue.png");

            Vector2f tileTextureSize = (Vector2f) sprite.Texture.Size;
        }

        public void Update(Ball ball, float deltaTime)
        {

        }

        public void Draw(RenderTarget target)
        {
            target.Draw(sprite);
        }
    }
}
