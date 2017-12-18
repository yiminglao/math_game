using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Homework_5
{
    class clsUser
    {
        int count = 0;
        /// <summary>
        /// check player name input
        /// </summary>
        /// <returns>true or false </returns>
        public bool CheckName(string pName)
        {
            try
            {
                //if name less than 1 and name greater then 60
                if (pName.Length > 1 && pName.Length < 60)
                {
                    //return true
                    return true;
                }
                else
                {
                    //return false
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
        /// check player age input
        /// </summary>
        /// <returns>true or false </returns>
        public bool checkAge(string pAge)
        {
            try
            {
                //age 
                int iAge = 0;
                //convert player inupt to int and assign to age
                bool isAge = Int32.TryParse(pAge, out iAge);
                //check if age greater then 0 or small than 130
                if (iAge > 0 && iAge < 130 && isAge == true)
                {
                    //return true 
                    return true;
                }
                else
                {
                    //return false
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
        /// check player gender input
        /// </summary>
        /// <returns>true or false </returns>
        public bool checkGender(string pGender)
        {
            try
            {
                //if user did not pick gender
                if (pGender == null)
                {
                    //return false
                    return false;
                }
                //if user did pick gender
                else
                {
                    //return true
                    return true;
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
      /// this is the method to store user info
      /// </summary>
      /// <param name="pName">player name</param>
      /// <param name="pAge">player age</param>
      /// <param name="gender">player gender</param>
      /// <param name="count">number of player</param>
      /// <returns></returns>
        public string[,] addUser(string pName, string pAge, string gender,int count)
        {
            //create new array to store player info
            string[,] userInfo = new string[1,3];
            //store player name
            userInfo[count, 0] = pName;
            //store player age
            userInfo[count, 1] = pAge;
            //store player gender
            userInfo[count, 2] = gender;
            //count player
            count++;
            //return user info array
            return userInfo;
        }



    }
}
