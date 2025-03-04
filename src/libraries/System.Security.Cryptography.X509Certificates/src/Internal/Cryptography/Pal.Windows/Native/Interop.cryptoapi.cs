// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;


using Internal.Cryptography;
using Internal.Cryptography.Pal.Native;

internal static partial class Interop
{
    public static partial class cryptoapi
    {
        [GeneratedDllImport(Libraries.Advapi32, EntryPoint = "CryptAcquireContextW", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static unsafe partial bool CryptAcquireContext(out IntPtr psafeProvHandle, char* pszContainer, char* pszProvider, int dwProvType, CryptAcquireContextFlags dwFlags);
    }
}
