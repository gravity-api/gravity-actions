namespace OpenQA.Selenium.Mock
{
    /// <summary>
    /// Provides methods representing basic keyboard actions.
    /// </summary>
    public class MockKeyboard : IKeyboard
    {
        /// <summary>
        /// Presses a key.
        /// </summary>
        /// <param name="keyToPress">The key value representing the key to press.</param>
        public void PressKey(string keyToPress)
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Releases a key.
        /// </summary>
        /// <param name="keyToRelease">The key value representing the key to release.</param>
        public void ReleaseKey(string keyToRelease)
        {
            // Method intentionally left empty.
        }

        /// <summary>
        /// Sends a sequence of keystrokes to the target.
        /// </summary>
        /// <param name="keySequence">A string representing the keystrokes to send.</param>
        public void SendKeys(string keySequence)
        {
            // Method intentionally left empty.
        }
    }
}