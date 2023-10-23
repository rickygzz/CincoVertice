// <copyright file="GDI32.cs" company="Ricardo Gonzalez-Garza">
// Copyright (c) 2018 - 2021 Ricardo Gonzalez-Garza. All Rights Reserved.
// Contact ricardo@5vertice.com for additional information.
// </copyright>
using System.Runtime.InteropServices;

namespace CincoVertice.WinAPI.Libs
{
    /// <summary>
    /// GDI32
    /// </summary>
    public class GDI32
    {
        /// <summary>
        /// Ternary raster oprations. Describes how three boolean values should combine to form an output boolean.
        /// <para>https://wiki.winehq.org/Ternary_Raster_Ops</para>
        /// </summary>
        public enum RasterOperationCode : uint
        {
            /// <summary>Fills the destination rectangle using the color associated with index 0 in the physical palette. (This color is black for the default physical palette.)
            /// <para>dest = BLACK</para></summary>
            BLACKNESS = 0x00000042,

            /// <summary>Includes any windows that are layered on top of your window in the resulting image. By default, the image only contains your window. Note that this generally cannot be used for printing device contexts.</summary>
            CAPTUREBLT = 0x40000000,

            /// <summary>Inverts the destination rectangle.
            /// <para>dest = (NOT dest)</para></summary>
            DSTINVERT = 0x00550009,

            /// <summary>Merges the colors of the source rectangle with the brush currently selected in hdcDest, by using the Boolean AND operator.
            /// <para>dest = (source AND pattern)</para></summary>
            MERGECOPY = 0x00C000CA,

            /// <summary>Merges the colors of the inverted source rectangle with the colors of the destination rectangle by using the Boolean OR operator.
            /// <para>dest = (NOT source) OR dest</para></summary>
            MERGEPAINT = 0x00BB0226,

            /// <summary>Prevents the bitmap from being mirrored.</summary>
            NOMIRRORBITMAP = 0x80000000,

            /// <summary>Copies the inverted source rectangle to the destination.
            /// <para>dest = (NOT source)</para></summary>
            NOTSRCCOPY = 0x00330008,

            /// <summary>Combines the colors of the source and destination rectangles by using the Boolean OR operator and then inverts the resultant color.
            /// <para>dest = (NOT src) AND (NOT dest)</para></summary>
            NOTSRCERASE = 0x001100A6,

            /// <summary>Copies the brush currently selected in hdcDest, into the destination bitmap.
            /// <para>dest = pattern</para></summary>
            PATCOPY = 0x00F00021,

            /// <summary>Combines the colors of the brush currently selected in hdcDest, with the colors of the destination rectangle by using the Boolean XOR operator.
            /// <para>dest = pattern XOR dest</para></summary>
            PATINVERT = 0x005A0049,

            /// <summary>Combines the colors of the brush currently selected in hdcDest, with the colors of the inverted source rectangle by using the Boolean OR operator. The result of this operation is combined with the colors of the destination rectangle by using the Boolean OR operator.
            /// <para>dest = DPSnoo</para></summary>
            PATPAINT = 0x00FB0A09,

            /// <summary>Combines the colors of the source and destination rectangles by using the Boolean AND operator.
            /// <para>dest = source AND dest</para></summary>
            SRCAND = 0x008800C6,

            /// <summary>Copies the source rectangle directly to the destination rectangle.
            /// <para>dest = source</para></summary>
            SRCCOPY = 0x00CC0020,

            /// <summary>Combines the inverted colors of the destination rectangle with the colors of the source rectangle by using the Boolean AND operator.
            /// <para>dest = source AND (NOT dest)</para></summary>
            SRCERASE = 0x00440328,

            /// <summary>Combines the colors of the source and destination rectangles by using the Boolean XOR operator.
            /// <para>dest = source XOR dest</para></summary>
            SRCINVERT = 0x00660046,

            /// <summary>Combines the colors of the source and destination rectangles by using the Boolean OR operator.
            /// <para>dest = source OR dest</para></summary>
            SRCPAINT = 0x00EE0086,

            /// <summary>Fills the destination rectangle using the color associated with index 1 in the physical palette. (This color is white for the default physical palette.)
            /// <para>dest = WHITE</para></summary>
            WHITENESS = 0x00FF0062
        }




