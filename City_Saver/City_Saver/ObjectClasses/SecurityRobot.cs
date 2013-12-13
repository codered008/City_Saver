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
    class SecurityRobot : ObjectClasses.People
    {
        Animation.Animation SecurityRobotAni;
        float currentTime = 0;
        float timeDuration = 1f;
        Vector2 enemyPosition;
        bool isEnemy = true; //registers the object as an enemy to the player
        bool isAlive = true;

        public SecurityRobot()//(Vector2 position)
        {
            Health = 20;
            Magic = 0;
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
                isAlive = false;
            }
            

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
