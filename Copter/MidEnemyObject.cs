using GameFramework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace Copter
{
    internal class MidEnemyObject : SpriteObject
    {

        //-------------------------------------------------------------------------------------
        // Class-level variables

        // A strongly typed reference to the game
        private Game1 _game;

        // The enemy block's has y velocity

        ///private float _yadd;

        CopterObject cop1;

        //-------------------------------------------------------------------------------------
        // Class constructors

        internal MidEnemyObject(Game1 game, Texture2D texture, int init_y, CopterObject cop, int speed)
            : base(game, Vector2.Zero, texture)
        {
            // Store a strongly-typed reference to the game
            _game = game;
            cop1 = cop;
            Height = texture.Height;
            Width = texture.Width;
            // Set a random position for X Coordinate  betweeen 120 and width of Device
            PositionX = GameHelper.RandomNext(110 + Width/2, 370 - Width/2);
            PositionY = init_y;
            
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




            // Update the position of the ball
            PositionY += _yadd;

            // If we reach the bottom of the window, reverse the y velocity so that the ball bounces upwards
            if (PositionY + Height <= 0)
            {
                // Reset back to the bottom of the window
                PositionY = 1200;
                PositionX = GameHelper.RandomNext(110 + Width/2, 370 - Width/2);
            }





        }
    }
}