        /// <summary>
        /// The BitBlt function performs a bit-block transfer of the color data corresponding to a rectangle of pixels from the specified source device context into a destination device context.
        /// </summary>
        /// <param name="hdc">A handle to the destination device context.</param>
        /// <param name="x">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
        /// <param name="y">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
        /// <param name="cxWidth">The width, in logical units, of the source and destination rectangles.</param>
        /// <param name="cyHeight">The height, in logical units, of the source and the destination rectangles.</param>
        /// <param name="hdcSrc">A handle to the source device context.</param>
        /// <param name="xSrc">The x-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
        /// <param name="ySrc">The y-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
        /// <param name="rop">A raster-operation code. These codes define how the color data for the source rectangle is to be combined with the color data for the destination rectangle to achieve the final color.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para></returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern int BitBlt(nint hdc, int x, int y, int cxWidth, int cyHeight, nint hdcSrc, int xSrc, int ySrc, RasterOperationCode rop);

        /// <summary>
        /// The CreateCompatibleBitmap function creates a bitmap compatible with the device that is associated with the specified device context.
        /// </summary>
        /// <param name="hDC">A handle to a device context.</param>
        /// <param name="cxWidth">The bitmap width, in pixels.</param>
        /// <param name="cyHeight">The bitmap height, in pixels.</param>
        /// <returns>If the function succeeds, the return value is a handle to the compatible bitmap (DDB).
        /// <para>If the function fails, the return value is NULL.</para></returns>
        [DllImport("gdi32.dll")]
        public static extern nint CreateCompatibleBitmap(nint hDC, int cxWidth, int cyHeight);

        /// <summary>
        /// The CreateCompatibleDC function creates a memory device context (DC) compatible with the specified device.
        /// </summary>
        /// <param name="hDC">A handle to an existing DC. If this handle is NULL, the function creates a memory DC compatible with the application's current screen.</param>
        /// <returns>If the function succeeds, the return value is the handle to a memory DC.
        /// <para>If the function fails, the return value is NULL.</para></returns>
        [DllImport("gdi32.dll")]
        public static extern nint CreateDC(string sDriver, string sDevice, string sPort, nint pdm);

        /// <summary>
        /// The CreateCompatibleDC function creates a memory device context (DC) compatible with the specified device.
        /// </summary>
        /// <param name="hDC">A handle to an existing DC. If this handle is NULL, the function creates a memory DC compatible with the application's current screen.</param>
        /// <returns>If the function succeeds, the return value is the handle to a memory DC.
        /// <para>If the function fails, the return value is NULL.</para></returns>
        [DllImport("gdi32.dll")]
        public static extern nint CreateCompatibleDC(nint hDC);

        /// <summary>
        /// The DeleteDC function deletes the specified device context (DC).
        /// </summary>
        /// <param name="hDC">A handle to the device context.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// <para>If the function fails, the return value is zero.</para></returns>
        [DllImport("gdi32.dll")]
        public static extern int DeleteDC(nint hDC);

        /// <summary>
        /// The DeleteObject function deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated with the object. After the object is deleted, the specified handle is no longer valid.
        /// </summary>
        /// <param name="hObject">A handle to a logical pen, brush, font, bitmap, region, or palette.</param>
        /// <returns>If the function succeeds, the return value is nonzero.
        /// <para>If the specified handle is not valid or is currently selected into a DC, the return value is zero.</para></returns>
        [DllImport("gdi32.dll")]
        public static extern int DeleteObject(nint hObject);

        /// <summary>
        /// The SelectObject function selects an object into the specified device context (DC). The new object replaces the previous object of the same type.
        /// </summary>
        /// <param name="hDC">A handle to the DC.</param>
        /// <param name="hObject">A handle to the object to be selected. The specified object must have been created by using one of the following functions.</param>
        /// <returns>If an error occurs and the selected object is not a region, the return value is NULL. Otherwise, it is HGDI_ERROR.</returns>
        [DllImport("gdi32.dll")]
        public static extern nint SelectObject(nint hDC, nint hObject);
    }
}
