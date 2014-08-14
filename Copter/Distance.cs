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
    internal class Distance : TextObject
    {

        //-------------------------------------------------------------------------------------
        // Class-level variables

        // A strongly typed reference to the game
        private Game1 _game;



        //-------------------------------------------------------------------------------------
        // Class constructors

        internal Distance(Game1 game, SpriteFont font, Vector2 position)
            : base(game, font)
        {
            // Store a strongly-typed reference to the game
            _game = game;

            Text = "Score";
            Angle = 1.57F;
            
            

        }


        //-------------------------------------------------------------------------------------
        // Game functions

        public override void Update(GameTime gameTime)
        {
            // Allow the base class to do any work it needs
            base.Update(gameTime);

            // Update the position of the Smoke
           


        }

    }
}
