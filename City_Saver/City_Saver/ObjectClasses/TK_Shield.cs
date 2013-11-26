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
    public class TK_Shield :ObjectClasses.Weapon
    {
        private int cost = 1;
        private bool animationState = false;
        public TK_Shield()
        {
            AttackDamage = 0;
        }

        public int MPcost
        {
            get
            {
                return cost;
            }
        }

        public bool getAnimationStatus()
        {
            return animationState;
        }

        public void playAnimation()
        {
            animationState = true;
        }

        public void stopAnimation() 
        { 
            animationState = false; 
        }

        public void Update(GameTime gameTime)
        {
            if (getAnimationStatus())
            {
                //Play animation code
            }
        }
    }
}
