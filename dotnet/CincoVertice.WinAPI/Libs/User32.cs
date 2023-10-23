// <copyright file="User32.cs" company="Ricardo Gonzalez-Garza">
// Copyright (c) 2018 - 2021 Ricardo Gonzalez-Garza. All Rights Reserved.
// Contact ricardo@5vertice.com for additional information.
// </copyright>
using System.Runtime.InteropServices;

namespace CincoVertice.WinAPI.Libs
{
    /// <summary>
    /// User32 class
    /// </summary>
    public class User32
    {
        /// <summary>
        /// Used by RegisterHotKey. The keys that must be pressed in combination with the key specified by the uVirtKey parameter in order to generate the WM_HOTKEY message. The fsModifiers parameter can be a combination of the following values.
        /// </summary>
        [Flags]
        public enum FSModifiers : uint
        {
            /// <summary>Either ALT key must be held down.</summary>
            MOD_ALT = 0x0001,

            /// <summary>Either CTRL key must be held down.</summary>
            MOD_CONTROL = 0x0002,

            /// <summary>Changes the hotkey behavior so that the keyboard auto-repeat does not yield multiple hotkey notifications.</summary>
            MOD_NOREPEAT = 0x4000,

            /// <summary>Either SHIFT key must be held down.</summary>
            MOD_SHIFT = 0x0004,

            /// <summary>Either WINDOWS key was held down. These keys are labeled with the Windows logo. Keyboard shortcuts that involve the WINDOWS key are reserved for use by the operating system.</summary>
            MOD_WIN = 0x0008
        }

        /// <summary>
        /// Virtual-Key Codes
        /// </summary>
        public enum KeyCode : ushort
        {
            /// <summary>Left mouse button</summary>
            VK_LBUTTON = 0x01,

            /// <summary>Right mouse button</summary>
            VK_RBUTTON = 0x02,

            /// <summary>Control-break processing</summary>
            VK_CANCEL = 0x03,

            /// <summary>Middle mouse button (three-button mouse)</summary>
            VK_MBUTTON = 0x04,

            /// <summary>X1 mouse button</summary>
            VK_XBUTTON1 = 0x05,

            /// <summary>X2 mouse button</summary>
            VK_XBUTTON2 = 0x06,

            /// <summary>BACKSPACE key</summary>
            VK_BACK = 0x07,

            /// <summary>TAB key</summary>
            VK_TAB = 0x09,

            /// <summary>CLEAR key</summary>
            VK_CLEAR = 0x0C,

            /// <summary>ENTER key</summary>
            VK_RETURN = 0x0D,

            /// <summary>SHIFT key</summary>
            VK_SHIFT = 0x10,

            /// <summary>CTRL key</summary>
            VK_CONTROL = 0x11,

            /// <summary>ALT key</summary>
            VK_MENU = 0x12,

            /// <summary>PAUSE key</summary>
            VK_PAUSE = 0x13,

            /// <summary>CAPS LOCK key</summary>
            VK_CAPITAL = 0x14,

            /// <summary>IME Kana mode</summary>
            VK_KANA = 0x15,

            /// <summary>IME Hanguel mode (maintained for compatibility; use VK_HANGUL)</summary>
            VK_HANGUEL = 0x15,

            /// <summary>IME Hangul mode</summary>
            VK_HANGUL = 0x15,

            /// <summary>IME Junja mode</summary>
            VK_JUNJA = 0x17,

            /// <summary>IME final mode</summary>
            VK_FINAL = 0x18,

            /// <summary>IME Hanja mode</summary>
            VK_HANJA = 0x19,

            /// <summary>IME Kanji mode</summary>
            VK_KANJI = 0x19,

            /// <summary>ESC key</summary>
            VK_ESCAPE = 0x1B,

            /// <summary>IME convert</summary>
            VK_CONVERT = 0x1C,

            /// <summary>IME nonconvert</summary>
            VK_NONCONVERT = 0x1D,

            /// <summary>IME accept</summary>
            VK_ACCEPT = 0x1E,

            /// <summary>IME mode change request</summary>
            VK_MODECHANGE = 0x1F,

            /// <summary>SPACEBAR</summary>
            VK_SPACE = 0x20,

