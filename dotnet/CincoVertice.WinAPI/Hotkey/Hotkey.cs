using CincoVertice.WinAPI.Libs;

namespace CincoVertice.WinAPI.Hotkey
{
    public sealed class Hotkey : IDisposable
    {
        private readonly HotkeyWindow _window;
        private int currentID;
        private List<HotKeyData> hotkeys = new List<HotKeyData>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Hotkey"/> class.
        /// </summary>
        public Hotkey()
        {
            // Initialize a Native Window
            _window = new HotkeyWindow();

            // Registers the event of the inner native window.
            _window.HotKeyPressed += Window_HotKeyPressed;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            // unregister all the registered hot keys.
            for (int i = 0; i < this.hotkeys.Count; i++)
            {
                User32.UnregisterHotKey(_window.Handle, this.hotkeys[i].ID);
            }

            // Dispose the inner native window.
            _window.Dispose();
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="hotkey">Hotkey.</param>
        public void RegisterHotKey(HotKeyData hotkey)
        {
            // Increment the counter.
            this.currentID++;

            hotkey.ID = this.currentID;

            // Register the hot key.
            if (User32.RegisterHotKey(_window.Handle, hotkey.ID, hotkey.Modifier, hotkey.Key) == 0)
            {
                //MC.Message.ShowLastWin32Error("RegisterHotKey() key " + hotkey.Key.ToString() + " modifier" + hotkey.Modifier.ToString());
                return;
            }

            this.hotkeys.Add(hotkey);
        }

        private void Window_HotKeyPressed(object? sender, HotkeyPressedEventArgs args)
        {
            // Gets fired every time WM_HOTKEY is received
            // Look for the hotkey specific event to fire
            for (int i = 0; i < this.hotkeys.Count; i++)
            {
                if (args.ID == this.hotkeys[i].ID)
                {
                    this.hotkeys[i].Invoke(this, args);

                    break;
                }
            }
        }
    }
}
