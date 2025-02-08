// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Windows.ApplicationModel.Resources;
using Richasy.WinUIKernel.Share.Toolkits;

namespace AISample;

/// <summary>
/// Resource toolkit.
/// </summary>
public sealed class ResourceToolkit : SharedResourceToolkit
{
    /// <inheritdoc/>
    protected override ResourceLoader GetResourceLoader()
        => new ResourceLoader(ResourceLoader.GetDefaultResourceFilePath(), "Resources");
}
