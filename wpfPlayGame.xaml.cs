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
using System.Media;
using System.Windows.Threading;

namespace Homework_5
{
    /// <summary>
    /// Interaction logic for wpfPlayGame.xaml
    /// </summary>
    public partial class wpfPlayGame : Window
    {
        //number of right answer
        public int numOfRight;
        //number of wrong answer
        public int numOfWrong;
        //total number of game
        public int numOfGame;
        //set timer
        int time;
        public int timeUse;
        //the first number
        int num1;
        //the second number
        int num2;
        //the operator sign
        char operatorSign;
        //the player answer
        int PlayerAnswer;
        //the right answer
        int rightAnswer;
        //store all player score
        public List<string[]> scoreList;
        //math class
        clsMath calMath;
        //
        ErrorHandler HandleError;
        DispatcherTimer gameTime;

        //get player info method
        private wpfPlayerInfo getPlayerInfo;


        /// <summary>
        /// copy player info data to playgame window
        /// </summary>
        public wpfPlayerInfo CopyPlayerInfo
        {
            get { return getPlayerInfo; }
            set { getPlayerInfo = value; }
        }

        wpfHighScore hScore;

        public wpfPlayGame()
        {
            InitializeComponent();
            //create new score list
            scoreList = new List<string[]>();
            //create new math class
            calMath = new clsMath();
            //create new error handler
            HandleError = new ErrorHandler();
            //create count down timer
            gameTime = new DispatcherTimer();

            hScore = new wpfHighScore();
            


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
        //Initialize countdown timer setting
        private void startGame()
        {
            //set timer update every 1 second
            gameTime.Interval = new TimeSpan(0, 0, 1);
            //call timeTick
            gameTime.Tick += timeTick;
            //countdown time begin
            gameTime.Start();
        }

        /// <summary>
        /// this is the time Tick method for update time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeTick(object sender, EventArgs e)
        {
            try
            {
                //if time is still run and total of number less than 10
                if (time > 0 && numOfGame < 10)
                {
                    //decreate time
                    time--;
                    //update lable
                    lblTimer.Content = string.Format("{00}:{01} Second left", time / 60, time % 60);
                    //update timer
                    timeUse = 300 - time;
                }
                //if time is up
                else if (numOfGame > 10)
                {
                    //load sound 
                    SoundPlayer playSound = new SoundPlayer(@"D:\Spring 2017\CS 3280\Home Work\Homework_5\Homework_5\ta_da.wav");
                    //play sound
                    playSound.Play();
                    //output message box for player final score
                    MessageBox.Show("Good Job! " + getPlayerInfo.playerName + ", You got " + numOfRight +
                        " out of 10 right in " + timeUse.ToString() + " second!!");
                    //call addScore method to add final score to list
                    addScore(scoreList, CopyPlayerInfo.userArr[CopyPlayerInfo.count - 1, 0], numOfRight, 10 - numOfRight, timeUse);
                    //hide current window
                    this.Hide();
                    gameTime.Stop();
                }

            }
            catch (Exception ex)
            {
                //thow a new exception with class name, method name and message
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// this button submit answer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //check if player input an integet, if so
                if (checkInput(txtResult.Text) && numOfGame < 10)
                {

                    //called calculate method
                    rightAnswer = calMath.calculate(num1, num2, operatorSign);
                    //call checkAnswer method, if answer is true
                    if (checkAnswer(rightAnswer, PlayerAnswer) == true)
                    {
                        //load sound
                        SoundPlayer playSound = new SoundPlayer(@"ta_da.wav");
                        //play sound
                        playSound.Play();
                        //count num of right answer
                        numOfRight++;

                    }
                    else
                    {
                        //count num of wrong answer
                        numOfWrong++;

                    }
                    //reset input box to empty
                    txtResult.Text = "";

                    //call random number method
                    ranNum();
                    //if operator is /
                    if (operatorSign == '/')
                    {
                        //create temp number to hold
                        int tempNum = num1;
                        //get answer by num1 * num2;
                        rightAnswer = num1 * num2;
                        //assing rightAnswer to number 1
                        num1 = rightAnswer;
                        //change lable 
                        assignLabel(num1, num2, operatorSign);
                    }
                    else if (operatorSign == '-')
                    {
                        num1 = num1 + 9;
                        assignLabel(num1, num2, operatorSign);
                    }
                    else
                    {
                        //change label 
                        assignLabel(num1, num2, operatorSign);
                    }
                    //increase total of game
                    numOfGame++;

                }
                //if not
                else
                {
                    //load sound 
                    SoundPlayer playSound = new SoundPlayer(@"ta_da.wav");
                    //play sound
                    playSound.Play();
                    //output message box for player final score
                    MessageBox.Show("Good Job! " + getPlayerInfo.playerName + ", You got " + numOfRight +
                    " out of 10 right in " + timeUse.ToString() + " second!!");
                    //call addScore method to add final score to list
                    addScore(scoreList, CopyPlayerInfo.userArr[CopyPlayerInfo.count - 1, 0], numOfRight, 10 - numOfRight, timeUse);

                    gameTime.Stop();
                    //hide current window
                    this.Hide();
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
        /// this button is to close the game (end game)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //stop countdown timer
                gameTime.Stop();
                //load sound 
                SoundPlayer playSound = new SoundPlayer(@"ta_da.wav");
                //play sound
                playSound.Play();
                //output message box for player final score
                MessageBox.Show("Good Job! " + getPlayerInfo.playerName + ", You got " + numOfRight +
                " out of 10 right in " + timeUse.ToString() + " second!!");
                //call addScore method to add final score to list
                addScore(scoreList, CopyPlayerInfo.userArr[CopyPlayerInfo.count - 1, 0], numOfRight, 10 - numOfRight, timeUse);

               // hScore.showScore();
                hScore.ShowDialog();

                //hide current window
                this.Hide();

            }
            catch (Exception ex)
            {
                //call handleError method
                HandleError.handleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }





        /// <summary>
        /// this is the method check if player has enter an answer
        /// </summary>
        /// <param name="input">player input answer</param>
        /// <returns></returns>
        private bool checkInput(string input)
        {
            try
            {
                //if player has not enter answer
                if (input == "")
                {
                    //outupt warning text
                    inputError.Content = "Entry your answer";
                    //return false to do nothing
                    return true;
                }
                else
                {
                    //convert player input answer to integer
                    bool isNum = Int32.TryParse(input, out PlayerAnswer);
                    //if player input is integer
                    if (isNum)
                    {
                        //do not output error message
                        inputError.Content = "";
                        return true;
                    }
                    else
                    {
                        //outupt warning text
                        inputError.Content = "Please enter number only";
                        //return false to do nothing
                        return true;
                    }

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
        /// this is the method check player answer is true or not
        /// </summary>
        /// <param name="rightanswer">right answer</param>
        /// <param name="playerAnswer">player answer</param>
        private bool checkAnswer(int rightanswer, int playerAnswer)
        {
            try
            {
                //if player answer is right
                if (rightAnswer == playerAnswer)
                {
                    //output heading label for right answer
                    lblHeader.Content = "Good Job! You're Right";
                    //return ture
                    return true;
                }
                else
                {
                    //output heading label if it wrong answer
                    lblHeader.Content = "Wrong, Try Again";
                    return false;
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
        /// when player press enter key on the text box
        /// it call submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtResult_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.Key == Key.Enter)
                {
                    //check if player input an integet, if so
                    if (checkInput(txtResult.Text) && numOfGame < 10)
                    {

                        //called calculate method
                        rightAnswer = calMath.calculate(num1, num2, operatorSign);
                        //call checkAnswer method, if answer is true
                        if (checkAnswer(rightAnswer, PlayerAnswer) == true)
                        {
                            //load sound
                            SoundPlayer playSound = new SoundPlayer(@"ta_da.wav");
                            //play sound
                            playSound.Play();
                            //count num of right answer
                            numOfRight++;

                        }
                        else
                        {
                            //count num of wrong answer
                            numOfWrong++;

                        }
                        //reset input box to empty
                        txtResult.Text = "";

                        //call random number method
                        ranNum();
                        //if operator is /
                        if (operatorSign == '/')
                        {
                            //create temp number to hold
                            int tempNum = num1;
                            //get answer by num1 * num2;
                            rightAnswer = num1 * num2;
                            //assing rightAnswer to number 1
                            num1 = rightAnswer;
                            //change lable 
                            assignLabel(num1, num2, operatorSign);
                        }
                        else if (operatorSign == '-')
                        {
                            num1 = num1 + 9;
                            assignLabel(num1, num2, operatorSign);
                        }
                        else
                        {
                            //change label 
                            assignLabel(num1, num2, operatorSign);
                        }
                        //increase total of game
                        numOfGame++;

                    }
                    //if not
                    else
                    {
                        //load sound 
                        SoundPlayer playSound = new SoundPlayer(@"ta_da.wav");
                        //play sound
                        playSound.Play();
                        //output message box for player final score
                        MessageBox.Show("Good Job! " + getPlayerInfo.playerName + ", You got " + numOfRight +
                        " out of 10 right in " + timeUse.ToString() + " second!!");
                        //call addScore method to add final score to list
                        addScore(scoreList, CopyPlayerInfo.userArr[CopyPlayerInfo.count - 1, 0], numOfRight, 10 - numOfRight, timeUse);

                        gameTime.Stop();
                        //hide current window
                        this.Hide();
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
        /// this is method to add final score to list
        /// </summary>
        /// <param name="scoreList">score list</param>
        /// <param name="fScore">final socre</param>
        /// <returns></returns>
        private List<string[]> addScore(List<string[]> mySoreList, string name, int numRight, int numMiss, int tUse)
        {
            try
            {
                //create score array
                string[] scoreArray = new string[] { name, numRight.ToString(), numMiss.ToString(), tUse.ToString() };
                //if array is empty
                if (mySoreList.Count == 0)
                {
                    //add score to list
                    mySoreList.Add(scoreArray);
                    //return list
                    return mySoreList;
                }
                else
                {
                    //create variable i for count
                    int i = 0;
                    foreach (var num in mySoreList)
                    {
                        //create variable for use time
                        int useTime;
                        //create variable for right answer
                        int num1;
                        //convert to string to int
                        Int32.TryParse(num[2], out useTime);
                        //convert to string to int
                        Int32.TryParse(num[1], out num1);
                        //if right number is eq then less time go top
                        if (numRight == num1 && tUse > useTime)
                        {
                            // insert to list
                            mySoreList.Insert(i + 1, scoreArray);
                            //return list
                            return mySoreList;
                        }
                        //if right number is eq then less time go top
                        else if (numRight == num1 && tUse < useTime)
                        {
                            // insert to list
                            mySoreList.Insert(i, scoreArray);
                            //return list
                            return mySoreList;
                        }
                        //if right number greater then go top
                        else if (numRight > num1)
                        {
                            // insert to list
                            mySoreList.Insert(i, scoreArray);
                            //return list
                            return mySoreList;
                        }
                        else if (numRight < num1)
                        {
                            // insert to list
                            mySoreList.Insert(i + 1, scoreArray);
                            //return list
                            return mySoreList;
                        }
                        //increase count
                        i++;

                    }
                    //return list
                    return mySoreList;
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
        /// set value method
        /// </summary>
        private void setValue()
        {
            //set num of right to 0
            numOfRight = 0;
            //set number of wrong answer to 0
            numOfWrong = 0;
            //set number of total game play to 0
            numOfGame = 0;
            txtResult.Text = "";
            //set timer
            time = 300;
        }

        /// <summary>
        /// plus method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plusSignBtn_Click(object sender, RoutedEventArgs e)
        {
            //call show method
            show();
            //operater sign
            operatorSign = '+';
            //call random method
            ranNum();
            //call setvalue method
            setValue();
            //change label
            assignLabel(num1, num2, operatorSign);
            //start timeer
            startGame();

        }

        private void minusSignBtn_Click(object sender, RoutedEventArgs e)
        {
            //call show method
            show();
            //operater sign
            operatorSign = '-';
            //call random method
            ranNum();
            //call setvalue method
            setValue();
            //change label
            num1 = num1 + 9;

            assignLabel(num1, num2, operatorSign);
            //start timeer
            startGame();
        }

        private void multiSignBtn_Click(object sender, RoutedEventArgs e)
        {
            //call show method
            show();
            //operater sign
            operatorSign = '*';
            //call random method
            ranNum();
            //call setvalue method
            setValue();
            //change label
            assignLabel(num1, num2, operatorSign);
            //start timeer
            startGame();
        }

        private void divSignBtn_Click(object sender, RoutedEventArgs e)
        {
            //call show method
            show();
            //operator sign
            operatorSign = '/';
            //call random method
            ranNum();
            //switch number
            int tempNum = num1;
            //switch number
            rightAnswer = num1 * num2;
            //switch number
            num1 = rightAnswer;
            //call set value method
            setValue();
            //change label
            assignLabel(num1, num2, operatorSign);
            //start timer
            startGame();
        }

        /// <summary>
        /// this is exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            //hide window
            this.Hide();

        }

        /// <summary>
        /// this is the show method
        /// </summary>
        private void show()
        {
            //hide - sign
            minusSignBtn.Visibility = Visibility.Hidden;
            //hide * sign
            multiSignBtn.Visibility = Visibility.Hidden;
            //hide / sign
            divSignBtn.Visibility = Visibility.Hidden;
            //hide + sign
            plusSignBtn.Visibility = Visibility.Hidden;
            //hide exit button
            exitBtn.Visibility = Visibility.Hidden;
            //hide submit button
            submitBtn.Visibility = Visibility.Hidden;

            //show time label
            lblTimer.Visibility = Visibility.Visible;
            //show number 1lable
            lblNum1.Visibility = Visibility.Visible;
            //show sign label
            lblSign.Visibility = Visibility.Visible;
            //show number label
            lblNum2.Visibility = Visibility.Visible;
            //show = label
            lblEq.Visibility = Visibility.Visible;
            //show text input label
            txtResult.Visibility = Visibility.Visible;
            //show submit label
            submitBtn.Visibility = Visibility.Visible;
            //show end label
            endBtn.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// this is the hide method
        /// </summary>
        public void hide()
        {
            //show label
            minusSignBtn.Visibility = Visibility.Visible;
            //show label
            multiSignBtn.Visibility = Visibility.Visible;
            //show label
            divSignBtn.Visibility = Visibility.Visible;
            //show label
            plusSignBtn.Visibility = Visibility.Visible;
            //show label
            exitBtn.Visibility = Visibility.Visible;
            //show label
            submitBtn.Visibility = Visibility.Visible;
            //hide label
            lblTimer.Visibility = Visibility.Hidden;
            //hide label
            lblNum1.Visibility = Visibility.Hidden;
            //hide label
            lblSign.Visibility = Visibility.Hidden;
            //hide label
            lblNum2.Visibility = Visibility.Hidden;
            //hide label
            lblEq.Visibility = Visibility.Hidden;
            //hide label
            txtResult.Visibility = Visibility.Hidden;
            //hide label
            submitBtn.Visibility = Visibility.Hidden;
            //hide label
            endBtn.Visibility = Visibility.Hidden;
            //hide label
        }
        /// <summary>
        /// this is chage label method
        /// </summary>
        /// <param name="num1">number 1</param>
        /// <param name="num2">number 2</param>
        /// <param name="sign"></param>
        private void assignLabel(int num1, int num2, char sign)
        {
            //label number 1
            lblNum1.Content = num1.ToString();
            //label number 2
            lblNum2.Content = num2.ToString();
            //sign
            lblSign.Content = sign;
        }

        /// <summary>
        /// this is the random number method
        /// </summary>
        public void ranNum()
        {
            try
            {
                //start new random method
                Random num = new Random();
                //assign random number to number 1
                num1 = num.Next(0, 10);
                //random number 2
                num2 = num.Next(1, 10);

            }
            catch (Exception ex)
            {
                //thow a new exception with class name, method name and message
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

    }
}
