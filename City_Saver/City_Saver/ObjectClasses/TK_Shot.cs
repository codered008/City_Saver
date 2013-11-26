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
