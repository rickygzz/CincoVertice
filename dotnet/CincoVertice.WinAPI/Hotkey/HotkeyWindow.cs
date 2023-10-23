using static CincoVertice.WinAPI.Libs.User32;

namespace CincoVertice.WinAPI.Hotkey
{
    /// <summary>
    /// Represents the window that is used internally to get the messages.
    /// </summary>
    public class HotkeyWindow : NativeWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        public HotkeyWindow()
            : base()
        {
        }

        public event EventHandler<HotkeyPressedEventArgs>? HotKeyPressed;

        /// <summary>
        /// Invokes the default window procedure associated with this window.
        /// </summary>
        /// <param name="m">A Message that is associated with the current Windows message.</param>
        protected override IntPtr WindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            // check if we got a hot key pressed.
            // WM_HOTKEY HOTKEY Windows Message.
            if (msg == 0x0312)
            {
                // Get ID
                int id = (int)wParam;

                // Get the keys.
                KeyCode key = (KeyCode)(((int)lParam >> 16) & 0xFFFF);

                // Get modifiers
                FSModifiers modifier = (FSModifiers)((int)lParam & 0xFFFF);

                // If hotkey event handler is set, invoke the event to notify the parent
                if (HotKeyPressed != null)
                {
                    HotKeyPressed(this, new HotkeyPressedEventArgs(id, modifier, key));
                }
            }

            return base.WindowProc(hWnd, msg, wParam, lParam);
        }
    }
}
