using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameFramework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.IO.IsolatedStorage;
using System.IO;
using Microsoft.Xna.Framework.Audio;
using MonoGame.Framework.WindowsPhone;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.Devices.Sensors;
using Microsoft.Xna.Framework.GamerServices;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using Microsoft.Phone.Shell;




namespace Copter
{
    
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : GameFramework.GameHost
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        // Declaring all the variables needed globally for the game
        
        // Objects in the game
        EnemyObject[]  _borderBlocks;         // Defines Enemy Blocks on border of the screen
        MidEnemyObject _midBlock;             // Defines Enemy Block in the mid of the screen
        MidEnemyObject _midBlock2;            // Defines Another Enemy Block in the mid of the screen
        CopterObject   _copter;               // Defines Copter 
        SmokeObject[]  _smoke;                // Defines the smoke particles blowing out of copter
        WingsObject _wings;                   // Defines the wings of the copter
        
        // Other Global variables required
        bool _isPlaying = false;               // Defines the start of copter ride
        int _highScore = 0;                    // Defines the highest score till
        string _highScoreString;               // For storing high score as a string and retrieving it as a string
        int _layer = -1;                        // Defines which layer is on Display : layer == 0 means that layer is on Display
        int _score = 0;                        // Defines the Present Score
        int _time_wait = 0;                    // Defines the time delay between end of a game and the start of new game
        int _alpha_factor = -100;                 // Defines the alpha factor of the main Screen Display
        int _alpha_factor_2 = 0;
        int _alpha_factor_3 = 0;
        int _alpha_factor_3_dec = 0;
        int _alpha_factor_dec = 0;             // Defines whether alpha facctor is decreasing or not
        bool _isPauseWindowOn = false;
        bool _firstUpdate = true;
        bool _isToFroOn = false;
        int _alpha_to_fro = 0;
        int _alpha_dec_to_fro = 0;
        public bool _isHighScoreScreenOn = false;
        int _bounceY = 1000;
        int _speed = 5;
        int _myGraphics = 1;
        int[] _ifClicked = new int[10];
        public string _topScorerName = null;
        int _timeWaiting = 0;
       // bool KeyboardInputIsVisible = false;
        

        public Button go;
        public TextBox topscorer;
        
        
       // Windows.Devices.I9nput.KeyboardCapabilities isKeyBoardPresent = new Windows.Devices.Input.KeyboardCapabilities();
      
      //  Microsoft.Xna.Framework.Input.GamePadButtons _buttons = new GamePadButtons();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
           // go = new Button();
           // topscorer = new TextBox();
            //panel.Children.Add(go);
            //panel.Children.Add(topscorer);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
             base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            // Load the object Textures into the Texture Dictionary
            Textures.Add("_copterGraphics", this.Content.Load<Texture2D>("copter_body"));
            Textures.Add("_copterGraphics1", this.Content.Load<Texture2D>("copter_body"));
            Textures.Add("_copterGraphics2", this.Content.Load<Texture2D>("copter_body"));
            Textures.Add("_copterGraphics3", this.Content.Load<Texture2D>("copter_white (1)"));
            
            Textures.Add("_gameBack1", this.Content.Load<Texture2D>("bg"));                      // bg is another background
            Textures.Add("_borderBlocksGraphics1", this.Content.Load<Texture2D>("log (1)"));             // log (1) is another texture
            Textures.Add("_midBlocksGraphics1", this.Content.Load<Texture2D>("obstacle2"));             // obstacle2 is another texture

            Textures.Add("_gameBack2", this.Content.Load<Texture2D>("gameBack2"));                      // bg is another background
            Textures.Add("_borderBlocksGraphics2", this.Content.Load<Texture2D>("block2"));             // log (1) is another texture
            Textures.Add("_midBlocksGraphics2", this.Content.Load<Texture2D>("midblock2"));

            Textures.Add("_gameBack3", this.Content.Load<Texture2D>("gameBack1"));                      // bg is another background
            Textures.Add("_borderBlocksGraphics3", this.Content.Load<Texture2D>("strip2"));             // log (1) is another texture
            Textures.Add("_midBlocksGraphics3", this.Content.Load<Texture2D>("obstacle"));

            Textures.Add("_gameBack", this.Content.Load<Texture2D>("bg"));                      // bg is another background
            Textures.Add("_borderBlocksGraphics", this.Content.Load<Texture2D>("log (1)"));             // log (1) is another texture
            Textures.Add("_midBlocksGraphics", this.Content.Load<Texture2D>("obstacle2"));             // obstacle2 is another texture


            Textures.Add("_smokeGraphics", this.Content.Load<Texture2D>("smoke"));
            Textures.Add("_pause", this.Content.Load<Texture2D>("Pause"));
            Textures.Add("_play", this.Content.Load<Texture2D>("Play"));


