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
    class Bullet : ObjectClasses.Weapon
    {
        private Vector2 position;//the current position of the bullet
        private bool isActive = false;//if the bullet is currently active ingame
        Animation.Animation bulletAnimation;//the animation for the bullet

        public Bullet()
        {
            AttackDamage = 10;
        }

        public int getDamage()
        {
            return AttackDamage;
        }

        public Animation.Animation getBulletAnimation()
        {
            return bulletAnimation;
        }

        public void setBulletAnimation(ContentManager content, String asset, int frameNumber, Vector2 shooterPos)
        {
            //Creating the animation sprite for the bullet
            //the position of the shooter will not move(unlike the player), so the bullet's initial position can be
            //set here   
            bulletAnimation = new Animation.Animation(content, asset, 0.3f, frameNumber, shooterPos);
            position = shooterPos;
        }

        public Vector2 getBulletPosition()
        {
            return position;
        }
        //Will be used to represent getAnimationStatus
        public bool getBulletStatus()
        {
            return isActive;
        }

        public void setActive()
        {
            isActive = true;
        }
        public void Update(GameTime gameTime)
        {
            //If the bullet has been shot, show it moving
            if (isActive)
            {
                position.X -= 10;
                bulletAnimation.setPosition(position);
            }
        }
    }
}
