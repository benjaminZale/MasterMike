namespace MasterMike
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// A form used to toggle between two states.
    /// </summary>
    public partial class ToggleForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleForm"/> class.
        /// </summary>
        public ToggleForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// An event that is fired when the toggle state is modified.
        /// </summary>
        /// <param name="sender">The sender of this event.</param>
        /// <param name="e">The parameter including the toggle state.</param>
        public delegate void ToggleStateChanged(object sender, ToggleEventArgs e);

        /// <summary>
        /// Event that fires when the toggle state changes.
        /// </summary>
        public event ToggleStateChanged OnToggleStatChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the state is toggled or not.
        /// </summary>
        protected bool ToggleState { get; set; }

        /// <summary>
        /// Fired when the user clicks on the icon.
        /// </summary>
        /// <param name="sender">The sender of the request.</param>
        /// <param name="e">Activation event arguments.</param>
        private void ToggleForm_Activated(object sender, EventArgs e)
        {
            ToggleState = !ToggleState;
            OnToggleStatChanged?.Invoke(this, new ToggleEventArgs(ToggleState));
        }

        /// <summary>
        /// Fired when the form paints.
        /// </summary>
        /// <param name="sender">The sender of the request.</param>
        /// <param name="e">Event arguments.</param>
        private void ToggleForm_Paint(object sender, PaintEventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Minimized;
            }
        }
    }
}
