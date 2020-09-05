using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePad_Intercepts
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);

            Application.Run(new App());
        }

        private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                string errorMsg = "An application error occurred. Please contact the adminstrator with the following information:\n\n";
                errorMsg = errorMsg + t.Exception.Message + "\n\nStack Trace:\n" + t.Exception.StackTrace;
                result = MessageBox.Show(errorMsg, "Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort) Application.Exit();
        }

        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception) e.ExceptionObject;
                string errorMsg = "An application error occurred. Please contact the adminstrator with the following information:\n\n";
                MessageBox.Show(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace, "Unexcpected Non-UI Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal Non-UI Error. Could not write the error to the event log. Reason: " + exc.Message, "Fatal Non-UI Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
            finally
            {
                Application.Exit();
            }
        }
    }
}
