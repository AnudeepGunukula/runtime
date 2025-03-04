﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IO;

namespace System.Text.RegularExpressions.Symbolic.Unicode
{
#if DEBUG
    internal static class GeneratorHelper
    {
        public static void WriteInt64ArrayInitSyntax(StreamWriter sw, long[] values)
        {
            sw.Write("new long[] {");
            for (int i = 0; i < values.Length; i++)
            {
                sw.Write($" 0x{values[i]:X}, ");
            }
            sw.Write("}");
        }
    }
#endif
}
