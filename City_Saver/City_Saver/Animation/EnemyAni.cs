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

namespace City_Saver.Animation
{
    class EnemyAni
    {
        Texture2D enemy;
        Vector2 enemyPos;
        float enemySpeed;
        float attackSpeed;
        int enemyDirection;


        //Used for most enemies that can move
        public EnemyAni(ContentManager content, string asset, float movementSpeed, Vector2 position)
        {
            this.enemy = content.Load<Texture2D>(@asset);       //Loads the proper sprite depending on the enemy
            this.enemyPos = position;                           //Places the enemy initial enemy sprite where it needs to be
            this.enemySpeed = movementSpeed;                    //Provides the movement speed for the enemy        

        }

        //Used for statically placed enemies
        public void turret(ContentManager content, string asset, float fireRate, int direction, Vector2 placement)
        {
            this.enemy = content.Load<Texture2D>(@asset);       //Loads the proper sprite for the turret
            this.enemyPos = placement;                          //Loads the placement for the turret
            this.attackSpeed = fireRate;                        //Gives a firing rate for the turret
            this.enemyDirection = direction;                    //Gives a direction for the turret

            //We can add in player targetting for this if we want by throwing in player position to the call
            
        }

        public void Update(GraphicsDeviceManager graphics, float movementSpeed, Vector2 position)
        {
            //************Placeholder for eventual A* pathing********//
            //Want to see if the enemy sprite can move up and down and possibly attack
            if (position.Y <= 0)
            {
                position.Y += 0.95f * movementSpeed;        
                
            }
            if (position.Y > graphics.GraphicsDevice.Viewport.Height)
            {
                position.Y += 0.95f * movementSpeed;
            }
            


        }


    }
}
