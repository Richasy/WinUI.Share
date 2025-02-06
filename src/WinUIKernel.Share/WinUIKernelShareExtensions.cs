// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using RichasyKernel;

namespace Richasy.WinUIKernel.Share;

/// <summary>
/// AI kernel extension.
/// </summary>
public static class WinUIKernelShareExtensions
{
    internal static Kernel Kernel { get; private set; }

    /// <summary>
    /// Initialize the Share kernel.
    /// </summary>
    /// <param name="kernel">Kernel.</param>
    public static void InitializeShareKernel(this Kernel kernel) => Kernel = kernel;
}
