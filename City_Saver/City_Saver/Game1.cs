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
        bool gameOver = false; //the game over validation

        //Variables used for setting up the character sprite
        //Texture2D TK_shot_texture;
        //Texture2D testSprite;
        Vector2 spriteOrigin;

        //The tools to create the string representation of the HP & MP
        SpriteFont romanFont;
        Vector2 hpPos;


        //Variables needed for creating the scrolling background

        //private ScrollingBackground myBackground;
        //City_Saver.ScrollingBackground myBackground = new City_Saver.ScrollingBackground();
        private ScrollingBackground myBackGround;
        Texture2D background1;
        Texture2D background2;
        Texture2D background3;
        Texture2D background4;
        Texture2D gameOverScreen;
        Texture2D pausedMenu;

        Vector2 backgroundOrigin;
        Vector2 screenPosition, screenOrigin, sizeOfTexture;
        int screenheight;   //Variable for the height of the viewport
        int screenwidth;    //Variable for the width of the viewport
        int newRoom = 0;       //Flag to draw a new room once the character has moved into it


        GamePadState currentControl;//the controller state of the player
        GamePadState prevControl;
        //The Telekinesis abilities of the player
        //TK_Shield barrier = new TK_Shield();      //Implemented further down
        //TK_Shot shot = new TK_Shot();             //Implemented further down
        Vector2 playerPosition = new Vector2(500, 500);     //Give player a starting position; can be changed easily
        Vector2 enemyPosition;
        float latMovementSpeed = 2.5f;             //Multiplication factor for movement speed

        /**The creation of the player object & other objects that will be used by the player**/
        ObjectClasses.Player player = new ObjectClasses.Player();
        ObjectClasses.TK_Shot TKShot = new ObjectClasses.TK_Shot();
        ObjectClasses.TK_Shield TKBarrier = new ObjectClasses.TK_Shield();
        

        //*****************Variables for enemies***********//
        Texture2D trooper;
        String robo_soldier;
        Texture2D enemy_ship;
        Texture2D securityrobot;
        Texture2D wallturret;
        Texture2D fireShooter;
        Texture2D[] enemies = new Texture2D[6];
        int rsCounter = 0;//counter for number of robot soldiers on screen
        bool collision = false;

        ObjectClasses.FireShooter fireS = new ObjectClasses.FireShooter();
        List<ObjectClasses.FireShooter> FireshooterList = new List<ObjectClasses.FireShooter>();

        ObjectClasses.RoboSoldier roboS = new ObjectClasses.RoboSoldier();
        ObjectClasses.RoboSoldier[] RoboSoldierList = new ObjectClasses.RoboSoldier[5];

        ObjectClasses.SecurityRobot secRob = new ObjectClasses.SecurityRobot();
        List<ObjectClasses.SecurityRobot> SecRobList = new List<ObjectClasses.SecurityRobot>();

        ObjectClasses.Trooper trooperS = new ObjectClasses.Trooper();
        List<ObjectClasses.Trooper> TrooperList = new List<ObjectClasses.Trooper>();

        ObjectClasses.Wallturret wallT = new ObjectClasses.Wallturret();
        List<ObjectClasses.Wallturret> WallTurretList = new List<ObjectClasses.Wallturret>();
        

        /***Collision Detection***/
        
       
        bool enemyAlive = true;

        /********Variables for pausing the game*********/
        bool gamePaused = false;
        bool pauseKeyDown = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }



        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            spriteOrigin = new Vector2(100, 100);
            //backgroundOrigin.X = graphics.GraphicsDevice.Viewport.Height / 2;
            //backgroundOrigin.Y = graphics.GraphicsDevice.Viewport.Width / 2;
            backgroundOrigin.X = 0;
            backgroundOrigin.Y = 0;

            //loads the font for representing statuses
            romanFont = Content.Load<SpriteFont>("Times New Roman");
            hpPos = new Vector2(50, 50);

            //Enemy Position initialize
            enemyPosition = new Vector2(700, 500);
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //testSprite = Content.Load<Texture2D>("SpriteAnimation//Hero(Exile)AttackAnimation");

            String player_walking = "SpriteAnimation\\HeroForwardWalk";
            String player_stationary = "SpriteAnimation\\StationaryHero";
            String player_back_walk = "SpriteAnimation\\HeroBackWalk";
            String player_attack_melee = "SpriteAnimation\\MeleeSprite";

            //Set the player's sprite animation
            player.setWalkingAnimation(Content, player_walking, 5, playerPosition);
            player.setMeleeAnimation(Content, player_attack_melee, 1, playerPosition);

            /*****Used for animating the TK attacks******/
            String telek_shot = "SpriteAnimation\\TKShot";
            String telek_shield = "SpriteAnimation\\Barrier";

            TKShot.setAnimation(Content, telek_shot, 1, player.getWalkingAni().getPosition());
            TKBarrier.setBarrierAnimation(Content, telek_shield, 1, player.getWalkingAni().getPosition());
            player.setShot(TKShot);
            player.setShield(TKBarrier);

            /*****Used for scrolling background - Start****/
            myBackGround = new ScrollingBackground();
            background1 = Content.Load<Texture2D>("Background//TestSpriteBackGround");
            background2 = Content.Load<Texture2D>("Background//Concrete_slate");
            background3 = Content.Load<Texture2D>("Background//jade_slate");
            background4 = Content.Load<Texture2D>("Background//marble_slate");
            myBackGround.Load(GraphicsDevice, background1);

            pausedMenu = Content.Load<Texture2D>("Sprites\\PauseMenu");
            gameOverScreen = Content.Load<Texture2D>("Sprites\\GameOverScreen");

            screenheight = GraphicsDevice.PresentationParameters.BackBufferHeight;//graphics.GraphicsDevice.Viewport.Height;
            screenwidth = GraphicsDevice.PresentationParameters.BackBufferWidth;//graphics.GraphicsDevice.Viewport.Width;
            backgroundOrigin = new Vector2(background1.Width / 2, 0);

            screenPosition = new Vector2(screenwidth / 2, screenheight / 2);
            sizeOfTexture = new Vector2(0, background1.Height);
            /*****Used for scrolling background - End*****/

            //****Enemy Sprites****//
            trooper = Content.Load<Texture2D>("Sprites//Enemy//trooper");
            robo_soldier = "Sprites//Enemy//RoboSoldier";
            securityrobot = Content.Load<Texture2D>("Sprites//Enemy//securityrobot");
            wallturret = Content.Load<Texture2D>("Sprites//Enemy//wallturret");
            enemy_ship = Content.Load<Texture2D>("Sprites//Enemy//enemy_ship");
            fireShooter = Content.Load<Texture2D>("Sprites//Enemy//fireShooter");


            roboS.setAnimation(Content, robo_soldier, 1, enemyPosition);
            //fills the array with robot soldier objects
            for (int i = 0; i < RoboSoldierList.Length; i++)
            {
                RoboSoldierList[i] = roboS;
            }


            
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
                /*****Checks for a gane over*****/
                if (player.getHealth() == 0)
                {
                    gameOver = true;
                }
                else
                {
                    /******Checking for user pause******/
                    checkForPauseKey(currentControl);
                    //Freeze the current state of the game
                    if (!gamePaused)
                    {

                        prevControl = currentControl;
                        /**********Handles Left and Right Horizontal movement */
                        if (currentControl.ThumbSticks.Left.X != 0)
                        {
                            playerPosition.X += (currentControl.ThumbSticks.Left.X) * latMovementSpeed;
                            //Reset the player's location when they try to go off screen
                            if (playerPosition.X < 100)
                            {
                                //Sprite stays on screen
                                playerPosition.X = 100;


                            }
                            if (playerPosition.X > graphics.GraphicsDevice.Viewport.Width)
                            {
                                playerPosition.X = 0;       //Reset player's X position to the left side of the screen.
                            }
                            //sets the player sprite's new position
                            player.getWalkingAni().setPosition(playerPosition);
                        }

                        /**********Handles Up and Down Vertical movement */
                        if (currentControl.ThumbSticks.Left.Y != 0)
                        {
                            playerPosition.Y -= (currentControl.ThumbSticks.Left.Y) * latMovementSpeed;
                            //Keeps the sprite on the screen
                            if (playerPosition.Y <= (graphics.GraphicsDevice.Viewport.Height / 2) + 150)
                            {
                                //playerPosition.Y = testSprite.Height * 2;
                                playerPosition.Y = (graphics.GraphicsDevice.Viewport.Height / 2) + 150;//resets the Y value to zero to avoid going off screen
                            }
                            if (playerPosition.Y > graphics.GraphicsDevice.Viewport.Height)
                            {
                                playerPosition.Y = graphics.GraphicsDevice.Viewport.Height+10;//sets Y to the furthest height it can go
                            }
                            player.getWalkingAni().setPosition(playerPosition);

                        }

                        /*
                         * The telekinesis ability activation by the player
                         * LT = TK Shot
                         * RT = TK Shield
                         */
                        //*****The Telekinesis Abilities*******//
                        //Activate the TK Shot
                        if (currentControl.Triggers.Left == 1.0f && currentControl.Triggers.Right == 0 && (player.getMagic() >= 5))
                        {

                            player.getShot().setPosition(player.getWalkingAni().getPosition());//gives the shot the player's current position
                            player.getShot().playAnimation();
                            player.currentAnimationNumber = 1; //the shot was activated
                            //  player.shotCost();

                            /**Collision Detection**/
                            //Rectangle boundRect = Animation.Animation.getBounding();

                        }

                        //Move to DRAW Method
                        //The TK shot sprite is removed when image either hits an enemy or goes out of range
                        if ((player.getShot().getPosition().X > graphics.GraphicsDevice.Viewport.Width)) //player.getShot().getAnimation().getBounding().Intersects()//hits an enemy)
                        {
                            player.getShot().endAnimation();
                            player.currentAnimationNumber = 0;
                            
                        }

                        //Activates the TK Shield
                        if (currentControl.Triggers.Right == 1.0f && currentControl.Triggers.Left == 0 && (player.getMagic() > 0))
                        {
                            player.getShield().setPosition(player.getWalkingAni().getPosition());
                            player.getShield().playAnimation();
                            player.currentAnimationNumber = 2;

                        }
                        else
                        {
                            player.getShield().stopAnimation();
                            player.currentAnimationNumber = 0;
                        }

                        //*******The Melee Ability*******//
                        //The player's melee attack functionality
                        if (currentControl.IsButtonDown(Buttons.A))
                        {
                            player.getMeleeAnimation().setPosition(player.getWalkingAni().getPosition());
                            player.playAttackAnimation();
                            player.getMeleeAnimation().playAnim(gameTime);
                            player.currentAnimationNumber = 3;

                        }
                        else
                        {
                            player.stopAttackAnimation();
                            player.currentAnimationNumber = 0;
                        }
                        player.getWalkingAni().playAnim(gameTime);
                        for (int j = 0; j < RoboSoldierList.Length; j++)
                        {
                            RoboSoldierList[j].Update(gameTime);
                        }
                    }

                    
                }
                
            }
            //IsMouseVisible = true;

            /**Check if enemies have been killed**/
            /**If enemy is dead, enemyAlive == false)**/

            //Collision Detection
            //loop here
            collision = player.getWalkingAni().getBounding().Intersects(RoboSoldierList[1].getAnimation().getBounding());

            switch (player.currentAnimationNumber)
            {
                case 0:
                    if (Math.Abs(player.getWalkingAni().getPosition().X - RoboSoldierList[rsCounter].getAnimation().getPosition().X) <= 30 ||
                        Math.Abs(player.getWalkingAni().getPosition().Y - RoboSoldierList[rsCounter].getAnimation().getPosition().Y) <= 30)
                    {

                        if (checkForCollision(player.getWalkingAni().getBounding(), RoboSoldierList[rsCounter].getAnimation().getBounding()))
                        {
                            //Player was damaged
                            player.HPdamage(RoboSoldierList[rsCounter].getDamage());
                        }
                    }
                    break;
                case 1:
                    if (checkForCollision(player.getShot().getAnimation().getBounding(), RoboSoldierList[rsCounter].getAnimation().getBounding()))
                    {
                        //the shot damages the robot on contact
                    }
                    break;
                case 2:
                    if(checkForCollision(player.getShield().getShieldAnimation().getBounding(), RoboSoldierList[rsCounter].getAnimation().getBounding()))
                    {
                        //no damage
                    }
                    break;
                case 3:
                    if (checkForCollision(player.getMeleeAnimation().getBounding(), RoboSoldierList[rsCounter].getAnimation().getBounding()))
                    {
                        RoboSoldierList[rsCounter].hpDamage(player.getMeleeDamage());
                    }
                    
                    break;
            }
            //if collision is true
            //player.damage(roboSoldierList[loopNumber].getDamage());

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            myBackGround.Update(elapsed * 100);
            player.Update(gameTime);
            

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
            spriteBatch.DrawString(romanFont, "Health:  " + player.getHealth() + "\nMagic:   " + player.getMagic(), hpPos, Color.Red);

            //If the player moves to the right side of the screen, reset the character's X position to the left side of the screen
            if (playerPosition.X > graphics.GraphicsDevice.Viewport.Width - 15)
            {
                playerPosition.X = 50;       //Reset player's X position to the left side of the screen.
                newRoom++;                 //Increment newRoom flag to allow for color change
                if (newRoom == 4)           //Can make this any number we desire
                {
                    newRoom = 0;            //Reset room color change as needed
                }

            }
            if (player.getAttackAniStatus())
            {
                player.getMeleeAnimation().Draw(spriteBatch);
            }

            if (player.getShot().getAnimationStatus())
            {
                //Console.WriteLine(player.getMagic());
                //Console.WriteLine(player.getShot().getPosition());
                player.getShot().getAnimation().Draw(spriteBatch);
            }

            //***********Enemy generation****///
            if (newRoom == 0)
            {
                //FireshooterList.Add(fireS);
                ////enemyAlive == FireshooterList.ElementAt<0>.fireS.
                //if (enemyAlive==true)
                //{
                //    spriteBatch.Draw(enemies[0], enemyPosition, Color.White);
                //}
                int num_fo_enemies = 0;
                if (rsCounter < 2)
                {
                    if (num_fo_enemies < 1)
                    {
                        RoboSoldierList[rsCounter].getAnimation().Draw(spriteBatch);
                        spriteBatch.DrawString(romanFont, "Robot HP: " + RoboSoldierList[rsCounter].getHealth(), new Vector2(500, 300), Color.Red);
                        num_fo_enemies++;
                    }
                    if (!RoboSoldierList[rsCounter].robotIsAlive())
                    {
                        num_fo_enemies = 0;
                        rsCounter++;
                    }

                }
            }

            if (newRoom == 1)
            {
                int num_fo_enemies = 0;
                if (rsCounter < 2)
                {
                    if (num_fo_enemies < 1)
                    {
                        RoboSoldierList[rsCounter].getAnimation().Draw(spriteBatch);
                        num_fo_enemies++;
                    }
                        if (!RoboSoldierList[rsCounter].robotIsAlive())
                        {
                            num_fo_enemies = 0;
                            rsCounter++;
                        }
                    
                }
                
            }

            //if (newRoom == 2)
            //{
            //    rsCounter = 0;
            //    int counter = 0;
            //    if (enemyAlive == true)
            //    {
            //        spriteBatch.Draw(fireShooter, enemyPosition, Color.White);
            //    }
            //}


            // spriteBatch.Draw(testSprite, playerPosition, null, Color.White, 0f, new Vector2(100,100), 1f, SpriteEffects.None, 1f);  // Keep the scaling factor above zero or the sprite disappears!
            
            //the animation for the TK shield
            if (!player.getShield().getAnimationStatus())
            {
                player.getWalkingAni().Draw(spriteBatch);
            }
            else
            {
                player.getShield().getShieldAnimation().Draw(spriteBatch);
            }
            //The animation for Melee Attack
            if (!player.getAttackAniStatus())
            {
                player.getWalkingAni().Draw(spriteBatch);
            }
            else
            {
                player.getMeleeAnimation().Draw(spriteBatch);
                //Collide method call here
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawScenery()
        {
            Rectangle screenRect = new Rectangle(0, 0, screenwidth, screenheight);
            //Player got a game over
            if (gameOver)
            {
                spriteBatch.Draw(gameOverScreen, screenRect, Color.White);
            }

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
            //Displays the pause menu
            if (gamePaused && !gameOver)
            {
                spriteBatch.Draw(pausedMenu, screenRect, Color.White);
            }
            

        }


        //Check for beginning of Pause
        private void BeginPause(bool playerPause)
        {
            gamePaused = true;
            //TODO: Pause any audio
            //TODO: Pause any vibration
        }

        //Check for end of Pause
        private void EndPause()
        {
            gamePaused = false;
        }

        private void checkForPauseKey(GamePadState gamePadState)
        {
            bool pauseKeyDownNow = (gamePadState.Buttons.Start == ButtonState.Pressed);

            if (!pauseKeyDown && pauseKeyDownNow)
            {
                if (!gamePaused)
                    BeginPause(true);
                else
                    EndPause();
            }
            pauseKeyDown = pauseKeyDownNow;
        }

        public bool checkForCollision(Rectangle mainChar, Rectangle other)
        {
            return mainChar.Intersects(other);
        }
    }
}
