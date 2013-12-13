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
        Vector2 shooterPos;
        float currentTime = 0;
        float timeDuration = 1f;
        bool isEnemy = true; //registers the object as an enemy to the player
        bool isAlive = true;
        List<Bullet> fireBullets = new List<Bullet>();//the bullets the enemy will shoot
        Bullet bullet = new Bullet();

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
            setPosition(position);
            fireShooterAni = new Animation.Animation(content, assetName, 0.3f, frameNumber, position);
        }

        public void setPosition(Vector2 pos)
        {
            shooterPos = pos;
        }
        public void createBullets(ContentManager content)
        {
            String assetName = "Sprites\\FireBullet";
            bullet.setBulletAnimation(content, assetName, 1, shooterPos);

            //Adds an amount of bullets to the enemy's pack
            for (int i = 0; i < 30; i++)
            {
                fireBullets.Add(bullet);
            }
        }
         
        public void Update(GameTime gameTime)
        {
            //Has the monster shoot a bullet

            if (Health <= 0)
            {
                isAlive = false;
            }
            else
            {
                foreach (Bullet b in fireBullets)
                {
                    b.Update(gameTime);
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
}
