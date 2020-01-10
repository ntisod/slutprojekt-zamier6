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

        protected bool IsTouchingRight(Platform platform)
        {
            return this.rectangle.Left + this.speed.X < platform.rectangle.Right &&
                this.rectangle.Right > platform.rectangle.Right &&
                this.rectangle.Bottom > platform.rectangle.Top &&
                this.rectangle.Top < platform.rectangle.Bottom;
        }
        protected bool IsTouchingTop(Platform platform)
        {
            return this.rectangle.Bottom + this.speed.Y > platform.rectangle.Top &&
                this.rectangle.Top < platform.rectangle.Top &&
                this.rectangle.Bottom > platform.rectangle.Top &&
                this.rectangle.Top < platform.rectangle.Bottom;
        }
        protected bool IsTouchingBottom(Platform platform)
        {
            return this.rectangle.Top + this.speed.X < platform.rectangle.Bottom &&
                this.rectangle.Bottom > platform.rectangle.Bottom &&
                this.rectangle.Right > platform.rectangle.Left &&
                this.rectangle.Left < platform.rectangle.Right;
        }
        #endregion
        

        
    }
 }

