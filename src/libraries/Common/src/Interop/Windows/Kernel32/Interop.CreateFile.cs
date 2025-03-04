// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Kernel32
    {
        /// <summary>
        /// WARNING: This method does not implicitly handle long paths. Use CreateFile.
        /// </summary>
#if DLLIMPORTGENERATOR_ENABLED
        [GeneratedDllImport(Libraries.Kernel32, EntryPoint = "CreateFileW", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        private static unsafe partial SafeFileHandle CreateFilePrivate(
#else
        [DllImport(Libraries.Kernel32, EntryPoint = "CreateFileW", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        private static unsafe extern SafeFileHandle CreateFilePrivate(
#endif
            string lpFileName,
            int dwDesiredAccess,
            FileShare dwShareMode,
            SECURITY_ATTRIBUTES* lpSecurityAttributes,
            FileMode dwCreationDisposition,
            int dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        internal static unsafe SafeFileHandle CreateFile(
            string lpFileName,
            int dwDesiredAccess,
            FileShare dwShareMode,
            SECURITY_ATTRIBUTES* lpSecurityAttributes,
            FileMode dwCreationDisposition,
            int dwFlagsAndAttributes,
            IntPtr hTemplateFile)
        {
            lpFileName = PathInternal.EnsureExtendedPrefixIfNeeded(lpFileName);
            return CreateFilePrivate(lpFileName, dwDesiredAccess, dwShareMode, lpSecurityAttributes, dwCreationDisposition, dwFlagsAndAttributes, hTemplateFile);
        }

        internal static unsafe SafeFileHandle CreateFile(
            string lpFileName,
            int dwDesiredAccess,
            FileShare dwShareMode,
            FileMode dwCreationDisposition,
            int dwFlagsAndAttributes)
        {
            lpFileName = PathInternal.EnsureExtendedPrefixIfNeeded(lpFileName);
            return CreateFilePrivate(lpFileName, dwDesiredAccess, dwShareMode, null, dwCreationDisposition, dwFlagsAndAttributes, IntPtr.Zero);
        }
    }
}
