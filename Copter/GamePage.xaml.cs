using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework;
using MonoGame.Framework.WindowsPhone;

using GameFramework;


namespace Copter
{
    public partial class GamePage : PhoneApplicationPage
    {
        private Game1 _game;
        //Button _save = new Button();
       // TextBox _topScorer = new TextBox();
        
        // Constructor
        public GamePage()
        {
            InitializeComponent();
            _game = XamlGame<Game1>.Create("", XnaSurface);

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            _updating();

        }

        private void _updating()
        {
            if (!this._game._isHighScoreScreenOn)
            {
                _save.Visibility = Visibility.Collapsed;
                _topScorer.Visibility = Visibility.Collapsed;
            }
            else
            {
                _save.Visibility = Visibility.Visible;
                _topScorer.Visibility = Visibility.Visible;
            }
        }

         private void GamePageWP8_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
             
            Microsoft.Xna.Framework.Input.GamePad.OnBackPressed();

            // We should detect if Game.Exit() is called and only do this if it wasn't
            e.Cancel = true;
           
        }


         void _save_Click(object sender, RoutedEventArgs e)
         {
             this._game._topScorerName = _topScorer.Text;

         }
        
        

        // private void Go_Click(object sender, RoutedEventArgs e)
      //  {
      //       string topScorer = dhruv.Text;
             
      //   }

        

        
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}