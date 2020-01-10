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
    class Player : Sprite
    {
        int points = 0;

        public List<Bullet> bullets;
        Texture2D bulletTexture;
        double timeSinceLastBullet;
       

        public Player(Texture2D texture, Vector2 position, Texture2D bulletTexture)
            : base(texture, position)
        {
            bullets = new List<Bullet>();
            this.bulletTexture = bulletTexture;
            timeSinceLastBullet = 0;

        }

        public int Points { get { return points; } set { points = value; } }

        public void Update(GameTime gameTime, GameWindow window)
        {

            //Tangentbordsstyrning
            KeyboardState keyboardState = Keyboard.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                //Kontrollera om spelaren får skjuta
                if (gameTime.TotalGameTime.TotalMilliseconds >
                    timeSinceLastBullet + 200)
                {
                    //Skapa skottet
                    Bullet temp = new Bullet(bulletTexture, new Vector2(position.X + gfx.Width / 2, position.Y));
                    bullets.Add(temp);
                    //Sätt timeSinceLastBullet till detta ögonblick
                    timeSinceLastBullet = gameTime.TotalGameTime.TotalMilliseconds;
                }

                //Flytta skotten

            }

            foreach (Bullet b in bullets.ToList())
            {
                b.Update();

                if (!b.IsAlive)
                {
                    bullets.Remove(b);
                }
            }

            //Förflyttning i x-led
            if (position.X <= window.ClientBounds.Width - gfx.Width && position.X >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    position.X += speed.X;
                }
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    position.X -= speed.X;

                }
            }
            //Förflyttning i y-led
            if (position.Y <= window.ClientBounds.Height - gfx.Height && position.Y >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.S))
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

            if (onGround && keyboardState.IsKeyDown(Keys.Up))
            {
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

            //kollisionen

            
        }

        //ritar in skotten
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(gfx, position, Color.White);
            foreach (Bullet b in bullets)
                b.Draw(spriteBatch);
        }

    }

    class Bullet : PhysicalObject
    {

        public bool LookingLeft = false;

        public Bullet(Texture2D texture, Vector2 position)
            : base(texture, position) //Base används för att kunna nå variabler i klassen man ärver
        {
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();


         
            position.X += -5;
            if (position.X < 0 || position.X > 800)
                IsAlive = false;
        }
    }
}
