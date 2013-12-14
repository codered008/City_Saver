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
    class Player : ObjectClasses.People, Animation.walkAnimation
    {
        Animation.Animation walkAnimation;
        Animation.Animation attackAnimation;
        Animation.Animation backWalkAnimation;


        //The Telekinesis abilities of the player
        TK_Shield barrier = new TK_Shield();      //Implemented further down
        TK_Shot shot = new TK_Shot();             //Implemented further down

        // Vector2 playerPosition;     //Give player a starting position; can be changed easily
        float latMovementSpeed = 0.95f;             //Multiplication factor for movement speed
        float countDuration = 1f;//every 2 seconds
        float currentTime = 0; //the current time on game clock

        int animationNumber = 0;//keeps track of which animation the player is currently on. 0 = normal, 1 = shot, 2= barrier, 3 = melee
        int meleeDamage = 3;
        bool playATKAnimation = false;
        bool isAlive = true;//For game over validation


        public Player()
        {
            Health = 100;
            Magic = 50;
        }

        public int getHealth()
        {
            return Health;
        }

        public int getMeleeDamage()
        {
            return meleeDamage;
        }
        //depletes the health from the damage taken
        public void HPdamage(int dmg)
        {
            Health -= dmg;
        }

        public int getMagic()
        {
            return Magic;
        }

        public void shotCost()
        {
            Magic = Magic - shot.getCost();
        }

        public bool getAttackAniStatus()
        {
            return playATKAnimation;
        }

        public void playAttackAnimation()
        {
            playATKAnimation = true;
        }

        public void stopAttackAnimation()
        {
            playATKAnimation = false;
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

        public void setShield(TK_Shield shield)
        {
            barrier = shield;
        }
        public Animation.Animation getWalkingAni()
        {
            return walkAnimation;
        }

        public int currentAnimationNumber
        {
            get
            {
                return animationNumber;
            }
            set
            {
                animationNumber = value;
            }
        }
        public void setWalkingAnimation(ContentManager content, String spriteName, int frameNum, Vector2 playerPos)
        {
            walkAnimation = new Animation.Animation(content, spriteName, 0.30f, frameNum, playerPos);
        }

        public Animation.Animation getMeleeAnimation()
        {
            return attackAnimation;
        }

        public void setMeleeAnimation(ContentManager c, String sName, int frNum, Vector2 playerPos)
        {
            attackAnimation = new Animation.Animation(c, sName, 0.30f, frNum, playerPos);
        }

        public void Update(GameTime gameTime)
        {
            getShot().Update(gameTime);
            getShield().Update(gameTime);

            //Once HP hits 0, game over
            if (Health == 0)
            {
                isAlive = false;
            }
            float shotTimeDuration = 2f;//the time duration for the TK shot

            //if the player has fired a shot, then subtract the cost of the attack from MP
            if (shot.getAnimationStatus())
            {
                currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (currentTime >= shotTimeDuration)
                {
                    Magic -= shot.getCost();
                    currentTime -= shotTimeDuration;
                }
            }
            //Decreases the MP as long as the barrier is activated
            if (barrier.getAnimationStatus())
            {
                currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                //Every 2 seconds will deplete the player's MP from using the ability
                if (currentTime >= countDuration)
                {
                    Magic -= barrier.MPcost;
                    currentTime -= countDuration;//use up the time
                }
            }
        }

        public bool getLifeStatus(){
            return isAlive;
        }

        void Animation.walkAnimation.playWalkAnimation()
        {

        }





    }
}
