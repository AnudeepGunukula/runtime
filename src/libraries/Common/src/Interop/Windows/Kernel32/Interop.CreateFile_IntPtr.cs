// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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
        private static unsafe partial IntPtr CreateFilePrivate_IntPtr(
#else
        [DllImport(Libraries.Kernel32, EntryPoint = "CreateFileW", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        private static unsafe extern IntPtr CreateFilePrivate_IntPtr(
#endif
            string lpFileName,
            int dwDesiredAccess,
            FileShare dwShareMode,
            SECURITY_ATTRIBUTES* lpSecurityAttributes,
            FileMode dwCreationDisposition,
            int dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        internal static unsafe IntPtr CreateFile_IntPtr(
            string lpFileName,
            int dwDesiredAccess,
            FileShare dwShareMode,
            FileMode dwCreationDisposition,
            int dwFlagsAndAttributes)
        {
            lpFileName = PathInternal.EnsureExtendedPrefixIfNeeded(lpFileName);
            return CreateFilePrivate_IntPtr(lpFileName, dwDesiredAccess, dwShareMode, null, dwCreationDisposition, dwFlagsAndAttributes, IntPtr.Zero);
        }
    }
}
