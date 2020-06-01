namespace MasterMike
{
    using System;
    using System.Timers;

    /// <summary>
    /// Request the garbage collector to run periodically.
    /// </summary>
    internal class PeriodicGarbageCollection : IDisposable
    {
        private Timer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeriodicGarbageCollection"/> class.
        /// </summary>
        /// <param name="timeSpan">The time to wait between requests.</param>
        public PeriodicGarbageCollection(TimeSpan timeSpan)
        {
            timer = new Timer(timeSpan.TotalMilliseconds)
            {
                AutoReset = true,
            };
            timer.Elapsed += (object sender, ElapsedEventArgs e) => GC.Collect();
            timer.Start();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            timer.Stop();
            timer.Dispose();
            timer = null;
        }
    }
}
