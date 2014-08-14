using GameFramework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Input;
namespace Copter
{
    internal class SmokeObject : SpriteObject
    {

        //-------------------------------------------------------------------------------------
        // Class-level variables

        // A strongly typed reference to the game
        private Game1 _game;

        // The Copter has x velocity only
        //private float _yadd;
        CopterObject cop1;
        private int start = 0;
      

        //-------------------------------------------------------------------------------------
        // Class constructors

        internal SmokeObject(Game1 game, Texture2D texture, CopterObject cop, float pos, int speed)
            : base(game, Vector2.Zero, texture)
        {
            // Store a strongly-typed reference to the game
            _game = game;
            cop1 = cop;
            Width = texture.Width;
            Height = texture.Height;
            // Set a random position
            PositionX = cop.PositionX + 10;
            PositionY = pos + 30 ;

            // Set the origin
            Origin = new Vector2(texture.Width, texture.Height) / 2;
            
            _yadd = -speed;

        }


        //-------------------------------------------------------------------------------------
        // Game functions

        public override void Update(GameTime gameTime)
        {
            // Allow the base class to do any work it needs
            base.Update(gameTime);

            // Update the position of the Smoke
            PositionY += _yadd;
            if (start == 1 && PositionY + Height/2 <= -1)
            {
                PositionX = cop1.PositionX - cop1.Width/2 - Width/2 + 10;
                PositionY = cop1.PositionY - cop1.Height/2 - Height/2 +30 ;
            }
            if (start == 0 && PositionY - Height/2 <= -200)
            {
                PositionX = cop1.PositionX - cop1.Width/2 - Width/2 + 10;
                PositionY = cop1.PositionY - cop1.Height/2 - Height/2 + 30;
                start = 1;
            }
            

        }

    }
}
