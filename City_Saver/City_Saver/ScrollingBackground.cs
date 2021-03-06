#region File Description
//-----------------------------------------------------------------------------
// ScrollingBackground.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace City_Saver
{
    public class ScrollingBackground
    {
        // class ScrollingBackground
        private Vector2 screenpos, origin, texturesize;
        private Texture2D mytexture;
        private int screenheight;
        int portingScreenwidth;
        Rectangle screenRectangle;

        //public void Load( GraphicsDevice device, Texture2D backgroundTexture )
        //{
        //    mytexture = backgroundTexture;
        //    screenheight = device.Viewport.Height;
        //    int screenwidth = device.Viewport.Width;
        //    portingScreenwidth = screenwidth;
        //    // Set the origin so that we're drawing from the 
        //    // center of the top edge.
        //    origin = new Vector2( mytexture.Width / 2, 0 );
        //    // Set the screen position to the center of the screen.
        //    screenpos = new Vector2( screenwidth / 2, screenheight / 2 );
        //    // Offset to draw the second texture, when necessary.
        //    texturesize = new Vector2( 0, mytexture.Height );
        //}


        //Horizontal Scroll Attempt*************/
        public void Load(GraphicsDevice device, Texture2D backgroundTexture)
        {
            mytexture = backgroundTexture;
            //screenheight = device.Viewport.Height;
            //int screenwidth = device.Viewport.Width;
            screenheight = device.PresentationParameters.BackBufferHeight;
            int screenwidth = device.PresentationParameters.BackBufferWidth;
            portingScreenwidth = screenwidth;
            // Set the origin so that we're drawing from the 
            // center of the top edge.
            origin = new Vector2(mytexture.Width / 2, 0);
            // Set the screen position to the center of the screen.
            screenpos = new Vector2(screenwidth / 2, screenheight / 2);
            // Offset to draw the second texture, when necessary.
            texturesize = new Vector2(mytexture.Width, 0);
            screenRectangle = new Rectangle(0, 0, screenwidth, screenheight);
        }


        // ScrollingBackground.Update
        //public void Update( float deltaY )
        //{
        //    screenpos.Y += deltaY;
        //    screenpos.Y = screenpos.Y % mytexture.Height;
        //}

        //Horizontal Scroll attempt ***********/
        public void Update(float deltaX)
        {
            screenpos.X += deltaX;
            screenpos.X = screenpos.X % mytexture.Width;
        }

        // ScrollingBackground.Draw
        //public void Draw( SpriteBatch batch )
        //{
        //    // Draw the texture, if it is still onscreen.
        //    if (screenpos.Y < screenheight)
        //    {
        //        batch.Draw( mytexture, screenpos, null,
        //             Color.White, 0, origin, 1, SpriteEffects.None, 0f );
        //    }
        //    // Draw the texture a second time, behind the first,
        //    // to create the scrolling illusion.
        //    batch.Draw( mytexture, screenpos - texturesize, null,
        //         Color.White, 0, origin, 1, SpriteEffects.None, 0f );
        //}

        //Horizontal Scroll attempt
        public void Draw(SpriteBatch batch)
        {
            
            // Draw the texture, if it is still onscreen.
            if (screenpos.X < portingScreenwidth)
            {
                batch.Draw(mytexture, screenpos, screenRectangle,
                     Color.White, 0, origin, 1, SpriteEffects.None, 0f);
            }
            // Draw the texture a second time, behind the first,
            // to create the scrolling illusion.
            batch.Draw(mytexture, screenpos - texturesize, screenRectangle,
                 Color.White, 0, origin, 1, SpriteEffects.None, 0f);
        }

    }
}
