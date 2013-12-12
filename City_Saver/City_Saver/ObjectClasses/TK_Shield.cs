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
    public class TK_Shield : ObjectClasses.Weapon
    {
        private int cost = 1;
        private bool animationState = false;
        private Animation.Animation barrierAnimation;
        private Vector2 position;
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

        public void setPosition(Vector2 playerPosition)
        {
            position = playerPosition;
        }
        public bool getAnimationStatus()
        {
            return animationState;
        }

        public void playAnimation()
        {
            animationState = true;
        }

        public void setBarrierAnimation(ContentManager content, String assetName, int frameNumber, Vector2 playerPosition)
        {
            barrierAnimation = new Animation.Animation(content, assetName, 0.3f, frameNumber, playerPosition);
        }
        public void stopAnimation()
        {
            animationState = false;
        }

        public Animation.Animation getShieldAnimation()
        {
            return barrierAnimation;
        }

        public void Update(GameTime gameTime)
        {
            if (getAnimationStatus())
            {
                barrierAnimation.setPosition(position);
            }
        }
    }
}