            /// <summary>PAGE UP key</summary>
            VK_PRIOR = 0x21,

            /// <summary>PAGE DOWN key</summary>
            VK_NEXT = 0x22,

            /// <summary>END key</summary>
            VK_END = 0x23,

            /// <summary>HOME key</summary>
            VK_HOME = 0x24,

            /// <summary>LEFT ARROW key</summary>
            VK_LEFT = 0x25,

            /// <summary>UP ARROW key</summary>
            VK_UP = 0x26,

            /// <summary>RIGHT ARROW key</summary>
            VK_RIGHT = 0x27,

            /// <summary>DOWN ARROW key</summary>
            VK_DOWN = 0x28,

            /// <summary>SELECT key</summary>
            VK_SELECT = 0x29,

            /// <summary>PRINT key</summary>
            VK_PRINT = 0x2A,

            /// <summary>EXECUTE key</summary>
            VK_EXECUTE = 0x2B,

            /// <summary>PRINT SCREEN key</summary>
            VK_SNAPSHOT = 0x2C,

            /// <summary>INS key</summary>
            VK_INSERT = 0x2D,

            /// <summary>DEL key</summary>
            VK_DELETE = 0x2E,

            /// <summary>HELP key</summary>
            VK_HELP = 0x2F,

            /// <summary>0 key</summary>
            D0 = 0x30,

            /// <summary>1 key</summary>
            D1 = 0x31,

            /// <summary>2 key</summary>
            D2 = 0x32,

            /// <summary>3 key</summary>
            D3 = 0x33,

            /// <summary>4 key</summary>
            D4 = 0x34,

            /// <summary>5 key</summary>
            D5 = 0x35,

            /// <summary>6 key</summary>
            D6 = 0x36,

            /// <summary>7 key</summary>
            D7 = 0x37,

            /// <summary>8 key</summary>
            D8 = 0x38,

            /// <summary>9 key</summary>
            D9 = 0x39,

            /// <summary>A key</summary>
            A = 0x41,

            /// <summary>B</summary>
            B = 0x42,

            /// <summary>C</summary>
            C = 0x43,

            /// <summary>D</summary>
            D = 0x44,

            /// <summary>E</summary>
            E = 0x45,

            /// <summary>F</summary>
            F = 0x46,

            /// <summary>G</summary>
            G = 0x47,

            /// <summary>H</summary>
            H = 0x48,

            /// <summary>I</summary>
            I = 0x49,

            /// <summary>J</summary>
            J = 0x4A,

            /// <summary>K</summary>
            K = 0x4B,

            /// <summary>L</summary>
            L = 0x4C,

            /// <summary>M</summary>
            M = 0x4D,

            /// <summary>N</summary>
            N = 0x4E,

            /// <summary>O</summary>
            O = 0x4F,

            /// <summary>P</summary>
            P = 0x50,

            /// <summary>Q</summary>
            Q = 0x51,

            /// <summary>R</summary>
            R = 0x52,

            /// <summary>S</summary>
            S = 0x53,

            /// <summary>T</summary>
            T = 0x54,

            /// <summary>U</summary>
            U = 0x55,

            /// <summary>V</summary>
            V = 0x56,

            /// <summary>W</summary>
            W = 0x57,

            /// <summary>X</summary>
            X = 0x58,

            /// <summary>Y</summary>
            Y = 0x59,

            /// <summary>Z</summary>
            Z = 0x5A,

            /// <summary>Left Windows key (Natural keyboard) </summary>
            VK_LWIN = 0x5B,

            /// <summary>Right Windows key (Natural keyboard)</summary>
            VK_RWIN = 0x5C,

            /// <summary>Applications key (Natural keyboard)</summary>
            VK_APPS = 0x5D,

            /// <summary>Computer Sleep key</summary>
            VK_SLEEP = 0x5F,

            /// <summary>Numeric keypad 0 key</summary>
            VK_NUMPAD0 = 0x60,

            /// <summary>Numeric keypad 1 key</summary>
            VK_NUMPAD1 = 0x61,

            /// <summary>Numeric keypad 2 key</summary>
            VK_NUMPAD2 = 0x62,

            /// <summary>Numeric keypad 3 key</summary>
            VK_NUMPAD3 = 0x63,

