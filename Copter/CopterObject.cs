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
    internal class CopterObject : SpriteObject
    {

        //-------------------------------------------------------------------------------------
        // Class-level variables

        // A strongly typed reference to the game
        private Game1 _game;

        // The Copter has x velocity only
        private float _xadd;
        EnemyObject[] rivals;
        MidEnemyObject mid_1;
        MidEnemyObject mid_2;
        

        //-------------------------------------------------------------------------------------
        // Class constructors

        internal CopterObject(Game1 game, Texture2D texture, EnemyObject[] enemies, MidEnemyObject mid1, MidEnemyObject mid2 )
            : base(game, Vector2.Zero, texture)
        {
            // Store a strongly-typed reference to the game
            _game = game;
            rivals = enemies;
            mid_1 = mid1;
            mid_2 = mid2;
            // Set a random position
            PositionX = 340;
            PositionY = 200;
            Height = texture.Height;
            Width = texture.Width;
            // Set the origin
            Origin = new Vector2(texture.Width, texture.Height) / 2;
            isHit = 0;
            _xadd = -3;
            Angle = 0.04F;

        }


        //-------------------------------------------------------------------------------------
        // Game functions

        public override void Update(GameTime gameTime)
        {
            // Allow the base class to do any work it needs
            base.Update(gameTime);

            // Update the position of the Copter
            if (isHit == 0)
            {
                if (TouchPanel.GetState().Count != 0)
                {
                    PositionX += -_xadd;
                    Angle = -0.04F;
                }
                else
                {
                    PositionX += _xadd;
                    Angle = 0.04F;
                }



                if (mid_1.PositionY + mid_1.Height / 2 >= PositionY - Height / 2 && mid_1.PositionY - mid_1.Height / 2 <= PositionY + Height / 2 && (PositionX + Width / 2 >= mid_1.PositionX - mid_1.Width / 2 && PositionX - Width / 2 <= mid_1.PositionX + mid_1.Width / 2)) { isHit = 1; Angle = 0.07F; }
                if (mid_2.PositionY + mid_2.Height / 2 >= PositionY - Height / 2 && mid_2.PositionY - mid_2.Height / 2 <= PositionY + Height / 2 && (PositionX + Width / 2 >= mid_2.PositionX - mid_2.Width / 2 && PositionX - Width / 2 <= mid_2.PositionX + mid_2.Width / 2)) { isHit = 1; Angle = 0.07F; }
                for (int i = 0; i < 17; ++i)
                {
                    if (rivals[i].PositionY + rivals[i].Height / 2 >= PositionY - Height / 2 && rivals[i].PositionY - rivals[i].Height / 2 <= PositionY + Height / 2 && (PositionX - Width / 2 <= rivals[i].PositionX - rivals[i].Width / 2 + 110 || PositionX + Width / 2 >= rivals[i].PositionX + rivals[i].Width / 2 - 110)) { isHit = 1; Angle = 0.07F; break; }
                }

            }
            
            
        }

    }
}
