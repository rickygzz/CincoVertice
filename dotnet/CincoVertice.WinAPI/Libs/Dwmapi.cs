// <copyright file="Dwmapi.cs" company="Ricardo Gonzalez-Garza">
// Copyright (c) 2018 - 2023 Ricardo Gonzalez-Garza. All Rights Reserved.
// Contact ricardo@5vertice.com for additional information.
// </copyright>
using System.Runtime.InteropServices;


namespace CincoVertice.WinAPI.Libs
{
    /// <summary>
    /// Dwmapi
    /// </summary>
    public class Dwmapi
    {
        /// <summary>
        /// Retrieves the current value of a specified Desktop Window Manager (DWM) attribute applied to a window. For programming guidance, and code examples, see Controlling non-client region rendering.
        /// </summary>
        /// <param name="hwnd">The handle to the window from which the attribute value is to be retrieved.</param>
        /// <param name="dwAttribute">A flag describing which value to retrieve, specified as a value of the DWMWINDOWATTRIBUTE enumeration. This parameter specifies which attribute to retrieve, and the pvAttribute parameter points to an object into which the attribute value is retrieved.</param>
        /// <param name="pvAttribute">A pointer to a value which, when this function returns successfully, receives the current value of the attribute. The type of the retrieved value depends on the value of the dwAttribute parameter. The DWMWINDOWATTRIBUTE enumeration topic indicates, in the row for each flag, what type of value you should pass a pointer to in the pvAttribute parameter.</param>
        /// <param name="cbAttribute">The size, in bytes, of the attribute value being received via the pvAttribute parameter. The type of the retrieved value, and therefore its size in bytes, depends on the value of the dwAttribute parameter.</param>
        /// <returns></returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmGetWindowAttribute(nint hwnd, int dwAttribute, out RECT pvAttribute, int cbAttribute);

        [Flags]
        private enum DwmWindowAttribute : uint
        {
            DWMWA_NCRENDERING_ENABLED = 1,
            DWMWA_NCRENDERING_POLICY,
            DWMWA_TRANSITIONS_FORCEDISABLED,
            DWMWA_ALLOW_NCPAINT,
            DWMWA_CAPTION_BUTTON_BOUNDS,
            DWMWA_NONCLIENT_RTL_LAYOUT,
            DWMWA_FORCE_ICONIC_REPRESENTATION,
            DWMWA_FLIP3D_POLICY,

            /// <summary>Use with DwmGetWindowAttribute. Retrieves the extended frame bounds rectangle in screen space. The retrieved value is of type RECT.</summary>
            DWMWA_EXTENDED_FRAME_BOUNDS,
            DWMWA_HAS_ICONIC_BITMAP,
            DWMWA_DISALLOW_PEEK,
            DWMWA_EXCLUDED_FROM_PEEK,
            DWMWA_CLOAK,
            DWMWA_CLOAKED,
            DWMWA_FREEZE_REPRESENTATION,
            DWMWA_LAST
        }

        /// <summary>
        /// GetWindowRectangle without adornments (like shadow).
        /// </summary>
        /// <param name="hWnd">hWnd.</param>
        /// <returns>RECT.</returns>
        public static RECT GetWindowRectangle(nint hWnd)
        {
            RECT rect = default;

            int size = Marshal.SizeOf(typeof(RECT));
            DwmGetWindowAttribute(hWnd, (int)DwmWindowAttribute.DWMWA_EXTENDED_FRAME_BOUNDS, out rect, size);

            return rect;
        }
    }
}