            /// <summary>Numeric keypad 4 key</summary>
            VK_NUMPAD4 = 0x64,

            /// <summary>Numeric keypad 5 key</summary>
            VK_NUMPAD5 = 0x65,

            /// <summary>Numeric keypad 6 key</summary>
            VK_NUMPAD6 = 0x66,

            /// <summary>Numeric keypad 7 key</summary>
            VK_NUMPAD7 = 0x67,

            /// <summary>Numeric keypad 8 key</summary>
            VK_NUMPAD8 = 0x68,

            /// <summary>Numeric keypad 9 key</summary>
            VK_NUMPAD9 = 0x69,

            /// <summary>Multiply key</summary>
            VK_MULTIPLY = 0x6A,

            /// <summary>Add key</summary>
            VK_ADD = 0x6B,

            /// <summary>Separator key</summary>
            VK_SEPARATOR = 0x6C,

            /// <summary>Subtract key</summary>
            VK_SUBTRACT = 0x6D,

            /// <summary>Decimal key</summary>
            VK_DECIMAL = 0x6E,

            /// <summary>Divide key</summary>
            VK_DIVIDE = 0x6F,

            /// <summary>F1 key</summary>
            VK_F1 = 0x70,

            /// <summary>F2 key</summary>
            VK_F2 = 0x71,

            /// <summary>F3 key</summary>
            VK_F3 = 0x72,

            /// <summary>F4 key</summary>
            VK_F4 = 0x73,

            /// <summary>F5 key</summary>
            VK_F5 = 0x74,

            /// <summary>F6 key</summary>
            VK_F6 = 0x75,

            /// <summary>F7 key</summary>
            VK_F7 = 0x76,

            /// <summary>F8 key</summary>
            VK_F8 = 0x77,

            /// <summary>F9 key</summary>
            VK_F9 = 0x78,

            /// <summary>F10 key</summary>
            VK_F10 = 0x79,

            /// <summary>F11 key</summary>
            VK_F11 = 0x7A,

            /// <summary>F12 key</summary>
            VK_F12 = 0x7B,

            /// <summary>F13 key</summary>
            VK_F13 = 0x7C,

            /// <summary>F14 key</summary>
            VK_F14 = 0x7D,

            /// <summary>F15 key</summary>
            VK_F15 = 0x7E,

            /// <summary>F16 key</summary>
            VK_F16 = 0x7F,

            /// <summary>F17 key</summary>
            VK_F17 = 0x80,

            /// <summary>F18 key</summary>
            VK_F18 = 0x81,

            /// <summary>F19 key</summary>
            VK_F19 = 0x82,

            /// <summary>F20 key</summary>
            VK_F20 = 0x83,

            /// <summary>F21 key</summary>
            VK_F21 = 0x84,

            /// <summary>F22 key</summary>
            VK_F22 = 0x85,

            /// <summary>F23 key</summary>
            VK_F23 = 0x86,

            /// <summary>F24 key</summary>
            VK_F24 = 0x87,

            /// <summary>NUM LOCK key</summary>
            VK_NUMLOCK = 0x90,

            /// <summary>SCROLL LOCK key</summary>
            VK_SCROLL = 0x91,

            /// <summary>Left SHIFT key</summary>
            VK_LSHIFT = 0xA0,

            /// <summary>Right SHIFT keY</summary>
            VK_RSHIFT = 0xA1,

            /// <summary>Left CONTROL key</summary>
            VK_LCONTROL = 0xA2,

            /// <summary>Right CONTROL key</summary>
            VK_RCONTROL = 0xA3,

            /// <summary>Left MENU key</summary>
            VK_LMENU = 0xA4,

            /// <summary>Right MENU key</summary>
            VK_RMENU = 0xA5,

            /// <summary>Browser Back key</summary>
            VK_BROWSER_BACK = 0xA6,

            /// <summary>Browser Forward key</summary>
            VK_BROWSER_FORWARD = 0xA7,

            /// <summary>Browser Refresh key</summary>
            VK_BROWSER_REFRESH = 0xA8,

            /// <summary>Browser Stop key</summary>
            VK_BROWSER_STOP = 0xA9,

            /// <summary>Browser Search key </summary>
            VK_BROWSER_SEARCH = 0xAA,

