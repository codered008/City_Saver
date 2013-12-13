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

        /*
         * The Methods for the Bullet
         * Here
         * 
         */
        public void Update(GameTime gameTime)
        {
            //Has the monster shoot a bullet
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
