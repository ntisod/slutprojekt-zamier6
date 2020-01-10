using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Game
{
    class Sprite
    {

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