            /// <summary>Browser Favorites key</summary>
            VK_BROWSER_FAVORITES = 0xAB,

            /// <summary>Browser Start and Home key</summary>
            VK_BROWSER_HOME = 0xAC,

            /// <summary>Volume Mute key</summary>
            VK_VOLUME_MUTE = 0xAD,

            /// <summary>Volume Down key</summary>
            VK_VOLUME_DOWN = 0xAE,

            /// <summary>Volume Up key</summary>
            VK_VOLUME_UP = 0xAF,

            /// <summary>Next Track key</summary>
            VK_MEDIA_NEXT_TRACK = 0xB0,

            /// <summary>Previous Track key</summary>
            VK_MEDIA_PREV_TRACK = 0xB1,

            /// <summary>Stop Media key</summary>
            VK_MEDIA_STOP = 0xB2,

            /// <summary>Play/Pause Media key</summary>
            VK_MEDIA_PLAY_PAUSE = 0xB3,

            /// <summary>Start Mail key</summary>
            VK_LAUNCH_MAIL = 0xB4,

            /// <summary>Select Media key</summary>
            VK_LAUNCH_MEDIA_SELECT = 0xB5,

            /// <summary>Start Application 1 key</summary>
            VK_LAUNCH_APP1 = 0xB6,

            /// <summary>Start Application 2 key</summary>
            VK_LAUNCH_APP2 = 0xB7,

            /// <summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ';:' key </summary>
            VK_OEM_1 = 0xBA,

            /// <summary>For any country/region, the '+' key</summary>
            VK_OEM_PLUS = 0xBB,

            /// <summary>For any country/region, the ',' key</summary>
            VK_OEM_COMMA = 0xBC,

            /// <summary>For any country/region, the '-' key</summary>
            VK_OEM_MINUS = 0xBD,

            /// <summary>For any country/region, the '.' key</summary>
            VK_OEM_PERIOD = 0xBE,

            /// <summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '/?' key </summary>
            VK_OEM_2 = 0xBF,

            /// <summary>Used for miscellaneous characters; it can vary by keyboard.  For the US standard keyboard, the '`~' key </summary>
            VK_OEM_3 = 0xC0,

            /// <summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '[{' key</summary>
            VK_OEM_4 = 0xDB,

            /// <summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the '\|' key</summary>
            VK_OEM_5 = 0xDC,

            /// <summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the ']}' key</summary>
            VK_OEM_6 = 0xDD,

            /// <summary>Used for miscellaneous characters; it can vary by keyboard. For the US standard keyboard, the 'single-quote/double-quote' key</summary>
            VK_OEM_7 = 0xDE,

            /// <summary>Used for miscellaneous characters; it can vary by keyboard.</summary>
            VK_OEM_8 = 0xDF,

            /// <summary>Either the angle bracket key or the backslash key on the RT 102-key keyboard</summary>
            VK_OEM_102 = 0xE2,

            /// <summary>IME PROCESS key</summary>
            VK_PROCESSKEY = 0xE5,

            /// <summary>Used to pass Unicode characters as if they were keystrokes. The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information, see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP</summary>
            VK_PACKET = 0xE7,

            /// <summary>Attn key</summary>
            VK_ATTN = 0xF6,

            /// <summary>CrSel key</summary>
            VK_CRSEL = 0xF7,

            /// <summary>ExSel key</summary>
            VK_EXSEL = 0xF8,

            /// <summary>Erase EOF key</summary>
            VK_EREOF = 0xF9,

            /// <summary>Play key</summary>
            VK_PLAY = 0xFA,

            /// <summary>Zoom key</summary>
            VK_ZOOM = 0xFB,

            /// <summary>Reserved</summary>
            VK_NONAME = 0xFC,

            /// <summary>PA1 key</summary>
            VK_PA1 = 0xFD,

            /// <summary>Clear key</summary>
            VK_OEM_CLEAR = 0xFE
        }

        [Flags]
        public enum ShowCmd
        {
            /// <summary>Hides the window and activates another window.</summary>
            SW_HIDE = 0,

            /// <summary>Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.</summary>
            SW_SHOWNORMAL = 1,

            /// <summary>Activates the window and displays it as a minimized window.</summary>
            SW_SHOWMINIMIZED = 2,

