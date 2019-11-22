using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Game
{
    class Player : PhysicalObject
    {
        

        public Player(Texture2D texture, Vector2 position)
            :base(texture, position)
        {
            this.position = position;
            this.gfx = texture;
            
        }


        public  void Update(GameTime gameTime, GameWindow window)
        {
         
            //Tangentbordsstyrning
            KeyboardState keyboardState = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
               
            }

            //Förflyttning i x-led
            if (position.X <= window.ClientBounds.Width - gfx.Width && position.X >= 0)
            {
                if  (keyboardState.IsKeyDown(Keys.Right))
                {
                    position.X += speed.X;
                }
                if ( keyboardState.IsKeyDown(Keys.Left))
                {
                    position.X -= speed.X;
                }
            }
            //Förflyttning i y-led
            if (position.Y <= window.ClientBounds.Height - gfx.Height && position.Y >= 0)
            {
                if ( keyboardState.IsKeyDown(Keys.S))
                {
                    position.Y += speed.Y + 5;
                }
               
               
            }

           // Flytta tillbaka rymdskeppet om det hamnar utanför bildskärmen
            if (position.X < 0) position.X = 0;
            if (position.X > window.ClientBounds.Width - gfx.Width)
                position.X = window.ClientBounds.Width - gfx.Width;
            if (position.Y < 0) position.Y = 0;
            if (position.Y > window.ClientBounds.Height - gfx.Height)
                position.Y = window.ClientBounds.Height - gfx.Height;

            if(onGround && keyboardState.IsKeyDown(Keys.Up)){
                speed.Y = -15;
                this.position.Y += this.speed.Y;

            }

            //Gravitation
            if (this.position.Y < window.ClientBounds.Height - gfx.Height)
            {
                onGround = false;
                this.speed.Y += 1;

                this.position.Y += this.speed.Y;
            }
            else
            {
                onGround = true;
                speed.Y = 0;
            }
        }

     
    }
}