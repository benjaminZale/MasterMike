namespace MasterMike
{
    using System.Drawing;

    /// <summary>
    /// The main from that toggles between muted and unmuted.
    /// </summary>
    public class MicEnableForm : ToggleForm
    {
        /// <summary>
        /// The mute image shown in the taskbar.
        /// </summary>
        private readonly Icon muteIcon = Icon.FromHandle(IconResources.MuteIcon.GetHicon());

        /// <summary>
        /// The unmute image shown in the taskbar.
        /// </summary>
        private readonly Icon unmuteIcon = Icon.FromHandle(IconResources.UnmuteIcon.GetHicon());

        /// <summary>
        /// Initializes a new instance of the <see cref="MicEnableForm"/> class.
        /// </summary>
        public MicEnableForm()
        {
            OnToggleStatChanged += MicEnableForm_OnToggleStatChanged;
        }

        /// <summary>
        /// Gets or sets the application settings.
        /// </summary>
        internal Settings Settings { get; set; }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            OnToggleStatChanged -= MicEnableForm_OnToggleStatChanged;
            muteIcon.Dispose();
            unmuteIcon.Dispose();
        }

        /// <summary>
        /// When fired the mute / unmute state changes.
        /// </summary>
        /// <param name="sender">The sender of the request.</param>
        /// <param name="e">Toggle state event arguments.</param>
        private void MicEnableForm_OnToggleStatChanged(object sender, ToggleEventArgs e)
        {
            if (e.ToggleState)
            {
                Text = "Select to Unmute";
                Icon = muteIcon;
                Settings.IsMuted = true;
            }
            else
            {
                Text = "Select to Mute";
                Icon = unmuteIcon;
                Settings.IsMuted = false;
            }
        }
    }
}
