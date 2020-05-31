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

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            OnToggleStatChanged -= MicEnableForm_OnToggleStatChanged;
            muteIcon.Dispose();
            unmuteIcon.Dispose();
        }

        private void MicEnableForm_OnToggleStatChanged(object sender, ToggleEventArgs e)
        {
            if (e.ToggleState)
            {
                Text = "Select to Unmute";
                Icon = muteIcon;
            }
            else
            {
                Text = "Select to Mute";
                Icon = unmuteIcon;
            }
        }
    }
}
