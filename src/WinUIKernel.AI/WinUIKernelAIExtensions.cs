// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using RichasyKernel;

namespace Richasy.WinUIKernel.AI;

/// <summary>
/// AI kernel extension.
/// </summary>
public static class WinUIKernelAIExtensions
{
    internal static Kernel Kernel { get; private set; }

    /// <summary>
    /// Initialize the AI kernel.
    /// </summary>
    /// <param name="kernel">Kernel.</param>
    public static void InitializeAIKernel(this Kernel kernel) => Kernel = kernel;

    internal static T Get<T>(this object ele) where T : class => Kernel.Get<T>();
}