            /// <summary>Activates the window and displays it as a maximized window.</summary>
            SW_MAXIMIZE = 3,

            /// <summary>Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except the window is not activated.</summary>
            SW_SHOWNOACTIVATE = 4,

            /// <summary>Activates the window and displays it in its current size and position.</summary>
            SW_SHOW = 5,

            /// <summary>Minimizes the specified window and activates the next top-level window in the z-order.</summary>
            SW_MINIMIZE = 6,

            /// <summary>Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.</summary>
            SW_SHOWMINNOACTIVE = 7,

            /// <summary>Displays the window in its current size and position. This value is similar to SW_SHOW, except the window is not activated.</summary>
            SW_SHOWNA = 8,

            /// <summary>Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.</summary>
            SW_RESTORE = 9,

        }

        /// <summary>
        /// Contains information about the placement of a window on the screen.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPLACEMENT
        {
            /// <summary>The length of the structure, in bytes. Before calling the GetWindowPlacement or SetWindowPlacement functions, set this member to sizeof(WINDOWPLACEMENT). GetWindowPlacement and SetWindowPlacement fail if this member is not set correctly.</summary>
            public uint Length;

            /// <summary>The flags that control the position of the minimized window and the method by which the window is restored. This member can be one or more of the following values.</summary>
            public uint Flags;

            /// <summary>The current show state of the window. This member can be one of the following values.</summary>
            public ShowCmd ShowCmd;

            /// <summary>The coordinates of the window's upper-left corner when the window is minimized.</summary>
            public POINT PtMinPosition;

            /// <summary>The coordinates of the window's upper-left corner when the window is maximized.</summary>
            public POINT PtMaxPosition;

            /// <summary>The window's coordinates when the window is in the restored position.</summary>
            public RECT RcNormalPosition;

            /// <summary>rcDevice.</summary>
            public RECT RcDevice;
        }

        /// <summary>
        /// Retrieves the show state and the restored, minimized, and maximized positions of the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpwndpl">A pointer to the WINDOWPLACEMENT structure that receives the show state and position information. Before calling GetWindowPlacement, set the length member to sizeof(WINDOWPLACEMENT). GetWindowPlacement fails if lpwndpl-> length is not set correctly.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement(nint hWnd, ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// Sets the show state and the restored, minimized, and maximized positions of the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpwndpl">A pointer to a WINDOWPLACEMENT structure that specifies the new show state and window positions.
        /// <para>Before calling SetWindowPlacement, set the length member of the WINDOWPLACEMENT structure to sizeof(WINDOWPLACEMENT). SetWindowPlacement fails if the length member is not set correctly.</para></param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPlacement(nint hWnd, ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings. This function does not search child windows. This function does not perform a case-sensitive search.
        ///     <para>To search child windows, beginning with a specified child window, use the FindWindowEx function.</para>
        /// </summary>
        /// <param name="lpClassName">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word must be zero.
        ///     <para>If lpClassName points to a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names.</para>
        ///     <para>If lpClassName is NULL, it finds any window whose title matches the lpWindowName parameter.</para></param>
        /// <param name="lpWindowName">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class name and window name.
        ///     <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern nint FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// Retrieves the extra message information for the current thread. Extra message information is an application- or driver-defined value associated with the current thread's message queue.
        /// </summary>
        /// <returns>The return value specifies the extra information. The meaning of the extra information is device specific.</returns>
        [DllImport("user32.dll")]
        public static extern nint GetMessageExtraInfo();

        /// <summary>
        /// Retrieves the cursor position for the last message retrieved by the GetMessage function.
        /// </summary>
        /// <returns>The return value specifies the x- and y-coordinates of the cursor position. The x-coordinate is the low order short and the y-coordinate is the high-order short</returns>
        [DllImport("user32.dll")]
        public static extern uint GetMessagePos();

        /// <summary>
        /// Retrieves the message time for the last message retrieved by the GetMessage function. The time is a long integer that specifies the elapsed time, in milliseconds, from the time the system was started to the time the message was created (that is, placed in the thread's message queue).
        /// </summary>
        /// <returns>The return value specifies the message time.</returns>
        [DllImport("user32.dll")]
        public static extern int GetMessageTime();

