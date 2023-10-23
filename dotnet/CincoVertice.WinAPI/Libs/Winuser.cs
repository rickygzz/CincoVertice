// <copyright file="Winuser.cs" company="Ricardo Gonzalez-Garza">
// Copyright (c) 2018 - 2021 Ricardo Gonzalez-Garza. All Rights Reserved.
// Contact ricardo@5vertice.com for additional information.
// </copyright>
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CincoVertice.WinAPI.Libs
{
    /// <summary>
    /// WinUser.
    /// </summary>
    public static class WinUser
    {
        /// <summary>
        /// Brings the specified window to the top of the Z order. If the window is a top-level window, it is activated.
        /// If the window is a child window, the top-level parent window associated with the child window is activated.
        /// </summary>
        /// <param name="hWnd">A handle to the window to bring to the top of the Z order.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero.To get extended error information, call
        ///         GetLastError.
        ///     </para>
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool BringWindowToTop(nint hWnd);

        /// <summary>
        /// Creates an overlapped, pop-up, or child window with an extended window style; otherwise, this function is
        /// identical to the CreateWindow function. For more information about creating a window and for full
        /// descriptions of the other parameters of CreateWindowEx, see CreateWindow.
        /// </summary>
        /// <param name="dwExStyle">
        ///     The extended window style of the window being created. For a list of possible values, see Extended
        ///     Window Styles.
        /// </param>
        /// <param name="lpClassName">
        ///     A null-terminated string or a class atom created by a previous call to the RegisterClass or
        ///     RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word
        ///     must be zero. If lpClassName is a string, it specifies the window class name. The class name can be any
        ///     name registered with RegisterClass or RegisterClassEx, provided that the module that registers the class
        ///     is also the module that creates the window. The class name can also be any of the predefined system
        ///     class names.
        /// </param>
        /// <param name="lpWindowName">
        ///     The window name. If the window style specifies a title bar, the window title pointed to by lpWindowName
        ///     is displayed in the title bar. When using CreateWindow to create controls, such as buttons, check boxes,
        ///     and static controls, use lpWindowName to specify the text of the control. When creating a static control
        ///     with the SS_ICON style, use lpWindowName to specify the icon name or identifier. To specify an
        ///     identifier, use the syntax "#num".
        /// </param>
        /// <param name="dwStyle">
        ///     The style of the window being created. This parameter can be a combination of the window style values,
        ///     plus the control styles indicated in the Remarks section.
        /// </param>
        /// <param name="x">
        ///     The initial horizontal position of the window. For an overlapped or pop-up window, the x parameter is
        ///     the initial x-coordinate of the window's upper-left corner, in screen coordinates. For a child window,
        ///     x is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the
        ///     parent window's client area. If x is set to CW_USEDEFAULT, the system selects the default position for
        ///     the window's upper-left corner and ignores the y parameter. CW_USEDEFAULT is valid only for overlapped
        ///     windows; if it is specified for a pop-up or child window, the x and y parameters are set to zero.
        /// </param>
        /// <param name="y">
        ///     The initial vertical position of the window. For an overlapped or pop-up window, the y parameter is the
        ///     initial y-coordinate of the window's upper-left corner, in screen coordinates. For a child window, y is
        ///     the initial y-coordinate of the upper-left corner of the child window relative to the upper-left corner
        ///     of the parent window's client area. For a list box y is the initial y-coordinate of the upper-left
        ///     corner of the list box's client area relative to the upper-left corner of the parent window's client
        ///     area.
        ///     <para>
        ///         If an overlapped window is created with the WS_VISIBLE style bit set and the x parameter is set to
        ///         CW_USEDEFAULT, then the y parameter determines how the window is shown. If the y parameter is
        ///         CW_USEDEFAULT, then the window manager calls ShowWindow with the SW_SHOW flag after the window has
        ///         been created. If the y parameter is some other value, then the window manager calls ShowWindow with
        ///         that value as the nCmdShow parameter.
        ///     </para>
        /// </param>
        /// <param name="nWidth">
        ///     The width, in device units, of the window. For overlapped windows, nWidth is the window's width, in
        ///     screen coordinates, or CW_USEDEFAULT. If nWidth is CW_USEDEFAULT, the system selects a default width and
        ///     height for the window; the default width extends from the initial x-coordinates to the right edge of the
        ///     screen; the default height extends from the initial y-coordinate to the top of the icon area.
        ///     CW_USEDEFAULT is valid only for overlapped windows; if CW_USEDEFAULT is specified for a pop-up or child
        ///     window, the nWidth and nHeight parameter are set to zero.
        /// </param>
        /// <param name="nHeight">
        ///     The height, in device units, of the window. For overlapped windows, nHeight is the window's height, in
        ///     screen coordinates. If the nWidth parameter is set to CW_USEDEFAULT, the system ignores nHeight.
        /// </param>
        /// <param name="hWndParent">
        ///     A handle to the parent or owner window of the window being created. To create a child window or an owned
        ///     window, supply a valid window handle. This parameter is optional for pop-up windows.
        ///     <para>
        ///         To create a message-only window, supply HWND_MESSAGE or a handle to an existing message-only window.
        ///     </para>
        /// </param>
        /// <param name="hMenu">
        ///     A handle to a menu, or specifies a child-window identifier, depending on the window style. For an
        ///     overlapped or pop-up window, hMenu identifies the menu to be used with the window; it can be NULL if the
        ///     class menu is to be used. For a child window, hMenu specifies the child-window identifier, an integer
        ///     value used by a dialog box control to notify its parent about events. The application determines the
        ///     child-window identifier; it must be unique for all child windows with the same parent window.
        /// </param>
        /// <param name="hInstance">A handle to the instance of the module to be associated with the window.</param>
        /// <param name="lpParam">
        ///     Pointer to a value to be passed to the window through the CREATESTRUCT structure (lpCreateParams member)
        ///     pointed to by the lParam param of the WM_CREATE message. This message is sent to the created window by
        ///     this function before it returns.
        ///     <para>
        ///         If an application calls CreateWindow to create a MDI client window, lpParam should point to a
        ///         CLIENTCREATESTRUCT structure.If an MDI client window calls CreateWindow to create an MDI child
        ///         window, lpParam should point to a MDICREATESTRUCT structure.lpParam may be NULL if no additional
        ///         data is needed.
        ///     </para>
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is a handle to the new window.
        ///     <para>
        ///         If the function fails, the return value is NULL.To get extended error information, call
        ///         GetLastError.
        ///     </para>
        ///     <para>This function typically fails for one of the following reasons:</para>
        ///     <para>- an invalid parameter value</para>
        ///     <para>- the system class was registered by a different module</para>
        ///     <para>- The WH_CBT hook is installed and returns a failure code</para>
        ///     <para>
        ///         - if one of the controls in the dialog template is not registered, or its window window procedure
        ///         fails WM_CREATE or WM_NCCREATE
        ///     </para>
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, EntryPoint = "CreateWindowEx")]
        public static extern IntPtr CreateWindowEx(
            uint dwExStyle,
            [MarshalAs(UnmanagedType.LPStr)]
            string lpClassName,
            [MarshalAs(UnmanagedType.LPStr)]
            string lpWindowName,
            uint dwStyle,
            int x,
            int y,
            int nWidth,
            int nHeight,
            IntPtr hWndParent,
            IntPtr hMenu,
            IntPtr hInstance,
            IntPtr lpParam);

        /// <summary>
        /// Destroys the specified window. The function sends WM_DESTROY and WM_NCDESTROY messages to the window to
        /// deactivate it and remove the keyboard focus from it. The function also destroys the window's menu, flushes
        /// the thread message queue, destroys timers, removes clipboard ownership, and breaks the clipboard viewer
        /// chain (if the window is at the top of the viewer chain).
        /// <para>
        ///     If the specified window is a parent or owner window, DestroyWindow automatically destroys the associated
        ///     child or owned windows when it destroys the parent or owner window.The function first destroys child or
        ///     owned windows, and then it destroys the parent or owner window.
        /// </para>
        /// <para>
        ///     DestroyWindow also destroys modeless dialog boxes created by the CreateDialog function.
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the window to be destroyed.</param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero.
        ///     <para>
        ///         If the function fails, the return value is zero.To get extended error information, call
        ///         GetLastError.
        ///     </para>
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool DestroyWindow([In] IntPtr hWnd);

        /// <summary>
        /// Calls the default window procedure to provide default processing for any window messages that an application
        /// does not process. This function ensures that every message is processed. DefWindowProc is called with the
        /// same parameters received by the window procedure.
        /// </summary>
        /// <param name="hWnd">A handle to the window procedure that received the message.</param>
        /// <param name="uMsg">The message.</param>
        /// <param name="wParam">
        ///     Additional message information. The content of this parameter depends on the value of the Msg parameter.
        /// </param>
        /// <param name="lParam">
        ///     Additional message information. The content of this parameter depends on the value of the Msg parameter.
        /// </param>
        /// <returns>
        ///     The return value is the result of the message processing and depends on the message.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Registers a window class for subsequent use in calls to the CreateWindow or CreateWindowEx function.
        /// </summary>
        /// <param name="lpWndClass">
        ///     A pointer to a WNDCLASSEX structure. You must fill the structure with the appropriate class attributes
        ///     before passing it to the function.
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern ushort RegisterClassEx([In] ref WNDCLASSEX lpWndClass);

        /// <summary>
        /// Unregisters a window class, freeing the memory required for the class.
        /// </summary>
        /// <param name="lpClassName">
        ///     A null-terminated string or a class atom. If lpClassName is a string, it specifies the window class
        ///     name. This class name must have been registered by a previous call to the RegisterClass or
        ///     RegisterClassEx function. System classes, such as dialog box controls, cannot be unregistered. If this
        ///     parameter is an atom, it must be a class atom created by a previous call to the RegisterClass or
        ///     RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word
        ///     must be zero.
        /// </param>
        /// <param name="hInstance">A handle to the instance of the module that created the class.</param>
        /// <returns>
        ///     If the function succeeds, the return value is nonzero. If the class could not be found or if a window
        ///     still exists that was created with the class, the return value is zero.To get extended error
        ///     information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterClass([In] string lpClassName, [In, Optional] IntPtr hInstance);

        /// <summary>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="lpClassName">The class name string.</param>
        /// <param name="nMaxCount">
        ///     The length of the lpClassName buffer, in characters. The buffer must be large enough to include the
        ///     terminating null character; otherwise, the class name string is truncated to nMaxCount-1 characters.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is the number of characters copied to the buffer, not
        ///     including the terminating null character.
        ///     <para>
        ///         If the function fails, the return value is zero. To get extended error information, call
        ///         GetLastError function.
        ///     </para>
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetClassName(nint hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer. If the specified window
        /// is a control, the text of the control is copied. However, GetWindowText cannot retrieve the text of a
        /// control in another application.
        /// </summary>
        /// <param name="hWnd">A handle to the window or control containing the text.</param>
        /// <param name="lpString">
        ///     The buffer that will receive the text. If the string is as long or longer than the buffer, the string is
        ///     truncated and terminated with a null character.
        /// </param>
        /// <param name="nMaxCount">
        ///     The maximum number of characters to copy to the buffer, including the null character. If the text
        ///     exceeds this limit, it is truncated.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is the length, in characters, of the copied string, not
        ///     including the terminating null character. If the window has no title bar or text, if the title bar is
        ///     empty, or if the window or control handle is invalid, the return value is zero. To get extended error
        ///     information, call GetLastError.
        ///     <para>This function cannot retrieve the text of an edit control in another application.</para>
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowText(nint hWnd, System.Text.StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// Retrieves a handle to the foreground window (the window with which the user is currently working). The
        /// system assigns a slightly higher priority to the thread that creates the foreground window than it does to
        /// other threads.
        /// </summary>
        /// <returns>
        ///     The return value is a handle to the foreground window. The foreground window can be NULL in certain
        ///     circumstances, such as when a window is losing activation.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern nint GetForegroundWindow();

        /// <summary>
        /// Retrieves the window handle to the active window attached to the calling thread's message queue.
        /// </summary>
        /// <returns>
        ///     The return value is the handle to the active window attached to the calling thread's message queue.
        ///     Otherwise, the return value is NULL.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern nint GetActiveWindow();

        /// <summary>
        /// Activates a window. The window must be attached to the calling thread's message queue.
        /// <para>Check SetForegroundWindow.</para>
        /// <para>
        ///     The SetActiveWindow function activates a window, but not if the application is in the background.
        ///     The window will be brought into the foreground (top of Z-Order) if its application is in the foreground
        ///     when the system activates the window.
        /// </para>
        /// <para>
        ///     If the window identified by the hWnd parameter was created by the calling thread, the active window
        ///     status of the calling thread is set to hWnd. Otherwise, the active window status of the calling thread
        ///     is set to NULL.
        /// </para>
        /// </summary>
        /// <param name="hWnd">A handle to the top-level window to be activated.</param>
        /// <returns>
        ///     If the function succeeds, the return value is the handle to the window that was previously active.
        ///     If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern nint SetActiveWindow(nint hWnd);

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for
        /// the specified window and does not return until the window procedure has processed the message.
        /// <para>
        ///     To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function. To
        ///     post a message to a thread's message queue and return immediately, use the PostMessage or
        ///     PostThreadMessage function.
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        ///     A handle to the window whose window procedure will receive the message. If this parameter is
        ///     HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including
        ///     disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not
        ///     sent to child windows.
        ///     <para>
        ///         Message sending is subject to UIPI. The thread of a process can send messages only to message queues
        ///         of threads in processes of lesser or equal integrity level.
        ///     </para>
        /// </param>
        /// <param name="wMsg">The message to be sent.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">lParam Additional message-specific information.</param>
        /// <returns>
        ///     The return value specifies the result of the message processing; it depends on the message sent.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(nint hWnd, Constants.WM wMsg, nint wParam, nint lParam);

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for
        /// the specified window and does not return until the window procedure has processed the message.
        /// <para>
        ///     To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function. To
        ///     post a message to a thread's message queue and return immediately, use the PostMessage or
        ///     PostThreadMessage function.
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        ///     A handle to the window whose window procedure will receive the message. If this parameter is
        ///     HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including
        ///     disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not
        ///     sent to child windows.
        ///     <para>
        ///         Message sending is subject to UIPI. The thread of a process can send messages only to message queues
        ///         of threads in processes of lesser or equal integrity level.
        ///     </para>
        /// </param>
        /// <param name="wMsg">The message to be sent.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">lParam Additional message-specific information.</param>
        /// <returns>
        ///     The return value specifies the result of the message processing; it depends on the message sent.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(nint hWnd, Constants.WM wMsg, int wParam, int lParam);

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for
        /// the specified window and does not return until the window procedure has processed the message.
        /// <para>
        ///     To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function. To
        ///     post a message to a thread's message queue and return immediately, use the PostMessage or
        ///     PostThreadMessage function.
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        ///     A handle to the window whose window procedure will receive the message. If this parameter is
        ///     HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including
        ///     disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not
        ///     sent to child windows.
        ///     <para>
        ///         Message sending is subject to UIPI. The thread of a process can send messages only to message queues
        ///         of threads in processes of lesser or equal integrity level.
        ///     </para>
        /// </param>
        /// <param name="wMsg">The message to be sent.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">lParam Additional message-specific information.</param>
        /// <returns>
        ///     The return value specifies the result of the message processing; it depends on the message sent.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(nint hWnd, Constants.WM wMsg, int wParam, ref POINT lParam);

        /// <summary>
        /// Retrieves a handle to the window that contains the specified point.
        /// <para>
        ///     The WindowFromPoint function does not retrieve a handle to a hidden or disabled window, even if the
        ///     point is within the window. An application should use the ChildWindowFromPoint function for a
        ///     nonrestrictive search.
        /// </para>
        /// </summary>
        /// <param name="point">The point to be checked.</param>
        /// <returns>
        ///     The return value is a handle to the window that contains the point. If no window exists at the given
        ///     point, the return value is NULL. If the point is over a static text control, the return value is a
        ///     handle to the window under the static text control.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern nint WindowFromPoint(POINT point);
    }

    /// <summary>
    /// The type of the input event. This member can be one of the following values.
    /// </summary>
    public enum InputType : uint
    {
        /// <summary>The information about a simulated mouse event.</summary>
        INPUT_MOUSE = 0,

        /// <summary>The information about a simulated keyboard event.</summary>
        INPUT_KEYBOARD = 1,

        /// <summary>The information about a simulated hardware event.</summary>
        INPUT_HARDWARE = 2,
    }

    /// <summary>
    /// Flags for MouseInput
    /// </summary>
    public enum MouseInputMouseData : uint
    {
        /// <summary>
        ///     If dwFlags does not contain MOUSEEVENTF_WHEEL, MOUSEEVENTF_XDOWN, or MOUSEEVENTF_XUP, then mouseData
        ///     should be zero.
        /// </summary>
        NONE = 0,

        /// <summary>
        ///     If dwFlags contains MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP, then mouseData specifies which X buttons were
        ///     pressed or released. Set if the first X button is pressed or released.
        /// </summary>
        XBUTTON1 = 1,

        /// <summary>
        ///     If dwFlags contains MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP, then mouseData specifies which X buttons were
        ///     pressed or released. Set if the second X button is pressed or released.
        /// </summary>
        XBUTTON2 = 2,

        /// <summary>
        ///     If dwFlags contains MOUSEEVENTF_WHEEL, then mouseData specifies the amount of wheel movement. A positive
        ///     value indicates that the wheel was rotated forward, away from the user; a negative value indicates that
        ///     the wheel was rotated backward, toward the user. One wheel click is defined as WHEEL_DELTA, which is
        ///     120.
        /// </summary>
        WHEEL_DELTA = 160,
    }

    /// <summary>
    /// A set of bit flags that specify various aspects of mouse motion and button clicks. The bits in this member can
    /// be any reasonable combination of the following values.
    /// <para>
    ///     The bit flags that specify mouse button status are set to indicate changes in status, not ongoing
    ///     conditions. For example, if the left mouse button is pressed and held down, MOUSEEVENTF_LEFTDOWN is set when
    ///     the left button is first pressed, but not for subsequent motions. Similarly, MOUSEEVENTF_LEFTUP is set only
    ///     when the button is first released.
    /// </para>
    /// <para>
    ///     You cannot specify both the MOUSEEVENTF_WHEEL flag and either MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP flags
    ///     simultaneously in the dwFlags parameter, because they both require use of the mouseData field.
    /// </para>
    /// </summary>
    public enum MouseInputDwFlags : uint
    {
        /// <summary>
        ///     The dx and dy members contain normalized absolute coordinates. If the flag is not set, dxand dy contain
        ///     relative data (the change in position since the last reported position). This flag can be set, or not
        ///     set, regardless of what kind of mouse or other pointing device, if any, is connected to the system. For
        ///     further information about relative mouse motion, see the following Remarks section.
        /// </summary>
        MOUSEEVENTF_ABSOLUTE = 0x8000,

        /// <summary>
        ///     The wheel was moved horizontally, if the mouse has a wheel. The amount of movement is specified in
        ///     mouseData.
        /// </summary>
        MOUSEEVENTF_HWHEEL = 0x01000,

        /// <summary>Movement occurred.</summary>
        MOUSEEVENTF_MOVE = 0x0001,

        /// <summary>
        ///     The WM_MOUSEMOVE messages will not be coalesced. The default behavior is to coalesce WM_MOUSEMOVE
        ///     messages.
        /// </summary>
        MOUSEEVENTF_MOVE_NOCOALESCE = 0x2000,

        /// <summary>The left button was pressed.</summary>
        MOUSEEVENTF_LEFTDOWN = 0x0002,

        /// <summary>The left button was released.</summary>
        MOUSEEVENTF_LEFTUP = 0x0004,

        /// <summary>The right button was pressed.</summary>
        MOUSEEVENTF_RIGHTDOWN = 0x0008,

        /// <summary>The right button was released.</summary>
        MOUSEEVENTF_RIGHTUP = 0x0010,

        /// <summary>The middle button was pressed.</summary>
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,

        /// <summary>The middle button was released.</summary>
        MOUSEEVENTF_MIDDLEUP = 0x0040,

        /// <summary>Maps coordinates to the entire desktop. Must be used with MOUSEEVENTF_ABSOLUTE.</summary>
        MOUSEEVENTF_VIRTUALDESK = 0x4000,

        /// <summary>
        ///     The wheel was moved, if the mouse has a wheel. The amount of movement is specified in mouseData.
        /// </summary>
        MOUSEEVENTF_WHEEL = 0x0800,

        /// <summary>An X button was pressed.</summary>
        MOUSEEVENTF_XDOWN = 0x0080,

        /// <summary>An X button was released.</summary>
        MOUSEEVENTF_XUP = 0x0100,
    }

    /// <summary>
    /// Specifies various aspects of a keystroke. This member can be certain combinations of the following values.
    /// </summary>
    public enum KeyboardInputDwFlags : uint
    {
        /// <summary>the key is being pressed</summary>
        KEYEVENTF_KEYDOWN = 0x0000,

        /// <summary>If specified, the scan code was preceded by a prefix byte that has the value 0xE0 (224).</summary>
        KEYEVENTF_EXTENDEDKEY = 0x0001,

        /// <summary>If specified, the key is being released. If not specified, the key is being pressed.</summary>
        KEYEVENTF_KEYUP = 0x0002,

        /// <summary>If specified, wScan identifies the key and wVk is ignored.</summary>
        KEYEVENTF_SCANCODE = 0x0008,

        /// <summary>
        ///     If specified, the system synthesizes a VK_PACKET keystroke. The wVk parameter must be zero. This flag
        ///     can only be combined with the KEYEVENTF_KEYUP flag. For more information, see the Remarks section.
        /// </summary>
        KEYEVENTF_UNICODE = 0x0004,
    }

    // StructLayoutAttribute fields
    // .Pack  Controls the alignment of data fields of a class or structure in memory.
    // .Size  Indicates the absolute size of the class or structure.
    //     This field must be equal or greater than the total size, in bytes, of the members of the class or structure.
    //     This field is primarily for compiler writers who want to extend the memory occupied by a structure for direct, unmanaged access.

    /// <summary>
    /// Contains message information from a thread's message queue.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct WINMSG
    {
        /// <summary>
        ///     A handle to the window whose window procedure receives the message. This member is NULL when the message
        ///     is a thread message.
        /// </summary>
        public nint Hwnd;

        /// <summary>
        ///     The message identifier. Applications can only use the low word; the high word is reserved by the system.
        /// </summary>
        public uint Message;

        /// <summary>
        ///     Additional information about the message. The exact meaning depends on the value of the message member.
        /// </summary>
        public nint WParam;

        /// <summary>
        ///     Additional information about the message. The exact meaning depends on the value of the message member.
        /// </summary>
        public nint LParam;

        /// <summary>The time at which the message was posted.</summary>
        public uint Time;

        /// <summary>The cursor position, in screen coordinates, when the message was posted.</summary>
        // public POINT Pt;
        public int X;

        /// <summary>The cursor position, in screen coordinates, when the message was posted.</summary>
        public int Y;

        // <summary>LPrivate not documentend</summary>
        // public uint LPrivate;
    }

    /// <summary>
    /// Contains information about a simulated mouse event.
    /// </summary>
    public struct MOUSEINPUT
    {
        /// <summary>
        ///     The absolute position of the mouse, or the amount of motion since the last mouse event was generated,
        ///     depending on the value of the dwFlags member. Absolute data is specified as the x coordinate of the
        ///     mouse; relative data is specified as the number of pixels moved.
        /// </summary>
        public int Dx;

        /// <summary>
        ///     The absolute position of the mouse, or the amount of motion since the last mouse event was generated,
        ///     depending on the value of the dwFlags member. Absolute data is specified as the y coordinate of the
        ///     mouse; relative data is specified as the number of pixels moved.
        /// </summary>
        public int Dy;

        /// <summary>Flags depending on DwFlags value</summary>
        public MouseInputMouseData MouseData;

        /// <summary>
        ///     A set of bit flags that specify various aspects of mouse motion and button clicks. The bits in this
        ///     member can be any reasonable combination of the following values.
        ///     <para>
        ///         The bit flags that specify mouse button status are set to indicate changes in status, not ongoing
        ///         conditions. For example, if the left mouse button is pressed and held down, MOUSEEVENTF_LEFTDOWN
        ///         is set when the left button is first pressed, but not for subsequent motions. Similarly,
        ///         MOUSEEVENTF_LEFTUP is set only when the button is first released.
        ///     </para>
        ///     <para>
        ///         You cannot specify both the MOUSEEVENTF_WHEEL flag and either MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP
        ///         flags simultaneously in the dwFlags parameter, because they both require use of the mouseData field.
        ///     </para>
        /// </summary>
        public MouseInputDwFlags DwFlags;

        /// <summary>
        ///     The time stamp for the event, in milliseconds. If this parameter is 0, the system will provide its own
        ///     time stamp.
        /// </summary>
        public uint Time;

        /// <summary>
        ///     An additional value associated with the mouse event. An application calls GetMessageExtraInfo to obtain
        ///     this extra information.
        /// </summary>
        public nint DwExtraInfo;
    }

    /// <summary>
    /// The information about a simulated keyboard event.
    /// </summary>
    public struct KEYBDINPUT
    {
        /// <summary>
        ///     A virtual-key code. The code must be a value in the range 1 to 254. If the dwFlags member specifies
        ///     KEYEVENTF_UNICODE, wVk must be 0.
        /// </summary>
        public User32.KeyCode WVk;

        /// <summary>
        ///     A hardware scan code for the key. If dwFlags specifies KEYEVENTF_UNICODE, wScan specifies a Unicode
        ///     character which is to be sent to the foreground application.
        /// </summary>
        public ushort WScan;

        /// <summary>Specifies various aspects of a keystroke.</summary>
        public KeyboardInputDwFlags DwFlags;

        /// <summary>
        ///     The time stamp for the event, in milliseconds. If this parameter is zero, the system will provide its
        ///     own time stamp.
        /// </summary>
        public uint Time;

        /// <summary>
        ///     An additional value associated with the keystroke. Use the GetMessageExtraInfo function to obtain this
        ///     information.
        /// </summary>
        public nint DwExtraInfo;
    }

    /// <summary>
    /// The information about a simulated hardware event.
    /// </summary>
    public struct HARDWAREINPUT
    {
        /// <summary>The message generated by the input hardware.</summary>
        public uint UMsg;

        /// <summary>The low-order word of the lParam parameter for uMsg.</summary>
        public ushort WParamL;

        /// <summary>The high-order word of the lParam parameter for uMsg.</summary>
        public ushort WParamH;
    }

    /// <summary>
    /// Union { MOUSEINPUT KEYBOARDINPUT and HARDWAREINPUT }
    /// Used in User32.SendInput()
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct MOUSEKEYBDHARDWAREINPUT
    {
        /// <summary>The information about a simulated mouse event.</summary>
        [FieldOffset(0)]
        public MOUSEINPUT MouseInput;

        /// <summary>The information about a simulated keyboard event.</summary>
        [FieldOffset(0)]
        public KEYBDINPUT KeyboardInput;

        /// <summary>The information about a simulated hardware event.</summary>
        [FieldOffset(0)]
        public HARDWAREINPUT HardwareInput;
    }

    /// <summary>
    /// Each structure represents an event to be inserted into the keyboard or mouse input stream.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        /// <summary>The type of the input event.</summary>
        public InputType Type;

        /// <summary>Mouse, keyboard or hardware input</summary>
        public MOUSEKEYBDHARDWAREINPUT MKHInput;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct WNDCLASSEX
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint cbSize;
        [MarshalAs(UnmanagedType.U4)]
        public uint style;
        public IntPtr lpfnWndProc;
        public int cbClsExtra;
        public int cbWndExtra;
        public IntPtr hInstance;
        public IntPtr hIcon;
        public IntPtr hCursor;
        public IntPtr hbrBackground;
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpszMenuName;
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpszClassName;
        public IntPtr hIconSm;
    }
}
