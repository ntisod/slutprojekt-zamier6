using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Printext printText;
        Player player;
        List<Enemy> enemies;
        int health = 100;
        List<Platform> platforms = new List<Platform>();
        int enemiesCount = 0;
        int roundnumber = 1;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            enemies = new List<Enemy>();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            printText = new Printext(Content.Load<SpriteFont>("myfont"));

            //laddar inn spelaren, positionen av spelaren, och hur våra bullets ska se ut
            player = new Player(Content.Load<Texture2D>("ship"), new Vector2(300,344), Content.Load<Texture2D>("bullet")); 

            //bottom level(Botten)
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(520, 400)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(350, 400)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(220, 400)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(90, 400)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(-40, 400)));
            //bottom mid level(Nära botten)
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(520, 290)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(350, 290)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(220, 290)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(90, 290)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(-40, 290)));
            //upper mid level(Nära toppen)
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(520, 180)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(350, 180)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(220, 180)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(90, 180)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(-40, 180)));
            //upper level(Topp)
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(520, 70)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(350, 70)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(220, 70)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(90, 70)));
            platforms.Add(new Platform(Content.Load<Texture2D>("platform"), new Vector2(-40, 70)));
            //TODO: use this.Content to load your game content here

            //create enemies metoden som vi använder för att ladda in flera enemies efter alla enemies är döda 
            CreateEnemies();

        }

        private void CreateEnemies() //metoden createenemies och koden som laddar in själva enemies
        {
            enemiesCount++;
            Random random = new Random();
            Texture2D tmpSprite = this.Content.Load<Texture2D>("mine");
            for (int i = 0; i < enemiesCount - 1; i++)
            {
                //int rndX = random.Next(0, Window.ClientBounds.Width - tmpSprite.Width);

                
                int rndY = random.Next(0, 3); //bestämmer vilken platform enemies kommer att laddas in på

                int rndX = random.Next(-200, 100); //bestämmer när de kommer fram eftersom de har samma speed

                int posY = 0; //Y till själva createenemies koden
                

                if (rndY == 0)
                {
                    posY = 40;
                }

                if (rndY == 1)
                {
                    posY = 150;
                }

                if (rndY == 2)
                {
                    posY = 260;
                }

                if (rndY == 3)
                {
                    posY = 380;
                }

               

                Mine temp = new Mine(tmpSprite, new Vector2(rndX , posY));
                enemies.Add(temp); // koden
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            IsMouseVisible = true;
       
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

         
          
            player.Update(gameTime, Window);

            //Kolla kollisioner med plattformar
            foreach(Platform pf in platforms)
            {
              
               if(player.CheckCollision(pf))
                {
                    player.PlatformCheck(pf);

                }

            }

            //  if(pla)

            foreach (Enemy e in enemies.ToList())
            {
                //Kontrollera om fienden kolliderar med ett skott
                foreach (Bullet b in player.bullets)
                {
                    if (e.CheckCollision(b))
                    {
                        e.IsAlive = false;  //Döda fienden
                        b.IsAlive = false;  //Döda skottet
                       
                    }
                }

                if (e.IsAlive)  //Kontrollera om fienden lever
                {   //Kontrollera kollision med spelaren
                    if (e.CheckCollision(player))
                    {
                       
                        System.Threading.Thread.Sleep(1000);
                        this.Exit();

                    }
                    e.Update(Window);   //Flytta på den
                }
                else //Ta bort fienden för den är död
                    enemies.Remove(e);
            }


            if (enemies.Count < 1)
            {

             
               
                CreateEnemies();

                
                
            }


            if (15 - enemiesCount == 0)
            {
                this.Exit();
            }
           

            base.Update(gameTime);
           
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            foreach (Platform platform in platforms)
                platform.Draw(spriteBatch);

            player.Draw(spriteBatch);

            foreach (Enemy e in enemies)
                e.Draw(spriteBatch);

            printText.Print("Rounds Left:" + (15 - enemiesCount + 1), spriteBatch, 0, 0);
            printText.Print("Enemies:" + enemies.Count, spriteBatch, 0, 20);
            printText.Print("Hold the Down button to sink down platforms for your bullets to hit", spriteBatch, 170, 10 );



            spriteBatch.End();




            base.Draw(gameTime);
        }
    }
}
