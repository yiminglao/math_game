using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework_5
{
    /// <summary>
    /// this is error handler class
    /// </summary>
    class ErrorHandler
    {

        /// <summary>
        /// this is the method handle error method
        /// </summary>
        /// <param name="sClass">this is class name</param>
        /// <param name="sMethod">this is method name</param>
        /// <param name="sMessage">this is the error message</param>
        public void handleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //show error message
                MessageBox.Show(sClass + "." + sMethod + "->" + sMessage);
            }
            catch (Exception ex)
            {
                //output to file
                System.IO.File.Create("C:\\error_log.txt");
                //output to file
                System.IO.File.AppendAllText("c:\\error_log.txt", Environment.NewLine + "error message: "
                    + ex.Message);
            }
        }
    }
}