            Textures.Add("_wingsGraphics1", this.Content.Load<Texture2D>("1"));
            Textures.Add("_wingsGraphics2", this.Content.Load<Texture2D>("2"));
            Textures.Add("_wingsGraphics3", this.Content.Load<Texture2D>("3"));
            Textures.Add("_wingsGraphics4", this.Content.Load<Texture2D>("4"));
            Textures.Add("_logoGraphics", this.Content.Load<Texture2D>("logo"));

            Textures.Add("_aboutGraphics", this.Content.Load<Texture2D>("about_page"));
            Textures.Add("_high1", this.Content.Load<Texture2D>("high_score_page"));
            Textures.Add("_high2", this.Content.Load<Texture2D>("high_score_page_1"));

            Textures.Add("_gameNameGraphics", this.Content.Load<Texture2D>("gameName"));
            Textures.Add("_background", this.Content.Load<Texture2D>("blank"));
            Textures.Add("_clickOnGraphics", this.Content.Load<Texture2D>("up"));
            Textures.Add("_clickOffGraphics", this.Content.Load<Texture2D>("down"));
            Textures.Add("_play1", this.Content.Load<Texture2D>("Play2"));
            Textures.Add("_about1", this.Content.Load<Texture2D>("about"));
            Textures.Add("_custom1", this.Content.Load<Texture2D>("maps"));
            Textures.Add("_bg1", this.Content.Load<Texture2D>("bg1"));
            Textures.Add("_bg2", this.Content.Load<Texture2D>("bg2"));
            Textures.Add("_bg3", this.Content.Load<Texture2D>("bg3"));
            Textures.Add("_bg4", this.Content.Load<Texture2D>("bg4"));
            Textures.Add("_note", this.Content.Load<Texture2D>("sorrynote"));

            Textures.Add("_border1.1", this.Content.Load<Texture2D>("Slow"));
            Textures.Add("_border1.2", this.Content.Load<Texture2D>("Medium"));
            Textures.Add("_border1.3", this.Content.Load<Texture2D>("Fast"));
            Textures.Add("_border2.1", this.Content.Load<Texture2D>("Slow_click"));
            Textures.Add("_border2.2", this.Content.Load<Texture2D>("Medium_click"));
            Textures.Add("_border2.3", this.Content.Load<Texture2D>("Fast_click"));
            Textures.Add("_border3.1", this.Content.Load<Texture2D>("Robotics"));
            Textures.Add("_border3.2", this.Content.Load<Texture2D>("Forest"));
            Textures.Add("_border3.3", this.Content.Load<Texture2D>("Rocks"));
            Textures.Add("_border4.1", this.Content.Load<Texture2D>("Robotics_click"));
            Textures.Add("_border4.2", this.Content.Load<Texture2D>("Forest_click"));
            Textures.Add("_border4.3", this.Content.Load<Texture2D>("Rocks_click"));


            Textures.Add("_copter_img", this.Content.Load<Texture2D>("copter_img"));
            Fonts.Add("_miramonteFont", this.Content.Load<SpriteFont>("Miramonte"));
            Textures.Add("_copterImg", this.Content.Load<Texture2D>("copter_img"));
         //   _blast = Content.Load<SoundEffect>("sound1");
            _ifClicked[8] = 1;
            _ifClicked[4] = 1;

            
        //    go.Visibility = Visibility.Collapsed;
           
          //  topscorer.Visibility = Visibility.Collapsed;
            
            // Resets the Game to its original state
            ResetGame();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            if (_timeWaiting == 1 || _timeWaiting == 0)
            {
                ++_timeWaiting;
                if (_timeWaiting == 50)
                {
                    _timeWaiting = (_timeWaiting + 1) % 2;
                }
            }
            


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                if (_layer == 2 || _layer == 0 || _layer == -1)
                {
                    System.Windows.Application.Current.Terminate();
                  
                }

                

