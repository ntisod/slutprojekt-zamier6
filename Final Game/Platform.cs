using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Final_Game 
{
    class Platform 
    {
        Texture2D texture;
        Vector2 position;
        public Rectangle rectangle;


        public Platform(Texture2D newTexture, Vector2 newPosition) 
        {
            texture = newTexture;
            position = newPosition;

            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }

    static class RectangleHelper
    {
        const int penetrationMargin = 5;
        public static bool isOnTopOf(this rectangle)
    }
}
