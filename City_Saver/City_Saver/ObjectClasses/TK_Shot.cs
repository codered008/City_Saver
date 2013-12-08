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

        public void setAnimation(Animation.Animation ani)
        {
            TK_animation = ani;
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
            if (shotAnimation)
            {

            }
        }

        void Animation.attackAnimation.playAttackAnimation()
        {
        }
    }
}
