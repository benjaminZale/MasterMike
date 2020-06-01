namespace MasterMike
{
    using System;
    using System.Threading;
    using System.Timers;
    using System.Windows.Forms;

    /// <summary>
    /// The main class of the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Gets or sets the application settings.
        /// </summary>
        internal static Settings Settings { get; set; }

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

            // For some strange reason Garbage Collection is not called.  Force it to run every 15 seconds.
            using var periodicGarbageCollection = new PeriodicGarbageCollection(TimeSpan.FromSeconds(15));
            Settings = Settings.LoadSettings("Settings.json");

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using var form = new MicEnableForm()
            {
                Settings = Settings,
            };
            using (PeriodicSettingsRefresher periodicSettingsRefresher = new PeriodicSettingsRefresher())
            {
                Application.Run(form);
            }

            // Ensure mutex is not GC'ed.
            GC.KeepAlive(mutex);
        }
    }
}
