namespace MasterMike
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// The main class of the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
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
            using var form = new MicEnableForm();
            Application.Run(form);

            // Ensure mutex is not GC'ed.
            GC.KeepAlive(mutex);
        }
    }
}
