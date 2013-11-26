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
        

        //Variables used for setting up the character sprite
        Texture2D testSprite;
        Vector2 spriteOrigin;

        //Variables needed for creating the scrolling background

        //private ScrollingBackground myBackground;
        //City_Saver.ScrollingBackground myBackground = new City_Saver.ScrollingBackground();
        //private ScrollingBackground myBackGround;
        Texture2D background;
        Vector2 backgroundOrigin;
        //Vector2 screenPosition, screenOrigin, sizeOfTexture;
        //int screenheight;
        //int screenwidth;


        GamePadState currentControl;//the controller state of the player
        //The Telekinesis abilities of the player
        //TK_Shield barrier = new TK_Shield();      //Implemented further down
        //TK_Shot shot = new TK_Shot();             //Implemented further down
        Vector2 playerPosition = new Vector2(0, 0);     //Give player a starting position; can be changed easily
        float latMovementSpeed = 2.5f;             //Multiplication factor for movement speed
        
        ObjectClasses.Player player = new ObjectClasses.Player();

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
            ///*****Used for scrolling background - Start****/
            //myBackGround = new ScrollingBackground();
            
            background = Content.Load<Texture2D>("Background//TestSpriteBackGround");
            //myBackGround.Load(GraphicsDevice, background);
            //screenheight = graphics.GraphicsDevice.Viewport.Height;
            //screenwidth = graphics.GraphicsDevice.Viewport.Width;
            //backgroundOrigin = new Vector2(background.Width / 2, 0);
            //screenPosition = new Vector2 (screenwidth /2, screenheight /2);
            //sizeOfTexture = new Vector2(0, background.Height);
            ///*****Used for scrolling background - End*****/

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

            if (currentControl.IsConnected)
            {
                /**********Handles Left and Right Horizontal movement */
                if (currentControl.ThumbSticks.Left.X != 0)
                {
                    playerPosition.X += (currentControl.ThumbSticks.Left.X) * latMovementSpeed;
                }

                /**********Handles Up and Down Vertical movement */
                if (currentControl.ThumbSticks.Left.Y != 0)
                {
                    playerPosition.Y -= (currentControl.ThumbSticks.Left.Y) * latMovementSpeed;
                }
            }
            player.Update(gameTime);

            // TODO: Add your update logic here
            //IsMouseVisible = true;

            //float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //myBackGround.Update(elapsed * 100);
            

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            //spriteBatch.Draw(testSprite, playerPosition,Color.White);     //Keep this one around for testing, it works, no bells and whistles
            spriteBatch.Draw(background, backgroundOrigin, null, Color.White, 0f, new Vector2(0, 0), 9f, SpriteEffects.None, 0f);
            //myBackGround.Draw(spriteBatch);
            spriteBatch.Draw(testSprite, playerPosition, null, Color.White, 0f, new Vector2(0,0), 1f, SpriteEffects.None, 1f);  // Keep the scaling factor above zero or the sprite disappears!
            
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