                if (_layer == 3 || _layer == 5)
                {
                    _isToFroOn = true;
                    _alpha_to_fro = 250;
                    _layer = 2;
                }
                if (_layer == 1 && _isPauseWindowOn)
                {
                    _isPauseWindowOn = false;
                    _isToFroOn = true;
                    _alpha_to_fro = 250;
                    _layer = 2;
                }
                if (_layer == 1 && !_isPauseWindowOn)
                {
                    _isPlaying = false;
                    _isPauseWindowOn = true;
                }
              
               

            }
            // TODO: Add your update logic here

            if (_isHighScoreScreenOn && _bounceY>0)
            {
                _bounceY -= 10;
                
            }

            if (!_isHighScoreScreenOn && _bounceY < 1000)
            {
                _bounceY += 10;
                if (_bounceY == 1000) _isPlaying = true;
            }



            if (_isToFroOn)
            {
                if (_alpha_dec_to_fro == 0)
                {
                    _alpha_to_fro =250;
                    if (_alpha_to_fro == 250) _alpha_dec_to_fro = 1;
                }
                if (_alpha_dec_to_fro == 1)
                {
                    _alpha_to_fro -= 10;
                    if (_alpha_to_fro == 0)
                    {
                        _alpha_dec_to_fro = 0;
                        _isToFroOn = false;
                    }
                }
            }
        //    System.Diagnostics.Debug.WriteLine("isToFro " + _isToFroOn.ToString() + " _alpha_to_fro  " + _alpha_to_fro.ToString() + " _alpha _ dec  " + _alpha_dec_to_fro.ToString());
            // If layer == 0 i.e. the Main Display Screen is ON AND
            // alpha_factor is less than 250 AND
            // alpha factor decrement is OFF
            if (_layer == 0 && _alpha_factor <= 250 && _alpha_factor_dec == 1)
            {// Increase alpha_factor
                _alpha_factor-=2;
                if (_alpha_factor == 0) _alpha_factor_dec = 0;
            }
           
            // If isPlaying is false i.e. copter is not flying AND
            // layer == 0 i.e. the Main Display is ON AND
            // alpha_factor is greater than or equal to 250 AND
            // some touch is there on the screen
       //     if (!_isPlaying && _layer == 0 && _alpha_factor <= 0 && TouchPanel.GetState().Count != 0)
                // Make alpha_factor decrement ON
        //        _alpha_factor_dec=1;

            // If layer == 0 i.e. Main Display is ON AND
            // alpha_factor decrement is ON
            if (_layer == 0 && _alpha_factor == 0)
            {
                if(_alpha_factor_3_dec == 0){
                _alpha_factor_3+=10;
                    if(_alpha_factor_3 == 250)_alpha_factor_3_dec =1;
                }
                // Decrease alpha_factor AND '3' decides the speed of decrement i.e. Fading Away
                if (_alpha_factor_3_dec == 1)
                {
                    _alpha_factor_3-=10;
                    if (_alpha_factor_3 == 0) _alpha_factor_3_dec = 0;
                }
            }

            // If layer == 0 i.e. Main Display is ON AND
            // alpha_factor decrement is ON AND
            // alpha_factor has reached 0 or is less than 0
            if (_layer == 0 && _alpha_factor_dec == 0 && _alpha_factor <= 0 && TouchPanel.GetState().Count != 0)
            {// Make Display layer == 1 i.e. Copter Screen is ON
                _layer = 2;
                _alpha_factor_dec = 1;
            }
            if (_layer == 2 && _alpha_factor_dec == 1 && _alpha_factor_2 < 250)
            {
                _alpha_factor_2+=3;
                
            }
            
            // If Copter is Hit by Some Block AND
            // time_wait is less than 100 i.e. time delay after game end is not reached its limit
            if (_copter.isHit != 0 && _time_wait<100 &&!_isHighScoreScreenOn ) 
                // Increase time_wait to let it reach the limit
                ++_time_wait;

            // If isPlaying is False i.e. copter is not flying AND
            // there is some touch on the screen AND
            // layer == 1 i.e. Copter Screen is ON
            if (!_isPauseWindowOn && !_isPlaying && TouchPanel.GetState().Count != 0 && _layer == 1)
            {
                // If copter is not hit by Any Block i.e. // initial stage here
                if (_copter.isHit == 0)
                {
                    // Make copter Flying == true and time_wait == 0 
                    _isPlaying = true;
                    _time_wait = 0;
                }
                    // If copter is HIT by some Block
                else
                {
                    // time_wait is greater than or equal to 100
                    if (_time_wait >= 100)
                    {
                        // Make Copter to its initial stage not hit by anyone 
                        // Reset Score
                        // Reset Game
                        _copter.isHit = 0;
                        _score = 0;
                        ResetGame();
                        
                    }
                }
            }

            // If isPlaying is True i.e. Copter is flying AND
            // copter is not hit by any block
            if (_isPlaying && _copter.isHit == 0)
            {
                if (_score % 4 == 0)
                {
                    _wings.SpriteTexture = Textures["_wingsGraphics1"];
                }
                else if(_score % 4 == 1)
                {
                    _wings.SpriteTexture = Textures["_wingsGraphics2"];
                }
                else if (_score % 4 == 2)
                {
                    _wings.SpriteTexture = Textures["_wingsGraphics3"];
                }
                else if (_score % 4 == 3)
                {
                    _wings.SpriteTexture = Textures["_wingsGraphics4"];
                }
                // Increase Score
                ++_score;
            }

            if (_layer == -1 && _alpha_factor < 250 && _alpha_factor_dec == 0)
            {
                _alpha_factor+=2;
                if (_alpha_factor == 250)
                {
                    _alpha_factor_dec = 1;
                    _layer = 0;
                }

            }
            

            if (_layer == 2 || _layer == 1 || _layer == 3 || _layer == 5)
            {
                // Get the current screen touch points
                TouchCollection touches = TouchPanel.GetState();
                // Is there an active touch point?
                if (touches.Count >= 1)
                {
                    // Read the previous location
                    TouchLocation prevLocation;
                    bool prevAvailable = touches[0].TryGetPreviousLocation(out prevLocation);
                    // Output current and previous information to the debug window
                    if (_alpha_factor_2>250 && _layer == 2 && touches[0].Position.X >= 350 - Textures["_clickOnGraphics"].Height && touches[0].Position.X <= 350 && touches[0].Position.Y <= 500 + Textures["_clickOnGraphics"].Width && touches[0].Position.Y >= 500)
                    {
                        
                        _isToFroOn = true;
                        _alpha_to_fro = 250;
                        _layer = 1;
                        ResetGame();
                        _score = 0;
                    }
                    if (_alpha_factor_2>250 && _layer == 2 && touches[0].Position.X >= 150 - Textures["_clickOnGraphics"].Height && touches[0].Position.X <= 150 && touches[0].Position.Y <= 500 + Textures["_clickOnGraphics"].Width && touches[0].Position.Y >= 500)
                    {

                        _isToFroOn = true;
                        _alpha_to_fro = 250;
                        _layer = 3;
                    }
                    if (_alpha_factor_2 > 250 && _layer == 2 && touches[0].Position.X >= 250 - Textures["_clickOnGraphics"].Height && touches[0].Position.X <= 250 && touches[0].Position.Y <= 500 + Textures["_clickOnGraphics"].Width && touches[0].Position.Y >= 500)
                    {
                        _isToFroOn = true;
                        _alpha_to_fro = 250;
                        _layer = 5;
                    }
                    

                    if (_timeWaiting==0 && _layer == 1 && touches[0].Position.X >= 425 && touches[0].Position.X <= 475 && touches[0].Position.Y <= 795 && touches[0].Position.Y >= 745) 
                    {
                        _isPlaying = false;
                        _isPauseWindowOn = true;            
                    }
                    if (_timeWaiting==1 && _layer == 1 && _isPauseWindowOn && touches[0].Position.X >= 425 && touches[0].Position.X <= 475 && touches[0].Position.Y <= 795 && touches[0].Position.Y >= 745)
                    {
                        _isPauseWindowOn = false;
                        _isPlaying = true;
                    }
                    
                    if (_layer == 1 && _isHighScoreScreenOn && _bounceY==0 && touches[0].Position.X >= 163 - 60  && touches[0].Position.X <= 163 && touches[0].Position.Y <= 259+282  && touches[0].Position.Y >= 259)
                    {
                        _isHighScoreScreenOn = false; 
                      //  go.Visibility = Visibility.Collapsed;
                      
                        //topscorer.Visibility = Visibility.Collapsed;

                        
                    }
                    if ( _layer == 5  && touches[0].Position.X >= 110 - Textures["_border1.1"].Height && touches[0].Position.X <= 110 && touches[0].Position.Y <= 110 + Textures["_border1.1"].Width && touches[0].Position.Y >= 110)
                    {
                        _ifClicked[7] = 1;
                        _ifClicked[8] = 0;
                        _ifClicked[9] = 0;
                        _speed = 3;
                       
                    }
                    if (_layer == 5 && touches[0].Position.X >= 110 - Textures["_border1.1"].Height && touches[0].Position.X <= 110 && touches[0].Position.Y <= 310 + Textures["_border1.1"].Width && touches[0].Position.Y >= 310)
                    {
                        _ifClicked[7] = 0;
                        _ifClicked[8] = 1;
                        _ifClicked[9] = 0;
                        _speed = 5;

                    }
                    if ( _layer == 5 && touches[0].Position.X >= 110 - Textures["_border1.1"].Height && touches[0].Position.X <= 110 && touches[0].Position.Y <= 510 + Textures["_border1.1"].Width && touches[0].Position.Y >= 510)
                    {
                        _ifClicked[7] = 0;
                        _ifClicked[8] = 0;
                        _ifClicked[9] = 1;
                        _speed = 7;

                    }

                    if (!_isToFroOn && _layer == 5 && touches[0].Position.X >= 400 - Textures["_border3.1"].Height && touches[0].Position.X <= 400 && touches[0].Position.Y <= 70 + Textures["_border3.1"].Width && touches[0].Position.Y >= 70)
                    {
                        _ifClicked[4] = 1;
                        _ifClicked[5] = 0;
                        _ifClicked[6] = 0;
                        Textures["_gameBack"] = Textures["_gameBack1"];                      
                        Textures["_borderBlocksGraphics"] = Textures["_borderBlocksGraphics1"];            
                        Textures["_midBlocksGraphics"] = Textures["_midBlocksGraphics1"];
                        Textures["_copterGraphics"] = Textures["_copterGraphics1"];
                        _myGraphics = 1;


                    }
                    if (!_isToFroOn && _layer == 5 && touches[0].Position.X >= 400 - Textures["_border3.1"].Height && touches[0].Position.X <= 400 && touches[0].Position.Y <= 300 + Textures["_border3.1"].Width && touches[0].Position.Y >= 300)
                    {
                        _ifClicked[4] = 0;
                        _ifClicked[5] = 1;
                        _ifClicked[6] = 0;
                        Textures["_gameBack"] = Textures["_gameBack2"];                      
                        Textures["_borderBlocksGraphics"] = Textures["_borderBlocksGraphics2"];            
                        Textures["_midBlocksGraphics"] = Textures["_midBlocksGraphics2"];
                        Textures["_copterGraphics"] = Textures["_copterGraphics2"];
                        _myGraphics = 2;

                    }
                    if (!_isToFroOn && _layer == 5 && touches[0].Position.X >= 400 - Textures["_border3.1"].Height && touches[0].Position.X <= 400 && touches[0].Position.Y <= 530 + Textures["_border3.1"].Width && touches[0].Position.Y >= 530)
                    {
                        _ifClicked[4] = 0;
                        _ifClicked[5] = 0;
                        _ifClicked[6] = 1;
                        Textures["_gameBack"] = Textures["_gameBack3"];                      
                        Textures["_borderBlocksGraphics"] = Textures["_borderBlocksGraphics3"];           
                        Textures["_midBlocksGraphics"] = Textures["_midBlocksGraphics3"];
                        Textures["_copterGraphics"] = Textures["_copterGraphics3"];
                        _myGraphics = 3;

                    }


                  //  System.Diagnostics.Debug.WriteLine("Position: " + touches[0].Position.ToString()
//+ " Previous position: " + prevLocation.Position.ToString() + "wid : " + Textures["_clickOnGraphics"].Width.ToString() + "hei : " + "wid : " + Textures["_clickOnGraphics"].Height.ToString());
                }
                
                
                
            }

            
           
           
            
            // Update All elements if isPLaying is True
            UpdateAll(gameTime,_isPlaying);

            base.Update(gameTime);
            if (_firstUpdate)
            {
                typeof(Microsoft.Xna.Framework.Input.Touch.TouchPanel).GetField("_touchScale", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).SetValue(null, Vector2.One);
                _firstUpdate = false;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Color _myColor1 = new Color(181, 230, 29);           // Self-defined Color
            Color _myColor2 = new Color(0,0,0,250 - _alpha_factor_2);    // Self-defined Color with Alpha factor
            Color _myColor3 = new Color(255, 214, 11, _alpha_factor);
            Color _myColor4 = new Color(255, 255, 255, _alpha_factor);
            Color _myColor5 = new Color(0, 0, 0, _alpha_factor_3);
            Color _myColor6 = new Color(255, 255, 255, _alpha_to_fro);

            if (_myGraphics == 1)
                GraphicsDevice.Clear(Color.Green);
            else if (_myGraphics == 2)
                GraphicsDevice.Clear(Color.White);
            else
                GraphicsDevice.Clear(new Color(0,0,0,100));

            // If Copter is Hit by Some Block
            if (_copter.isHit != 0)
            {
               // _blast.Play();
                // Stop the game
                _isPlaying = false;
               _wings.SpriteTexture = Textures["_wingsGraphics1"];
                // If highscore is less than new score
                if (_highScore < _score)
                {
                    _isHighScoreScreenOn = true;
                    _isPlaying = false;
                //    go.Visibility = Visibility.Visible;
                //    topscorer.Visibility = Visibility.Visible;
                    // Make highscore == new score and write it in the file
                    
                    _highScore = _score;
                    writeScore(_highScore);
                   // _isPauseWindowOn = true;
                }
            }

            // Drawing Code
            _spriteBatch.Begin();
            // If isPlaying is false i.e copter is not flying
            if (_layer == 1)
            {
               _spriteBatch.Draw(
                 Textures["_gameBack"],
                 new Vector2(480, 0),
                 null,
                 Color.White,
                 1.57f,
                 Vector2.Zero,
                 1.0f,
                 SpriteEffects.None,
                 0.0f);
                
             /*   if (!_isPlaying)
                    _spriteBatch.DrawString(
                        Fonts["_miramonteFont"],
                        "Press to Start",
                        new Vector2(240, 400),
                        Color.White,
                        1.57f,                           // Rotation is 90 Degrees
                        Vector2.Zero,
                        1.0f,
                        SpriteEffects.None,
                        0.0f);
               */
                DrawSprites(gameTime, _spriteBatch);

                _highScoreString = LoadScore();                    // Load Highscore string
                _highScore = Convert.ToInt32(_highScoreString);    // Convert the Loaded Highscore into int
                _spriteBatch.DrawString(
                    Fonts["_miramonteFont"],
                    "Score : " + _score,
                    new Vector2(470, 20),
                    Color.White,
                    1.57f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);

                _spriteBatch.DrawString(
                    Fonts["_miramonteFont"],
                    "High Score : " + _highScoreString + _topScorerName,
                    new Vector2(30, 20),
                    Color.White,
                    1.57f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);
               
                
                _spriteBatch.Draw(Textures["_pause"], new Vector2(425, 745), Color.White);
                

                // Copter is Hit by Some Block and time_wait has not reached its limit
                if (_copter.isHit != 0 && 100 - _time_wait > 0 && !_isHighScoreScreenOn)
                    _spriteBatch.DrawString(
                        Fonts["_miramonteFont"],
                         "" + (100 - _time_wait) / 20,
                        new Vector2(240, 400),
                        Color.White,
                        1.57f,
                        Vector2.Zero,
                        1.0f,
                        SpriteEffects.None,
                        0.0f);

                // Copter is Hit by Some Block and time_wait limit is reached 
                if (_copter.isHit != 0 && 100 - _time_wait <= 0 && !_isHighScoreScreenOn)
                    _spriteBatch.DrawString(
                        Fonts["_miramonteFont"],
                        "Press to play again",
                        new Vector2(240, 400),
                        Color.White,
                        1.57f,
                        Vector2.Zero,
                        1.0f,
                        SpriteEffects.None,
                        0.0f);

              

                if (_isPauseWindowOn)
                {
                    _spriteBatch.Draw(
                  Textures["_play"],
                  new Vector2(425,745),
                  Color.White);
                    
                }

                if (_isHighScoreScreenOn)
                {
                    _spriteBatch.Draw(
                    Textures["_high1"],
                    new Vector2(480 +_bounceY, 0),
                    null,
                    Color.White,
                    1.57f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);

                    _spriteBatch.DrawString(
                        Fonts["_miramonteFont"],
                        "" + _highScore,
                        new Vector2(258 + _bounceY, 450),
                        Color.White,
                        1.57f,
                        Vector2.Zero,
                        1.0f,
                        SpriteEffects.None,
                        0.0f);

                  
                }
                if (!_isHighScoreScreenOn && _bounceY < 1000)
                {
                    _spriteBatch.Draw(
                    Textures["_high2"],
                    new Vector2(480 + _bounceY, 0),
                    null,
                    Color.White,
                    1.57f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);
                    _spriteBatch.DrawString(
                       Fonts["_miramonteFont"],
                       "" + _highScore,
                       new Vector2(258 + _bounceY, 450),
                       Color.White,
                       1.57f,
                       Vector2.Zero,
                       1.0f,
                       SpriteEffects.None,
                       0.0f);
                }

                _spriteBatch.Draw(
                    Textures["_bg1"],
                    new Vector2(480, 0),
                    null,
                    _myColor6,
                    1.57f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);
            }
            // If layer  == 0 i.e. Main Display is ON
            if(_layer == 0 || _layer == 2)
            {
                _spriteBatch.Draw(
                  Textures["_background"],
                  new Vector2(480, 0),
                  null,
                  Color.White,
                  1.57f,
                  Vector2.Zero,
                  1.0f,
                  SpriteEffects.None,
                  0.0f);
                
                _spriteBatch.Draw(
                    Textures["_gameNameGraphics"],
                    new Vector2(275  
                        + (_alpha_factor_dec ) *( _alpha_factor_2) * 162 / 255f
                        ,110 - (_alpha_factor_dec )*( _alpha_factor_2) * 87 / 255f
                        ),
                    null,
                    Color.White,
                    1.57f,
                    Vector2.Zero,
                    new Vector2(1.0f 
                        - (_alpha_factor_dec) * ( _alpha_factor_2) / 1500f
                       , 1.0f - (_alpha_factor_dec) * ( _alpha_factor_2) / 1500f
                       ),
                    SpriteEffects.None,
                    0.0f);

                
               /* _spriteBatch.DrawString(
                    Fonts["_miramonteFont"],
                    "  COPTER", 
                    new Vector2(400, 180), 
                    _myColor2, 
                    1.57f, 
                    Vector2.Zero,
                    4.0f,
                    SpriteEffects.None,
                    0.0f);

                _spriteBatch.DrawString(
                   Fonts["_miramonteFont"], 
                    "          Developer:Dhruv Kohli\n       Graphics : Suwardhan Ahirrao",
                    new Vector2(300, 180),
                    _myColor2,
                    1.57f,
                    Vector2.Zero, 
                    1.0f,
                    SpriteEffects.None,
                    0.0f);
                
                */ 
                
                // If alpha_factor decrement is ON OR
                // IF alpha_factor is greater than equal to 200
                if(_layer==0)
                    _spriteBatch.DrawString(
                        Fonts["_miramonteFont"],
                        "PRESS", 
                        new Vector2(140, 350), 
                        _myColor5, 1.57f,
                        Vector2.Zero,
                        1.0f,
                        SpriteEffects.None,
                        0.0f);

                if (_layer == 2)
                {
                    _spriteBatch.Draw(
                        Textures["_about1"],
                        new Vector2(150, 500),
                        null,
                        new Color(255, 255, 255, _alpha_factor_2),
                        1.57f,
                        Vector2.Zero,
                        new Vector2(1f,1f),
                        SpriteEffects.None,
                        0.0f);
                    _spriteBatch.Draw(
                        Textures["_custom1"],
                        new Vector2(250, 500),
                        null,
                        new Color(255, 255, 255, _alpha_factor_2),
                        1.57f,
                        Vector2.Zero,
                        new Vector2(1f, 1f),
                        SpriteEffects.None,
                        0.0f);
                    _spriteBatch.Draw(
                        Textures["_play1"],
                        new Vector2(350, 500),
                        null,
                        new Color(255, 255, 255, _alpha_factor_2),
                        1.57f,
                        Vector2.Zero,
                        new Vector2(1f, 1f),
                        SpriteEffects.None,
                        0.0f);

                    _spriteBatch.Draw(
                          Textures["_copterImg"],
                          new Vector2(120, 150),
                          null,
                          new Color(255, 255, 255, _alpha_factor_2),
                          1.57f,
                          new Vector2(Textures["_copterImg"].Height / 2f, Textures["_copterImg"].Width / 2f),
                          new Vector2(_alpha_factor_2/250f, _alpha_factor_2/250f),
                          SpriteEffects.None,
                          0.0f);


                }
               

                _spriteBatch.Draw(
                    Textures["_bg1"],
                    new Vector2(480, 0),
                    null,
                    _myColor4,
                    1.57f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);

     /*           _spriteBatch.Draw(
                Textures["_bg1"],
                new Vector2(480, 0),
                null,
                _myColor6,
                1.57f,
                Vector2.Zero,
                1.0f,
                SpriteEffects.None,
                0.0f);
        */       
                }

            if (_layer == -1)
            {

                _spriteBatch.Draw(
                    Textures["_logoGraphics"],
                    new Vector2(480, 0),
                    null,
                    Color.White,
                    1.57f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);
                

                _spriteBatch.Draw(
                    Textures["_bg1"],
                    new Vector2(480, 0), 
                    null,
                    _myColor4,
                    1.57f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);
                   
                    
            }

            if (_layer == 3)
            {
                _spriteBatch.Draw(
                    Textures["_aboutGraphics"],
                    new Vector2(480, 0),
                    null,
                    Color.White,
                    1.57f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);

                
                _spriteBatch.Draw(
                    Textures["_bg1"],
                    new Vector2(480, 0),
                    null,
                    _myColor6,
                    1.57f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);
            }
            if (_layer == 5)
            {
                _spriteBatch.Draw(
                    Textures["_background"],
                    new Vector2(480, 0),
                    null,
                    Color.White,
                    1.57f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);



                if (_ifClicked[4] == 0)
                    _spriteBatch.Draw(
                     Textures["_border3.1"],
                     new Vector2(400, 70),
                     null,
                     new Color(255, 255, 255, _alpha_factor_2),
                     1.57f,
                     Vector2.Zero,
                     new Vector2(1f, 1f),
                     SpriteEffects.None,
                     0.0f);
                else
                    _spriteBatch.Draw(
                          Textures["_border4.1"],
                          new Vector2(400, 70),
                          null,
                          new Color(255, 255, 255, _alpha_factor_2),
                          1.57f,
                          Vector2.Zero,
                          new Vector2(1f, 1f),
                          SpriteEffects.None,
                          0.0f);

                if (_ifClicked[5] == 0)
                    _spriteBatch.Draw(
                     Textures["_border3.2"],
                     new Vector2(400, 300),
                     null,
                     new Color(255, 255, 255, _alpha_factor_2),
                     1.57f,
                     Vector2.Zero,
                     new Vector2(1f, 1f),
                     SpriteEffects.None,
                     0.0f);
                else
                    _spriteBatch.Draw(
                          Textures["_border4.2"],
                          new Vector2(400, 300),
                          null,
                          new Color(255, 255, 255, _alpha_factor_2),
                          1.57f,
                          Vector2.Zero,
                          new Vector2(1f, 1f),
                          SpriteEffects.None,
                          0.0f);

                if (_ifClicked[6] == 0)
                    _spriteBatch.Draw(
                     Textures["_border3.3"],
                     new Vector2(400, 530),
                     null,
                     new Color(255, 255, 255, _alpha_factor_2),
                     1.57f,
                     Vector2.Zero,
                     new Vector2(1f, 1f),
                     SpriteEffects.None,
                     0.0f);

                else
                    _spriteBatch.Draw(
                          Textures["_border4.3"],
                          new Vector2(400, 530),
                          null,
                          new Color(255, 255, 255, _alpha_factor_2),
                          1.57f,
                          Vector2.Zero,
                          new Vector2(1f, 1f),
                          SpriteEffects.None,
                          0.0f);

                
                if (_ifClicked[7] == 0)
                    _spriteBatch.Draw(
                     Textures["_border1.1"],
                     new Vector2(110, 110),
                     null,
                     new Color(255, 255, 255, _alpha_factor_2),
                     1.57f,
                     Vector2.Zero,
                     new Vector2(1f, 1f),
                     SpriteEffects.None,
                     0.0f);
                else
                _spriteBatch.Draw(
                      Textures["_border2.1"],
                      new Vector2(110, 110),
                      null,
                      new Color(255, 255, 255, _alpha_factor_2),
                      1.57f,
                      Vector2.Zero,
                      new Vector2(1f, 1f),
                      SpriteEffects.None,
                      0.0f);

                if (_ifClicked[8] == 0)
                    _spriteBatch.Draw(
                     Textures["_border1.2"],
                     new Vector2(110, 310),
                     null,
                     new Color(255, 255, 255, _alpha_factor_2),
                     1.57f,
                     Vector2.Zero,
                     new Vector2(1f, 1f),
                     SpriteEffects.None,
                     0.0f);
                else
                    _spriteBatch.Draw(
                          Textures["_border2.2"],
                          new Vector2(110, 310),
                          null,
                          new Color(255, 255, 255, _alpha_factor_2),
                          1.57f,
                          Vector2.Zero,
                          new Vector2(1f, 1f),
                          SpriteEffects.None,
                          0.0f);

                if (_ifClicked[9] == 0)
                    _spriteBatch.Draw(
                     Textures["_border1.3"],
                     new Vector2(110, 510),
                     null,
                     new Color(255, 255, 255, _alpha_factor_2),
                     1.57f,
                     Vector2.Zero,
                     new Vector2(1f, 1f),
                     SpriteEffects.None,
                     0.0f);
                else
                    _spriteBatch.Draw(
                          Textures["_border2.3"],
                          new Vector2(110, 510),
                          null,
                          new Color(255, 255, 255, _alpha_factor_2),
                          1.57f,
                          Vector2.Zero,
                          new Vector2(1f, 1f),
                          SpriteEffects.None,
                          0.0f);



                _spriteBatch.Draw(
                    Textures["_bg1"],
                    new Vector2(480, 0),
                    null,
                    _myColor6,
                    1.57f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);
            }
               

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
        
        private void ResetGame()
        {
            GameObjects.Clear();

            _borderBlocks = new EnemyObject[17];

            for (int i = 0; i < 17; ++i)
            {
                _borderBlocks[i] = new EnemyObject(this, Textures["_borderBlocksGraphics"],62*i+800 ,_copter, _speed);
                GameObjects.Add(_borderBlocks[i]);
            }

            _midBlock = new MidEnemyObject(this, Textures["_midBlocksGraphics"], 850, _copter, _speed);
            _midBlock2 = new MidEnemyObject(this, Textures["_midBlocksGraphics"], 850 + 600, _copter, _speed);
            GameObjects.Add(_midBlock);
            GameObjects.Add(_midBlock2);

            _copter = new CopterObject(this, Textures["_copterGraphics"],_borderBlocks, _midBlock , _midBlock2);
            GameObjects.Add(_copter);

            _smoke = new SmokeObject[20];
            for (int i = 0; i < 20; ++i)
            {
                _smoke[i] = new SmokeObject(this, Textures["_smokeGraphics"],_copter, -195 + i*10, _speed);
                GameObjects.Add(_smoke[i]);
            }

            _wings = new WingsObject(this, Textures["_wingsGraphics1"], _copter);
            GameObjects.Add(_wings);
            
        }
     /// <summary>
     /// Loads Score From the File "score.txt"
     /// </summary>
        string   LoadScore()
       {
            string fileContent;
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
           if (!store.FileExists("score.txt"))
           {
             // The score file doesn't exist
              return null;
           }
            // Read the contents of the file
           using (StreamReader sr = new StreamReader(
            store.OpenFile("score.txt", FileMode.Open)))
           {
            fileContent = sr.ReadToEnd();
            }
        }
        return fileContent;
     }
        /// <summary>
        /// Write Score to the file
        /// </summary>
        void writeScore(int sb)
        {
         using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
         {
             // Create a file and attach a streamwriter
             using (StreamWriter sw = new StreamWriter(store.CreateFile("score.txt")))
             {
                 // Write the  string to the streamwriter
                 sw.Write(sb.ToString());
             }
         }
        }

       

          




    }
}