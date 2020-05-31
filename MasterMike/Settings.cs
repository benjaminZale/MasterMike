namespace MasterMike
{
    using System.IO;
    using System.Text.Json;

    /// <summary>
    /// Application settings.
    /// </summary>
    internal class Settings
    {
        /// <summary>
        /// Gets or sets the fixed line level or null to leave the line level alone.
        /// </summary>
        public float? LineLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to mute or unmute the mike.
        /// </summary>
        public bool IsMuted { get; set; }

        /// <summary>
        /// Loads the settings from a settings file or creates a new settings file.
        /// </summary>
        /// <returns>The settings file.</returns>
        /// <param name="path">The location to of the settings.</param>
        internal static Settings LoadSettings(string path)
        {
            Settings settings;

            if (!File.Exists(path))
            {
                settings = new Settings
                {
                    LineLevel = 0.50F,
                };
                SaveSettings(settings, path);
            }
            else
            {
                string settingsJson = File.ReadAllText(path);
                settings = JsonSerializer.Deserialize<Settings>(settingsJson);
            }

            return settings;
        }

        /// <summary>
        /// Writes settings to a file.
        /// </summary>
        /// <param name="settings">The settings to write.</param>
        /// <param name="path">The location to write to.</param>
        internal static void SaveSettings(Settings settings, string path)
        {
            string settingsJson = JsonSerializer.Serialize(settings);
            File.WriteAllText(path, settingsJson);
        }
    }
}
