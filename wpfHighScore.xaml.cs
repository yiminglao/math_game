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

namespace Homework_5
{
    /// <summary>
    /// Interaction logic for wpfHighScore.xaml
    /// </summary>
    public partial class wpfHighScore : Window
    {

        //pass data from wpfPlayGame window
        private wpfPlayGame getGameScore;

        //copy date fromwpfPlayGame window
        public wpfPlayGame copyGameScore
        {
            //get date
            get { return getGameScore; }
            //set date
            set { getGameScore = value; }
        }

        //pass data from wpfPlayerInfo
        private wpfPlayerInfo getPlayInfo;
        //copy date wpfPlayerInfo window
        public wpfPlayerInfo copyPlayer
        {
            //get date
            get { return getPlayInfo; }
            //set date
            set { getPlayInfo = value; }
        }
      

        public wpfHighScore()
        {
            InitializeComponent();
        }

        /// <summary>
        /// this is the show score method
        /// </summary>
        public void showScore()
        {
            //show label top    name    right   missed  use time
            headDetail.Content = "Top #" +"\tYour Name"+ "\t# Right"  + "\t# Missed" + "\t Use time";
            //create variable string
            string temp = "";
            //score list more the 10 
            if (getGameScore.scoreList.Count > 10)
            {
                //create new list
                List<string[]> myNewList = new List<string[]>();
                //get the first the list
                myNewList = getGameScore.scoreList.GetRange(0, 10);
                //create top number 1,2,3,.....
                int count = 1;
                //loop for data
                foreach (string[] s in myNewList)
                {
                    //output data
                    temp += count.ToString() + '\t' +s[0]+ " "+ '\t'  + '\t' + s[1] + '\t' + s[2] + '\t' + s[3] + '\n';
                    //increate count
                    count++;
                }
                //assign temp to socre label
                lblScore.Content = temp;
            }
            else
            {
                //create top number 1,2,3,.....
                int count = 1;
                //loop for data
                foreach (string[] s in getGameScore.scoreList)
                {
                    //output data
                    temp += count.ToString() + '\t' + s[0] + " " + '\t' + '\t' + s[1] + '\t' + s[2] + '\t' + s[3] + '\n';
                    //increate count
                    count++;
                }
                //assign temp to socre label
                lblScore.Content = temp;
            }

        }
        /// <summary>
        /// when player close window by right corner X 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //hide the window
            this.Hide();
            //stop app to actruly close window
            e.Cancel = true;
        }

        /// <summary>
        /// this is a button that player close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            //hide window
            this.Hide();
        }
    }
}
