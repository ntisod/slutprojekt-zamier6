using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Game
{
    abstract class Enemy : PhysicalObject //används till Våra enemies
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
            : base(texture, position, 0.3f, 0f) //Våra basic enemies
        {
        }

        public override void Update(GameWindow window)
        {
            int i = 0;
            i++;
            //Flytta på fienden
            position.X += (1+i);
     

            if (position.X == 830)//utanför banan
            {

                IsAlive = false;

              
            }
        }


    }


}
