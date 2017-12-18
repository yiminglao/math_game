using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

namespace Homework_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //initalize wpfplayerinfo window
        wpfPlayerInfo playerInfo;
        //initalize wpfPlayGame window
        wpfPlayGame playGame;
        //initalize wpfHighScore window
        wpfHighScore highScore;
        //HandleError class
        ErrorHandler HandleError;
        public MainWindow()
        {
            InitializeComponent();
            //main windown shut up mode
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            //create new wpfplayerinfo window
            playerInfo = new wpfPlayerInfo();
            //create new wpfPlayGame window
            playGame = new wpfPlayGame();
            //create new wpfHighScore window
            highScore = new wpfHighScore();
            //check if player info is empty
            checkPlayerInfo();

            //pass data to playgame window
            playGame.CopyPlayerInfo = playerInfo;
            //pass data to highscore from playgame window
            highScore.copyGameScore = playGame;
            //pass data to highscore from player info window
            highScore.copyPlayer = playerInfo;
            //create new HandleError class
            HandleError = new ErrorHandler();
        }
        /// <summary>
        /// check player info is empty method
        /// </summary>
        public void checkPlayerInfo()
        {
            try
            {
                //if player info is not empty
                if (playerInfo.playerReady == true)
                {
                    //enable play game button
                    playGameButton.IsEnabled = true;
                    //enable high score button
                    highScoreButton.IsEnabled = true;
                }
                else
                {

                    //disable play game button
                    playGameButton.IsEnabled = false;
                    //disable high score button
                    highScoreButton.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {

                //throw a new exception and show message
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// this is the button player click for input and update data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playerInfoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //hide main window
                this.Hide();
                //show playinfo window
                playerInfo.ShowDialog(); 
                //update player info window
                playerInfo.updateInfo();
                //check player info is empty
                checkPlayerInfo();
                //show main window
                this.Show();
            }
            catch (Exception ex)
            {

                //call handleError method
                HandleError.handleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
        /// <summary>
        /// this is the main window play game button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playGameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //hide window
                this.Hide();
                //clall hide method
                playGame.hide();
                //create header
                playGame.lblHeader.Content = "Let's play game";
                //reset error label  
                playGame.inputError.Content = "";
                //show play game window
                playGame.ShowDialog();
                //show window
                this.Show();
            }
            catch (Exception ex)
            {

                //call handleError method
                HandleError.handleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
        /// <summary>
        /// this the high score button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void highScoreButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //hide window
                this.Hide();
                //call show score method
                highScore.showScore();
                //show high score window
                highScore.ShowDialog();
                //show main window
                this.Show();
            }
            catch (Exception ex)
            {

                //call handleError method
                HandleError.handleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
    }
}
