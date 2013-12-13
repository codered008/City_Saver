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
    class Wallturret
    {
        //Animation.Animation SecurityRobotAni;  //Don't think this one needs much animation, it's stationary
        float currentTime = 0;
        float timeDuration = 1f;
        Vector2 enemyPosition;
        bool isEnemy = true;

        public Wallturret(Vector2 position)
        {
            //I'd like these to be indestructible obstacles.  Something the player simply has to get around.
            this.enemyPosition = position;
        }

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
