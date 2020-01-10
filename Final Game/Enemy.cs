using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Game
{
    abstract class Enemy : PhysicalObject
    {
        public Enemy(Texture2D texture, Vector2 position, float speedX, float speedY)
            : base(texture,position)
        {
        }

        public virtual void Update(GameWindow window)
        {

        }





    }

    class Mine : Enemy
    {
        public Mine(Texture2D texture, Vector2 position)
            : base(texture, position, 0.3f, 0f)
        {
        }

        public override void Update(GameWindow window)
        {
            int i = 0;
            i++;
            //Flytta på fienden
            position.X += (1+(i/10));
     
            //Kontrollera så att den inte åker utanför kanten
           // if (position.X > window.ClientBounds.Width - gfx.Width || position.X < 100)
            //{
              //  speed.X *= -1;
            //}
            //Gör fienden inaktiv om den åker ut där nere
            if (position.X == 830)
            {
                IsAlive = false;
            }
        }

    }

   /* class Tripod : Enemy
    {
        public Tripod(Texture2D texture, Vector2 position)
            : base(texture, position, 0f, 1f)
        {
        }

        public override void Update(GameWindow window)
        {
            //Flytta på fienden
            position.Y += speed.X;
            //Gör fienden inaktiv om den åker ut där nere
            if (position.Y > window.ClientBounds.Height)
            {
                IsAlive = false;

               
            }
        }

    }
    */
}