        /// <summary>
        /// Retrieves a handle to the desktop window. The desktop window covers the entire screen. The desktop window is the area on top of which other windows are painted.
        /// </summary>
        /// <returns>The return value is a handle to the desktop window.</returns>
        [DllImport("user32.dll")]
        public static extern nint GetDesktopWindow();

        /// <summary>
        /// Retrieves a handle to the specified window's parent or owner. To retrieve a handle to a specified ancestor, use the GetAncestor function.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose parent window handle is to be retrieved.</param>
        /// <returns>If the window is a child window, the return value is a handle to the parent window. If the window is a top-level window with the WS_POPUP style, the return value is a handle to the owner window.
        /// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern nint GetParent(nint hWnd);

        /// <summary>
        /// GetWindowCmd for GetWindow.
        /// </summary>
        public enum GetWindowCmd : uint
        {
            /// <summary>The retrieved handle identifies the window of the same type that is highest in the Z order.
            /// <para>If the specified window is a topmost window, the handle identifies a topmost window.</para>
            /// <para>If the specified window is a top-level window, the handle identifies a top-level window.</para>
            /// <para>If the specified window is a child window, the handle identifies a sibling window.</para></summary>
            GW_HWNDFIRST = 0,

            /// <summary>The retrieved handle identifies the window of the same type that is lowest in the Z order.
            /// <para>If the specified window is a topmost window, the handle identifies a topmost window.</para>
            /// <para>If the specified window is a top-level window, the handle identifies a top-level window.</para>
            /// <para>If the specified window is a child window, the handle identifies a sibling window.</para></summary>
            GW_HWNDLAST = 1,

            /// <summary>The retrieved handle identifies the window below the specified window in the Z order.
            /// If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window.</summary>
            GW_HWNDNEXT = 2,

            /// <summary>The retrieved handle identifies the window above the specified window in the Z order.
            /// If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window.</summary>
            GW_HWNDPREV = 3,

            /// <summary>The retrieved handle identifies the specified window's owner window, if any. For more information, see Owned Windows.</summary>
            GW_OWNER = 4,

            /// <summary>The retrieved handle identifies the child window at the top of the Z order, if the specified window is a parent window; otherwise, the retrieved handle is NULL. The function examines only child windows of the specified window. It does not examine descendant windows.</summary>
            GW_CHILD = 5,

            /// <summary>The retrieved handle identifies the enabled popup window owned by the specified window (the search uses the first such window found using GW_HWNDNEXT); otherwise, if there are no enabled popup windows, the retrieved handle is that of the specified window.</summary>
            GW_ENABLEDPOPUP = 6,
        }

        /// <summary>
        /// Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to a window. The window handle retrieved is relative to this window, based on the value of the uCmd parameter.</param>
        /// <param name="uCmd">The relationship between the specified window and the window whose handle is to be retrieved. This parameter can be one of the following values.</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern nint GetWindow(nint hWnd, GetWindowCmd uCmd);

        /// <summary>
        /// The GetWindowDC function retrieves the device context (DC) for the entire window, including title bar, menus, and scroll bars. A window device context permits painting anywhere in a window, because the origin of the device context is the upper-left corner of the window instead of the client area.
        /// <para>GetWindowDC assigns default attributes to the window device context each time it retrieves the device context. Previous attributes are lost.</para>
        /// </summary>
        /// <param name="hWnd">A handle to the window with a device context that is to be retrieved. If this value is NULL, GetWindowDC retrieves the device context for the entire screen.
        /// <para>If this parameter is NULL, GetWindowDC retrieves the device context for the primary display monitor. To get the device context for other display monitors, use the EnumDisplayMonitors and CreateDC functions.</para></param>
        /// <returns>If the function succeeds, the return value is a handle to a device context for the specified window.
        /// <para>If the function fails, the return value is NULL, indicating an error or an invalid hWnd parameter.</para></returns>
        [DllImport("user32.dll")]
        public static extern nint GetWindowDC(nint hWnd);

