namespace MasterMike
{
    using System;
    using Timer = System.Timers.Timer;

    /// <summary>
    /// Periodically updates the mike settings to ensue they sync with this application.
    /// </summary>
    internal class PeriodicSettingsRefresher : IDisposable
    {
        /// <summary>
        /// The timer when fired refreshes the settings.
        /// </summary>
        private readonly Timer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeriodicSettingsRefresher"/> class.
        /// </summary>
        internal PeriodicSettingsRefresher()
        {
            timer = new Timer(100)
            {
                AutoReset = true,
            };
            timer.Elapsed += UpdateMikeSettings;
            timer.Disposed += Unmute;
            timer.Start();
        }

        /// <summary>
        /// Cleans up the timer.
        /// </summary>
        public void Dispose()
        {
            timer.Stop();
            timer.Dispose();
        }

        private void Unmute(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Unmute");
        }

        private void UpdateMikeSettings(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Update: {Program.Settings.IsMuted}, {Program.Settings.LineLevel}");
        }
    }
}
