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
    internal class WingsObject : SpriteObject
    {

        //-------------------------------------------------------------------------------------
        // Class-level variables

        // A strongly typed reference to the game
        private Game1 _game;

        // The Copter has x velocity only
        CopterObject _virtualCopter;
       


        //-------------------------------------------------------------------------------------
        // Class constructors

        internal WingsObject(Game1 game, Texture2D texture, CopterObject copter)
            : base(game, Vector2.Zero, texture)
        {
            // Store a strongly-typed reference to the game
            _game = game;
            _virtualCopter = copter;
             Height = texture.Height;
            Width = texture.Width;
            // Set a random position
            PositionX = copter.PositionX + copter.Width/2;
            PositionY = 1.043f*copter.PositionY;
            Angle = 1.57F;
            
           
            // Set the origin
            Origin = new Vector2(texture.Width, texture.Height) / 2;
            

        }


        //-------------------------------------------------------------------------------------
        // Game functions

        public override void Update(GameTime gameTime)
        {
            // Allow the base class to do any work it needs
            base.Update(gameTime);

            PositionX = _virtualCopter.PositionX + _virtualCopter.Width / 2;
            PositionY = 1.043f*_virtualCopter.PositionY;
           


        }

    }
}
