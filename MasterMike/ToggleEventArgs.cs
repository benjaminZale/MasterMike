namespace IconTest
{
    /// <summary>
    /// The event parameters for when the state changes.
    /// </summary>
    public class ToggleEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToggleEventArgs"/> class.
        /// </summary>
        /// <param name="toggleState">The current toggle state.</param>
        public ToggleEventArgs(bool toggleState)
        {
            ToggleState = toggleState;
        }

        /// <summary>
        /// Gets a value indicating whether the current state is toggled.
        /// </summary>
        public bool ToggleState { get; }
    }
}
