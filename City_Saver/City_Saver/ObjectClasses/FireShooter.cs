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
    class FireShooter: ObjectClasses.People
    {
        Animation.Animation fireShooterAni;
        float currentTime = 0;
        float timeDuration = 1f;
        bool isEnemy = true; //registers the object as an enemy to the player
        bool isAlive = true;
        //Firebullet object here

        public FireShooter()
        {
            Health = 30;
            Magic = 0;
        }

        //The enemy takes damage
        public void hpDamage(int damage)
        {
            Health -= damage;
        }

        public Animation.Animation getSpriteAnimation()
        {
            return fireShooterAni;
        }
        public void setSpriteAnimation(ContentManager content, String assetName, int frameNumber, Vector2 position)
        {
            fireShooterAni = new Animation.Animation(content, assetName, 0.3f, frameNumber, position);
        }

        //public void createBullet
         
        public void Update(GameTime gameTime)
        {
            //Has the monster shoot a bullet

            if (Health <= 0)
            {
                isAlive = false;
            }

            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (currentTime >= timeDuration)
            {
                //Shoot a bullet
                //Put code here
                currentTime -= timeDuration;
            }


        }
    }
}
