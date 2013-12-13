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
    class Trooper : ObjectClasses.People
    {
        Animation.Animation TrooperAni;
        float currentTime = 0;
        float timeDuration = 1f;
        Vector2 enemyPosition;
        bool isEnemy = true; //registers the object as an enemy to the player
        bool isAlive = true;

        public Trooper()//(Vector2 position)
        {
            Health = 40;
            Magic = 20;
            //this.enemyPosition = position;
        }

        public void hpDamage(int damage)
        {
            Health -= damage;
        }

        public void Update(GameTime gameTime)
        {
            if (Health <= 0)
            {
                setAlive(false);
            }
            //Has the monster shoot a bullet
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (currentTime >= timeDuration)
            {
                //Shoot a bullet
                //Put code here
                //enemyPosition.X -= 0.5f * currentTime;      //Need to test this
                currentTime -= timeDuration;
            }
        }

        public void setAlive(bool alive)
        {
            this.isAlive = alive;
        }

        public bool getAlive()
        {
            return isAlive;
        }
    }
}
