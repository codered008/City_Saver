using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace City_Saver.ObjectClasses
{
    class Player: ObjectClasses.People, Animation.walkAnimation
    {
        GamePadState currentControl;//the controller state of the player
        //The Telekinesis abilities of the player
        //TK_Shield barrier = new TK_Shield();      //Implemented further down
        //TK_Shot shot = new TK_Shot();             //Implemented further down
        Vector2 playerPosition = new Vector2(0, 0);     //Give player a starting position; can be changed easily
        float latMovementSpeed = 0.95f;             //Multiplication factor for movement speed

        /********Variables for pausing the game*********/
        bool gamePaused = false;
        bool pauseKeyDown = false;


        public Player()
        {
            
        }

        /*
         * Maybe add a LoadContent method here?
         */

        public void Update(GameTime gameTime)
        {
            TK_Shot shot = new TK_Shot();
            TK_Shield barrier = new TK_Shield();
            //moves the player right-forward
            if (currentControl.IsConnected)
            {
                /******Checking for user pause******/
                checkForPauseKey(currentControl);

                //if (currentControl.ThumbSticks.Left.X != 0)
                //{
                //    playerPosition.X += (currentControl.ThumbSticks.Left.X) * latMovementSpeed;
                //}

                ///**********Handles Up and Down Vertical movement */
                //if (currentControl.ThumbSticks.Left.Y != 0)
                //{
                //    playerPosition.Y -= (currentControl.ThumbSticks.Left.Y) * latMovementSpeed;
                //}


                //if (currentControl.ThumbSticks.Left.X == 1.0f)
                //{
                //    playerPosition.X += (currentControl.ThumbSticks.Left.X * latMovementSpeed);
                //}
                ////moves the player left-backwards
                //else if (currentControl.ThumbSticks.Left.X == 1.0f)
                //{
                //    playerPosition.X -= (currentControl.ThumbSticks.Left.X * latMovementSpeed);
                //}

                /**********Handles Left and Right Horizontal movement */
                playerPosition.X += (currentControl.ThumbSticks.Left.X * latMovementSpeed);
                

                /**********Handles Up and Down Vertical movement */
                playerPosition.Y += (currentControl.ThumbSticks.Left.Y * latMovementSpeed);

                /*
                 * The vertical movement of the player
                 * HERE
                 */

                //if (currentControl.ThumbSticks.Left == )
                //{
                    
                //}


                /*
                 * The diagonal movement of the player
                 * HERE
                 */

                /*
                 * The telekinesis ability activation by the player
                 * LT = TK Shot
                 * RT = TK Shield
                 */
                //Activate the TK Shot
                if (currentControl.Triggers.Left == 1.0f)
                {
                    shot.playAnimation();
                }
                else
                {
                    shot.endAnimation();
                }

                //Activates the TK Shield
                if (currentControl.Triggers.Right == 1.0f)
                {
                    barrier.playAnimation();
                }
                else
                {
                    barrier.stopAnimation();
                }

            }
        }

        void Animation.walkAnimation.playWalkAnimation()
        {
            
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

    }
}
