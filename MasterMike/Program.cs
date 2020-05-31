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
