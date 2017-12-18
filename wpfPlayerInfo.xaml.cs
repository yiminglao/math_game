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
using System.Windows.Shapes;
using System.Reflection;

namespace Homework_5
{
    /// <summary>
    /// Interaction logic for wpfPlayerInfo.xaml
    /// </summary>
    public partial class wpfPlayerInfo : Window
    {

        //player name
        public string playerName;
        //player age
        public string age;
        //player gender
        public string gender;
        //check if player input basic info
        public bool playerReady = false;
        //user info array
        public string[,] userArr;
        // ErrorHandler class
        ErrorHandler HandleError;
        // user class
        clsUser checkPlayerInfo;
        //count players
        public int count = 0;
        //current player
        public int current = 0;

        public wpfPlayerInfo()
        {
            InitializeComponent();
            //create user array
            userArr = new string[100, 3];
            //create new ErrorHandler class
            HandleError = new ErrorHandler();
            //create new User class
            checkPlayerInfo = new clsUser();

        }

        /// <summary>
        /// when player close window by right corner X 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                //hide the window
                this.Hide();
                //stop app to actruly close window
                e.Cancel = true;
            }
            catch (Exception ex)
            {

                //call handleError method
                HandleError.handleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// this is the button that player close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            //hide window
            this.Hide();
        }
        /// <summary>
        /// check if player wanna update info
        /// </summary>
        public void updateInfo()
        {
            try
            {
                //if player exist
                if (playerReady == true)
                {
                    //show update button
                    updateBtn.Visibility = Visibility.Visible;
                    //hide sumbit button
                    submitBtn.Visibility = Visibility.Hidden;
                }
                //if player doesnot exist
                else
                {
                    //hide update button
                    updateBtn.Visibility = Visibility.Hidden;
                    //show submit button
                    submitBtn.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {


                //call handleError method
                HandleError.handleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// this is the button player submit info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //check if player had input name, age and gender
                if (checkPlayerInfo.CheckName(playerNameBox.Text) && checkPlayerInfo.checkAge(ageBox.Text) && checkPlayerInfo.checkGender(gender))
                {
                    //error message for name
                    lblNameError.Content = "";
                    //error message for age
                    lblAgeError.Content = "";
                    //error message for gender
                    lblGenderError.Content = "";
                    //add name to array
                    userArr[count, 0] = playerNameBox.Text;
                    //add age to array
                    userArr[count, 1] = ageBox.Text;
                    //arrage gender to array
                    userArr[count, 2] = gender;
                    //count player
                    count++;
                    //show messsage 
                    MessageBox.Show("Successful!! Lest's play some game " + playerNameBox.Text);
                    //hide this windows
                    this.Hide();
                    //assing playerReady to true to enable play game button and high score button
                    playerReady = true;
                }
                else
                {
                    //if player did not input name
                    if (checkPlayerInfo.CheckName(playerNameBox.Text) == false)
                    {
                        //show error message
                        lblNameError.Content = "Please Enter your name!!!";
                    }
                    //if player did not input age
                    else if (checkPlayerInfo.checkAge(ageBox.Text) == false)
                    {
                        //show error message
                        lblAgeError.Content = "please check your age!!!";
                    }
                    else
                    {
                        //show error message if player did pick gender
                        lblGenderError.Content = "please select gender!!!";
                    }
                }

            }
            catch (Exception ex)
            {
                //call handleError method
                HandleError.handleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// this is event when player pick girl as gender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbGirl_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                //create new radio button
                RadioButton rb = (RadioButton)sender;
                //assign user picked gender to gender variable
                gender = rb.Name;
            }
            catch (Exception ex)
            {

                //call handleError method
                HandleError.handleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
        /// <summary>
        /// this is event when player pick boy as gender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbBoy_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                //create new radio button
                RadioButton rb = (RadioButton)sender;
                //assign user picked gender to gender variable
                gender = rb.Name;
            }
            catch (Exception ex)
            {

                //call handleError method
                HandleError.handleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }



        }
        /// <summary>
        /// this is upade player info button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //check if player had input name, age and gender
                if (checkPlayerInfo.CheckName(playerNameBox.Text) && checkPlayerInfo.checkAge(ageBox.Text) && checkPlayerInfo.checkGender(gender))
                {
                    //error message for name
                    lblNameError.Content = "";
                    //error message for age
                    lblAgeError.Content = "";
                    //error message for gender
                    lblGenderError.Content = "";
                    //add name to array
                    userArr[count, 0] = playerNameBox.Text;
                    //add age to array
                    userArr[count, 1] = ageBox.Text;
                    //arrage gender to array
                    userArr[count, 2] = gender;

                    //show messsage 
                    MessageBox.Show("Successful!! Lest's play game some game " + playerNameBox.Text);
                    //hide this windows
                    this.Hide();
                    //assing playerReady to true to enable play game button and high score button
                    playerReady = true;
                }
                else
                {
                    //if player did not input name
                    if (checkPlayerInfo.CheckName(playerNameBox.Text) == false)
                    {
                        //show error message
                        lblNameError.Content = "Please Enter your name!!!";
                    }
                    //if player did not input age
                    else if (checkPlayerInfo.checkAge(ageBox.Text) == false)
                    {
                        //show error message
                        lblAgeError.Content = "please check your age!!!";
                    }
                    else
                    {
                        //show error message if player did pick gender
                        lblGenderError.Content = "please select gender!!!";
                    }
                }

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
