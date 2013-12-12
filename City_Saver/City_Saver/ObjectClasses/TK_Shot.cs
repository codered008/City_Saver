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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class TK_Shot : ObjectClasses.Weapon, Animation.attackAnimation
    {
        private int cost = 2;//the MP cost to use the attack
        private bool shotAnimation = false;//enable shot animation
        private Animation.Animation TK_animation;//the animation object for the telekinesis shot
        private Vector2 position;//the player's current position
        public TK_Shot()
        {
            AttackDamage = 10;//the damage amount of the attack
            
        }

        //returns the cost to use the attack
        public int getCost()
        {
            return cost;
        }
        //returns the play Animation status
        public bool getAnimationStatus()
        {
            return shotAnimation;
        }
        //Sets the animation boolean to true
        public void playAnimation()
        {
            shotAnimation = true;
        }

        public void setAnimation(ContentManager content, String spriteName, int frameNum, Vector2 playerPos)
        {
            TK_animation = new Animation.Animation(content, spriteName, 0.3f, frameNum, playerPos);
        }

        public Animation.Animation getAnimation()
        {
            return TK_animation;
        }
        //Assigns the attack the player's current position
        //Movement of attack will be horizontal only
        public void setPosition(Vector2 playerPos)
        {
            position = playerPos;
        }

        public Vector2 getPosition()
        {
            return position;
        }
        /*
         * ends the animation when the projectile hits an enemy
         * or goes off-screen
         */
        public void endAnimation()
        {
            shotAnimation = false;
        }

        protected void Update(GameTime gameTime)
        {
            //play animation here?
                //NO. Move into player class
            //When the player fires a TK shot, the attack moves to the right horizonatally only
            if (shotAnimation)
            {
                position.X += 2;
            }
        }

        void Animation.attackAnimation.playAttackAnimation()
        {
        }
    }
}
