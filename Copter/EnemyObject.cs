using GameFramework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace Copter
{
    internal class EnemyObject : SpriteObject
    {

        //-------------------------------------------------------------------------------------
        // Class-level variables

        // A strongly typed reference to the game
        private Game1 _game;

        // The enemy block's has y velocity
        
     //   private float _yadd;
        private int id;
        private bool count = false;
        CopterObject cop1;

        //-------------------------------------------------------------------------------------
        // Class constructors

        internal EnemyObject(Game1 game, Texture2D texture, int init_y, CopterObject cop, int speed)
            : base(game, Vector2.Zero, texture)
        {
            // Store a strongly-typed reference to the game
            cop1 = cop;
            _game = game;
            id = (init_y -800)/ 64  ;
            // Set a random position for X Coordinate  betweeen 120 and width of Device
            PositionX = 220;
            PositionY = init_y;
            Height = texture.Height;
            Width = texture.Width;
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

            
            
                PositionY += _yadd;
            
            
                // If we reach the bottom of the window, reverse the y velocity so that the ball bounces upwards
                if (PositionY < -124)
                {
                    count = !count;
                    // Reset back to the bottom of the window
                    PositionY = 806 + 62 * 2 ;
                    if (count == true)
                        PositionX = 220 + 2 * 20 * (id) / 17;
                    else
                        PositionX = 260 - 2 * 20 * (id) / 17;

                }
            
            

            
        }

    }
}
