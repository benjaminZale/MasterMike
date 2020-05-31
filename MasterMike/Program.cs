using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMike
{
    /// <summary>
    /// The main class of the application.
    /// </summary>
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using var mutex = new Mutex(true, "UniqueAppId", out bool isAnotherInstanceRunning);

            // Another instance is already running.
            if (!isAnotherInstanceRunning)
            {
                return;
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // Ensure mutex is not GC'ed.
            GC.KeepAlive(mutex);
        }
    }
}
