using static CincoVertice.WinAPI.Libs.User32;

namespace CincoVertice.WinAPI.Hotkey
{
    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    public class HotkeyPressedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyPressedEventArgs"/> class.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="modifier">Modifier.</param>
        /// <param name="key">Key.</param>
        internal HotkeyPressedEventArgs(int id, FSModifiers modifier, KeyCode key)
        {
            this.ID = id;
            this.Modifier = modifier;
            this.Key = key;
        }

        /// <summary>Gets ID.</summary>
        public int ID { get; }

        /// <summary>Gets modifier.</summary>
        public FSModifiers Modifier { get; }

        /// <summary>Gets keyCode.</summary>
        public KeyCode Key { get; }

        public static readonly HotkeyPressedEventArgs Empty = new HotkeyPressedEventArgs(0, 0, 0);
    }
}
