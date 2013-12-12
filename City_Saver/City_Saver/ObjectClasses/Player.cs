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
        Animation.Animation walkAnimation;
        Animation.Animation attackAnimation;
        Animation.Animation backWalkAnimation;

        //The Telekinesis abilities of the player
        TK_Shield barrier = new TK_Shield();      //Implemented further down
        TK_Shot shot = new TK_Shot();             //Implemented further down

       // Vector2 playerPosition;     //Give player a starting position; can be changed easily
        float latMovementSpeed = 0.95f;             //Multiplication factor for movement speed

        /********Variables for pausing the game*********/
        bool gamePaused = false;
        bool pauseKeyDown = false;


        public Player()
        {
            Health = 100;
            Magic = 50;
        }

        public int getHealth()
        {
            return Health;
        }

        public int getMagic()
        {
            return Magic;
        }

        public TK_Shot getShot()
        {
            return shot;
        }
        //assigns the player a Telekinesis Shot object
        public void setShot(TK_Shot s)
        {
            shot = s;
        }
        public TK_Shield getShield()
        {
            return barrier;
        }

        public Animation.Animation getWalkingAni()
        {
            return walkAnimation;
        }

        public void setWalkingAnimation(ContentManager content, String spriteName, int frameNum, Vector2 playerPos)
        {
            walkAnimation = new Animation.Animation(content, spriteName, 0.30f, frameNum, playerPos);
        }

        public void Update(GameTime gameTime)
        {
            
            //moves the player right-forward
            if (currentControl.IsConnected)
            {
                /******Checking for user pause******/
                checkForPauseKey(currentControl);


            }
            //if the player has fired a shot, then subtract the cost of the attack from MP
            if (shot.getAnimationStatus())
            {
                Magic = Magic - shot.getCost();
            }
            //Decreases the MP as long as the barrier is activated
            if (barrier.getAnimationStatus())
            {
                Magic -= barrier.MPcost;
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
