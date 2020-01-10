using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Game
{
    class GameObject
    {
        protected Texture2D gfx; //grafiken
        protected Vector2 position; //spelarens position

        public GameObject(Texture2D gfx, Vector2 position)
        {
            this.gfx = gfx;
            this.position.X = position.X;
            this.position.Y = position.Y;
        }

        public float X { get { return position.X; } }
        public float Y { get { return position.Y; } }
        public float Width { get { return gfx.Width; } }
        public float Height { get { return gfx.Height; } }


        public virtual void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(gfx, position, Color.White);
        }


    }

    abstract class MovingObject : GameObject
    {
        protected Vector2 speed;
        public Vector2 oldPos;

        public MovingObject(Texture2D gfx, Vector2 position)
            : base(gfx, position)
        {
            this.speed = new Vector2(5,5);
            
        }
    }

    //Abstract klass är en klass som inte kan skapa objekt inom sig men klasser som ärver den kan.
    abstract class PhysicalObject : MovingObject
    {
        private bool isAlive = true;
        protected bool onGround = false;
        protected float gravity = 9.81f;
        private Texture2D texture;
    
        public PhysicalObject(Texture2D texture, Vector2 position)
        :base(texture , position )
        {
            this.texture = texture;
            this.position = position;
        }

        //Protected : Bara själva klassen som har skapat den och andra klasser som ärver den kan se variabeln




        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        //Kollar kollisionen mellan Olika Object
        public bool CheckCollision(PhysicalObject other)
        {
            Rectangle myRect = new Rectangle(Convert.ToInt32(X), Convert.ToInt32(Y),
                Convert.ToInt32(Width), Convert.ToInt32(Height));
            Rectangle otherRect = new Rectangle(Convert.ToInt32(other.X), Convert.ToInt32(other.Y),
                Convert.ToInt32(other.Width), Convert.ToInt32(other.Height));
            return myRect.Intersects(otherRect);
        }


    }
}



