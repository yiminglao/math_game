using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Homework_5
{
    /// <summary>
    /// this is the math call to do calculate
    /// </summary>
    class clsMath
    {

        /// <summary>
        /// this is the + math method 
        /// </summary>
        /// <param name="num1">number 1</param>
        /// <param name="num2">number 2</param>
        /// <returns>answer</returns>
        public int plus(int num1, int num2)
        {
            try
            {
                // answer = number + number 
                int answer = num1 + num2;
                //return answer;
                return answer;
            }
            catch (Exception ex)
            {

                //throw a new exception and show message
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }
        /// <summary>
        /// this is the - math method 
        /// </summary>
        /// <param name="num1">number 1</param>
        /// <param name="num2">number 2</param>
        /// <returns>answer</returns>
        public int minus(int num1, int num2)
        {
            try
            {
                // answer = number - number 
                int answer = num1 - num2;
                //return answer;
                return answer;
            }
            catch (Exception ex)
            {

                //throw a new exception and show message
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }
        /// <summary>
        /// this is the * math method 
        /// </summary>
        /// <param name="num1">number 1</param>
        /// <param name="num2">number 2</param>
        /// <returns>answer</returns>
        public int multiply(int num1, int num2)
        {
            try
            {
                // answer = number * number 
                int answer = num1 * num2;
                //return answer;
                return answer;
            }
            catch (Exception ex)
            {

                //throw a new exception and show message
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }
        /// <summary>
        /// this is the / math method 
        /// </summary>
        /// <param name="num1">number 1</param>
        /// <param name="num2">number 2</param>
        /// <returns>answer</returns>
        public int divide(int num1, int num2)
        {
            try
            {
                // answer = number / number 
                int answer = num1 / num2;
                //return answer;
                return answer;
            }
            catch (Exception ex)
            {

                //throw a new exception and show message
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// this is a method calculate the answer;
        /// </summary>
        /// <param name="n1">number 1</param>
        /// <param name="n2">number 2</param>
        /// <param name="sign">operatorSign </param>
        /// <returns>rightAnswer</returns>
        public int calculate(int n1, int n2, char sign)
        {
            try
            {
                int rightAnswer;
                //if sign is " + " 
                if (sign == '+')
                {
                    //add number 1 and number 2 and assign to rightAnswer variable
                    return rightAnswer = n1 + n2;
                }
                //if sign is " - "
                else if (sign == '-')
                {
                    //number 1 minus number 2 and assign to rightAnswer variable
                    return rightAnswer = n1 - n2;
                }
                else if (sign == '*')
                {
                    //number 1 minus number 2 and assign to rightAnswer variable
                    return rightAnswer = n1 * n2;
                }
                else
                {
                    //number 1 minus number 2 and assign to rightAnswer variable
                    return rightAnswer = n1 / n2;
                }
            }
            catch (Exception ex)
            {

                //throw a new exception and show message
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }
    }
}