        /// <summary>
        /// The ReleaseDC function releases a device context (DC), freeing it for use by other applications. The effect of the ReleaseDC function depends on the type of DC. It frees only common and window DCs. It has no effect on class or private DCs.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose DC is to be released.</param>
        /// <param name="hDC">A handle to the DC to be released.</param>
        /// <returns>The return value indicates whether the DC was released. If the DC was released, the return value is 1.
        /// <para>If the DC was not released, the return value is zero.</para></returns>
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(nint hWnd, nint hDC);

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window. The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="lpRect">A pointer to a RECT structure that receives the screen coordinates of the upper-left and lower-right corners of the window.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowRect(nint hWnd, out RECT lpRect);

        /// <summary>
        /// Retrieves a handle to the window that contains the specified point.
        /// </summary>
        /// <param name="point">The point to be checked.</param>
        /// <returns>The return value is a handle to the window that contains the point. If no window exists at the given point, the return value is NULL. If the point is over a static text control, the return value is a handle to the window under the static text control.</returns>
        [DllImport("user32.dll")]
        public static extern nint WindowFromPoint(POINT point);

        /// <summary>
        /// Determines which, if any, of the child windows belonging to a parent window contains the specified point. The search is restricted to immediate child windows. Grandchildren, and deeper descendant windows are not searched.
        /// <para>To skip certain child windows, use the ChildWindowFromPointEx function.</para>
        /// </summary>
        /// <param name="hWndParent">A handle to the parent window.</param>
        /// <param name="pt">A structure that defines the client coordinates, relative to hWndParent, of the point to be checked.</param>
        /// <returns>The return value is a handle to the child window that contains the point, even if the child window is hidden or disabled. If the point lies outside the parent window, the return value is NULL. If the point is within the parent window but not within any child window, the return value is a handle to the parent window.</returns>
        [DllImport("user32.dll")]
        public static extern nint ChildWindowFromPoint(nint hWndParent, POINT pt);

        /// <summary>
        /// Determines whether a key is up or down at the time the function is called, and whether the key was pressed after a previous call to GetAsyncKeyState.
        /// </summary>
        /// <param name="vKey">The virtual-key code. For more information, see Virtual Key Codes. You can use left- and right-distinguishing constants to specify certain keys. See the Remarks section for further information.</param>
        /// <returns>If the function succeeds, the return value specifies whether the key was pressed since the last call to GetAsyncKeyState, and whether the key is currently up or down. If the most significant bit is set, the key is down, and if the least significant bit is set, the key was pressed after the previous call to GetAsyncKeyState. However, you should not rely on this last behavior; for more information, see the Remarks.
        /// <para>The return value is zero for the following cases:</para>
        /// <para>- The current desktop is not the active desktop</para>
        /// <para>- The foreground thread belongs to another process and the desktop does not allow the hook or the journal record.</para>
        /// </returns>
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(KeyCode vKey);

        /// <summary>
        /// Retrieves the position of the mouse cursor, in screen coordinates.
        /// <para>BOOL GetCursorPos(LPPOINT lpPoint)</para>
        /// </summary>
        /// <param name="lpPoint">A pointer to a POINT structure that receives the screen coordinates of the cursor.</param>
        /// <returns>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetCursorPos(out POINT lpPoint);

        /// <summary>
        /// Moves the cursor to the specified screen coordinates. If the new coordinates are not within the screen rectangle set by the most recent ClipCursor function call, the system automatically adjusts the coordinates so that the cursor stays within the rectangle.
        /// </summary>
        /// <param name="x">The new x-coordinate of the cursor, in screen coordinates.</param>
        /// <param name="y">The new y-coordinate of the cursor, in screen coordinates.</param>
        /// <returns>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetCursorPos(int x, int y);

        /// <summary>
        /// Brings the thread that created the specified window into the foreground and activates the window. Keyboard input is directed to the window, and various visual cues are changed for the user. The system assigns a slightly higher priority to the thread that created the foreground window than it does to other threads.
        /// <para>The system restricts which processes can set the foreground window. A process can set the foreground window only if one of the following conditions is true:</para>
        /// <para>An application cannot force a window to the foreground while the user is working with another window. Instead, Windows flashes the taskbar button of the window to notify the user.</para>
        /// <para>A process that can set the foreground window can enable another process to set the foreground window by calling the AllowSetForegroundWindow function. The process specified by dwProcessId loses the ability to set the foreground window the next time the user generates input, unless the input is directed at that process, or the next time a process calls AllowSetForegroundWindow, unless that process is specified.</para>
        /// </summary>
        /// <param name="hWnd">A handle to the window that should be activated and brought to the foreground.</param>
        /// <returns>If the window was brought to the foreground, the return value is nonzero. If the window was not brought to the foreground, the return value is zero.</returns>
        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(nint hWnd);

