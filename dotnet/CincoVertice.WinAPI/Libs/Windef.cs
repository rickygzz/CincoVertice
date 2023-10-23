// <copyright file="Windef.cs" company="Ricardo Gonzalez-Garza">
// Copyright (c) 2018 - 2021 Ricardo Gonzalez-Garza. All Rights Reserved.
// Contact ricardo@5vertice.com for additional information.
// </copyright>
using System.Runtime.InteropServices;

namespace CincoVertice.WinAPI.Libs
{
    // https://docs.microsoft.com/en-us/windows/desktop/winprog/windows-data-types
    //
    // C#           Win32
    //              APIENTRY
    //              ATOM
    // int          BOOL                                typedef int BOOL
    //              BOOLEAN
    //              BYTE                                A byte (8 bits).
    //              CALLBACK
    //              CCHAR
    //              CHAR
    //              COLORREF
    //              CONST
    // uint         DWORD               System.UInt32   A 32-bit unsigned integer. The range is 0 through 4294967295 decimal.
    //              DWORDLONG                           A 64-bit unsigned integer. The range is 0 through 18446744073709551615 decimal.
    //              DWORD_PTR
    //              DWORD32
    //              DWORD64
    //              FLOAT
    //              HACCEL
    //              HALF_PTR
    //              HANDLE
    // IntPtr       HBITMAP         System.IntPtr
    //              HBRUSH
    //              HCOLORSPACE
    //              HCONV
    //              HCONVLIST
    //              HCURSOR
    // IntPtr       HDC             System.IntPtr
    //              HDDEDATA
    //              HDESK
    //              HDROP
    //              HDWP
    //              HENHMETAFILE
    //              HFILE
    //              HFONT
    // IntPtr       HGDIOBJ         System.IntPtr
    //              HGLOBAL
    //              HHOOK
    //              HICON
    //              HINSTANCE
    //              HKEY
    //              HKL
    //              HLOCAL
    //              HMENU
    //              HMETAFILE
    //              HMODULE
    //              HMONITOR
    //              HPALETTE
    //              HPEN
    //              HRESULT
    //              HRGN
    //              HRSRC
    //              HSZ
    //              HWINSTA
    // IntPtr       HWND                System.IntPtr       typedef HANDLE HWND;
    //              INT                                     typedef int INT;
    //              INT_PTR
    //              INT8
    //              INT16
    //              INT32
    //              INT64
    //              LANGID
    //              LCID
    //              LCTYPE
    //              LGRPID
    // int          LONG                System.Int32        A 32-bit signed integer. The range is -2147483648 through 2147483647 decimal.
    //              LONGLONG
    //              LONG_PTR
    //              LONG32
    //              LONG64
    // IntPtr       LPARAM              System.IntPtr       typedef LONG_PTR LPARAM;
    //              LPBOOL
    //              LPBYTE
    //              LPCOLORREF
    // string       LPCSTR              System.String       A pointer to a constant null-terminated string of 8-bit Windows (ANSI) characters.
    //              LPCTSTR
    //              LPCVOID
    //              LPCWSTR
    //              LPDWORD
    //              LPHANDLE
    //              LPINT
    //              LPLONG
    //              LPSTR
    //              LPTSTR
    // IntPtr       LPVOID
    //              LPWORD
    //              LPWSTR
    //              LRESULT
    //              PBOOL
    //              PBOOLEAN
    //              PBYTE
    //              PCHAR
    //              PCSTR
    //              PCTSTR
    //              PCWSTR
    //              PDWORD
    //              PDWORDLONG
    //              PDWORD_PTR
    //              PDWORD32
    //              PDWORD64
    //              PFLOAT
    //              PHALF_PTR
    //              PHANDLE
    //              PHKEY
    //              PINT
    //              PINT_PTR
    //              PINT8
    //              PINT16
    //              PINT32
    //              PINT64
    //              PLCID
    //              PLONG
    //              PLONGLONG
    //              PLONG_PTR
    //              PLONG32
    //              PLONG64
    //              POINTER_32
    //              POINTER_64
    //              POINTER_SIGNED
    //              POINTER_UNSIGNED
    //              PSHORT
    //              PSIZE_T
    //              PSSIZE_T
    //              PSTR
    //              PTBYTE
    //              PTCHAR
    //              PTSTR
    //              PUCHAR
    //              PUHALF_PTR
    //              PUINT
    //              PUINT_PTR
    //              PUINT8
    //              PUINT16
    //              PUINT32
    //              PUINT64
    //              PULONG
    //              PULONGLONG
    //              PULONG_PTR
    //              PULONG32
    //              PULONG64
    //              PUSHORT
    //              PVOID
    //              PWCHAR
    //              PWORD
    //              PWSTR
    //              QWORD
    //              SC_HANDLE
    //              SC_LOCK
    //              SERVICE_STATUS_HANDLE
    //              SHORT
    // uint         SIZE_T
    //              SSIZE_T
    //              TBYTE
    //              TCHAR
    //              UCHAR
    //              UHALF_PTR
    // uint         UINT                                    typedef unsigned int UINT
    //              UINT_PTR
    //              UINT8
    //              UINT16
    //              UINT32
    //              UINT64
    //              ULONG
    //              ULONGLONG
    //              ULONG_PTR
    //              ULONG32
    //              ULONG64
    //              UNICODE_STRING
    //              USHORT
    //              USN
    //              VOID
    //              WCHAR
    //              WINAPI
    // ushort       WORD                System.UInt16
    // UIntPtr      WPARAM              System.UIntPtr

    /// <summary>
    /// The POINT structure defines the x- and y- coordinates of a point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        /// <summary>The x-coordinate of the point.</summary>
        public int X;

        /// <summary>The y-coordinate of the point.</summary>
        public int Y;
    }

    /// <summary>
    /// The RECT structure defines the coordinates of the upper-left and lower-right corners of a rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        /// <summary>The x-coordinate of the upper-left corner of the rectangle.</summary>
        public int Left;

        /// <summary>The y-coordinate of the upper-left corner of the rectangle.</summary>
        public int Top;

        /// <summary>The x-coordinate of the lower-right corner of the rectangle.</summary>
        public int Right;

        /// <summary>The y-coordinate of the lower-right corner of the rectangle.</summary>
        public int Bottom;
    }
}
