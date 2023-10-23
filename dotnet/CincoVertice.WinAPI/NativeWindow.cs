using CincoVertice.WinAPI.Libs;
using System.Runtime.InteropServices;

namespace CincoVertice.WinAPI
{
    public class NativeWindow : IDisposable
    {
        public IntPtr Handle { get; private set; }

        private readonly IntPtr hInstance;
        private const string className = "NativeWindow";
        private WNDCLASSEX windowClass = new WNDCLASSEX();

        private delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        public NativeWindow()
        {
            hInstance = Marshal.GetHINSTANCE(GetType().Module);

            windowClass.cbSize = (uint) Marshal.SizeOf(typeof(WNDCLASSEX));
            windowClass.style = (uint) (Constants.CS.CS_HREDRAW | Constants.CS.CS_VREDRAW);
            windowClass.cbClsExtra = 0;
            windowClass.cbWndExtra = 0;
            windowClass.hInstance = hInstance;
            windowClass.hIcon = IntPtr.Zero;
            windowClass.hCursor = IntPtr.Zero;
            windowClass.hbrBackground = (IntPtr)5;
            windowClass.lpszMenuName = string.Empty;
            windowClass.lpszClassName = className;
            windowClass.hIconSm = IntPtr.Zero;
            windowClass.lpfnWndProc = Marshal.GetFunctionPointerForDelegate<WndProc>(WindowProc);

            if (WinUser.RegisterClassEx(ref windowClass) == 0)
            {
                // An error occurred
            }

            Handle = WinUser.CreateWindowEx(
                0,
                className,
                "NativeWindow",
                (uint) Constants.WS.WS_EX_LEFT,
                0, 0, 0, 0,
                IntPtr.Zero, // HWND_DESKTOP
                IntPtr.Zero, // No menu
                hInstance,
                IntPtr.Zero);

            if (Handle == IntPtr.Zero)
            {
                // An error occurred
            }
        }

        public void Dispose()
        {
            WinUser.DestroyWindow(Handle);
            WinUser.UnregisterClass(className, hInstance);
        }

        protected virtual IntPtr WindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            return WinUser.DefWindowProc(hWnd, msg, wParam, lParam);
        }
    }
}