        /// <summary>
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        /// </summary>
        /// <param name="cInputs">The number of structures in the pInputs array.</param>
        /// <param name="pInputs">An array of INPUT structures. Each structure represents an event to be inserted into the keyboard or mouse input stream.</param>
        /// <param name="cbSize">The size, in bytes, of an INPUT structure. If cbSize is not the size of an INPUT structure, the function fails.</param>
        /// <returns>The function returns the number of events that it successfully inserted into the keyboard or mouse input stream. If the function returns zero, the input was already blocked by another thread. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint cInputs, INPUT[] pInputs, int cbSize);

        /// <summary>
        /// The MapWindowPoints function converts (maps) a set of points from a coordinate space relative to one window to a coordinate space relative to another window.
        /// </summary>
        /// <param name="hWndFrom">A handle to the window from which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are presumed to be in screen coordinates.</param>
        /// <param name="hWndTo">A handle to the window to which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are converted to screen coordinates.</param>
        /// <param name="lpPoints">A pointer to an array of POINT structures that contain the set of points to be converted. The points are in device units. This parameter can also point to a RECT structure, in which case the cPoints parameter should be set to 2.</param>
        /// <param name="cPoints">The number of POINT structures in the array pointed to by the lpPoints parameter.</param>
        /// <returns>If the function succeeds, the low-order word of the return value is the number of pixels added to the horizontal coordinate of each source point in order to compute the horizontal coordinate of each destination point. (In addition to that, if precisely one of hWndFrom and hWndTo is mirrored, then each resulting horizontal coordinate is multiplied by -1.) The high-order word is the number of pixels added to the vertical coordinate of each source point in order to compute the vertical coordinate of each destination point.
        /// <para>If the function fails, the return value is zero.Call SetLastError prior to calling this method to differentiate an error return value from a legitimate "0" return value.</para></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int MapWindowPoints(nint hWndFrom, nint hWndTo, ref POINT lpPoints, uint cPoints);

        /// <summary>
        /// The PrintWindow function copies a visual window into the specified device context (DC), typically a printer DC.
        /// </summary>
        /// <param name="hwnd">A handle to the window that will be copied.</param>
        /// <param name="hdcBlt">A handle to the device context.</param>
        /// <param name="nFlags">The drawing options. It can be one of the following values. PW_CLIENTONLY Only the client area of the window is copied to hdcBlt.By default, the entire window is copied.</param>
        /// <returns>If the function succeeds, it returns a nonzero value. If the function fails, it returns zero.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PrinWindow(nint hwnd, nint hdcBlt, uint nFlags);

        /// <summary>
        /// Defines a system-wide hot key.
        /// </summary>
        /// <param name="hWnd">A handle to the window that will receive WM_HOTKEY messages generated by the hot key. If this parameter is NULL, WM_HOTKEY messages are posted to the message queue of the calling thread and must be processed in the message loop.</param>
        /// <param name="id">The identifier of the hot key. If the hWnd parameter is NULL, then the hot key is associated with the current thread rather than with a particular window. If a hot key already exists with the same hWnd and id parameters, see Remarks for the action taken.</param>
        /// <param name="fsModifiers">The keys that must be pressed in combination with the key specified by the uVirtKey parameter in order to generate the WM_HOTKEY message. The fsModifiers parameter can be a combination of the following values.</param>
        /// <param name="vk">The virtual-key code of the hot key. See Virtual Key Codes.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int RegisterHotKey(nint hWnd, int id, FSModifiers fsModifiers, KeyCode vk);

        /// <summary>
        /// Frees a hot key previously registered by the calling thread.
        /// </summary>
        /// <param name="hWnd">A handle to the window associated with the hot key to be freed. This parameter should be NULL if the hot key is not associated with a window.</param>
        /// <param name="id">The identifier of the hot key to be freed.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int UnregisterHotKey(nint hWnd, int id);

    }
}
