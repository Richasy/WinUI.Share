// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Markup;
using Richasy.WinUIKernel.Share.Toolkits;

namespace Richasy.WinUIKernel.AI.Extensions;

/// <summary>
/// Localized text extension.
/// </summary>
[MarkupExtensionReturnType(ReturnType = typeof(string))]
internal sealed partial class LocaleExtension : MarkupExtension
{
    /// <summary>
    /// Language name.
    /// </summary>
    public string Name { get; set; }

    /// <inheritdoc/>
    protected override object ProvideValue()
        => this.Get<IResourceToolkit>().GetLocalizedString(Name);
}
