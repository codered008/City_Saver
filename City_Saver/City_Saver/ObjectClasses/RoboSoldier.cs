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
    class RoboSoldier : ObjectClasses.People
    {
        Animation.Animation roboSoldierAni;
        float currentTime = 0;
        float timeDuration = 1f;
        Vector2 enemyPosition;
        bool isEnemy = true; //registers the object as an enemy to the player
        bool isAlive = true;


        public RoboSoldier()//(Vector2 position)
        {
            Health = 50;
            Magic = 0;
            //this.enemyPosition = position;
        }


        //The enemy takes damage
        public void hpDamage(int damage)
        {
            Health -= damage;
        }

        public void setPosition(Vector2 pos)
        {
            enemyPosition = pos;
        }

        public Vector2 getPosition()
        {
            return enemyPosition;
        }

        public void setAnimation(ContentManager c, String asset, int frameNum, Vector2 position)
        {
            setPosition(position);
            roboSoldierAni = new Animation.Animation(c, asset, 0.3f, 1, position);
        }

        public Animation.Animation getAnimation()
        {
            return roboSoldierAni;
        }

        public void Update(GameTime gameTime)
        {
            if (Health <= 0)
            {
                isAlive = false;
            }
            roboSoldierAni.playAnim(gameTime);
            //Enemy should move towards the left
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (currentTime >= timeDuration)
            {
                enemyPosition.X -= 0.5f * currentTime;      //Need to test this
                roboSoldierAni.setPosition(enemyPosition);
                
                currentTime -= timeDuration;
            }
           
        }
    }
}
