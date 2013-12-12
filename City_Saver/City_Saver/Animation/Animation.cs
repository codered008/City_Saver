using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace City_Saver.Animation
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Animation
    {
        Texture2D animation;
        Rectangle sourceRect;
        Vector2 position = new Vector2(200, 500);//in case the the player class does not pass in position

        float elapsed;
        float frameTime;
        int numberOfFrames;
        int currentFrame;
        
        int width;
        int height;
        int frameWidth;
        int frameHeight;
        bool reset = true;


        public Animation(ContentManager content, string asset, float frameSpeed, int numberOfFrames, Vector2 position)
        {
            this.frameTime = frameSpeed;
            this.numberOfFrames = numberOfFrames;
            this.animation = content.Load<Texture2D>(@asset);
            frameWidth = (animation.Width / numberOfFrames);
            frameHeight = animation.Height;
            this.position = position;
        }

        public void stopAnimation()
        {
            reset = true;
        }

        public int getFrameWidth()
        {
            //returns the width of the sprite in order to move it
            return frameWidth;
        }

        public int getFrameHeight()
        {
            //returns the height of the sprite to move it
            return frameHeight;
        }

        public Vector2 getPosition()
        {
            return position;
        }
        //Changes the position of the sprite
        public void setPosition(Vector2 pos)
        {
            position = pos;
        }

        public void setBounding()
        {
            sourceRect = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
        }

        public Rectangle getBounding()
        {
            return sourceRect;
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public  void playAnim(GameTime gameTime)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            setBounding();

            if (elapsed >= frameTime)
            {
                if (currentFrame >= numberOfFrames - 1)
                {
                    if (reset)
                    {
                        currentFrame = 0;

                    }
                    
                }
                else
                {
                    currentFrame++;
                }
                elapsed = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(animation, position, sourceRect, Color.White, 0f, new Vector2(0, 0), new Vector2(1,1), SpriteEffects.None, 1f);
            spriteBatch.Draw(animation, position, null, Color.White, 0f, new Vector2(100,100), 1f, SpriteEffects.None, 1f);  // Keep the scaling factor above zero or the sprite disappears!

        }
    }
}
