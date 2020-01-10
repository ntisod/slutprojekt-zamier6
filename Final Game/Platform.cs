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
    class Platform : PhysicalObject
    {
        
        public Rectangle rectangle;


       public Platform(Texture2D texture, Vector2 position) : base(texture, position)
        {
      

            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            
        }

        


        #region Collision
        protected bool IsTouchingLeft(Platform platform)
        {
            return this.rectangle.Left + this.speed.X > platform.rectangle.Left &&
                this.rectangle.Right < platform.rectangle.Left &&
                this.rectangle.Bottom > platform.rectangle.Top &&
                this.rectangle.Top < platform.rectangle.Bottom;
        }

   

        
    }

    static class RectangleHelper
    {
        const int penetrationMargin = 5;
        public static bool isOnTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - penetrationMargin &&
                r1.Bottom <= r2.Top + 1 &&
                r1.Right >= r2.Left + 5 &&
                r1.Left <= r2.Right - 5);

        }
    }
}
