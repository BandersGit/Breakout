using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Breakout
{
    public class Paddle
    {
        public Sprite sprite;
        public Vector2f size;

        public Paddle()
        {
            sprite = new Sprite();
            sprite.Texture = new Texture("assets/paddle.png");

            Vector2f paddleTextureSize = (Vector2f) sprite.Texture.Size;
            sprite.Origin = 0.5f * paddleTextureSize;
            sprite.Scale = new Vector2f(paddleTextureSize.Y / paddleTextureSize.X ,paddleTextureSize.Y / paddleTextureSize.X);
            sprite.Position = new Vector2f(Program.ScreenW * 0.5f, Program.ScreenH - 50);
            size = new Vector2f(sprite.GetGlobalBounds().Width, sprite.GetGlobalBounds().Height);
        }

        public void Update(Ball ball, float deltaTime)
        {
            if (ball.isBallOnPaddle)
            {
                Vector2f temporaryPos = sprite.Position;
                temporaryPos.Y -= 20;
                ball.sprite.Position = temporaryPos;
            }
            var newPos = sprite.Position;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                newPos.X += deltaTime * 300.0f;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                newPos.X -= deltaTime * 300.0f; 
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                ball.isBallOnPaddle = false;
            }
            
            if (newPos.X > Program.ScreenW - size.X/2)  //Why does dividing by 2 work? If you dont know just use 70px
            {
                newPos.X = Program.ScreenW - size.X/2;

            }else if (newPos.X < 0 + size.X/2)
            {
                newPos.X = 0 + size.X/2;
            }

            if (Collision.CircleRectangle(ball.sprite.Position, Ball.Radius, this.sprite.Position, size, out Vector2f hit))
            {
                ball.tileHitStreak = 0;
                ball.sprite.Position += hit;
                ball.Reflect(hit.Normalized());
            }

            sprite.Position = newPos;
        }

        public void Draw(RenderTarget target)
        {
            target.Draw(sprite);
        }
    }
}
