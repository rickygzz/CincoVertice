using static CincoVertice.WinAPI.Libs.User32;

namespace CincoVertice.WinAPI.Hotkey
{
    public class HotKeyData
    {
        /// <summary>Automatically assigned.</summary>
        public int ID;

        public FSModifiers Modifier;
        public KeyCode Key;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotKeyData"/> class.
        /// </summary>
        /// <param name="modifier">modifier.</param>
        /// <param name="key">key.</param>
        /// <param name="keypressed">keypressed.</param>
        public HotKeyData(FSModifiers modifier, KeyCode key, EventHandler<HotkeyPressedEventArgs> keypressed)
        {
            ID = 0;
            Modifier = modifier;
            Key = key;
            KeyPressed = keypressed;
        }

        public event EventHandler<HotkeyPressedEventArgs> KeyPressed;

        public void Invoke(object sender, HotkeyPressedEventArgs e)
        {
            if (KeyPressed != null)
            {
                KeyPressed(sender, e);
            }
        }
    }
}
