using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace City_Saver
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Animation.Animation player_walkingSprite;

        //Variables used for setting up the character sprite
        Texture2D testSprite;
        Vector2 spriteOrigin;

        //Variables needed for creating the scrolling background

        //private ScrollingBackground myBackground;
        //City_Saver.ScrollingBackground myBackground = new City_Saver.ScrollingBackground();
        private ScrollingBackground myBackGround;
        Texture2D background1;
        Texture2D background2;
        Texture2D background3;
        Texture2D background4;
        Vector2 backgroundOrigin;
        Vector2 screenPosition, screenOrigin, sizeOfTexture;
        int screenheight;   //Variable for the height of the viewport
        int screenwidth;    //Variable for the width of the viewport
        int newRoom = 0;       //Flag to draw a new room once the character has moved into it


        GamePadState currentControl;//the controller state of the player
        //The Telekinesis abilities of the player
        //TK_Shield barrier = new TK_Shield();      //Implemented further down
        //TK_Shot shot = new TK_Shot();             //Implemented further down
        Vector2 playerPosition = new Vector2(400, 400);     //Give player a starting position; can be changed easily
        float latMovementSpeed = 2.5f;             //Multiplication factor for movement speed
        
        ObjectClasses.Player player = new ObjectClasses.Player();


        //*****************Textures for enemies***********//
        Texture2D enemy1;
        Texture2D enemy2;
        Texture2D enemy_ship;
        Texture2D securityrobot;
        Texture2D wallturret;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

 
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            spriteOrigin = new Vector2(100,100);
            //backgroundOrigin.X = graphics.GraphicsDevice.Viewport.Height / 2;
            //backgroundOrigin.Y = graphics.GraphicsDevice.Viewport.Width / 2;
            backgroundOrigin.X = 0;
            backgroundOrigin.Y = 0;

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            testSprite = Content.Load<Texture2D>("SpriteAnimation//Hero(Exile)AttackAnimation");
            String player_walking = "SpriteAnimation//Hero(Exile)WalkingAnimation";
            player.setWalkingAnimation(Content, player_walking, 5, playerPosition);
            /*****Used for scrolling background - Start****/
            myBackGround = new ScrollingBackground();
            
            background1 = Content.Load<Texture2D>("Background//TestSpriteBackGround");
            background2 = Content.Load<Texture2D>("Background//Concrete_slate");
            background3 = Content.Load<Texture2D>("Background//jade_slate");
            background4 = Content.Load<Texture2D>("Background//marble_slate");
            myBackGround.Load(GraphicsDevice, background1);
            screenheight = GraphicsDevice.PresentationParameters.BackBufferHeight;//graphics.GraphicsDevice.Viewport.Height;
            screenwidth = GraphicsDevice.PresentationParameters.BackBufferWidth;//graphics.GraphicsDevice.Viewport.Width;
            backgroundOrigin = new Vector2(background1.Width / 2, 0);
            screenPosition = new Vector2(screenwidth / 2, screenheight / 2);
            sizeOfTexture = new Vector2(0, background1.Height);
            /*****Used for scrolling background - End*****/

            //****Enemy Sprites****//
            enemy1 = Content.Load<Texture2D>("Sprites//Enemy//enemy1");
            enemy2 = Content.Load<Texture2D>("Sprites//Enemy//enemy2");
            enemy_ship = Content.Load<Texture2D>("Sprites//Enemy//enemy_ship");
            securityrobot = Content.Load<Texture2D>("Sprites//Enemy//securityrobot");
            wallturret = Content.Load<Texture2D>("Sprites//Enemy//wallturret");



        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            currentControl = GamePad.GetState(PlayerIndex.One);
            player.getWalkingAni();

            if (currentControl.IsConnected)
            {
                /**********Handles Left and Right Horizontal movement */
                if (currentControl.ThumbSticks.Left.X != 0)
                {
                    playerPosition.X += (currentControl.ThumbSticks.Left.X) * latMovementSpeed;
                    if (playerPosition.X < 0 + testSprite.Width)
                    {
                        playerPosition.X = testSprite.Width;
                    }
                    player.getWalkingAni();

                }

                /**********Handles Up and Down Vertical movement */
                if (currentControl.ThumbSticks.Left.Y != 0)
                {
                    playerPosition.Y -= (currentControl.ThumbSticks.Left.Y) * latMovementSpeed;

                    if (playerPosition.Y < 0 + testSprite.Height)
                    {
                        playerPosition.Y = testSprite.Height * 2;
                    }

                    if (playerPosition.Y > screenheight - testSprite.Height)
                    {
                        playerPosition.Y = screenheight - testSprite.Height;
                    }
                    player.getWalkingAni();

                }
            }
            player.Update(gameTime);

            // TODO: Add your update logic here
            //IsMouseVisible = true;

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            myBackGround.Update(elapsed * 100);
            

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //spriteBatch.Draw(testSprite, playerPosition,Color.White);     //Keep this one around for testing, it works, no bells and whistles
            //spriteBatch.Draw(background, backgroundOrigin, null, Color.White, 0f, new Vector2(0, 0), 9f, SpriteEffects.None, 0f);
            //myBackGround.Draw(spriteBatch);
            DrawScenery();

            //If the player moves to the right side of the screen, reset the character's X position to the left side of the screen
            if (playerPosition.X > graphics.GraphicsDevice.Viewport.Width)
            {
                playerPosition.X = 0 + testSprite.Width;       //Reset player's X position to the left side of the screen.
                newRoom ++;                 //Increment newRoom flag to allow for color change
                if (newRoom == 4)           //Can make this any number we desire
                {
                    newRoom = 0;            //Reset room color change as needed
                }

            }

            spriteBatch.Draw(enemy1, new Vector2(200, 200), Color.White);

           // spriteBatch.Draw(testSprite, playerPosition, null, Color.White, 0f, new Vector2(100,100), 1f, SpriteEffects.None, 1f);  // Keep the scaling factor above zero or the sprite disappears!
            player.getWalkingAni().Draw(spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        private void DrawScenery()
        {
            Rectangle screenRect = new Rectangle(0,0, screenwidth, screenheight);
            //if (newRoom == 0)
            //{
            //     spriteBatch.Draw(background, screenRect, Color.White);
            //}
            switch (newRoom)
            {
                case 0:
                    {
                        spriteBatch.Draw(background1, screenRect, Color.White);
                        break;
                    }
                case 1:
                    {
                        spriteBatch.Draw(background2, screenRect, Color.Yellow);
                        break;
                    }
                case 2:
                    {
                        spriteBatch.Draw(background3, screenRect, Color.Purple);
                        break;
                    }
                case 3:
                    {
                        spriteBatch.Draw(background4, screenRect, Color.Green);
                        break;
                    }

            }
        }
    }
}
